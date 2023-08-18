﻿
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
namespace LazyLib.Wow
{
    public static class Descriptors
    {
        public enum CGObjectData
        {
            Guid = 0, // size 2, flags MIRROR_ALL
            Data = 2, // size 2, flags MIRROR_ALL
            Type = 4, // size 1, flags MIRROR_ALL
            EntryID = 5, // size 1, flags MIRROR_VIEWER_DEPENDENT
            DynamicFlags = 6, // size 1, flags MIRROR_VIEWER_DEPENDENT, MIRROR_URGENT
            Scale = 7, // size 1, flags MIRROR_ALL
            End = 8
        }

        public enum CGItemData
        {
            Owner = CGObjectData.End + 0, // size 2, flags MIRROR_ALL
            ContainedIn = CGObjectData.End + 2, // size 2, flags MIRROR_ALL
            Creator = CGObjectData.End + 4, // size 2, flags MIRROR_ALL
            GiftCreator = CGObjectData.End + 6, // size 2, flags MIRROR_ALL
            StackCount = CGObjectData.End + 8, // size 1, flags MIRROR_OWNER
            Expiration = CGObjectData.End + 9, // size 1, flags MIRROR_OWNER
            SpellCharges = CGObjectData.End + 10, // size 5, flags MIRROR_OWNER
            DynamicFlags = CGObjectData.End + 15, // size 1, flags MIRROR_ALL
            Enchantment = CGObjectData.End + 16, // size 39, flags MIRROR_ALL
            PropertySeed = CGObjectData.End + 55, // size 1, flags MIRROR_ALL
            RandomPropertiesID = CGObjectData.End + 56, // size 1, flags MIRROR_ALL
            Durability = CGObjectData.End + 57, // size 1, flags MIRROR_OWNER
            MaxDurability = CGObjectData.End + 58, // size 1, flags MIRROR_OWNER
            CreatePlayedTime = CGObjectData.End + 59, // size 1, flags MIRROR_ALL
            ModifiersMask = CGObjectData.End + 60, // size 1, flags MIRROR_OWNER
            End = CGObjectData.End + 61
        }

        public enum CGContainerData
        {
            Slots = CGItemData.End + 0, // size 72, flags MIRROR_ALL
            NumSlots = CGItemData.End + 72, // size 1, flags MIRROR_ALL
            End = CGItemData.End + 73
        }

