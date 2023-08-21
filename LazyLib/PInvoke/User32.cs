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

        [DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr Hwnd, int iCmdShow);

        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr Hwnd);
    }
}
