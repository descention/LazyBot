
﻿/*
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using LazyLib.ActionBar;
using LazyLib.Helpers;

#endregion

namespace LazyLib.Wow
{
    /// <summary>
    ///   Representing a unit ingame
    /// </summary>
    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class PUnit : PObject
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "PUnit" /> class.
        /// </summary>
        /// <param name = "baseAddress">The base address.</param>
        public PUnit(uint baseAddress)
            : base(baseAddress)
        {
        }

        /// <summary>
        ///   Determines whether [is facing away].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is facing away]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFacingAway
        {
            get
            {
                if (MoveHelper.NegativeAngle(Facing - ObjectManager.MyPlayer.Facing) > 5.5 ||
                    MoveHelper.NegativeAngle(Facing - ObjectManager.MyPlayer.Facing) < 0.6)
                    return true;
                return false;
            }
        }

        /// <summary>
        ///   Gets the facing PI.
        /// </summary>
        /// <value>The facing PI.</value>
        public double FacingPI
        {
            get
            {
                float wowFacing =
                    MoveHelper.NegativeAngle(
                        (float)Math.Atan2((Y - ObjectManager.MyPlayer.Y), (X - ObjectManager.MyPlayer.X)));
                return wowFacing;
            }
        }


        public Constants.SkinnableType GetSkinnableType()
        {
            if (this.IsSkinnable)
            {
                if (this.IsHerb)
                {
                    if (LazySettings.DebugMode)
                    {
                        Logging.Write("GetSkinnableType = IsHerb", new object[0]);
                    }
                    return Constants.SkinnableType.Herb;
                }
                if (this.IsMining)
                {
                    if (LazySettings.DebugMode)
                    {
                        Logging.Write("GetSkinnableType = IsMining", new object[0]);
                    }
                    return Constants.SkinnableType.Mining;
                }
                if (this.IsIngener)
                {
                    if (LazySettings.DebugMode)
                    {
                        Logging.Write("GetSkinnableType = IsIngener", new object[0]);
                    }
                    return Constants.SkinnableType.Engineer;
                }
                if (LazySettings.DebugMode)
                {
                    Logging.Write("GetSkinnableType = Skining", new object[0]);
                }
                return Constants.SkinnableType.Skining;
            }
            if (LazySettings.DebugMode)
            {
                Logging.Write("GetSkinnableType = None", new object[0]);
            }
            return Constants.SkinnableType.None;
        }

        /// <summary>
        ///   Gets the type of the power.
        /// </summary>
        /// <value>The type of the power.</value>
        public string PowerType
        {
            get
            {
                //Logging.Debug("Power: " + PowerTypeId);
                switch (this.PowerTypeId)
                {
                    case 0:
                        return "Mana";

                    case 1:
                        return "Rage";

                    case 2:
                        return "Focus";

                    case 3:
                        return "Energy";

                    case 4:
                        return "Hapiness";

                    case 5:
                        return "Runes";

                    case 6:
                        return "Runic Power";

                    case 7:
                        return "SoulShards";

                    case 8:
                        return "Eclipse";

                    case 9:
                        return "HolyPower";

                    case 10:
                        return "Alternate";

                    case 11:
                        return "DarkForce";

                    case 12:
                        return "LightForce";

                    case 13:
                        return "ShadowOrbs";

                    case 14:
                        return "BurningEmbers";

                    case 15:
                        return "DemonicFury";

                    case 16:
                        return "ArcaneCharges";
                }
                return "";
            }
        }

        /// <summary>
        ///   Gets the unit race.
        /// </summary>
        /// <value>The unit race.</value>
        public string UnitRace
        {
            get
            {
                //Logging.Debug("Race:" + RaceId);
                switch (this.RaceId)
                {
                    case 1:
                        return "Human";

                    case 2:
                        return "Orc";

                    case 3:
                        return "Dwarf";

                    case 4:
                        return "Night Elf";

                    case 5:
                        return "Undead";

                    case 6:
                        return "Tauren";

                    case 7:
                        return "Gnome";

                    case 8:
                        return "Troll";

                    case 9:
                        return "Goblin";

                    case 10:
                        return "Blood Elf";

                    case 11:
                        return "Draenei";

                    case 12:
                        return "Fel Orc";

                    case 13:
                        return "Naga";

                    case 14:
                        return "Broken";

                    case 15:
                        return "Skeleton";

                    case 0x16:
                        return "Worgen";

                    case 0x18:
                        return "Pandaren";
                }
                return "Unknown";
            }
        }

        /// <summary>
        /// Returns the object's speed.
        /// </summary>
        public Single Speed
        {
            get
            {
                var pointer = Memory.Read<uint>(BaseAddress + (uint)Pointers.UnitSpeed.Pointer1);
                var speed = Memory.Read<float>(pointer + (uint)Pointers.UnitSpeed.Pointer2);
                return speed;
            }
        }

        /// <summary>
        /// Returns True if unit is moving, else False.
        /// </summary>
        public bool IsMoving
        {
            get { return (Speed > 0); }
        }

        /// <summary>
        ///   Gets the gender.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender
        {
            get
            {
                string gender;
                switch (GenderId)
                {
                    case (uint)Constants.UnitGender.UnitGender_Male:
                        gender = @"Male";
                        break;
                    case (uint)Constants.UnitGender.UnitGender_Female:
                        gender = @"Female";
                        break;
                    default:
                        gender = @"Unknown";
                        break;
                }
                return gender;
            }
        }

        private uint InfoFlags
        {
            get
            {
                try
                {
                    return GetStorageField<UInt32>((uint)Descriptors.CGUnitData.Sex);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public uint RaceId
        {
            get { return ((InfoFlags >> 0) & 0xFF); }
        }

        public uint UnitClassId
        {
            get { return ((InfoFlags >> 8) & 0xFF); }
        }

        public uint GenderId
        {
            get { return ((InfoFlags >> 16) & 0xFF); }
        }

        public uint PowerTypeId
        {
            get
            {
                try
                {
                    return ((GetStorageField<UInt32>((uint)Descriptors.CGUnitData.DisplayPower) >> 0) & 0xFF);
                }
                catch
                {
                    return 0;
                }
            }
        }


        /// <summary>
        ///   Gets the class.
        /// </summary>
        /// <value>The class.</value>
        public string Class
        {
            get
            {
                switch (this.UnitClassId)
                {
                    case 1:
                        return "Warrior";

                    case 2:
                        return "Paladin";

                    case 3:
                        return "Hunter";

                    case 4:
                        return "Rogue";

                    case 5:
                        return "Priest";

                    case 6:
                        return "Death Knight";

                    case 7:
                        return "Shaman";

                    case 8:
                        return "Mage";

                    case 9:
                        return "Warlock";

                    case 10:
                        return "Monk";

                    case 11:
                        return "Druid";
                }
                return "Unknown";
            }
        }

        public LazyLib.Wow.Constants.UnitClass UnitClass
        {
            get
            {
                switch (this.UnitClassId)
                {
                    case 0:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Unknown;

                    case 1:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Warrior;

                    case 2:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Paladin;

                    case 3:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Hunter;

                    case 4:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Rogue;

                    case 5:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Priest;

                    case 6:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_DeathKnight;

                    case 7:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Shaman;

                    case 8:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Mage;

                    case 9:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Warlock;

                    case 10:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Monk;

                    case 11:
                        return LazyLib.Wow.Constants.UnitClass.UnitClass_Druid;
                }
                throw new Exception("Unknown class");
            }
        }


        /// <summary>
        /// Return the unit classification
        /// </summary>
        /// <value>The classification.</value>
        public Constants.Classification Classification
        {
            get
            {
                var v1 = Memory.Read<uint>(base.BaseAddress + (uint)Pointers.CgUnitCGetCreatureRank.Offset1);
                return
                    (Constants.Classification)Memory.Read<uint>(v1 + (uint)Pointers.CgUnitCGetCreatureRank.Offset2);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is elite.
        /// </summary>
        /// <value><c>true</c> if this instance is elite; otherwise, <c>false</c>.</value>
        public bool IsElite
        {
            get
            {
                return this.Classification.Equals(LazyLib.Wow.Constants.Classification.Elite);
            }
        }

        public bool IsBoss
        {
            get
            {
                return this.Classification.Equals(LazyLib.Wow.Constants.Classification.WorldBoss);
            }
        }

        /// <summary>
        /// Return the unit type
        /// </summary>
        /// <value>The type of the creature.</value>     
        public Constants.CreatureType CreatureType
        {
            get
            {
                var v4 = Memory.Read<uint>(base.BaseAddress + (uint)Pointers.CgUnitCGetCreatureType.Offset1);
                return
                    (Constants.CreatureType)Memory.Read<uint>(v4 + (uint)Pointers.CgUnitCGetCreatureType.Offset2);
            }
        }


        /// <summary>
        ///   Gets the reaction.
        /// </summary>
        /// <value>The reaction.</value>
        public LazyLib.Wow.Reaction Reaction
        {
            get
            {
                return LazyLib.Wow.Faction.GetReaction(LazyLib.Wow.ObjectManager.MyPlayer, this);
            }
        }

        /// <summary>
        ///   Gets a value indicating whether this unit is a player.
        /// </summary>
        /// <value><c>true</c> if this instance is player; otherwise, <c>false</c>.</value>
        public bool IsPlayer
        {
            get { return ObjectManager.GetPlayers.Any(player => player.GUID.Equals(GUID)); }
        }

        /// <summary>
        /// Returns the current ShapeshiftForm.
        /// </summary>
        public Constants.ShapeshiftForm ShapeshiftForm
        {
            get
            {
                return
                    (Constants.ShapeshiftForm)
                    Memory.Read<byte>(Memory.Read<uint>(BaseAddress + (uint)Pointers.ShapeshiftForm.BaseAddressOffset1) + (uint)Pointers.ShapeshiftForm.BaseAddressOffset2);
            }
        }

        /// <summary>
        ///   Determines whether the specified unit is pet.
        /// </summary>
        /// <value><c>true</c> if this instance is pet; otherwise, <c>false</c>.</value>
        /// <returns>
        ///   <c>true</c> if the specified unit is pet; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPet
        {
            get
            {
                try
                {
                    return ObjectManager.GetPlayers.Where(cur => cur.HasLivePet).Any(cur => cur.PetGUID == GUID);
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool IsTotem
        {
            get
            {
                return (this.CreatureType == LazyLib.Wow.Constants.CreatureType.Totem);
            }
        }


        /// <summary>
        ///   Retuns the current Target of the unit
        ///   Return a new PUnit if null, you can check if the PUnit is valid using the IsValid property.
        /// </summary>
        public virtual PUnit Target
        {
            get
            {
                try
                {
                    if (TargetGUID.Equals(ObjectManager.MyPlayer.GUID))
                        return ObjectManager.MyPlayer;
                    foreach (PUnit u in ObjectManager.GetUnits)
                    {
                        try
                        {
                            if (u.GUID.Equals(TargetGUID))
                                return u;
                        }
                        catch
                        {
                        }
                    }
                }
                catch (Exception)
                {
                }
                return new PUnit(uint.MinValue);
            }
        }

        public bool HasTarget
        {
            get
            {
                try
                {
                    if (TargetGUID.Equals(ObjectManager.MyPlayer.GUID))
                        return true;
                    if (ObjectManager.GetUnits.Any(u => u.GUID.Equals(TargetGUID)))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                }
                return false;
            }
        }

        /// <summary>
        ///   Gets a value indicating whether this unit is in flight form.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this unit is in flight form; otherwise, <c>false</c>.
        /// </value>
        public bool IsInFlightForm
        {
            get { return HasBuff(33943) || HasBuff(40120) || AquaticForm; }
        }

        public bool TravelForm
        {
            get
            {
                if (!this.HasBuff(0x30f))
                {
                    return this.HasBuff(0xa55);
                }
                return true;
            }
        }

        public bool AquaticForm
        {
            get
            {
                if (!this.HasBuff(0x42a))
                {
                    return this.ShapeshiftForm.Equals(LazyLib.Wow.Constants.ShapeshiftForm.Aqua);
                }
                return true;
            }
        }

        /// <summary>
        ///   Gets a value indicating whether this instance is mounted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is mounted; otherwise, <c>false</c>.
        /// </value>
        public bool IsMounted
        {
            get
            {
                try
                {
                    return (this.IsInFlightForm || (this.TravelForm || (this.AquaticForm || (base.GetStorageField<int>((uint)0x47) != 0))));
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        ///   True if this unit is lootable right now.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is lootable; otherwise, <c>false</c>.
        /// </value>
        public bool IsLootable
        {
            get
            {
                return Convert.ToBoolean((int)(this.GetDynFlags & 2));
            }
        }

        /// <summary>
        ///   True if this monster has been tagged by another Player
        /// </summary>
        /// <value><c>true</c> if this instance is tagged; otherwise, <c>false</c>.</value>
        public bool IsTagged
        {
            get
            {
                if (GetDynFlags == 8)
                    return true;
                return false;
            }
        }
        /// <summary>
        ///   True if this monster has been tagged by you
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is tagged by me; otherwise, <c>false</c>.
        /// </value>
        public bool IsTaggedByMe
        {
            get
            {
                if (Convert.ToBoolean((long)this.GetDynFlags & (long)16))
                {
                    return true;
                }
                if (Convert.ToBoolean((long)this.GetDynFlags & (long)2))
                {
                    return true;
                }
                return false;
            }
        }


        /*
        The Flags can be seen as:
        01: has loot
        02: ???
        04: locked to a Player
        08: locked to you
        If the function returns 13 (01 * 04 * 08) the mob is locked to you and is lootable.
        If it is returns 12 (04 & 08) you are either still fighting it, or you have already looted it.
        */

        /// <summary>
        ///   Gets the get dyn flags.
        /// </summary>
        /// <value>The get dyn flags.</value>
        public int GetDynFlags
        {
            get
            {
                try
                {
                    return base.GetStorageField<int>((uint)Descriptors.CGObjectData.DynamicFlags);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public bool IsNotSelectable
        {
            get
            {
                return Convert.ToBoolean(this.Flags & (long)0x2000000);
            }
        }


        /// <summary>
        ///   Returns true if the unit is in combat
        /// </summary>
        /// <value><c>true</c> if [in combat]; otherwise, <c>false</c>.</value>
        public bool IsInCombat
        {
            get
            {
                return Convert.ToBoolean((long)(this.Flags & (uint)UnitNPCFlags2.UNIT_FLAG_IN_COMBAT));
            }
        }


        public bool InCombat
        {
            get
            {
                uint num = Memory.Read<uint>(new uint[] { base.BaseAddress + (uint)Pointers.InCombat.Pointer });
                return (((Memory.Read<uint>(new uint[] { num + (uint)Pointers.InCombat.Offset }) >> 0x13) & 1) == 1);
            }
        }

        /// <summary>
        ///   Returns true if the unit is influenced
        /// </summary>
        /// <value><c>true</c> if [in combat]; otherwise, <c>false</c>.</value>
        public bool IsInfluenced
        {
            get { return Convert.ToBoolean(Flags & (uint)Constants.UnitFlags.Preparation); }
        }

        /// <summary>
        ///   Returns true if the unit is plusmob
        /// </summary>
        /// <value><c>true</c> if [in combat]; otherwise, <c>false</c>.</value>
        public bool IsPlusMob
        {
            get { return Convert.ToBoolean(Flags & (uint)Constants.UnitFlags.PlusMob); }
        }

        /// <summary>
        ///   Gets a value indicating whether this unit is fleeing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is fleeing; otherwise, <c>false</c>.
        /// </value>
        public bool IsFleeing
        {
            get
            {
                return Convert.ToBoolean((long)(this.Flags & (uint)UnitNPCFlags2.UNIT_FLAG_FLEEING));
            }
        }


        /// <summary>
        ///   Gets a value indicating whether this unit is stunned.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is stunned; otherwise, <c>false</c>.
        /// </value>
        public bool IsStunned
        {
            get
            {
                return Convert.ToBoolean((long)(this.Flags & (uint)UnitNPCFlags2.UNIT_FLAG_STUNNED));
            }
        }

        /// <summary>  New Thanks Charles
        ///   Gets a value indicating whether this unit is SILENCED.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is SILENCED; otherwise, <c>false</c>.
        /// </value>
        public bool IsSilenced
        {
            get
            {
                return Convert.ToBoolean((long)(this.Flags & (uint)UnitNPCFlags2.UNIT_FLAG_SILENCED));
            }
        }

        /// <summary>  New Thanks Charles
        ///   Gets a value indicating whether this unit is Disarmed
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance Is Disarmed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisarmed
        {
            get
            {
                return Convert.ToBoolean((long)(this.Flags & (uint)UnitNPCFlags2.UNIT_FLAG_DISARMED));
            }
        }

        /// <summary>  New Thanks Charles
        ///   Gets a value indicating whether this unit is Confused
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance Is Confused; otherwise, <c>false</c>.
        /// </value>
        public bool IsConfused
        {
            get
            {
                return Convert.ToBoolean((long)(this.Flags & (uint)UnitNPCFlags2.UNIT_FLAG_CONFUSED));
            }
        }

        /// <summary>  New Thanks Charles
        ///   Gets a value indicating whether this unit is PACIFIED
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance Is PACIFIED; otherwise, <c>false</c>.
        /// </value>
        public bool IsPacified
        {
            get
            {
                return Convert.ToBoolean((long)(this.Flags & (uint)UnitNPCFlags2.UNIT_FLAG_PACIFIED));
            }
        }
        /// <summary>
        ///   Returns true if auto attack in enabled
        /// </summary>
        /// <value><c>true</c> if [auto attack]; otherwise, <c>false</c>.</value>
        public bool IsAutoAttacking
        {
            get
            {
                return ((Memory.Read<int>(BaseAddress + (uint)Pointers.AutoAttack.AutoAttackFlag)) |
                        Memory.Read<int>(BaseAddress + (uint)Pointers.AutoAttack.AutoAttackMask)) != 0;
            }
        }

        /// <summary>
        ///   Returns true if swimming
        /// </summary>
        /// <value><c>true</c> if [swimming]; otherwise, <c>false</c>.</value>
        public bool IsSwimming
        {
            get
            {
                var p1 = Memory.Read<uint>(BaseAddress + (uint)Pointers.Swimming.Pointer);
                var p2 = Memory.Read<uint>(p1 + (uint)Pointers.Swimming.Offset);
                return (p2 & (uint)Pointers.Swimming.Mask) != 0;
            }
        }

        /// <summary>
        /// Return True if unit is Flying, else False.
        /// </summary>
        public bool IsFlying
        {
            get
            {
                var p1 = Memory.Read<uint>(BaseAddress + (uint)Pointers.IsFlying.Pointer);
                var p2 = Memory.Read<uint>(p1 + (uint)Pointers.IsFlying.Offset);
                return (p2 & (uint)Pointers.IsFlying.Mask) != 0;
            }
        }

        /// <summary>
        ///   Returns true if the unit is Skinnable
        /// </summary>
        /// <value><c>true</c> if skinnable; otherwise, <c>false</c>.</value>
        public bool IsSkinnable
        {
            get
            {
                return Convert.ToBoolean((long)(this.Flags & (uint)UnitNPCFlags2.UNIT_FLAG_SKINNABLE));
            }
        }

        ///<summary>
        ///  Returns the current unit field flag.
        ///</summary>
        ///<value>
        ///  8: PVP Enabled
        ///  10: totem?!
        ///  40: elite? 
        ///  800: fighing
        ///  1000: in pvp
        ///  8000: ???
        ///  40000: immobile (Player dead / stunned = C0000)
        ///  80000:  in melee
        ///  4000000: Skinnable
        ///  20000000: dazed
        ///</value>
        public long Flags
        {
            get
            {
                try
                {
                    return (long)base.GetStorageField<int>((uint)Descriptors.CGUnitData.Flags);
                }
                catch
                {
                    return 0L;
                }
            }
        }

        /// <summary>
        ///   Faction template id of this unit
        /// </summary>
        /// <value>The faction.</value>
        public uint Faction
        {
            get
            {
                try
                {
                    return base.GetStorageField<uint>((uint)Descriptors.CGUnitData.FactionTemplate);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        ///   True if unit is ghost
        /// </summary>
        /// <value><c>true</c> if this instance is ghost; otherwise, <c>false</c>.</value>
        public bool IsGhost
        {
            get
            {
                if (HealthPoints == 1)
                    return true;
                return false;
            }
        }

        /// <summary>
        ///   Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name
        {
            get
            {
                try
                {
                    return
                        Memory.ReadUtf8(
                            Memory.Read<uint>(
                                Memory.Read<uint>(BaseAddress + (uint)Pointers.UnitName.UnitName1) +
                                (uint)Pointers.UnitName.UnitName2), 256);
                }
                catch (Exception)
                {
                }
                return "Read failed";
            }
        }

        /// <summary>
        ///   Checks if Unit is casting and returns an int of the spellID being cast
        /// </summary>
        public int CastingId
        {
            get
            {
                try
                {
                    uint num = base.BaseAddress + (uint)Pointers.CastingInfo.IsCasting;
                    return Memory.Read<int>(new uint[] { num });
                }
                catch (Exception)
                {
                }
                return 0;
            }
        }

        /// <summary>
        ///   Gets a value indicating whether this unit is casting.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this unit is casting; otherwise, <c>false</c>.
        /// </value>
        public bool IsCasting
        {
            get
            {
                if ((this.CastingId == 0) && (this.ChanneledCastingId == 0))
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        ///   Gets the channeled casting id.
        /// </summary>
        /// <value>The channeled casting id.</value>
        public int ChanneledCastingId
        {
            get
            {
                uint num = base.BaseAddress + (uint)Pointers.CastingInfo.ChanneledCasting;
                return Memory.Read<int>(new uint[] { num });
            }
        }


        /// <summary>
        ///   Is this unit a critter?
        /// </summary>
        public bool Critter
        {
            get
            {
                if (base.GetStorageField<int>((uint)12) != 1)
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        ///   The GUID of the object this unit is charmed by.
        /// </summary>
        public ulong CharmedBy
        {
            get
            {
                return base.GetStorageField<ulong>((uint)Descriptors.CGUnitData.CharmedBy);
            }
        }

        /// <summary>
        ///   The GUID of the object this unit is summoned by.
        /// </summary>
        public ulong SummonedBy
        {
            get
            {
                return base.GetStorageField<ulong>((uint)Descriptors.CGUnitData.SummonedBy);
            }
        }

        /// <summary>
        ///   The GUID of the object this unit was created by.
        /// </summary>
        public ulong CreatedBy
        {
            get
            {
                return base.GetStorageField<ulong>((uint)Descriptors.CGUnitData.CreatedBy);
            }
        }


        private int SkinnableFlags
        {
            get
            {
                try
                {
                    return Memory.Read<int>(new uint[] { Memory.Read<uint>(new uint[] { base.BaseAddress + (uint)Pointers.Skinning.SkinnableFlags1 }) + (uint)Pointers.Skinning.SkinnableFlags2 });
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        ///   The unit's health.
        /// </summary>
        public int HealthPoints
        {
            get
            {
                return base.GetStorageField<int>((uint)Descriptors.CGUnitData.Health);
            }
        }

        /// <summary>
        ///   The unit's maximum health.
        /// </summary>
        public int MaximumHealthPoints
        {
            get
            {
                return base.GetStorageField<int>((uint)Descriptors.CGUnitData.MaxHealth);
            }
        }

        /// <summary>
        ///   True if this unit is dead
        /// </summary>
        /// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
        public bool IsDead
        {
            get { return !IsAlive; }
        }

        public bool IsAlive
        {
            get
            {
                if (HealthPoints == 0)
                    return false;
                if (HasBuff(new List<int>() { 8326, 9036, 20584 }))
                    return false;
                return true;
            }
        }


        /// <summary>
        ///   The unit's health as a percentage.
        /// </summary>
        public int Health
        {
            get
            {
                try
                {
                    return (100 * HealthPoints) / MaximumHealthPoints;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        ///   The unit's health as a percentage.
        /// </summary>
        public int Mana
        {
            get
            {
                try
                {
                    return (100 * ManaPoints) / MaximumManaPoints;
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        ///   The unit's base health.
        /// </summary>
        public int BaseHealth
        {
            get
            {
                return base.GetStorageField<int>((uint)Descriptors.CGUnitData.BaseHealth);
            }
        }

        /// <summary>
        ///   The unit's base health.
        /// </summary>
        public int BaseMana
        {
            get
            {
                return base.GetStorageField<int>((uint)Descriptors.CGUnitData.BaseMana);
            }
        }

        public int BurningEmbers
        {
            get
            {
                int num = base.GetStorageField<int>((uint)0x25) / 10;
                if (LazySettings.DebugMode)
                {
                    //Logging.Write("BurningEmbers = " + num.ToString(), new object[0]);
                }
                return num;
            }
        }

        public int MaximumBurningEmbers
        {
            get
            {
                return (base.GetStorageField<int>((uint)0x2b) / 10);
            }
        }


        private int MonkEnergy
        {
            get
            {
                return base.GetStorageField<int>((uint)0x23);
            }
        }

        private int MonkEnergyMax
        {
            get
            {
                return base.GetStorageField<int>((uint)0x29);
            }
        }

        /// <summary>
        ///   The unit's mana.
        /// </summary>
        public int ManaPoints
        {
            get
            {
                return base.GetStorageField<int>((uint)0x22);
            }
        }

        /// <summary>
        ///   The unit's maximum mana.
        /// </summary>
        public int MaximumManaPoints
        {
            get
            {
                return base.GetStorageField<int>((uint)40);
            }
        }

        /// <summary>
        ///   The unit's Chi.
        /// </summary>
        public int Chi
        {
            get
            {
                int storageField = base.GetStorageField<int>((uint)0x26);
                if (LazySettings.DebugMode)
                {
                    // Logging.Write("chi = " + storageField.ToString(), new object[0]);
                }
                return storageField;
            }
        }

        /// <summary>
        ///   The unit's maxx Chi.
        /// </summary>
        public int MaximumChi
        {
            get
            {
                return base.GetStorageField<int>((uint)0x2c);
            }
        }

        /// <summary>
        ///   The unit's rage.
        /// </summary>
        public int Rage
        {
            get
            {
                try
                {
                    if (this.UnitClass == LazyLib.Wow.Constants.UnitClass.UnitClass_Druid)
                    {
                        return this.DruidRage;
                    }
                }
                catch (Exception)
                {
                }
                return (base.GetStorageField<int>((uint)0x22) / 10);
            }
        }

        /// <summary>
        ///   The unit's focus.
        /// </summary>
        public int Focus
        {
            get
            {
                return base.GetStorageField<int>((uint)0x22);
            }
        }

        /// <summary>
        ///   The unit's Eclipse power.
        /// </summary>
        public int Eclipse
        {
            get
            {
                return base.GetStorageField<int>((uint)0x25);
            }
        }

        /// <summary>
        ///   The unit's Max Eclipse power.
        /// </summary>
        public int MaximumEclipse
        {
            get
            {
                return base.GetStorageField<int>((uint)0x2b);
            }
        }

        /// <summary>
        ///   The unit's Soul Shards.
        /// </summary>
        public int SoulShard
        {
            get
            {
                int num = base.GetStorageField<int>((uint)0x23) / 100;
                if (LazySettings.DebugMode)
                {
                    //Logging.Write("SoulShard = " + num.ToString(), new object[0]);
                }
                return num;
            }
        }

        /// <summary>
        ///   The unit's Max Soul Shards.
        /// </summary>
        public int MaximumSoulShard
        {
            get
            {
                return (base.GetStorageField<int>((uint)0x29) / 100);
            }
        }

        /// <summary>
        ///   The unit's Holy Power.
        /// </summary>
        public int HolyPower
        {
            get
            {
                return base.GetStorageField<int>((uint)0x23);
            }
        }

        /// <summary>
        ///   The unit's Max Holy Power.
        /// </summary>
        public int MaximumHolyPower
        {
            get
            {
                return base.GetStorageField<int>((uint)0x29);
            }
        }

        /// <summary>
        ///   The unit's energy.
        /// </summary>
        public int Energy
        {
            get
            {
                try
                {
                    if (this.UnitClass == LazyLib.Wow.Constants.UnitClass.UnitClass_Druid)
                    {
                        return this.DruidEnergy;
                    }
                    if (this.UnitClass == LazyLib.Wow.Constants.UnitClass.UnitClass_Rogue)
                    {
                        return this.RogueEnergy;
                    }
                    if (this.UnitClass == LazyLib.Wow.Constants.UnitClass.UnitClass_Monk)
                    {
                        return this.MonkEnergy;
                    }
                }
                catch (Exception)
                {
                }
                return base.GetStorageField<int>((uint)0x22);
            }
        }

        private int DruidEnergy
        {
            get
            {
                return base.GetStorageField<int>((uint)0x24);
            }
        }

        private int DruidEnergyMax
        {
            get
            {
                return base.GetStorageField<int>((uint)0x2a);
            }
        }

        private int DruidRage
        {
            get
            {
                return (base.GetStorageField<int>((uint)0x23) / 10);
            }
        }

        private int DruidRageMax
        {
            get
            {
                return base.GetStorageField<int>((uint)0x2c);
            }
        }

        /// <summary>
        ///   The unit's happinnes.
        /// </summary>
        public int Happinnes
        {
            get
            {
                return base.GetStorageField<int>((uint)0x25);
            }
        }

        /// <summary>
        ///   The unit's runic power.
        /// </summary>
        public int RunicPower
        {
            get
            {
                return (base.GetStorageField<int>((uint)0x22) / 10);
            }
        }

        /// <summary>
        ///   The unit's maximum rage.
        /// </summary>
        public int MaximumRage
        {
            get
            {
                try
                {
                    if (this.UnitClass == LazyLib.Wow.Constants.UnitClass.UnitClass_Druid)
                    {
                        return this.DruidRageMax;
                    }
                }
                catch (Exception)
                {
                }
                return base.GetStorageField<int>((uint)40);
            }
        }


        private int RogueEnergy
        {
            get
            {
                return base.GetStorageField<int>((uint)0x23);
            }
        }

        private int RogueEnergyMax
        {
            get
            {
                return base.GetStorageField<int>((uint)0x29);
            }
        }

        /// <summary>
        ///   The unit's maximum focus.
        /// </summary>
        public int MaximumFocus
        {
            get
            {
                return base.GetStorageField<int>((uint)40);
            }
        }

        /// <summary>
        ///   The unit's maximum energy.
        /// </summary>
        public int MaximumEnergy
        {
            get
            {
                try
                {
                    if (this.UnitClass == LazyLib.Wow.Constants.UnitClass.UnitClass_Druid)
                    {
                        return this.DruidEnergyMax;
                    }
                    if (this.UnitClass == LazyLib.Wow.Constants.UnitClass.UnitClass_Rogue)
                    {
                        return this.RogueEnergyMax;
                    }
                    if (this.UnitClass == LazyLib.Wow.Constants.UnitClass.UnitClass_Monk)
                    {
                        return this.MonkEnergyMax;
                    }
                }
                catch (Exception)
                {
                }
                return base.GetStorageField<int>((uint)40);
            }
        }

        /// <summary>
        ///   The unit's maximum runic power.
        /// </summary>

        public int MaximumRunicPower
        {
            get
            {
                return base.GetStorageField<int>((uint)40);
            }
        }

        /// <summary>
        ///   The unit's level.
        /// </summary>
        public new int Level
        {
            get
            {
                return base.GetStorageField<int>((uint)Descriptors.CGUnitData.Level);
            }
        }

        /// <summary>
        ///   The unit's DisplayID.
        /// </summary>
        public int DisplayId
        {
            get
            {
                return base.GetStorageField<int>((uint)Descriptors.CGUnitData.DisplayID);
            }
        }


        public bool IsMining
        {
            get
            {
                return Convert.ToBoolean((int)(this.SkinnableFlags & 0x200));
            }
        }

        public bool IsHerb
        {
            get
            {
                return Convert.ToBoolean((int)(this.SkinnableFlags & 0x100));
            }
        }

        public bool IsIngener
        {
            get
            {
                return Convert.ToBoolean((int)(this.SkinnableFlags & 0x8000));
            }
        }

        /// <summary>
        ///   The mount display of the mount the unit is mounted on.
        /// </summary>
        public int MountDisplayId
        {
            get
            {
                return base.GetStorageField<int>((uint)Descriptors.CGUnitData.MountDisplayID);
            }
        }

        /// <summary>
        ///   The GUID of the object this unit is targeting.
        /// </summary>
        public ulong TargetGUID
        {
            get
            {
                return base.GetStorageField<ulong>((uint)Descriptors.CGUnitData.Target);
            }
        }

        /// <summary>
        ///   True if this unit is targeting me.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is targeting me; otherwise, <c>false</c>.
        /// </value>
        public bool IsTargetingMe
        {
            get
            {
                return ((this.Target != null) && this.Target.TargetGUID.Equals(LazyLib.Wow.ObjectManager.MyPlayer.GUID));
            }
        }

        /// <summary>
        ///   True if I have a pet and this unit is targeting it.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is targeting my pet; otherwise, <c>false</c>.
        /// </value>
        public bool IsTargetingMyPet
        {
            get
            {
                if (!ObjectManager.MyPlayer.HasLivePet) return false;
                if (Target != null && Target.TargetGUID.Equals(ObjectManager.MyPlayer.TargetGUID))
                    return true;
                return false;
            }
        }

        /// <summary>
        ///   Returns the GUID of our pet
        /// </summary>
        /// <remarks>
        ///   Does not look at non combat pets
        /// </remarks>
        public virtual ulong PetGUID
        {
            get
            {
                try
                {
                    if (HasLivePet)
                    {
                        return Pet.GUID;
                    }
                }
                catch { }
                return 0;
            }
        }

        /// <summary>
        ///   Returns true if one of the objects is summond by the Player
        /// </summary>
        /// <remarks>
        ///   Does not look at non combat pets!
        /// </remarks>
        public bool HasLivePet
        {
            get
            {
                try
                {
                    if (Pet != null)
                        return true;
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        ///   Returns our pet
        /// </summary>
        /// <remarks>
        ///   Does not return non combat pets!
        /// </remarks>
        public PUnit Pet
        {
            get
            {
                try
                {
                    foreach (PUnit obj in ObjectManager.GetObjects.OfType<PUnit>())
                    {
                        if (obj.SummonedBy.Equals(GUID))
                        {
                            return obj;
                        }
                    }
                }
                catch (Exception)
                {
                }
                return null;
            }
        }

        /// <summary>
        ///   Gets the distance to self.
        /// </summary>
        /// <value>The distance to self.</value>
        public double DistanceToSelf
        {
            get { return Location.DistanceToSelf; }
        }
        /// <summary>
        /// Determines whether [has well known buff] [the specified buff name].
        /// </summary>
        /// <param name="buffName">Name of the buff.</param>
        /// <returns>
        /// 	<c>true</c> if [has well known buff] [the specified buff name]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasWellKnownBuff(string buffName)
        {
            return HasBuff(BarMapper.GetIdByName(buffName));
        }

        public bool HasWellKnownBuff(string buffName, bool playerIsOwner)
        {
            return HasBuff(BarMapper.GetIdByName(buffName), playerIsOwner);
        }

        /// <summary>
        ///   Check to see if this unit currently has the specified buff
        /// </summary>
        /// <param name = "buff">Buff id's.</param>
        /// <returns>
        ///   <c>true</c> if the specified unit has the buff; otherwise, <c>false</c>.
        /// </returns>
        public bool HasBuff(int[] buff)
        {
            List<int> auras = GetBuffs();
            try
            {
                if (buff.Any(u => auras.Contains(u)))
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }


        /// <summary>
        ///   Check to see if this unit currently has the specified buff
        /// </summary>
        /// <param name = "buff">Buff id.</param>
        /// <returns>
        ///   <c>true</c> if the specified unit has the buff; otherwise, <c>false</c>.
        /// </returns>
        public bool HasBuff(int buff)
        {
            List<int> auras = GetBuffs();
            if (auras.Contains(buff)) return true;
            return false;
        }

        public bool HasBuff(int buff, bool playerShouldBeOwner)
        {
            if (!playerShouldBeOwner)
            {
                return HasBuff(buff);
            }
            try
            {
                var auras = GetAuras;
                return auras.Any(woWAura => buff == woWAura.SpellId && (woWAura.OwnerGUID == ObjectManager.MyPlayer.GUID) || (woWAura.OwnerGUID == ObjectManager.MyPlayer.PetGUID));
            }
            catch
            {
                return false;
            }
        }

        public bool HasBuff(string buff)
        {
            List<int> auras = GetBuffs();
            List<int> buf = BarMapper.GetIdsFromName(buff);
            if (auras.Any(buf.Contains))
                return true;
            return false;
        }

        public bool HasBuff(string buff, bool playerShouldBeOwner)
        {
            if (!playerShouldBeOwner)
            {
                return HasBuff(buff);
            }
            var auras = GetAuras;
            List<int> buf = BarMapper.GetIdsFromName(buff);
            return auras.Any(woWAura => buf.Contains(woWAura.SpellId) && (woWAura.OwnerGUID == ObjectManager.MyPlayer.GUID) || (woWAura.OwnerGUID == ObjectManager.MyPlayer.PetGUID));
        }

        /// <summary>
        ///   Check to see if this unit currently has the specified buff
        /// </summary>
        /// <param name = "buffs">Buff list.</param>
        /// <returns>
        ///   <c>true</c> if the specified unit has the buff; otherwise, <c>false</c>.
        /// </returns>
        public bool HasBuff(List<int> buffs)
        {
            try
            {
                if (buffs.Any(HasBuff))
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }


        [DllImport("KERNEL32")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);
        public uint BuffTimeLeft(int spellId)
        {
            try
            {
                return (from woWAura in GetAuras where woWAura.SpellId == spellId select woWAura.SecondsLeft).FirstOrDefault();
            }
            catch
            {
                return 0;
            }
        }

          public IEnumerable<WoWAura> GetAuras
          {
              get
              {
                  var auraCount = Memory.Read<int>(BaseAddress + (uint)Pointers.UnitAuras.AuraCount1);
                  if (auraCount == -1)
                  {
                      auraCount = Memory.Read<int>(BaseAddress + (uint)Pointers.UnitAuras.AuraCount2);
                  }
                  var result = new List<WoWAura>();
                  long frequency;
                  long perfCount;
                  QueryPerformanceFrequency(out frequency);
                  QueryPerformanceCounter(out perfCount);
                  long currentTime = (perfCount * 1000) / frequency;
                  //Current time in ms
                  for (uint i = 0; i < auraCount; i++)
                  {
                      int localSpellId;
                      byte stackCount;
                      uint timeLeft;
                      ulong ownerGuid;
                      if (Memory.Read<int>(BaseAddress + (uint)Pointers.UnitAuras.AuraCount1) == -1)
                      {
                          var auraTable = Memory.Read<uint>(BaseAddress + (uint)Pointers.UnitAuras.AuraTable2);
                          localSpellId = Memory.Read<int>(auraTable + (uint)Pointers.UnitAuras.AuraSize * i + (int)Pointers.UnitAuras.AuraSpellId);
                          stackCount = Memory.Read<byte>((auraTable + ((uint)Pointers.UnitAuras.AuraSize * i)) + (uint)Pointers.UnitAuras.AuraStack);
                          timeLeft = Memory.Read<uint>((auraTable + ((uint)Pointers.UnitAuras.AuraSize * i)) + (uint)Pointers.UnitAuras.TimeLeft);
                          ownerGuid = Memory.Read<ulong>(auraTable + (uint)Pointers.UnitAuras.AuraSize * i );
                      }
                      else
                      {
                          localSpellId = Memory.Read<int>(BaseAddress + (uint)Pointers.UnitAuras.AuraTable1 + (uint)Pointers.UnitAuras.AuraSize * i + (int)Pointers.UnitAuras.AuraSpellId);
                          stackCount = Memory.Read<byte>((BaseAddress + (uint)Pointers.UnitAuras.AuraTable1 + ((uint)Pointers.UnitAuras.AuraSize * i)) + (uint)Pointers.UnitAuras.AuraStack);
                          timeLeft = Memory.Read<uint>((BaseAddress + (uint)Pointers.UnitAuras.AuraTable1 + ((uint)Pointers.UnitAuras.AuraSize * i)) + (uint)Pointers.UnitAuras.TimeLeft);
                          ownerGuid = Memory.Read<ulong>((BaseAddress + (uint)Pointers.UnitAuras.AuraTable1 + ((uint)Pointers.UnitAuras.AuraSize * i )));
                      }
                      if (localSpellId != 0)
                      {
                          timeLeft = (uint)(timeLeft - currentTime) / 1000;
                          var aura = new WoWAura { SpellId = localSpellId, Stack = stackCount, SecondsLeft = timeLeft, OwnerGUID = ownerGuid };
                          result.Add(aura);
                      }
                  }
                  return result;
              }
          }

        /// <summary>
        ///   Returns ArrayList with SpellID's of Auras on the unit
        /// </summary>
        public List<int> GetBuffs()
        {
            return GetAuras.Select(woWAura => woWAura.SpellId).ToList();
        }

        /// <summary>
        /// Returns Number of stacks SpellID has
        /// </summary>
        /// <param name="spellId"></param>
        /// <returns></returns>
        public int BuffStacks(int spellId)
        {
            try
            {
                return (from woWAura in GetAuras where woWAura.SpellId == spellId select woWAura.Stack).FirstOrDefault();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        ///   Target a friend unit with TargetFriend
        /// </summary>
        /// <returns>true if sucess</returns>
        public bool TargetFriend()
        {
            if (ObjectManager.MyPlayer.TargetGUID.Equals(GUID))
                return true;
            // Logging.Write("[Unit]TargetingF: " + Name);
            if (IsDead)
                return TargetDead();
            Face();
            var timer = new Ticker(600);
            Thread.Sleep(500);
            while (!ObjectManager.MyPlayer.TargetGUID.Equals(GUID) && !timer.IsReady)
            {
                KeyHelper.SendKey("TargetFriend");
                Thread.Sleep(1000);
            }
            if (ObjectManager.MyPlayer.TargetGUID.Equals(GUID))
            {
                Face();
                return true;
            }
            // Logging.Write("[Unit]Could not targetF: " + Name);
            return false;
        }

        /// <summary>
        ///   Interacts with the unit.
        /// </summary>
        public void InteractWithTarget()
        {
            KeyHelper.SendKey("InteractTarget");
        }

        public void Interact()
        {
            InteractWithTarget();
        }

        /// <summary>
        ///   Target a hostile unit with TargetHostile
        /// </summary>
        /// <returns>true if sucess</returns>
        public bool TargetHostile()
        {
            if (ObjectManager.MyPlayer.TargetGUID.Equals(GUID))
                return true;
            Logging.Write("[Unit]TargetingH: " + Name);
            if (IsDead)
                return TargetDead();
            if (LazySettings.BackgroundMode)
            {
                return HostileBackgroundTargetting();
            }
            return HostileTabTargetting();
        }

        private bool HostileBackgroundTargetting()
        {
            var t = new Ticker(4 * 1000);
            while (!t.IsReady)
            {
                if (ObjectManager.MyPlayer.TargetGUID.Equals(GUID))
                {
                    return true;
                }
                if (!Location.IsFacing())
                {
                    Location.Face();
                }
                Memory.Write(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, GUID);
                Thread.Sleep(50);
                KeyHelper.SendKey("InteractWithMouseOver");
                Thread.Sleep(500);
            }
            return false;
        }

        /// <summary>
        /// Returns True if targettind succeed, else False.
        /// </summary>
        private bool HostileTabTargetting()
        {
            var t = new Ticker(4 * 1000);
            while (!t.IsReady)
            {
                if (ObjectManager.MyPlayer.TargetGUID.Equals(GUID))
                {
                    return true;
                }
                if (!Location.IsFacing())
                {
                    Location.Face();
                }
                KeyHelper.SendKey("TargetEnemy");
                Thread.Sleep(700);

            }
            return false;
        }

        private bool TargetDead()
        {
            return Interact(false);
        }

        /// <summary>
        ///   Faces the unit.
        /// </summary>
        public void Face()
        {
            if (!Location.IsFacing())
            {
                Location.Face();
            }
        }

        public bool IsSpiritHealer
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_SPIRITHEALER) != 0);
            }
        }

        public bool IsInnkeeper
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_INNKEEPER) != 0);
            }
        }

        public bool IsFlightmaster
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_FLIGHTMASTER) != 0);
            }
        }

        public bool IsTrainerMyClass
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_TRAINER_CLASS) != 0);
            }
        }

        public bool CanRepair
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_REPAIR) != 0);
            }
        }

        public bool IsVendorReagent
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_VENDOR_REAGENT) != 0);
            }
        }

        public bool IsVendorFood
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_VENDOR_FOOD) != 0);
            }
        }

        public bool IsVendor
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_VENDOR) != 0);
            }
        }

        public bool IsBanker
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_BANKER) != 0);
            }
        }

        public bool IsAuctioneer
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_AUCTIONEER) != 0);
            }
        }

        /// <summary> 
        ///   Gets a value indicating whether The unit is IsTrainerMyProfession
        /// </summary>
        /// 
        public bool IsTrainerMyProfession
        {
            get
            {
                return ((base.GetStorageField<uint>((uint)Descriptors.CGUnitData.NpcFlags) & (uint)UnitNPCFlags.UNIT_NPC_FLAG_TRAINER_PROFESSION) != 0);
            }
        }

        public struct WoWAura
        {
            public int SpellId;
            public short Stack;
            public uint SecondsLeft;
            public ulong OwnerGUID;
        }

        internal enum UnitNPCFlags2 : uint
        {
            UNIT_FLAG_CONFUSED = 0x400000,
            UNIT_FLAG_DISABLE_MOVE = 4,
            UNIT_FLAG_DISARMED = 0x200000,
            UNIT_FLAG_FLEEING = 0x800000,
            UNIT_FLAG_IMMUNE_TO_NPC = 0x200,
            UNIT_FLAG_IMMUNE_TO_PC = 0x100,
            UNIT_FLAG_IN_COMBAT = 0x80000,
            UNIT_FLAG_LOOTING = 0x400,
            UNIT_FLAG_MOUNT = 0x8000000,
            UNIT_FLAG_NON_ATTACKABLE = 2,
            UNIT_FLAG_NOT_ATTACKABLE_1 = 0x80,
            UNIT_FLAG_NOT_SELECTABLE = 0x2000000,
            UNIT_FLAG_PACIFIED = 0x20000,
            UNIT_FLAG_PET_IN_COMBAT = 0x800,
            UNIT_FLAG_PLAYER_CONTROLLED = 0x1000000,
            UNIT_FLAG_PREPARATION = 0x20,
            UNIT_FLAG_PVP = 0x1000,
            UNIT_FLAG_PVP_ATTACKABLE = 8,
            UNIT_FLAG_RENAME = 0x10,
            UNIT_FLAG_SERVER_CONTROLLED = 1,
            UNIT_FLAG_SHEATHE = 0x40000000,
            UNIT_FLAG_SILENCED = 0x2000,
            UNIT_FLAG_SKINNABLE = 0x4000000,
            UNIT_FLAG_STUNNED = 0x40000,
            UNIT_FLAG_TAXI_FLIGHT = 0x100000,
            UNIT_FLAG_UNK_14 = 0x4000,
            UNIT_FLAG_UNK_15 = 0x8000,
            UNIT_FLAG_UNK_16 = 0x10000,
            UNIT_FLAG_UNK_28 = 0x10000000,
            UNIT_FLAG_UNK_29 = 0x20000000,
            UNIT_FLAG_UNK_31 = 0x80000000,
            UNIT_FLAG_UNK_6 = 0x40
        }

        internal enum UnitNPCFlags
        {
            UNIT_NPC_FLAG_AUCTIONEER = 0x200000,
            UNIT_NPC_FLAG_BANKER = 0x20000,
            UNIT_NPC_FLAG_BATTLEMASTER = 0x100000,
            UNIT_NPC_FLAG_FLIGHTMASTER = 0x2000,
            UNIT_NPC_FLAG_GOSSIP = 1,
            UNIT_NPC_FLAG_INNKEEPER = 0x10000,
            UNIT_NPC_FLAG_NONE = 0,
            UNIT_NPC_FLAG_PETITIONER = 0x40000,
            UNIT_NPC_FLAG_QUESTGIVER = 2,
            UNIT_NPC_FLAG_REPAIR = 0x1000,
            UNIT_NPC_FLAG_SPIRITGUIDE = 0x8000,
            UNIT_NPC_FLAG_SPIRITHEALER = 0x4000,
            UNIT_NPC_FLAG_STABLEMASTER = 0x400000,
            UNIT_NPC_FLAG_TABARDDESIGNER = 0x80000,
            UNIT_NPC_FLAG_TRAINER = 0x10,
            UNIT_NPC_FLAG_TRAINER_CLASS = 0x20,
            UNIT_NPC_FLAG_TRAINER_PROFESSION = 0x40,
            UNIT_NPC_FLAG_UNK1 = 4,
            UNIT_NPC_FLAG_UNK2 = 8,
            UNIT_NPC_FLAG_VENDOR = 0x80,
            UNIT_NPC_FLAG_VENDOR_AMMO = 0x100,
            UNIT_NPC_FLAG_VENDOR_FOOD = 0x200,
            UNIT_NPC_FLAG_VENDOR_POISON = 0x400,
            UNIT_NPC_FLAG_VENDOR_REAGENT = 0x800
        }
    }
}