        public enum CGUnitData
        {
            Charm = CGObjectData.End + 0, // size 2, flags MIRROR_ALL
            Summon = CGObjectData.End + 2, // size 2, flags MIRROR_ALL
            Critter = CGObjectData.End + 4, // size 2, flags MIRROR_SELF
            CharmedBy = CGObjectData.End + 6, // size 2, flags MIRROR_ALL
            SummonedBy = CGObjectData.End + 8, // size 2, flags MIRROR_ALL
            CreatedBy = CGObjectData.End + 10, // size 2, flags MIRROR_ALL
            DemonCreator = CGObjectData.End + 12, // size 2, flags MIRROR_ALL
            Target = CGObjectData.End + 14, // size 2, flags MIRROR_ALL
            BattlePetCompanionGUID = CGObjectData.End + 16, // size 2, flags MIRROR_ALL
            ChannelObject = CGObjectData.End + 18, // size 2, flags MIRROR_ALL, MIRROR_URGENT
            ChannelSpell = CGObjectData.End + 20, // size 1, flags MIRROR_ALL, MIRROR_URGENT
            SummonedByHomeRealm = CGObjectData.End + 21, // size 1, flags MIRROR_ALL
            Sex = CGObjectData.End + 22, // size 1, flags MIRROR_ALL
            DisplayPower = CGObjectData.End + 23, // size 1, flags MIRROR_ALL
            OverrideDisplayPowerID = CGObjectData.End + 24, // size 1, flags MIRROR_ALL
            Health = CGObjectData.End + 25, // size 1, flags MIRROR_ALL
            Power = CGObjectData.End + 26, // size 5, flags MIRROR_ALL
            MaxHealth = CGObjectData.End + 31, // size 1, flags MIRROR_ALL
            MaxPower = CGObjectData.End + 32, // size 5, flags MIRROR_ALL
            PowerRegenFlatModifier = CGObjectData.End + 37, // size 5, flags MIRROR_SELF, MIRROR_OWNER, MIRROR_UNIT_ALL
            PowerRegenInterruptedFlatModifier = CGObjectData.End + 42, // size 5, flags MIRROR_SELF, MIRROR_OWNER, MIRROR_UNIT_ALL
            Level = CGObjectData.End + 47, // size 1, flags MIRROR_ALL
            EffectiveLevel = CGObjectData.End + 48, // size 1, flags MIRROR_ALL
            FactionTemplate = CGObjectData.End + 49, // size 1, flags MIRROR_ALL
            VirtualItemID = CGObjectData.End + 50, // size 3, flags MIRROR_ALL
            Flags = CGObjectData.End + 53, // size 1, flags MIRROR_ALL
            Flags2 = CGObjectData.End + 54, // size 1, flags MIRROR_ALL
            AuraState = CGObjectData.End + 55, // size 1, flags MIRROR_ALL
            AttackRoundBaseTime = CGObjectData.End + 56, // size 2, flags MIRROR_ALL
            RangedAttackRoundBaseTime = CGObjectData.End + 58, // size 1, flags MIRROR_SELF
            BoundingRadius = CGObjectData.End + 59, // size 1, flags MIRROR_ALL
            CombatReach = CGObjectData.End + 60, // size 1, flags MIRROR_ALL
            DisplayID = CGObjectData.End + 61, // size 1, flags MIRROR_VIEWER_DEPENDENT, MIRROR_URGENT
            NativeDisplayID = CGObjectData.End + 62, // size 1, flags MIRROR_ALL, MIRROR_URGENT
            MountDisplayID = CGObjectData.End + 63, // size 1, flags MIRROR_ALL, MIRROR_URGENT
            MinDamage = CGObjectData.End + 64, // size 1, flags MIRROR_SELF, MIRROR_OWNER, MIRROR_EMPATH
            MaxDamage = CGObjectData.End + 65, // size 1, flags MIRROR_SELF, MIRROR_OWNER, MIRROR_EMPATH
            MinOffHandDamage = CGObjectData.End + 66, // size 1, flags MIRROR_SELF, MIRROR_OWNER, MIRROR_EMPATH
            MaxOffHandDamage = CGObjectData.End + 67, // size 1, flags MIRROR_SELF, MIRROR_OWNER, MIRROR_EMPATH
            AnimTier = CGObjectData.End + 68, // size 1, flags MIRROR_ALL
            PetNumber = CGObjectData.End + 69, // size 1, flags MIRROR_ALL
            PetNameTimestamp = CGObjectData.End + 70, // size 1, flags MIRROR_ALL
            PetExperience = CGObjectData.End + 71, // size 1, flags MIRROR_OWNER
            PetNextLevelExperience = CGObjectData.End + 72, // size 1, flags MIRROR_OWNER
            ModCastingSpeed = CGObjectData.End + 73, // size 1, flags MIRROR_ALL
            ModSpellHaste = CGObjectData.End + 74, // size 1, flags MIRROR_ALL
            ModHaste = CGObjectData.End + 75, // size 1, flags MIRROR_ALL
            ModRangedHaste = CGObjectData.End + 76, // size 1, flags MIRROR_ALL
            ModHasteRegen = CGObjectData.End + 77, // size 1, flags MIRROR_ALL
            CreatedBySpell = CGObjectData.End + 78, // size 1, flags MIRROR_ALL
            NpcFlags = CGObjectData.End + 80, // size 2, flags MIRROR_ALL
            EmoteState = CGObjectData.End + 81, // size 1, flags MIRROR_ALL
            Stats = CGObjectData.End + 82, // size 5, flags MIRROR_SELF, MIRROR_OWNER
            StatPosBuff = CGObjectData.End + 87, // size 5, flags MIRROR_SELF, MIRROR_OWNER
            StatNegBuff = CGObjectData.End + 92, // size 5, flags MIRROR_SELF, MIRROR_OWNER
            Resistances = CGObjectData.End + 97, // size 7, flags MIRROR_SELF, MIRROR_OWNER, MIRROR_EMPATH
            ResistanceBuffModsPositive = CGObjectData.End + 104, // size 7, flags MIRROR_SELF, MIRROR_OWNER
            ResistanceBuffModsNegative = CGObjectData.End + 111, // size 7, flags MIRROR_SELF, MIRROR_OWNER
            BaseMana = CGObjectData.End + 118, // size 1, flags MIRROR_ALL
            BaseHealth = CGObjectData.End + 119, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            ShapeshiftForm = CGObjectData.End + 120, // size 1, flags MIRROR_ALL
            AttackPower = CGObjectData.End + 121, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            AttackPowerModPos = CGObjectData.End + 122, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            AttackPowerModNeg = CGObjectData.End + 123, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            AttackPowerMultiplier = CGObjectData.End + 124, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            RangedAttackPower = CGObjectData.End + 125, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            RangedAttackPowerModPos = CGObjectData.End + 126, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            RangedAttackPowerModNeg = CGObjectData.End + 127, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            RangedAttackPowerMultiplier = CGObjectData.End + 128, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            MinRangedDamage = CGObjectData.End + 129, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            MaxRangedDamage = CGObjectData.End + 130, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            PowerCostModifier = CGObjectData.End + 131, // size 7, flags MIRROR_SELF, MIRROR_OWNER
            PowerCostMultiplier = CGObjectData.End + 138, // size 7, flags MIRROR_SELF, MIRROR_OWNER
            MaxHealthModifier = CGObjectData.End + 145, // size 1, flags MIRROR_SELF, MIRROR_OWNER
            HoverHeight = CGObjectData.End + 146, // size 1, flags MIRROR_ALL
            MinItemLevel = CGObjectData.End + 147, // size 1, flags MIRROR_ALL
            MaxItemLevel = CGObjectData.End + 148, // size 1, flags MIRROR_ALL
            WildBattlePetLevel = CGObjectData.End + 149, // size 1, flags MIRROR_ALL
            BattlePetCompanionNameTimestamp = CGObjectData.End + 150, // size 1, flags MIRROR_ALL
            InteractSpellID = CGObjectData.End + 151, // size 1, flags MIRROR_ALL
            End = CGObjectData.End + 152
        }

