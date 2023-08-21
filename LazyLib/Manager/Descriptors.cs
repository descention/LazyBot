
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
namespace LazyLib.Wow
{
    public static class Descriptors
    {
        public const uint Multiplicator = 4;
        public static readonly uint StartDescriptors = 4;

        public enum CGObjectData
        {
            Data = 4,
            DynamicFlags = 10,
            EntryID = 9,
            Guid = 0,
            Scale = 11,
            Type = 8
        }

        public enum CGItemData
        {
            ContainedIn = 0x10,
            Context = 0x51,
            CreatePlayedTime = 0x4f,
            Creator = 20,
            Durability = 0x4d,
            DynamicFlags = 0x23,
            Enchantment = 0x24,
            Expiration = 0x1d,
            GiftCreator = 0x18,
            MaxDurability = 0x4e,
            ModifiersMask = 80,
            Owner = 12,
            PropertySeed = 0x4b,
            RandomPropertiesID = 0x4c,
            SpellCharges = 30,
            StackCount = 0x1c
        }

        public enum CGContainerData
        {
            NumSlots = 0xe2,
            Slots = 0x52
        }

        public enum CGUnitData
        {
            AnimTier = 0x6f,
            AttackPower = 0xa5,
            AttackPowerModNeg = 0xa7,
            AttackPowerModPos = 0xa6,
            AttackPowerMultiplier = 0xa8,
            AttackRoundBaseTime = 0x63,
            AuraState = 0x62,
            BaseHealth = 0xa3,
            BaseMana = 0xa2,
            BattlePetCompanionGUID = 0x2c,
            BattlePetCompanionNameTimestamp = 0xc3,
            BattlePetDBID = 0x30,
            BoundingRadius = 0x66,
            ChannelObject = 50,
            ChannelSpell = 0x36,
            ChannelSpellXSpellVisual = 0x37,
            Charm = 12,
            CharmedBy = 0x18,
            CombatReach = 0x67,
            CreatedBy = 0x20,
            CreatedBySpell = 0x79,
            Critter = 20,
            DemonCreator = 0x24,
            DisplayID = 0x68,
            DisplayPower = 0x3a,
            EffectiveLevel = 0x57,
            EmoteState = 0x7c,
            FactionTemplate = 0x58,
            Flags = 0x5f,
            Flags2 = 0x60,
            Flags3 = 0x61,
            Health = 60,
            HoverHeight = 190,
            InteractSpellID = 0xc4,
            Level = 0x56,
            LookAtControllerID = 0xcf,
            LookAtControllerTarget = 0xd0,
            LooksLikeCreatureID = 0xce,
            LooksLikeMountID = 0xcd,
            MaxDamage = 0x6c,
            MaxHealth = 0x43,
            MaxHealthModifier = 0xbd,
            MaxItemLevel = 0xc1,
            MaxOffHandDamage = 110,
            MaxPower = 0x44,
            MaxRangedDamage = 0xae,
            MinDamage = 0x6b,
            MinItemLevel = 0xc0,
            MinItemLevelCutoff = 0xbf,
            MinOffHandDamage = 0x6d,
            MinRangedDamage = 0xad,
            ModBonusArmor = 0xa1,
            ModCastingSpeed = 0x74,
            ModHaste = 0x76,
            ModHasteRegen = 120,
            ModRangedHaste = 0x77,
            ModSpellHaste = 0x75,
            MountDisplayID = 0x6a,
            NativeDisplayID = 0x69,
            NpcFlags = 0x7a,
            OverrideDisplayPowerID = 0x3b,
            PetExperience = 0x72,
            PetNameTimestamp = 0x71,
            PetNextLevelExperience = 0x73,
            PetNumber = 0x70,
            Power = 0x3d,
            PowerCostModifier = 0xaf,
            PowerCostMultiplier = 0xb6,
            PowerRegenFlatModifier = 0x4a,
            PowerRegenInterruptedFlatModifier = 80,
            RangedAttackPower = 0xa9,
            RangedAttackPowerModNeg = 0xab,
            RangedAttackPowerModPos = 170,
            RangedAttackPowerMultiplier = 0xac,
            RangedAttackRoundBaseTime = 0x65,
            ResistanceBuffModsNegative = 0x9a,
            ResistanceBuffModsPositive = 0x93,
            Resistances = 140,
            ScaleDuration = 0xcc,
            Sex = 0x39,
            ShapeshiftForm = 0xa4,
            StateAnimID = 0xc6,
            StateAnimKitID = 0xc7,
            StateSpellVisualID = 0xc5,
            StateWorldEffectID = 200,
            StatNegBuff = 0x87,
            StatPosBuff = 130,
            Stats = 0x7d,
            Summon = 0x10,
            SummonedBy = 0x1c,
            SummonedByHomeRealm = 0x38,
            Target = 40,
            VirtualItems = 0x59,
            WildBattlePetLevel = 0xc2
        }

