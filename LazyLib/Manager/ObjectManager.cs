﻿
/*
This file is part of LazyBot - Copyright (C) 2011 Arutha

   LazyBot is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   LazyBot is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with LazyBot.  If not, see <http://www.gnu.org/licenses/>.
*/

using LazyLib.Helpers;
using LazyLib.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Unity;

namespace LazyLib.Wow
{
    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class ObjectManager : IObjectManager 
    {
        private static Process[] _wowProc = GetProcesses().ToArray();
        private static int _processPid;
        private static PulseWorker _pulseWorker;
        private Thread _monitor = new Thread(Monitor) { 
            IsBackground = true, 
            Name = "ObjectManager" 
        };

        private static bool _alearted;
        private static readonly object Locker = new object();
        private static List<PObject> ObjectList { get; set; } = new List<PObject>();
        public IntPtr WowHandle { get; set; }
        public PPlayerSelf MyPlayer { get; private set; } = new PPlayerSelf(0);
        public static bool Initialized { get; private set; }
        public static bool Closing { get; set; }
        public static bool ForceIngame { get; set; }

        public static IGamePointers GamePointers => ServiceManager.Provider.GetService<IGamePointers>();

        public bool ShouldPulse => (ForceIngame || InGame);

        /// <summary>
        ///   Gets a value indicating whether [in game].
        /// </summary>
        /// <value><c>true</c> if [in game]; otherwise, <c>false</c>.</value>
        public static bool InGame
        {
            get
            {
                try
                {
                    if (ForceIngame)
                    {
                        return true;
                    }
                    return Memory.ReadRelative<byte>((uint)GamePointers.GameState) == 1;
                    // 1 ingame 0 not ingame
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool ShouldDefend
        {
            get
            {
                if (!MyPlayer.InCombat)
                    return false;
                if (HasAttackers() && (MyPlayer.InCombat || (MyPlayer.HasLivePet && MyPlayer.Pet.InCombat)) &&
                    !MyPlayer.IsDead)
                    return true;
                return false;
            }
        }

        ///<summary>
        ///  Returns the closest GUnit attacking you or you pet
        ///</summary>
        public PUnit GetClosestAttacker
        {
            get
            {
                PUnit closestAttacker = null;
                try
                {
                    List<PUnit> units = GetAttackers;
                    foreach (PUnit u in units)
                    {
                        if (closestAttacker == null) closestAttacker = u;
                        else if (u.DistanceToSelf < closestAttacker.DistanceToSelf) closestAttacker = u;
                    }
                }
                catch (Exception)
                {
                }
                return closestAttacker;
            }
        }

        ///<summary>
        ///  Returns a List of all units that are targeting you or your pet.
        ///</summary>
        public List<PUnit> GetAttackers
        {
            get
            {
                var returnList = new List<PUnit>();
                try
                {
                    returnList.AddRange(GetUnits.Where(AttackingMeOrPet));
                }
                catch (Exception)
                {
                }
                return returnList;
            }
        }

        /// <summary>
        ///   Gets the get objects.
        /// </summary>
        /// <value>The get objects.</value>
        public List<PObject> GetObjects
        {
            get
            {
                lock (Locker)
                {
                    return ObjectList.OfType<PObject>().ToList();
                }
            }
        }

        /// <summary>
        ///   Gets the get items.
        /// </summary>
        /// <value>The get items.</value>
        public List<PContainer> GetContainers
        {
            get
            {
                lock (Locker)
                {
                    return ObjectList.OfType<PContainer>().ToList();
                }
            }
        }

        /// <summary>
        ///   Gets the get items.
        /// </summary>
        /// <value>The get items.</value>
        public List<PItem> GetItems
        {
            get
            {
                lock (Locker)
                {
                    return ObjectList.OfType<PItem>().ToList();
                }
            }
        }

        /// <summary>
        ///   Gets the get players.
        /// </summary>
        /// <value>The get players.</value>
        public List<PPlayer> GetPlayers
        {
            get
            {
                lock (Locker)
                {
                    return ObjectList.OfType<PPlayer>().ToList();
                }
            }
        }

        /// <summary>
        ///   Gets the get units.
        /// </summary>
        /// <value>The get units.</value>
        public List<PUnit> GetUnits
        {
            get
            {
                lock (Locker)
                {
                    return
                        ObjectList.OfType<PUnit>().ToList().Where(wowObject => !wowObject.GUID.Equals(MyPlayer.GUID)).
                            ToList();
                }
            }
        }

        /// <summary>
        ///   Gets the get game object.
        /// </summary>
        /// <value>The get game object.</value>
        public List<PGameObject> GetGameObject
        {
            get
            {
                List<PObject> objects = GetObjects;
                return objects.OfType<PGameObject>().ToList();
            }
        }

        #region Process stuff

        /// <summary>
        ///   Doeses the process exsist.
        /// </summary>
        /// <param name = "pid">The pid.</param>
        /// <returns></returns>
        private static bool DoesProcessExsist(int pid)
        {
            lock (_wowProc)
            {
                _wowProc = GetProcesses().ToArray();
            }
            return _wowProc.Any(proc => proc.Id.Equals(pid));
        }

        public static IEnumerable<Process> GetProcesses()
        {
            return Process.GetProcesses().Where(t => t.ProcessName.Contains("Wow"));
        }

        #endregion

        /// <summary>
        /// Gets the object by GUID.
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <returns></returns>
        public static PObject GetObjectByGuid<T>(T guid)
        {
            lock (Locker)
            {
                return ObjectList.OfType<PObject>().Where(wowObject => wowObject.GUID.Equals(guid)).FirstOrDefault();
            }
        }

        public void MakeReady()
        {
            _monitor.Start();
        }

        internal static void Pulse()
        {
            while (!Closing)
            {
                var objectManager = ServiceManager.Provider.GetService<IObjectManager>();
                lock (Locker)
                {
                    // Fill the new list.
                    objectManager.Refresh();
                }
                Thread.Sleep(700);
            }
        }

        private void ReadObjectList()
        {
            var currentObject = new PObject(Memory.Read<uint>(CurrentManager + GamePointers.EntityList));
            LocalGUID = Memory.Read<byte[]>(CurrentManager + GamePointers.LocalPlayer);
            while (currentObject.BaseAddress != uint.MinValue &&
                   currentObject.BaseAddress % 2 == uint.MinValue)
            {
                // Keep the static reference to the local player updated... at all times.
                if (currentObject.GUID.SequenceEqual(LocalGUID))
                {
                    //MessageBox.Show("Found localplayer! 0x" + currentObject.ToString("X8"));
                    MyPlayer.UpdateBaseAddress(currentObject.BaseAddress);
                }
                if (!ObjectList.Any(t=> t.GUID.SequenceEqual(currentObject.GUID)))
                {
                    PObject? obj = default;
                    // Add the object based on it's *actual* type. Note: WoW's Object descriptors for OBJECT_FIELD_TYPE
                    // is a bitmask. We want to use the type at 0x14, as it's an 'absolute' type.
                    switch (currentObject.Type)
                    {
                        // Belive it or not, the base Object class is hardly used in WoW.
                        case (int)Constants.ObjectType.Object:
                            obj = new PObject(currentObject.BaseAddress);
                            break;
                        case Constants.ObjectType.Unit:
                            obj = new PUnit(currentObject.BaseAddress);
                            break;
                        case Constants.ObjectType.Player:
                            obj = new PPlayer(currentObject.BaseAddress);
                            break;
                        case Constants.ObjectType.GameObject:
                            obj = new PGameObject(currentObject.BaseAddress);
                            break;
                        case Constants.ObjectType.Item:
                            obj = new PItem(currentObject.BaseAddress);
                            break;
                        case Constants.ObjectType.Container:
                            obj = new PContainer(currentObject.BaseAddress);
                            break;
                        // These two aren't used in most bots, as they're fairly pointless.
                        // They are AI and area triggers for NPCs handled by the client itself.
                        case Constants.ObjectType.AiGroup:
                        case Constants.ObjectType.AreaTrigger:
                            break;
                    }

                    if (obj?.IsValid == true)
                    {
                        // We have a valid object that isn't in the object list already.
                        // So lets add it.
                        ObjectList.Add(obj);
                    }
                }
                else
                {
                    var existingObject = ObjectList.SingleOrDefault(t => t.GUID.SequenceEqual(currentObject.GUID));
                    if (existingObject?.IsValid == true)
                    {
                        // The object already exists, just update the pointer.
                        ObjectList.SingleOrDefault(t => t.GUID.SequenceEqual(currentObject.GUID))?.UpdateBaseAddress(currentObject.BaseAddress);
                    }
                }
                // We need the next object.
                currentObject.BaseAddress = Memory.Read<uint>(currentObject.BaseAddress + GamePointers.NextEntity);
            }

            // remove all invalid objects
            ObjectList = ObjectList.Where(t=>t.IsValid).ToList();
        }

        public static event EventHandler<NotifyEventAttach> Attach;
        public static event EventHandler<NotifyEventNoAttach> NoAttach;

        /// <summary>
        ///   Initializes the ObjectManager, attaching it to the selected process.
        /// </summary>
        /// <param name = "pid">The World of Warcraft process ID.</param>
        public void Initialize(int pid)
        {
            ObjectList.Clear();
            if (DoesProcessExsist(pid))
            {
                var _objectManager = LazyLib.ServiceManager.Provider.GetService<IObjectManager>();
                Memory.OpenProcess(pid);
                _processPid = pid;
                InterfaceHelper.StartUpdate();
                
                if (InGame)
                {
                    try
                    {
                        CurrentManager = Memory.Read<uint>(Memory.ReadRelative<uint>((uint)ServiceManager.TestOffsets.ObjMgr) + (uint)ServiceManager.TestOffsets.CurMgr);
                        
                        LocalGUID = Memory.Read<byte[]>(CurrentManager + (uint)ServiceManager.TestOffsets.LocalGUID);

                        //Logging.Write(string.Format("[Player] Local GUID: {0}", LocalGUID));
                        if (CurrentManager != UInt32.MinValue && CurrentManager != UInt32.MaxValue)
                        {
                            Initialized = true;
                            _objectManager.WowHandle = Memory.ProcessHandle;
                        }
                        if (Attach != null)
                        {
                            Attach(new object(), new NotifyEventAttach(pid));
                        }
                        Logging.Write(LogType.Info, "Attached");
                        _alearted = false;
                    }
                    catch (Exception ex)
                    {
                        Logging.Write(ex.Message);
                    }
                }
                else
                {
                    Logging.Write(LogType.Warning, "Not ingame, could not attach");
                }
            }
            else
            {
                Logging.Write("Instance does not exist: " + pid + " please select another process");
            }
        }

        /// <summary>
        ///   Monitors this instance.
        /// </summary>
        private void Monitor()
        {
            while (!Closing)
            {
                if (InGame && _processPid != -1)
                {
                    Thread.Sleep(500);
                    continue;
                }
                if (!DoesProcessExsist(_processPid) && !_alearted)
                {
                    InterfaceHelper.StopUpdate();
                    Logging.Write(LogType.Info, "No wow process, cannot attach");
                    ObjectList.Clear();
                    if (NoAttach != null)
                    {
                        NoAttach(new object(), new NotifyEventNoAttach("Not attached"));
                    }
                    _alearted = true;
                }
                Initialized = false;
                //if (_refresher != null)
                //{
                //    if (_refresher.IsAlive)
                //    {
                //        _refresher.Abort();
                //        _refresher = null;
                //    }
                //}
                if (DoesProcessExsist(_processPid))
                {
                    _alearted = false;
                    ObjectList.Clear();
                    if (NoAttach != null)
                    {
                        NoAttach(new object(), new NotifyEventNoAttach("Not attached"));
                    }
                    Logging.Write(LogType.Info, "Not ingame");
                    Thread.Sleep(1500);
                    while (DoesProcessExsist(_processPid) && !InGame)
                    {
                        Thread.Sleep(1000);
                    }
                    if (InGame)
                    {
                        Initialize(_processPid);
                    }
                    else
                    {
                        _processPid = -1;
                    }
                }
                else
                {
                    _processPid = -1;
                }
                Thread.Sleep(2000);
            }
        }

        public void Close()
        {
            ObjectList.Clear();
        }

        /// <summary>
        ///   GetNumAdds - tells you how many adds you have
        /// </summary>
        /// <returns></returns>
        public int GetNumAdds()
        {
            return GetAttackers.Count - 1;
        }

        /// <summary>
        ///   Gets the closest hostile unit
        /// </summary>
        /// <returns></returns>
        public static PUnit GetClosestUnit(List<PUnit> units)
        {
            PUnit toReturn = null;
            double distance = double.MaxValue;
            foreach (PUnit selectMonster in units)
            {
                if (!selectMonster.Reaction.Equals(Reaction.Hostile))
                    continue;
                if (selectMonster.Location.DistanceToSelf < distance)
                {
                    toReturn = selectMonster;
                    distance = selectMonster.Location.DistanceToSelf;
                }
            }
            return toReturn;
        }

        /// <summary>
        ///   GetNumAttackers - tells you how many attackers you have
        /// </summary>
        /// <returns></returns>
        public int GetNumAttackers()
        {
            return GetAttackers.Count;
        }

        /// <summary>
        ///   AttackersInRange - returns number of attackers within a specified distance
        /// </summary>
        /// <param name = "pRangeToCheck">The p range to check.</param>
        /// <returns></returns>
        public int AttackersInRange(double pRangeToCheck)
        {
            return GetAttackers.Count(attacker => attacker.Location.DistanceToSelf < pRangeToCheck);
        }

        /// <summary>
        ///   Gets the likely adds.
        /// </summary>
        /// <returns></returns>
        public List<PUnit> GetLikelyAdds(int distance)
        {
            return
                GetUnits.Where(
                    monster => monster.Health == 1 && !monster.InCombat && monster.Location.DistanceToSelf < distance)
                    .ToList();
        }

        /// <summary>
        ///   Determines whether you have adds.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if you have adds; otherwise, <c>false</c>.
        /// </returns>
        public bool HasAdds()
        {
            if (GetNumAdds() > 1)
                return true;
            return false;
        }


        /// <summary>
        ///   HasAttackers - tells you if you have attackers
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has attackers; otherwise, <c>false</c>.
        /// </returns>
        public bool HasAttackers()
        {
            return GetAttackers.Count != 0;
        }

        /// <summary>
        ///   Targetings me or my pet.
        /// </summary>
        /// <param name = "u">The unit.</param>
        /// <returns></returns>
        public bool TargetingMeOrPet(PUnit u)
        {
            if (u == null || MyPlayer == null)
            {
                return false;
            }
            if (u.TargetGUID.Equals(MyPlayer.GUID))
            {
                return true;
            }
            if (!MyPlayer.HasLivePet)
            {
                return false;
            }
            if (u.TargetGUID.Equals(MyPlayer.PetGUID))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///   Attacking me or my pet.
        /// </summary>
        /// <param name = "u">The unit.</param>
        /// <returns></returns>
        public bool AttackingMeOrPet(PUnit u)
        {
            //return TargetingMeOrPet(u) && u.InCombat && (u.IsAutoAttacking || u.IsCasting);
            return TargetingMeOrPet(u) && u.InCombat;
        }

        /// <summary>
        ///   Gets the closest attacker other than the PUnit specified. .
        /// </summary>
        /// <param name = "exclude">The PUnit to exclude.</param>
        /// <returns></returns>
        public PUnit GetClosestAttackerExclude(PUnit exclude)
        {
            PUnit closestAttacker = null;
            try
            {
                List<PUnit> units = GetAttackers;
                foreach (PUnit u in units)
                {
                    if (!u.GUID.Equals(exclude.GUID))
                    {
                        if (closestAttacker == null) closestAttacker = u;
                        else if (u.DistanceToSelf < closestAttacker.DistanceToSelf) closestAttacker = u;
                    }
                }
            }
            catch (Exception)
            {
            }
            return closestAttacker;
        }

        /// <summary>
        ///   Determines whether [is it safe at] [the specified ignore].
        /// </summary>
        /// <param name = "ignore">The ignore.</param>
        /// <param name = "u">The u.</param>
        /// <returns>
        ///   <c>true</c> if [is it safe at] [the specified ignore]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsItSafeAt(ulong ignore, PUnit u)
        {
            return IsItSafeAt(ignore, u.Location);
        }

        /// <summary>
        ///   Determines whether [is it safe at] [the specified ignore].
        /// </summary>
        /// <param name = "ignore">The ignore.</param>
        /// <param name = "l">The l.</param>
        /// <returns>
        ///   <c>true</c> if [is it safe at] [the specified ignore]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsItSafeAt(ulong ignore, Location l)
        {
            List<PUnit> mobs = CheckForMobsAtLoc(l, 15.0f, false); // Setting for radius?
            return mobs.Where(mob => !mob.GUID.Equals(ignore)).All(mob => mob.IsDead || mob.TargetGUID.Equals(0));
        }

        /// <summary>
        ///   Checks for mobs at location.
        /// </summary>
        /// <param name = "l">The location.</param>
        /// <param name = "radius">The radius.</param>
        /// <param name = "includeFriendly">if set to <c>true</c> [include friendly units].</param>
        /// <returns></returns>
        public List<PUnit> CheckForMobsAtLoc(Location l, float radius, bool includeFriendly)
        {
            var returns = new List<PUnit>();
            List<PUnit> mobs = GetUnits;
            if (l != null)
            {
                if (mobs.Count > 0)
                {
                    if (includeFriendly)
                        returns.AddRange(from mob in mobs
                                         let mdt = mob.Location.GetDistanceTo(l)
                                         where
                                             mdt <= radius && !mob.IsDead && !mob.IsTagged && mob.Level > 1 &&
                                             !mob.IsTargetingMe
                                         select mob);
                    else
                        returns.AddRange(from mob in mobs
                                         let mdt = mob.Location.GetDistanceTo(l)
                                         where
                                             mdt <= radius && !mob.IsDead && !mob.IsTagged && mob.Level > 1 &&
                                             !mob.IsTargetingMe && mob.Reaction.Equals(Reaction.Hostile)
                                         select mob);
                }
            }
            return returns;
        }

        #region <Initialization Fields>

        public static uint CurrentManager { get; set; }

        #endregion

        #region <Properties>

        public static byte[] LocalGUID { get; set; }

        #endregion

        public void Refresh()
        {
            // Fill the new list.
            ReadObjectList();
        }
    }

    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class NotifyEventAttach : EventArgs
    {
        private readonly int _pid;

        /// <summary>
        ///   Initializes a new instance of the <see cref = "NotifyEventAttach" /> class.
        /// </summary>
        /// <param name = "pid">The pid.</param>
        public NotifyEventAttach(int pid)
        {
            _pid = pid;
        }

        /// <summary>
        ///   Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public int Pid
        {
            get { return _pid; }
        }
    }

    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class NotifyEventNoAttach : EventArgs
    {
        private readonly string _message;

        /// <summary>
        ///   Initializes a new instance of the <see cref = "NotifyEventNoAttach" /> class.
        /// </summary>
        /// <param name = "message">The pid.</param>
        public NotifyEventNoAttach(string message)
        {
            _message = message;
        }

        /// <summary>
        ///   Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get { return _message; }
        }
    }
}