        public enum CGPlayerData
        {
            DuelArbiter = CGUnitData.End + 0, // size 2, flags MIRROR_ALL
            PlayerFlags = CGUnitData.End + 2, // size 1, flags MIRROR_ALL
            GuildRankID = CGUnitData.End + 3, // size 1, flags MIRROR_ALL
            GuildDeleteDate = CGUnitData.End + 4, // size 1, flags MIRROR_ALL
            GuildLevel = CGUnitData.End + 5, // size 1, flags MIRROR_ALL
            HairColorID = CGUnitData.End + 6, // size 1, flags MIRROR_ALL
            RestState = CGUnitData.End + 7, // size 1, flags MIRROR_ALL
            ArenaFaction = CGUnitData.End + 8, // size 1, flags MIRROR_ALL
            DuelTeam = CGUnitData.End + 9, // size 1, flags MIRROR_ALL
            GuildTimeStamp = CGUnitData.End + 10, // size 1, flags MIRROR_ALL
            QuestLog = CGUnitData.End + 11, // size 750, flags MIRROR_PARTY
            VisibleItems = CGUnitData.End + 761, // size 38, flags MIRROR_ALL
            PlayerTitle = CGUnitData.End + 799, // size 1, flags MIRROR_ALL
            FakeInebriation = CGUnitData.End + 800, // size 1, flags MIRROR_ALL
            VirtualPlayerRealm = CGUnitData.End + 801, // size 1, flags MIRROR_ALL
            CurrentSpecID = CGUnitData.End + 802, // size 1, flags MIRROR_ALL
            TaxiMountAnimKitID = CGUnitData.End + 803, // size 1, flags MIRROR_ALL
            CurrentBattlePetBreedQuality = CGUnitData.End + 804, // size 1, flags MIRROR_ALL
            InvSlots = CGUnitData.End + 805, // size 172, flags MIRROR_SELF
            FarsightObject = CGUnitData.End + 977, // size 2, flags MIRROR_SELF
            KnownTitles = CGUnitData.End + 979, // size 10, flags MIRROR_SELF
            Coinage = CGUnitData.End + 989, // size 2, flags MIRROR_SELF
            XP = CGUnitData.End + 991, // size 1, flags MIRROR_SELF
            NextLevelXP = CGUnitData.End + 992, // size 1, flags MIRROR_SELF
            Skill = CGUnitData.End + 993, // size 448, flags MIRROR_SELF
            CharacterPoints = CGUnitData.End + 1441, // size 1, flags MIRROR_SELF
            MaxTalentTiers = CGUnitData.End + 1442, // size 1, flags MIRROR_SELF
            TrackCreatureMask = CGUnitData.End + 1443, // size 1, flags MIRROR_SELF
            TrackResourceMask = CGUnitData.End + 1444, // size 1, flags MIRROR_SELF
            MainhandExpertise = CGUnitData.End + 1445, // size 1, flags MIRROR_SELF
            OffhandExpertise = CGUnitData.End + 1446, // size 1, flags MIRROR_SELF
            RangedExpertise = CGUnitData.End + 1447, // size 1, flags MIRROR_SELF
            CombatRatingExpertise = CGUnitData.End + 1448, // size 1, flags MIRROR_SELF
            BlockPercentage = CGUnitData.End + 1449, // size 1, flags MIRROR_SELF
            DodgePercentage = CGUnitData.End + 1450, // size 1, flags MIRROR_SELF
            ParryPercentage = CGUnitData.End + 1451, // size 1, flags MIRROR_SELF
            CritPercentage = CGUnitData.End + 1452, // size 1, flags MIRROR_SELF
            RangedCritPercentage = CGUnitData.End + 1453, // size 1, flags MIRROR_SELF
            OffhandCritPercentage = CGUnitData.End + 1454, // size 1, flags MIRROR_SELF
            SpellCritPercentage = CGUnitData.End + 1455, // size 7, flags MIRROR_SELF
            ShieldBlock = CGUnitData.End + 1462, // size 1, flags MIRROR_SELF
            ShieldBlockCritPercentage = CGUnitData.End + 1463, // size 1, flags MIRROR_SELF
            Mastery = CGUnitData.End + 1464, // size 1, flags MIRROR_SELF
            PvpPowerDamage = CGUnitData.End + 1465, // size 1, flags MIRROR_SELF
            PvpPowerHealing = CGUnitData.End + 1466, // size 1, flags MIRROR_SELF
            ExploredZones = CGUnitData.End + 1467, // size 200, flags MIRROR_SELF
            RestStateBonusPool = CGUnitData.End + 1667, // size 1, flags MIRROR_SELF
            ModDamageDonePos = CGUnitData.End + 1668, // size 7, flags MIRROR_SELF
            ModDamageDoneNeg = CGUnitData.End + 1675, // size 7, flags MIRROR_SELF
            ModDamageDonePercent = CGUnitData.End + 1682, // size 7, flags MIRROR_SELF
            ModHealingDonePos = CGUnitData.End + 1689, // size 1, flags MIRROR_SELF
            ModHealingPercent = CGUnitData.End + 1690, // size 1, flags MIRROR_SELF
            ModHealingDonePercent = CGUnitData.End + 1691, // size 1, flags MIRROR_SELF
            ModPeriodicHealingDonePercent = CGUnitData.End + 1692, // size 1, flags MIRROR_SELF
            WeaponDmgMultipliers = CGUnitData.End + 1693, // size 3, flags MIRROR_SELF
            ModSpellPowerPercent = CGUnitData.End + 1696, // size 1, flags MIRROR_SELF
            ModResiliencePercent = CGUnitData.End + 1697, // size 1, flags MIRROR_SELF
            OverrideSpellPowerByAPPercent = CGUnitData.End + 1698, // size 1, flags MIRROR_SELF
            OverrideAPBySpellPowerPercent = CGUnitData.End + 1699, // size 1, flags MIRROR_SELF
            ModTargetResistance = CGUnitData.End + 1700, // size 1, flags MIRROR_SELF
            ModTargetPhysicalResistance = CGUnitData.End + 1701, // size 1, flags MIRROR_SELF
            LifetimeMaxRank = CGUnitData.End + 1702, // size 1, flags MIRROR_SELF
            SelfResSpell = CGUnitData.End + 1703, // size 1, flags MIRROR_SELF
            PvpMedals = CGUnitData.End + 1704, // size 1, flags MIRROR_SELF
            BuybackPrice = CGUnitData.End + 1705, // size 12, flags MIRROR_SELF
            BuybackTimestamp = CGUnitData.End + 1717, // size 12, flags MIRROR_SELF
            YesterdayHonorableKills = CGUnitData.End + 1729, // size 1, flags MIRROR_SELF
            LifetimeHonorableKills = CGUnitData.End + 1730, // size 1, flags MIRROR_SELF
            WatchedFactionIndex = CGUnitData.End + 1731, // size 1, flags MIRROR_SELF
            CombatRatings = CGUnitData.End + 1732, // size 27, flags MIRROR_SELF
            PvpInfo = CGUnitData.End + 1759, // size 24, flags MIRROR_SELF
            MaxLevel = CGUnitData.End + 1783, // size 1, flags MIRROR_SELF
            RuneRegen = CGUnitData.End + 1784, // size 4, flags MIRROR_SELF
            NoReagentCostMask = CGUnitData.End + 1788, // size 4, flags MIRROR_SELF
            GlyphSlots = CGUnitData.End + 1792, // size 6, flags MIRROR_SELF
            Glyphs = CGUnitData.End + 1798, // size 6, flags MIRROR_SELF
            GlyphSlotsEnabled = CGUnitData.End + 1804, // size 1, flags MIRROR_SELF
            PetSpellPower = CGUnitData.End + 1805, // size 1, flags MIRROR_SELF
            Researching = CGUnitData.End + 1806, // size 8, flags MIRROR_SELF
            ProfessionSkillLine = CGUnitData.End + 1814, // size 2, flags MIRROR_SELF
            UiHitModifier = CGUnitData.End + 1816, // size 1, flags MIRROR_SELF
            UiSpellHitModifier = CGUnitData.End + 1817, // size 1, flags MIRROR_SELF
            HomeRealmTimeOffset = CGUnitData.End + 1818, // size 1, flags MIRROR_SELF
            ModPetHaste = CGUnitData.End + 1819, // size 1, flags MIRROR_SELF
            SummonedBattlePetGUID = CGUnitData.End + 1820, // size 2, flags MIRROR_SELF
            OverrideSpellsID = CGUnitData.End + 1822, // size 1, flags MIRROR_SELF, MIRROR_URGENT_SELF_ONLY
            LfgBonusFactionID = CGUnitData.End + 1823, // size 1, flags MIRROR_SELF
            LootSpecID = CGUnitData.End + 1824, // size 1, flags MIRROR_SELF
            OverrideZonePVPType = CGUnitData.End + 1825, // size 1, flags MIRROR_SELF, MIRROR_URGENT_SELF_ONLY
            ItemLevelDelta = CGUnitData.End + 1826, // size 1, flags MIRROR_SELF
            End = CGUnitData.End + 1827
        }

