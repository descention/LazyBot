namespace LazyLib.Wow
{
    using LazyLib;
    using LazyLib.Helpers;
    using LazyLib.PInvoke;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Threading;
    using Unity;

    [Obfuscation(Feature = "renaming", ApplyToMembers = true)]
    public class PObject
    {
        private static Point _oldPoint;
        private const int iRestore = 9;
        private const int iShow = 5;
        protected readonly IObjectManager _objectManager;
        public PObject(uint baseAddress)
        {
            this.BaseAddress = baseAddress;
            _objectManager = ServiceManager.Provider.GetService<IObjectManager>();
        }

        private static bool DoSmallestSearch<T>(T guid)
        {
            var _objectManager = ServiceManager.Provider.GetService<IObjectManager>();
            if (_objectManager.ShouldDefend)
                return true;
            GamePosition.Findpos(Memory.WindowHandle);
            int xOffset = -40;
            int yOffset = -40;
            while (!Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(T)).Equals(guid))
            {
                MoveMouse(GamePosition.GetCenterX + xOffset, GamePosition.GetCenterY + yOffset);
                Thread.Sleep(10);
                if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(T)).Equals(guid))
                    break;
                xOffset = xOffset + 10;
                if (xOffset > 50)
                {
                    yOffset = yOffset + 10;
                    xOffset = -40;
                    if (yOffset > 50)
                    {
                        break;
                    }
                }
            }
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(T)).Equals(guid))
                return true;
            return false;
        }

        private void FindUsingWorldToScreen()
        {
            Point worldToScreen = Camera.World2Screen.WorldToScreen(Location, true);
            MoveMouse(worldToScreen.X, worldToScreen.Y);
            Thread.Sleep(50);
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(GUID))
                return;
            MoveMouse(MouseHelper.MousePosition.X, MouseHelper.MousePosition.Y - 15);
            Thread.Sleep(50);
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(GUID))
                return;
            MoveMouse(MouseHelper.MousePosition.X, MouseHelper.MousePosition.Y + 15);
            Thread.Sleep(50);
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(GUID))
                return;
            Thread.Sleep(50);
            MoveMouse(MouseHelper.MousePosition.X - 15, MouseHelper.MousePosition.Y);
            Thread.Sleep(50);
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(GUID))
                return;
            MoveMouse(MouseHelper.MousePosition.X + 15, MouseHelper.MousePosition.Y);
            Thread.Sleep(50);
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(GUID))
                return;
            MoveMouse(MouseHelper.MousePosition.X, MouseHelper.MousePosition.Y + 35);
            Thread.Sleep(50);
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(GUID))
                return;
            MoveMouse(MouseHelper.MousePosition.X, MouseHelper.MousePosition.Y + 40);
            Thread.Sleep(50);
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(GUID))
                return;
            MoveMouse(MouseHelper.MousePosition.X, MouseHelper.MousePosition.Y + 45);
            Thread.Sleep(50);
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(GUID))
                return;
        }

        protected T GetStorageField<T>(Descriptors.CGObjectData field) where T : struct
        {
            try
            {
                return this.GetStorageField<T>((uint)field);
            }
            catch (Exception exception)
            {
                Console.WriteLine("DO NOT POST THIS WARNING ON THE FORUM! ONLY DEBUG!: " + exception);
                return default(T);
            }
        }

        protected T GetStorageField<T>(uint field) where T : struct
        {
            try
            {
                return (T)Memory.ReadObject(this.StorageField + (field * 4), typeof(T));
            }
            catch (Exception exception)
            {
                Console.WriteLine("DO NOT POST THIS WARNING ON THE FORUM! ONLY DEBUG!: " + exception);
                return default(T);
            }
        }

        /// <summary>
        /// Get an array of object from storage fields
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <returns></returns>
        protected T[] GetStorageFields<T>(uint field) where T : struct
        {
            try
            {
                return (T[])Memory.ReadObject(this.StorageField + (field * 4), typeof(T[]));
            }
            catch (Exception exception)
            {
                Console.WriteLine("DO NOT POST THIS WARNING ON THE FORUM! ONLY DEBUG!: " + exception);
                return default;
            }
        }

        public bool Interact(bool multiclick)
        {
            return InteractOrTarget(multiclick);
        }

        public bool InteractOrTarget(bool multiclick)
        {
            if (_objectManager.MyPlayer.TargetGUID.Equals(GUID))
            {
                KeyHelper.SendKey("InteractWithMouseOver");
                return true;
            }
            if (!LazySettings.BackgroundMode)
            {
                User32.GetCursorPos(out POINT position);
                _oldPoint.X = position.X;
                _oldPoint.Y = position.Y;
                MouseHelper.Hook();
                if (!LazySettings.HookMouse)
                {
                    SetForGround();
                }
                FindUsingWorldToScreen();
                bool toReturn = LetsSearch(GUID, multiclick, true);
                MoveMouse(_oldPoint.X, _oldPoint.Y);
                MouseHelper.ReleaseMouse();
                return toReturn;
            }

            // TODO fix writing later
            //We are using background mode lets do it the easy way.

            //Memory.Write(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, GUID);
            Thread.Sleep(50);
            KeyHelper.SendKey("InteractWithMouseOver");
            Thread.Sleep(500);
            if (_objectManager.MyPlayer.TargetGUID.Equals(GUID))
                return true;
            return false;
        }

        public void LeftClick()
        {
            if (!LazySettings.HookMouse)
            {
                SetForGround();
            }
            Point worldToScreen = Camera.World2Screen.WorldToScreen(Location, true);
            MoveMouse(worldToScreen.X, worldToScreen.Y);
            Thread.Sleep(50);
            MouseHelper.LeftClick();
            Thread.Sleep(50);
        }

        //TODO: Do something to this functions, its freaking ugly
        private bool LetsSearch(byte[] guid, bool multiclick, bool click)
        {
            if (!Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(guid))
            {
                GamePosition.Findpos(Memory.WindowHandle);
                if (!DoSmallestSearch(guid))
                    if (!Search(guid, GamePosition.Width / 16))
                        if (!Search(guid, GamePosition.Width / 12))
                            if (!Search(guid, GamePosition.Width / 10))
                                if (!Search(guid, GamePosition.Width / 8))
                                    if (!Search(guid, GamePosition.Width / 6))
                                    {
                                        // DoSmallSearch(guid);
                                    }
            }
            if (_objectManager.GetAttackers.Count != 0 && _objectManager.ShouldDefend)
                return false;
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(guid))
            {
                if (click)
                {
                    if (!LazySettings.HookMouse)
                    {
                        SetForGround();
                    }
                    if (multiclick)
                    {
                        MoveMouse(MouseHelper.MousePosition.X, MouseHelper.MousePosition.Y - 15);
                        Thread.Sleep(50);
                        KeyHelper.SendKey("InteractWithMouseOver");
                        Thread.Sleep(50);
                        MoveMouse(MouseHelper.MousePosition.X, MouseHelper.MousePosition.Y + 15);
                        Thread.Sleep(50);
                        KeyHelper.SendKey("InteractWithMouseOver");
                        Thread.Sleep(50);
                        MoveMouse(MouseHelper.MousePosition.X - 15, MouseHelper.MousePosition.Y);
                        Thread.Sleep(50);
                        KeyHelper.SendKey("InteractWithMouseOver");
                        MoveMouse(MouseHelper.MousePosition.X + 15, MouseHelper.MousePosition.Y);
                        Thread.Sleep(50);
                        KeyHelper.SendKey("InteractWithMouseOver");
                        Thread.Sleep(50);
                    }
                    MoveMouse(MouseHelper.MousePosition.X, MouseHelper.MousePosition.Y);
                    Thread.Sleep(50);
                    KeyHelper.SendKey("InteractWithMouseOver");
                    Thread.Sleep(50);
                }
                return true;
            }
            return false;
        }

        public bool MouseOver()
        {
            FindUsingWorldToScreen();
            bool toReturn = LetsSearch(GUID, false, false);
            return toReturn;
        }

        private static void MoveMouse(int x, int y)
        {
            if (LazySettings.HookMouse)
            {
                MouseHelper.MoveMouseToPosHooked(x, y);
            }
            else
            {
                User32.SetCursorPos(x, y);
            }
        }

        private bool Search(byte[] guid, int yValue)
        {
            if (_objectManager.ShouldDefend)
                return true;
            int xOffset = 0;
            int yOffset = -yValue;
            bool right = true;
            while (!Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(guid))
            {
                MoveMouse(GamePosition.GetCenterX + xOffset, GamePosition.GetCenterY + yOffset);
                Thread.Sleep(10);
                if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(guid))
                    break;
                if (right)
                {
                    if (yOffset < 0)
                        xOffset += 15;
                    else
                        xOffset -= 15;
                }
                else
                {
                    if (yOffset < 0)
                        xOffset -= 15;
                    else
                        xOffset += 15;
                }
                yOffset = yOffset + 8;
                if (yOffset > yValue)
                {
                    if (!right)
                    {
                        break;
                    }
                    yOffset = -yValue;
                    right = false;
                }
            }
            if (Memory.ReadObject(Memory.BaseAddress + (uint)Pointers.Globals.MouseOverGUID, typeof(byte[])).Equals(guid))
                return true;
            return false;
        }



        private static void SetForGround()
        {
            IntPtr hwnd = Memory.WindowHandle;
            if (hwnd.ToInt32() > 0)
            {
                User32.SetForegroundWindow(hwnd);
                User32.ShowWindow(hwnd, User32.IsIconic(hwnd) ? iRestore : iShow);
            }
        }

        public PGameObject ToGameObject(PObject obj)
        {
            return new PGameObject(obj.BaseAddress);
        }

        public PPlayer ToPlayer(PItem obj)
        {
            return new PPlayer(obj.BaseAddress);
        }

        public PPlayer ToPlayer(PObject obj)
        {
            return new PPlayer(obj.BaseAddress);
        }

        public PPlayer ToPlayer(PPlayer obj)
        {
            return new PPlayer(obj.BaseAddress);
        }

        public PPlayer ToPlayer(PUnit obj)
        {
            return new PPlayer(obj.BaseAddress);
        }

        public PUnit ToUnit(PItem obj)
        {
            return new PUnit(obj.BaseAddress);
        }

        public PUnit ToUnit(PObject obj)
        {
            return new PUnit(obj.BaseAddress);
        }

        internal void UpdateBaseAddress(uint address)
        {
            this.BaseAddress = address;
        }

        public uint BaseAddress { get; set; }

        public int Entry
        {
            get
            {
                return this.GetStorageField<int>((uint)Descriptors.CGObjectData.EntryID);
            }
        }

        public virtual float Facing
        {
            get
            {
                try
                {
                    return Memory.Read<float>(new uint[] { this.BaseAddress + (uint)Pointers.WowObject.RotationOffset });
                }
                catch
                {
                    return 0;
                }
            }
        }

        public virtual byte[] GUID
        {
            get
            {
                if (this.IsValid)
                {
                    return this.GetStorageFields<byte>((uint)Descriptors.CGObjectData.Guid);
                }
                return new byte[0];
            }
        }



        public bool IsMe
        {
            get
            {
                if (!GUID.Equals(_objectManager.MyPlayer.GUID))
                {
                    return false;
                }
                return true;
            }
        }

        public bool IsValid
        {
            get { return BaseAddress != uint.MinValue; }
        }

        public int Level
        {
            get
            {
                return this.GetStorageField<int>((uint)Descriptors.CGUnitData.Level);
            }
        }

        /// <summary>
        ///   Gets the location.
        /// </summary>
        /// <value>The location.</value>
        public virtual Location Location
        {
            get { return new Location(X, Y, Z); }
        }

        public uint StorageField
        {
            get
            {
                return Memory.Read<uint>(new uint[] { this.BaseAddress + 4 });
            }
        }

        public Constants.ObjectType Type
        {
            get
            {
                return (Constants.ObjectType)Memory.Read<int>(new uint[] { this.BaseAddress + 12 });
            }
        }


        public virtual float X
        {
            get
            {
                try
                {
                    return Memory.Read<float>(new uint[] { this.BaseAddress + (uint)Pointers.WowObject.X });
                }
                catch
                {
                    return 0;
                }
            }
        }

        public virtual float Y
        {
            get
            {
                try
                {
                    return Memory.Read<float>(new uint[] { this.BaseAddress + (uint)Pointers.WowObject.Y });
                }
                catch
                {
                    return 0;
                }
            }
        }

        public virtual float Z
        {
            get
            {
                try
                {
                    return Memory.Read<float>(new uint[] { this.BaseAddress + (uint)Pointers.WowObject.Z });
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
}