        public enum CGPlayerData
        {
            Amplify = 0x8d4,
            ArenaFaction = 0xe7,
            AvgItemLevel = 0x403,
            Avoidance = 0x8da,
            BagSlotFlags = 0xa9a,
            BankBagSlotFlags = 0xa9e,
            BlockPercentage = 0x8c4,
            BuybackPrice = 0xa0b,
            BuybackTimestamp = 0xa17,
            CharacterPoints = 0x8bc,
            Cleave = 0x8dc,
            Coinage = 0x6f8,
            CombatRatingExpertise = 0x8c3,
            CombatRatings = 0xa26,
            CritPercentage = 0x8c7,
            CurrentBattlePetBreedQuality = 0x407,
            CurrentSpecID = 0x401,
            DodgePercentage = 0x8c5,
            DuelArbiter = 0xd4,
            DuelTeam = 0xe8,
            ExploredZones = 0x8e1,
            FakeInebriation = 0x3ff,
            FarsightObject = 0x6e8,
            Glyphs = 0xa79,
            GlyphSlots = 0xa73,
            GlyphSlotsEnabled = 0xa7f,
            GuildDeleteDate = 0xe3,
            GuildLevel = 0xe4,
            GuildRankID = 0xe2,
            GuildTimeStamp = 0xe9,
            HairColorID = 0xe5,
            HomeRealmTimeOffset = 0xa8f,
            InsertItemsLeftToRight = 0xaa5,
            InvSlots = 0x408,
            ItemLevelDelta = 0xa99,
            KnownTitles = 0x6ec,
            LfgBonusFactionID = 0xa96,
            Lifesteal = 0x8d9,
            LifetimeHonorableKills = 0xa24,
            LifetimeMaxRank = 0xa08,
            LocalFlags = 0xa07,
            LootSpecID = 0xa97,
            LootTargetGUID = 220,
            MainhandExpertise = 0x8c0,
            Mastery = 0x8d3,
            MaxLevel = 0xa6a,
            MaxTalentTiers = 0x8bd,
            ModDamageDoneNeg = 0x9e9,
            ModDamageDonePercent = 0x9f0,
            ModDamageDonePos = 0x9e2,
            ModHealingDonePercent = 0x9f9,
            ModHealingDonePos = 0x9f7,
            ModHealingPercent = 0x9f8,
            ModPeriodicHealingDonePercent = 0x9fa,
            ModPetHaste = 0xa90,
            ModResiliencePercent = 0xa02,
            ModSpellPowerPercent = 0xa01,
            ModTargetPhysicalResistance = 0xa06,
            ModTargetResistance = 0xa05,
            Multistrike = 0x8d5,
            MultistrikeEffect = 0x8d6,
            NextLevelXP = 0x6fb,
            NoReagentCostMask = 0xa6f,
            OffhandCritPercentage = 0x8c9,
            OffhandExpertise = 0x8c1,
            OverrideAPBySpellPowerPercent = 0xa04,
            OverrideSpellPowerByAPPercent = 0xa03,
            OverrideSpellsID = 0xa95,
            OverrideZonePVPType = 0xa98,
            ParryPercentage = 0x8c6,
            PetSpellPower = 0xa80,
            PlayerFlags = 0xe0,
            PlayerFlagsEx = 0xe1,
            PlayerTitle = 0x3fe,
            ProfessionSkillLine = 0xa8b,
            PvpInfo = 0xa46,
            PvpMedals = 0xa0a,
            PvpPowerDamage = 0x8df,
            PvpPowerHealing = 0x8e0,
            QuestCompleted = 0xaa6,
            QuestLog = 0xea,
            RangedCritPercentage = 0x8c8,
            RangedExpertise = 0x8c2,
            Readiness = 0x8d7,
            Researching = 0xa81,
            RestState = 230,
            RestStateBonusPool = 0x9e1,
            RuneRegen = 0xa6b,
            SelfResSpell = 0xa09,
            ShieldBlock = 0x8d1,
            ShieldBlockCritPercentage = 0x8d2,
            Skill = 0x6fc,
            Speed = 0x8d8,
            SpellCritPercentage = 0x8ca,
            Sturdiness = 0x8db,
            SummonedBattlePetGUID = 0xa91,
            TaxiMountAnimKitID = 0x402,
            TrackCreatureMask = 0x8be,
            TrackResourceMask = 0x8bf,
            UiHitModifier = 0xa8d,
            UiSpellHitModifier = 0xa8e,
            Versatility = 0x8dd,
            VersatilityBonus = 0x8de,
            VirtualPlayerRealm = 0x400,
            VisibleItems = 0x3d8,
            WatchedFactionIndex = 0xa25,
            WeaponAtkSpeedMultipliers = 0x9fe,
            WeaponDmgMultipliers = 0x9fb,
            WowAccount = 0xd8,
            XP = 0x6fa,
            YesterdayHonorableKills = 0xa23
        }

        public enum CGGameObjectData
        {
            CreatedBy = 12,
            DisplayID = 0x10,
            FactionTemplate = 0x16,
            Flags = 0x11,
            Level = 0x17,
            ParentRotation = 0x12,
            PercentHealth = 0x18,
            SpellVisualID = 0x19,
            StateAnimID = 0x1b,
            StateAnimKitID = 0x1c,
            StateSpellVisualID = 0x1a,
            StateWorldEffectID = 0x1d
        }

        public enum CGDynamicObjectData
        {
            Caster = 12,
            CastTime = 0x13,
            Radius = 0x12,
            SpellID = 0x11,
            TypeAndVisualID = 0x10
        }

        public enum CGCorpseData
        {
            DisplayID = 20,
            DynamicFlags = 0x2b,
            FacialHairStyleID = 0x29,
            FactionTemplate = 0x2c,
            Flags = 0x2a,
            Items = 0x15,
            Owner = 12,
            PartyGUID = 0x10,
            SkinID = 40
        }

        public enum CGAreaTriggerData
        {
            BoundsRadius2D = 0x1b,
            Caster = 0x13,
            Duration = 0x17,
            ExplicitScale = 0x1c,
            OverrideScaleCurve = 12,
            SpellID = 0x19,
            SpellVisualID = 0x1a,
            TimeToTargetScale = 0x18
        }

        public enum CGSceneObjectData
        {
            CreatedBy = 14,
            RndSeedVal = 13,
            SceneType = 0x12,
            ScriptPackageID = 12
        }

        public enum CGConversationData
        {
            Dummy = 12
        }
    }
}