        public enum CGGameObjectData
        {
            CreatedBy = CGObjectData.End + 0, // size 2, flags MIRROR_ALL
            DisplayID = CGObjectData.End + 2, // size 1, flags MIRROR_ALL
            Flags = CGObjectData.End + 3, // size 1, flags MIRROR_ALL, MIRROR_URGENT
            ParentRotation = CGObjectData.End + 4, // size 4, flags MIRROR_ALL
            FactionTemplate = CGObjectData.End + 8, // size 1, flags MIRROR_ALL
            Level = CGObjectData.End + 9, // size 1, flags MIRROR_ALL
            PercentHealth = CGObjectData.End + 10, // size 1, flags MIRROR_ALL, MIRROR_URGENT
            StateSpellVisualID = CGObjectData.End + 11, // size 1, flags MIRROR_ALL, MIRROR_URGENT
            End = CGObjectData.End + 12
        }

        public enum CGDynamicObjectData
        {
            Caster = CGObjectData.End + 0, // size 2, flags MIRROR_ALL
            TypeAndVisualID = CGObjectData.End + 2, // size 1, flags MIRROR_VIEWER_DEPENDENT
            SpellID = CGObjectData.End + 3, // size 1, flags MIRROR_ALL
            Radius = CGObjectData.End + 4, // size 1, flags MIRROR_ALL
            CastTime = CGObjectData.End + 5, // size 1, flags MIRROR_ALL
            End = CGObjectData.End + 6
        }

