using LazyLib.Helpers;
using LazyLib.Wow;
using System;

namespace LazyEvo.Plugins.ExtraLazy
{
    public class EventMessage
    {
        public static String readChat()
        {
            return Memory.ReadUtf8StringRelative(Convert.ToUInt32((uint)Pointers.Globals.RedMessage), 128);
        }
    }
}
