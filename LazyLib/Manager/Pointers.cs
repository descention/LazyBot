
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

using System.Reflection;

#endregion

namespace LazyLib.Wow
{
    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class PublicPointers
    {
        #region Globals enum

        /// <summary>
        /// </summary>
        public enum Globals
        {
            PlayerName = 0xFEFA98,
        }

        #endregion

        #region InGame enum

        /// <summary>
        /// </summary>
        public enum InGame
        {
            InGame = 0xEAEACA,
        }

        #endregion
    }

    internal class Pointers
    {
        #region ActionBar enum

        /// <summary>
        /// </summary>
        public enum ActionBar
        {
            ActionBarFirstSlot = 0xF1EC80,
            ActionBarBonus = 0xF1EEC0,
        }

        #endregion

        #region AutoLoot enum

        /// <summary>
        /// </summary>
        public enum AutoLoot
        {
            Offset = 0x34,
            Pointer = 0xEAEC7C,
        }

        #endregion

        #region CgUnitCGetCreatureRank enum

        /// <summary>
        /// </summary>
        public enum CgUnitCGetCreatureRank
        {
            Offset1 = 0xC38,
            Offset2 = 0x2C,  
        }

        #endregion

        #region CgUnitCGetCreatureType enum

        /// <summary> 
        /// </summary>
        public enum CgUnitCGetCreatureType
        {
            Offset1 = 0xC38,
            Offset2 = 0x24,
        }

        #endregion

        #region CgWorldFrameGetActiveCamera enum

        /// <summary>
        /// </summary>
        public enum CgWorldFrameGetActiveCamera
        {
            CameraX = 0x8,
            CameraY = 0xC,
            CameraZ = 0x10,
            CameraMatrix = 0x14,
            CameraPointer = 0xEAF270,
            CameraOffset = 0x7610,  
        }

        #endregion

        #region ClickToMove enum

        /// <summary>
        /// </summary>
        public enum ClickToMove
        {
            Offset = 0x34,
            Pointer = 0xEAEC5C,
        }

        #endregion

        #region Nested type: AutoAttack

        /// <summary>
        /// </summary>
        internal enum AutoAttack
        {
            AutoAttackFlag = 0xEE8,       //Old Method
            AutoAttackMask = 0xEEC,       //Old Method
            AutoAttackGUID = 0xF44,  
        }

        #endregion

        #region Nested type: CastingInfo

        /// <summary>
        /// </summary>
        internal enum CastingInfo
        {
            IsCasting = 0xF98,
            ChanneledCasting = 0xFB8,  
        }

        #endregion

        #region Nested type: Chat

        /// <summary>
        ///  reversed From CGChat__RecordChat
        /// </summary>
        internal enum Chat : uint
        {
            ChatStart = 0xEB0B10,
            OffsetToNextMsg = 0x17E8,
            chatBufferPos = 0xF0AE8C,

            msgFormatedChat = 0x65,
            MsgSenderGuid = 0x00,
            MsgSenderName = 0x034,
            MsgFullMessage = 0x0065,
            MsgOnlyMessage = 0x0C1D,
            MsgChannelNum = 0x17D8,
            MsgTimeStamp = 0x17E4,
        }

        #endregion

        #region Nested type: Container

        /// <summary>
        /// </summary>
        internal enum Container
        {
            EquippedBagGUID = 0xF253F8
        }

        #endregion

        #region Nested type: Globals

        /// <summary>
        ///
        /// </summary>
        internal enum Globals
        {
            RedMessage = 0xEADEB8,
            MouseOverGUID = 0xEAEEA0,
            LootWindow = 0xF1FDE8,
            ChatboxIsOpen = 0xD26F08,
            CursorType = 0xE75430,
            IsBobbing = 0x104,
            ArchFacing = 0x270,
            ArchFacingOffset2 = 0x150,
        }

        #endregion

        #region Nested type: KeyBinding

        /// <summary>
        /// </summary>
        internal enum KeyBinding
        {
            NumKeyBindings = 0xF0CA30,
            First = 0xC8,
            Next = 0xC0,
            Key = 0x18,
            Command = 0x2C,    
        }

        #endregion

        #region Nested type: ObjectManager

        /// <summary>
        /// </summary>
        internal enum ObjectManager
        {
            CurMgrPointer = 0xFEFA58,
            CurMgrOffset = 0x62C,
            NextObject = 0x3C,
            FirstObject = 0xD8,
            LocalGUID = 0xF8,
        }

        #endregion

        #region Nested type: Reaction

        /// <summary>
        /// </summary>
        internal enum Reaction : uint
        {
            FriendlyOffset2 = 0xC,
            HostileOffset2 = 0xC,
            FriendlyOffset1 = 010,
            HostileOffset1 = 0x14,
            DBCPtrFactionTemplate = 0xD6C8D4,
        }