        public enum CGCorpseData
        {
            Owner = CGObjectData.End + 0, // size 2, flags MIRROR_ALL
            PartyGUID = CGObjectData.End + 2, // size 2, flags MIRROR_ALL
            DisplayID = CGObjectData.End + 4, // size 1, flags MIRROR_ALL
            Items = CGObjectData.End + 5, // size 19, flags MIRROR_ALL
            SkinID = CGObjectData.End + 24, // size 1, flags MIRROR_ALL
            FacialHairStyleID = CGObjectData.End + 25, // size 1, flags MIRROR_ALL
            Flags = CGObjectData.End + 26, // size 1, flags MIRROR_ALL
            DynamicFlags = CGObjectData.End + 27, // size 1, flags MIRROR_VIEWER_DEPENDENT
            End = CGObjectData.End + 28
        }

        public enum CGAreaTriggerData
        {
            Caster = CGObjectData.End + 0, // size 2, flags MIRROR_ALL
            Duration = CGObjectData.End + 2, // size 1, flags MIRROR_ALL
            SpellID = CGObjectData.End + 3, // size 1, flags MIRROR_ALL
            SpellVisualID = CGObjectData.End + 4, // size 1, flags MIRROR_VIEWER_DEPENDENT
            ExplicitScale = CGObjectData.End + 5, // size 1, flags MIRROR_ALL, MIRROR_URGENT
            End = CGObjectData.End + 6
        }

        public enum CGSceneObjectData
        {
            ScriptPackageID = CGObjectData.End + 0, // size 1, flags MIRROR_ALL
            RndSeedVal = CGObjectData.End + 1, // size 1, flags MIRROR_ALL
            CreatedBy = CGObjectData.End + 2, // size 2, flags MIRROR_ALL
            SceneType = CGObjectData.End + 4, // size 1, flags MIRROR_ALL
            End = CGObjectData.End + 5
        }
    }
}