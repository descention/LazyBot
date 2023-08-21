// Type: LazyLib.Wow.PContainer
// Assembly: LazyLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A92FE1A9-C28E-4E6F-9BAC-5C48387A25CC
// Assembly location: E:\VeryOldLazyBots\Lazy Evolution\LazyLib.dll

using LazyLib.Helpers;
using LazyLib.Manager;
using System;
using System.Reflection;

namespace LazyLib.Wow
{
    [Obfuscation(ApplyToMembers = true, Feature = "renaming")]
    public class PContainer<T> : PObject<T> where T : struct, IEquatable<T>
    {
        public int Slots
        {
            get
            {
                return this.GetStorageField<int>((uint)Descriptors.CGContainerData.NumSlots);
            }
        }

        public int GetSlot(int slot)
        {
            int num;
            try
            {
                slot--;
                num = (slot < 0 || slot > this.Slots ? 0 : base.GetStorageField<int>((uint)(Descriptors.CGContainerData.Slots + slot * 8)));
            }
            catch (Exception exception)
            {
                Logging.Write(string.Concat("GetSlot(int slot): ", exception), true);
                num = 0;
            }
            return num;
        }

        public PContainer(uint baseAddress)
            : base(baseAddress)
        {
        }

        public int _Slots(uint i)
        {
            return this.GetStorageField<int>(i);
        }
    }
}
