
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
#region

using LazyLib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

#endregion

namespace LazyLib.Wow
{
    /// <summary>
    ///   Representing us ingame
    /// </summary>
    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class PPlayerSelf : PPlayer
    {
        private readonly uint[] _healthStone = new uint[] { 0x901c, 0x901e, 0x901d, 0x9019, 0x901b, 0x901a, 0x5659, 0x5657, 0x5658, 0x24cd, 0x4a45, 0x4a44, 0x4a43, 0x4a42, 0x1586, 0x1585, 0x1587, 0x1588, 0x4a3d, 0x4a3c, 0x4a41, 0x4a40, 0x4a3f };

        private readonly uint[] _mageFood = new uint[] { 0xffdb, 0xaa03, 0xa9fe, 0xffed, 0xffec, 0xffeb, 0xffdc };

        /// <summary>
        ///   Initializes a new instance of the <see cref = "PPlayerSelf" /> class.
        /// </summary>
        /// <param name = "baseAddress">The base address.</param>
        public PPlayerSelf(uint baseAddress) : base(baseAddress)
        {
        }


        /// <summary>
        ///   Gets a value indicating whether [should repair].
        /// </summary>
        /// <value><c>true</c> if [should repair]; otherwise, <c>false</c>.</value>
        public bool ShouldRepair
        {
            get
            {
                if (InterfaceHelper.GetFrameByName("DurabilityFrame") == null)
                    return false;
                return InterfaceHelper.GetFrameByName("DurabilityFrame").IsVisible;
            }
        }

        public bool HasAttackers
        {
            get { return ObjectManager.GetAttackers.Count != 0; }
        }

        public int CoinAge
        {
            get { return GetStorageField<int>((uint)Descriptors.CGPlayerData.Coinage); }
        }

        /// <summary>
        ///   Gets the get id's of the items equipped
        /// </summary>
        /// <value>The id's</value>
        public List<uint> GetItemsEquippedId
        {
            get
            {
                var toReturn = new List<uint>();
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x8));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x16));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x24));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x32));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x40));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x48));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x56));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x64));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x72));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x80));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x88));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x96));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x104));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x112));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x120));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x128));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x136));
                toReturn.Add(GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x144));
                return toReturn;
            }
        }


        public bool LootWinOpen
        {
            get { return Memory.Read<uint>(Memory.BaseAddress + (uint)Pointers.Globals.LootWindow) != 0; }
        }

        public bool MainHandHasTempEnchant
        {
            get
            {
                PItem item = ObjectManager.MyPlayer.MainHand;
                if (item == null)
                    return true;
                return item.TempEnchants.Any(oneEnchant => oneEnchant != 0);
            }
        }

        public bool OffHandHasTempEnchant
        {
            get
            {
                PItem item = ObjectManager.MyPlayer.OffHand;
                if (item == null)
                    return true;
                foreach (uint oneEnchant in item.TempEnchants)
                {
                    if (oneEnchant != 0)
                        return true;
                }
                return false;
            }
        }

        public int BagSlotFlags
        {
            get { return GetStorageField<int>((uint)Descriptors.CGPlayerData.BagSlotFlags); }
        }

        internal List GUIDOfItemsInBag
        {
            get
            {
                var guids = new List();
                const int numberOfItems = 16;
                uint i;
                for (i = 0; i < numberOfItems; i++)
                {
                    guids.Add(GetStorageField((uint)Descriptors.CGPlayerData.InvSlots + 0x8 * i));
                    //Logging.Write(GetStorageField<ulong>((uint)Descriptors.CGPlayerData.InvSlots + 0x8 * i) + "");
                }
                return guids;
            }
        }

        internal List<UInt64> GUIDOfBags
        {
            get
            {
                var guids = new List<UInt64>();
                UInt64 bag;
                try
                {
                    bag =
                        Memory.ReadRelative<UInt64>(((uint)Pointers.Container.EquippedBagGUID));
                    guids.Add(bag);
                }
                catch
                {
                }
                try
                {
                    bag =
                        Memory.ReadRelative<UInt64>(((uint)Pointers.Container.EquippedBagGUID + 0x8 * 1));  // + 8
                    guids.Add(bag);
                }
                catch
                {
                }
                try
                {
                    bag =
                        Memory.ReadRelative<UInt64>(((uint)Pointers.Container.EquippedBagGUID + 0x8 * 2)); // + 16
                    guids.Add(bag);
                }
                catch
                {
                }
                try
                {
                    bag =
                        Memory.ReadRelative<UInt64>(((uint)Pointers.Container.EquippedBagGUID + 0x8 * 3));  // + 24
                    guids.Add(bag);
                }
                catch
                {
                }
                return guids;
            }
        }


        /// <summary>
        ///   Returns a item pointer to the mainhand
        /// </summary>
        /// <value>The main hand.</value>
        public PItem MainHand
        {
            get
            {
                foreach (PItem pItem in ObjectManager.GetItems)
                {
                    if (
                        pItem.EntryId.Equals(
                            GetStorageField<uint>((uint)0xec0)))
                    {
                        return pItem;
                    }
                }
                return null;
            }
        }

        /// <summary>
        ///   Return a item pointer to the offhand
        /// </summary>
        /// <value>The off hand.</value>
        public PItem OffHand
        {
            get
            {
                foreach (PItem pItem in ObjectManager.GetItems)
                {
                    if (
                        pItem.EntryId.Equals(
                            GetStorageField<uint>((uint)0xec8)))
                    {
                        return pItem;
                    }
                }
                return null;
            }
        }


        /// <summary>
        /// Gets the mage refreshment.
        /// </summary>
        /// <value>The mage refreshment.</value>
        public int MageRefreshment
        {
            get { return ObjectManager.GetItems.Count(var => _mageFood.Contains(var.EntryId)); }
        }

        /// <summary>
        ///   Gets the health stone count.
        /// </summary>
        /// <value>The health stone count.</value>
        public int HealthStoneCount
        {
            get { return ObjectManager.GetItems.Count(var => _healthStone.Contains(var.EntryId)); }
        }

        /// <summary>
        ///   Gets a value indicating whether [winter grasp is in progress].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [winter grasp in progress]; otherwise, <c>false</c>.
        /// </value>
        public bool WinterGraspInProgress
        {
            get { return HasBuff(37795) || (HasBuff(33280) || HasBuff(55629)); }
        }

        /// <summary>
        ///   Gets a value indicating whether [blood rune1 ready].
        /// </summary>
        /// <value><c>true</c> if [blood rune1 ready]; otherwise, <c>false</c>.</value>
        public bool BloodRune1Ready
        {
            get { return IsRuneReady(0); }
        }

        /// <summary>
        ///   Gets a value indicating whether [blood rune2 ready].
        /// </summary>
        /// <value><c>true</c> if [blood rune2 ready]; otherwise, <c>false</c>.</value>
        public bool BloodRune2Ready
        {
            get { return IsRuneReady(1); }
        }

        /// <summary>
        ///   Gets a value indicating whether [frost rune1 ready].
        /// </summary>
        /// <value><c>true</c> if [frost rune1 ready]; otherwise, <c>false</c>.</value>
        public bool UnholyRune1Ready
        {
            get { return IsRuneReady(2); }
        }

        /// <summary>
        ///   Gets a value indicating whether [frost rune2 ready].
        /// </summary>
        /// <value><c>true</c> if [frost rune2 ready]; otherwise, <c>false</c>.</value>
        public bool UnholyRune2Ready
        {
            get { return IsRuneReady(3); }
        }

        /// <summary>
        ///   Gets a value indicating whether [unholy rune1 ready].
        /// </summary>
        /// <value><c>true</c> if [unholy rune1 ready]; otherwise, <c>false</c>.</value>
        public bool FrostRune1Ready
        {
            get { return IsRuneReady(4); }
        }

        /// <summary>
        ///   Gets a value indicating whether [unholy rune2 ready].
        /// </summary>
        /// <value><c>true</c> if [unholy rune2 ready]; otherwise, <c>false</c>.</value>
        public bool FrostRune2Ready
        {
            get { return IsRuneReady(5); }
        }


        /// <summary>
        /// Gets a value indicating whether [in vashir].
        /// </summary>
        /// <value><c>true</c> if [in vashir]; otherwise, <c>false</c>.</value>
        public bool InVashjir
        {
            get { return (ZoneId == 5145 || ZoneId == 5144 || ZoneId == 5146 || ZoneId == 4815); }
        }

        /// <summary>
        ///   Returns current zoneid
        /// </summary>
        public uint ZoneId
        {
            get
            {
                return Memory.ReadRelative<uint>((uint)Pointers.Zone.ZoneID);
            }
        }


        /// <summary>
        ///   Returns current zonetext
        /// </summary>
        public string ZoneText
        {
            get
            {
                return Memory.ReadUtf8(
                    Memory.ReadRelative<uint>((uint)Pointers.Zone.ZoneText), 40);
            }
        }


        /// <summary>
        ///   Returns current SubZoneText
        /// </summary>
        public string SubZoneText
        {
            get
            {
                return Memory.ReadUtf8(Memory.ReadRelative<uint>((uint)Pointers.Zone.SubZoneText), 40);
            }
        }

        /// <summary>
        ///   Returns the experience as percentage.
        /// </summary>
        /// <value>The experience percentage.</value>
        public int ExperiencePercentage
        {
            get
            {
                try
                {
                    return (100 * Experience) / NextLevel;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        ///   Return the experience points.
        /// </summary>
        /// <value>The experience points.</value>
        public int Experience
        {
            get { return GetStorageField<int>((uint)Descriptors.CGPlayerData.XP); }
        }

        /// <summary>
        ///   Returns experience requires to advance to the next level.
        /// </summary>
        /// <value>The experience points to next level.</value>
        public int NextLevel
        {
            get { return GetStorageField<int>((uint)Descriptors.CGPlayerData.NextLevelXP); }
        }

        /// <summary>
        ///   Returns the last red message.
        /// </summary>
        /// <value>The red message.</value>
        public string RedMessage
        {
            get { return Memory.ReadUtf8StringRelative((uint)Pointers.Globals.RedMessage, 256); }
        }

        /// <summary>
        ///   Gets the get id's of the item
        /// </summary>
        /// <param name = "slot">The slot.</param>
        /// <returns></returns>
        /// <value>The id's</value>
        public uint GetItemBySlot(int slot)
        {
            switch (slot)
            {
                case 1:
                    return base.GetStorageField<uint>((uint)(uint)Descriptors.CGPlayerData.VisibleItems);

                case 2:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x8);

                case 3:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x16);

                case 4:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x24);

                case 5:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x32);

                case 6:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x40);

                case 7:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x48);

                case 8:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x56);

                case 9:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x64);

                case 10:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x72);

                case 11:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x80);

                case 12:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x88);

                case 13:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x96);

                case 14:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x104);

                case 15:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x112);

                case 0x10:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x120);

                case 0x11:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x128);

                case 0x12:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x136);

                case 0x13:
                    return base.GetStorageField<uint>((uint)Descriptors.CGPlayerData.VisibleItems + 0x144);
            }
            return 0;
        }

        /// <summary>
        ///   Targets the self.
        /// </summary>
        public void TargetSelf()
        {
            // KeyHelper.SendKey("F1");
            Thread.Sleep(100);
        }

        private bool IsRuneReady(int runeIndex)
        {
            return (((1 << runeIndex) & Memory.ReadRelative<byte>((uint)Pointers.Runes.RunesOffset)) != 0);
        }
    }
}