        #endregion

        #region Nested type: InCombat

        /// <summary>
        /// </summary>
        public enum InCombat
        {
            Mask = 19,
            Offset2 = 0x14C,
            Offset1 = 0x124  
        }

        #endregion

        #region Nested type: Runes

        /// <summary>
        /// </summary>
        internal enum Runes
        {
            RuneTypes = 0xF25814,
            RunesOffset = 0xF25878,
        }

        #endregion

        #region Nested type: ShapeshiftForm

        /// <summary>
        /// </summary>
        internal enum ShapeshiftForm
        {
            BaseAddressOffset1 = 0x0EDC,
            BaseAddressOffset2 = 0x263,
        }

        #endregion

        #region Nested type: SpellCooldown

        /// <summary>
        /// </summary>
        internal enum SpellCooldown : uint
        {
            CooldPown = 0xD94170,
        }

        #endregion

        #region Nested type: PowerIndex
        /// <summary>
        /// </summary>
        internal enum PowerIndex
        {
            PowerIndexArrays = 0xE4772C,
            Multiplicator = 0x10
        }

        #endregion

        #region Nested type: Swimming

        /// <summary>
        /// </summary>
        internal enum Swimming
        {
            Pointer = 0x12C,
            Offset = 0x40,
            Mask = 0x100000,
        }

        #endregion

        #region IsFlying enum

        /// <summary>
        /// </summary>
        public enum IsFlying
        {
            Pointer = 0x12C,
            Offset = 0x40,
            Mask = 0x1000000
        }

        #endregion

        #region IsFalling enum

        /// <summary>
        /// </summary>
        public enum IsFalling
        {
            Pointer = 0x12C,
            Offset = 0x40,
            Mask = 0x1000000
        }

        #endregion

        #region Nested type: UnitAuras

        /// <summary>
        /// </summary>
        internal enum UnitAuras : uint
        {
            AuraCount1 = 0x1588,
            AuraCount2 = 0x1108,
            AuraTable1 = 0x1108,
            AuraTable2 = 0x110C,
            AuraSize = 0x48,
            AuraSpellId = 0x30,
            AuraStack = 0x39,
            TimeLeft = 0x40,
            OwnerGUID = 0x20, 
        }

        #endregion

        #region Nested type: UnitName

        /// <summary>
        /// </summary>
        internal enum UnitName : uint
        {
            ObjectName1 = 0x274,
            ObjectName2 = 0xB4,
            PlayerNameGUIDOffset = 0x010,
            PlayerNameStringOffset = 0x021,
            PlayerNameCachePointer = 0xD7BF94,
            UnitName1 = 0xC38,                  
            UnitName2 = 0x7C,         
        }

        #endregion

        #region Nested type: UnitSpeed

        /// <summary>
        /// </summary>
        internal enum UnitSpeed
        {
            Pointer1 = 0x12C,
            Pointer2 = 0x88,
        }

        #endregion

        #region Nested type: WowObject

        /// <summary>
        /// </summary>
        internal enum WowObject
        {
            X = 0xAC0,
            Y = X + 0x4,
            Z = X + 0x8,
            RotationOffset = X + 0x10,
            GameObjectX = 0x0140,
            GameObjectY = GameObjectX + 0x4,
            GameObjectZ = GameObjectX + 0x8,
            GameObjectRotation = GameObjectX + 0x10,  
        }

        #endregion

        #region Nested type: Zone

        /// <summary>
        /// </summary>
        internal enum Zone : uint
        {
            SubZoneText = 0xEAEABC,
            ZoneText = 0xEAEAC0,
            ZoneID = 0xEAEB14
        }

        #endregion

        #region Nested type: UiFrame
        /// <summary>
        /// </summary>
        internal enum UiFrame
        {
            ScrWidth = 0xC5ADC8,
            ScrHeight = 0xC5ADCC,
            FrameBase = 0xD1A2DC,

            FirstFrame = 0x12F4,
            NextFrame = 0x12EC,
            RegionsFirst = 0x168,
            RegionsNext = 0x160,
            Visible = 0x64,
            Visible1 = 0x1A,
            Visible2 = 1,
            LabelText = 0xF8,
            Name = 0x1C,

            ButtonEnabledPointer = 0x1F4,
            ButtonEnabledMask = 0xF,
            ButtonChecked = 0x230,
            EditBoxText = 0x210,
            FrameBottom = 0x68,
            FrameLeft = 0x6c,
            FrameTop = 0x70,
            FrameRight = 0x74,
            CurrentFrameOffset = 0x88,  
        }
        #endregion
    }
}