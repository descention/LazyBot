using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LazyLib.PInvoke
{
    public static class User32
    {
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr Hwnd);
    }
}
