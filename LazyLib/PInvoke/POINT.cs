using System.Runtime.InteropServices;

namespace LazyLib.PInvoke
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public Int32 X;
        public Int32 Y;
    }
}
