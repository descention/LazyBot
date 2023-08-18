
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
        public enum Globals
        {
            PlayerName = 0xEBF648,     // 5.4.2 (17658) (0x1D280 diff)
        }
        #endregion


        #region InGame enum
        public enum InGame
        {
            InGame = 0xD60C2C,   // 5.4.2 (17658) (0x1D040 diff)
        }
        #endregion
    }


    internal class Pointers
    {


        #region Nested type: ObjectManager
        internal enum ObjectManager
        {
            //CurrentManager = Memory.Read<uint>(Memory.ReadRelative<uint>((uint) Pointers.ObjectManager.CurMgrPointer)
            //    + (uint) Pointers.ObjectManager.CurMgrOffset);
            //LocalGUID = Memory.Read<UInt64>(CurrentManager + (uint) Pointers.ObjectManager.LocalGUID);
            CurMgrPointer = 0xEBF608,   // 5.4.2 (17658) (0x1D280 diff)
            CurMgrOffset = 0x462C,      // 5.4.2 (17658) (0x0 diff)
            NextObject = 0x34,          // 5.4.2 (17658) (0x0 diff)
            FirstObject = 0xCC,         // 5.4.2 (17658) (0x0 diff)
            LocalGUID = 0xE8,           // 5.4.2 (17658) (0x0 diff)
        }
        #endregion


        #region Nested type: Globals
        internal enum Globals
        {
            RedMessage = 0xD5FF10,      // 5.4.2 (17658) (0x1D040 diff)  
            MouseOverGUID = 0xD60B20,   // 5.4.2 (17658) (0x1D040 diff)  
            LootWindow = 0xDCEB8C,      // 5.4.2 (17658) (0x1D080 diff)  
            IsBobbing = 0xCC,           // 5.4.2 (17658)
            ArchFacing = 0x1BC,         // 5.4.2 (17658)                    
            ArchFacingOffset2 = 0x108,  // 5.4.2 (17658)                    
            ChatboxIsOpen = 0xBB99EC,   // 5.4.2 (17658) (0x196B0 diff)  
            CursorType = 0xD29548       // 5.4.2 (17658) (0x1D038 diff)  
        }
        #endregion


        #region ActionBar enum
        public enum ActionBar
        {
            ActionBarFirstSlot = 0xDD2AD8,    // 5.4.2 (17658) (0x1D070 diff)
            ActionBarBonus = 0xDD2F60,        // 5.4.2 (17658) (0x1D070 diff)
        }
        #endregion


        #region AutoLoot enum
        public enum AutoLoot
        {
            Offset = 0x30,         // 5.4.2 (17658)
            Pointer = 0xD60D50,    // 5.4.2 (17658) (0x1D040 diff)
        }
        #endregion


        #region ClickToMove enum
        public enum ClickToMove
        {
            Offset = 0x30,         // 5.4.2 (17658)
            Pointer = 0xD60D30,    // 5.4.2 (17658) (0x1D040 diff)
        }
        #endregion


        #region CgUnitCGetCreatureRank enum
        public enum CgUnitCGetCreatureRank
        {
            Offset1 = 0x9B4,  // 5.4.2 (17658)  
            Offset2 = 0x20,   // 5.4.2 (17658)  
        }
        #endregion


        #region CgUnitCGetCreatureType enum
        public enum CgUnitCGetCreatureType
        {
            Offset1 = 0x9B4,    // 5.4.2 (17658)
            Offset2 = 0x18,     // 5.4.2 (17658)
        }
        #endregion


        #region CgWorldFrameGetActiveCamera enum
        public enum CgWorldFrameGetActiveCamera
        {
            //return Memory.Read<uint>(Memory.ReadRelative<uint>((uint)Pointers.CgWorldFrameGetActiveCamera.CameraPointer) 
            // + (uint)Pointers.CgWorldFrameGetActiveCamera.CameraOffset);


            CameraX = 0x8,             // 5.4.2 (17658)
            CameraY = 0xC,             // 5.4.2 (17658)
            CameraZ = 0x10,            // 5.4.2 (17658)
            CameraMatrix = 0x14,       // 5.4.2 (17658)
            CameraPointer = 0xD5FE4C,  // 5.4.2 (17658) (0x1D038 diff)      
            CameraOffset = 0x8208,     // 5.4.2 (17658) (0x00 diff)        
        }
        #endregion




        #region Nested type: AutoAttack
        internal enum AutoAttack
        {
            //Shows 0x06 when not wanding, 0x0C or 0x0E when wanding.
            AutoAttackFlag = 0xC58,  // 5.4.2 (17658)
            AutoAttackMask = 0xC5C,  // 5.4.2 (17658)
            Wanding = 0xC70,         // 5.4.2 (17658)
        }
        #endregion


        #region Nested type: CastingInfo
        internal enum CastingInfo
        {
            IsCasting = 0xCB8,              // 5.4.2 (17658) 
            ChanneledCasting = 0xCD0,       // 5.4.2 (17658) 
        }
        #endregion


        #region Nested type: Chat
        internal enum Chat : uint
        {
            ChatStart = 0xD62955,           // 5.4.2 (17658) (0x1D038 diff)
            OffsetToNextMsg = 0x17C8,       // 5.4.2 (17658)
        }
        #endregion


        #region BlueChat
        internal enum Messages
        {
            EventMessage = 0xD9BA38     // 5.0.4 (15929)  <--- FIX THIS
        }
        #endregion


        #region Nested type: ComboPoints
        internal enum ComboPoints
        {
            ComboPoints = 0xD60BF1,     // 5.4.2 (17658) (0x1D040 diff)
        }
        #endregion


        #region Nested type: Runes
        internal enum Runes
        {
            RunesOffset = 0xDD2234,     // 5.4.2 (17658) (0x1D070 diff)
        }
        #endregion


        #region Nested type: Container
        internal enum Container
        {
            //I think this is completely wrong. Needs fixing at some point.
            EquippedBagGUID = 0xCE3F96,  // 5.4.2 (17658) (-0x98FA diff)  //VALIDATE??
        }
        #endregion




        #region Nested type: KeyBinding
        internal enum KeyBinding
        {
            NumKeyBindings = 0xDBD8F8,      // 5.4.2 (17658) (0x1d058 diff)
            First = 0xC8,                   // 5.4.2 (17658)
            Next = 0xC0,                    // 5.4.2 (17658)
            Key = 0x14,                     // 5.4.2 (17658)
            Command = 0x28,                 // 5.4.2 (17658)
        }
        #endregion




        #region Nested type: Macros
        internal enum MacroManager
        {
            //CurrentManager = Memory.Read<uint>(Memory.ReadRelative<uint>((uint) Pointers.ObjectManager.CurMgrPointer)
            //    + (uint) Pointers.ObjectManager.CurMgrOffset);
            //LocalGUID = Memory.Read<UInt64>(CurrentManager + (uint) Pointers.ObjectManager.LocalGUID);


            MacroTable = 0xDD2120,     // 5.4.2 (17658) (0x1d070 diff)
            GeneralOffset = 0x04,      // 5.4.2 (17658)
        }
        #endregion




        #region Nested type: Reaction
        internal enum Reaction : uint
        {
            FactionPointer = FactionStartIndex + 0xC,    // 5.4.2 (17658)
            FactionTotal = FactionStartIndex - 0x4,      // 5.4.2 (17658)
            HostileOffset1 = 0x14,                       // 5.4.2 (17658)
            HostileOffset2 = 0x0C,                       // 5.4.2 (17658)
            FriendlyOffset1 = 0x10,                      // 5.4.2 (17658)
            FriendlyOffset2 = 0x0C,                      // 5.4.2 (17658)
            FactionStartIndex = 0xC85B9C,                // 5.4.2 (17658) (0x19BB0 diff)
        }
        #endregion






        #region Nested type: ShapeshiftForm
        internal enum ShapeshiftForm
        {
            BaseAddressOffset1 = 0xE4,       // 5.4.2 (17658)
            BaseAddressOffset2 = 0x1E3,      // 5.4.2 (17658)
        }
        #endregion


        #region Nested type: SpellCooldown
        internal enum SpellCooldown : uint
        {
            CooldPown = 0xC9D608,   // 5.4.2 (17658) (0x1A088 diff) 
        }
        #endregion


        #region Nested type: Swimming
        internal enum Swimming
        {
            Pointer = 0xEC,     // 5.4.2 (17658)    
            Offset = 0x38,      // 5.4.2 (17658)    
            Mask = 0x100000,    // 5.4.2 (17658)    
        }
        #endregion


        #region IsFlying enum
        public enum IsFlying
        {
            Pointer = 0xEC,     // 5.4.2 (17658)    
            Offset = 0x38,      // 5.4.2 (17658)    
            Mask = 0x1000000    // 5.4.2 (17658)    
        }
        #endregion




        #region Nested type: UnitAuras
        internal enum UnitAuras : uint
        {
            AuraCount1 = 0x1218, // 5.4.2 (17658)
            AuraCount2 = 0xE18, // 5.4.2 (17658)
            AuraTable1 = 0xE18, // 5.4.2 (17658)
            AuraTable2 = 0xE1C, // 5.4.2 (17658)
            AuraSize = 0x40,    // 5.4.2 (17658)
            AuraSpellId = 0x28,  // 5.4.2 (17658)
            AuraStack = 0x2D,    // 5.4.2 (17658)
            TimeLeft = 0x34,    // 5.4.2 (17658)
            OwnerGUID = 0x20,    // 5.4.2 (17658)
        }
        #endregion


        #region Nested type: UnitName
        internal enum UnitName : uint
        {
            ObjectName1 = 0x1C0,            // 5.4.2 (17658)       
            ObjectName2 = 0xB0,             // 5.4.2 (17658)
            PlayerNameMaskOffset = 0x02c,   // 5.4.2 (17658)
            PlayerNameBaseOffset = 0x020,   // 5.4.2 (17658)
            PlayerNameStringOffset = 0x021, // 5.4.2 (17658)
            PlayerNameCachePointer = 0xC81878, // 5.4.2 (17658)  (0x19CA8 diff)
            UnitName1 = 0x9B4,              // 5.4.2 (17658)
            UnitName2 = 0x6C,               // 5.4.2 (17658)
        }
        #endregion


        #region Nested type: UnitSpeed
        internal enum UnitSpeed
        {
            Pointer1 = 0xEC,  // 5.4.2 (17658)    
            Pointer2 = 0x80,  // 5.4.2 (17658)
        }
        #endregion


        #region Nested type: WowObject
        internal enum WowObject
        {
            X = 0x838,              // 5.4.2 (17658) 
            Y = X + 0x4,            // 5.4.2 (17658)
            Z = X + 0x8,            // 5.4.2 (17658)
            RotationOffset = X + 0x10,       // 5.4.2 (17658)
            GameObjectX = 0x01F4,             // 5.4.2 (17658)
            GameObjectY = GameObjectX + 0x4, // 5.4.2 (17658)
            GameObjectZ = GameObjectX + 0x8, // 5.4.2 (17658)
            GameObjectRotation = GameObjectX + 0x10, // 5.4.2 (17658)
        }
        #endregion


        #region Nested type: Zone
        internal enum Zone : uint
        {
            ZoneText = 0xD60B04, // 5.4.2 (17658) (0x1d040 diff)
            ZoneID = 0xD60BAC, // 5.4.2 (17658) (0x1d040 diff)
        }
        #endregion




        #region Nested type: UiFrame
        internal enum UiFrame
        {
            //var @base = Memory.ReadRelative<uint>((uint)Pointers.UiFrame.FrameBase);
            //var currentFrame = Memory.Read<uint>(@base + (uint)Pointers.UiFrame.FirstFrame);


            ScrWidth = 0xADA9D4,            // 5.4.2 (17658) (0x19000 diff)
            ScrHeight = 0xADA9D8,           // 5.4.2 (17658) (0x19000 diff)
            FrameBase = 0xBADCB0,           // 5.4.2 (17658) (0x196AC diff)
            CurrentFramePtr = 0xBADCB0,     // 5.4.2 (17658) (0x196AC diff)


            ButtonEnabledPointer = 0x1F8,   // 5.4.2 (17658) <<-- FIX IT
            ButtonEnabledMask = 0xF,        // 5.4.2 (17658) <<-- FIX IT
            ButtonChecked = 0x234,          // 5.4.2 (17658) <<-- FIX IT
            EditBoxText = 0x214,            // 5.4.2 (17658) <<-- FIX IT
            FirstFrame = 0xce4,             // 5.4.2 (17658) <<-- FIX IT
            FrameBottom = 0x68,             // 5.4.2 (17658)
            FrameLeft = 0x6c,               // 5.4.2 (17658)
            FrameTop = 0x70,                // 5.4.2 (17658)
            FrameRight = 0x74,              // 5.4.2 (17658)
            LabelText = 0xF8,               // 5.4.2 (17658)
            Name = 0x1C,                    // 5.4.2 (17658)
            NextFrame = 0xCDC,              // 5.4.2 (17658) <<-- FIX IT
            RegionsFirst = 0x16c,           // 5.4.2 (17658) <<-- FIX IT
            RegionsNext = 0x164,            // 5.4.2 (17658) <<-- FIX IT
            Visible = 0x64,                 // 5.4.2 (17658) <<-- FIX IT
            Visible1 = 0x1A,                // 5.4.2 (17658) <<-- FIX IT
            Visible2 = 1,                   // 5.4.2 (17658) <<-- FIX IT
            CurrentFrameOffset = 0x88,      // 5.4.2 (17658) <<-- FIX IT        
        }


        #endregion
    }
}