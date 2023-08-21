using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LazyLib.PInvoke
{
    public static class Kernel32
    {
        /// <summary>
        ///   The QueryPerformanceCounter function retrieves the current 
        ///   value of the high-resolution performance counter.
        /// </summary>
        /// <param name = "x">
        ///   Pointer to a variable that receives the 
        ///   current performance-counter value, in counts.
        /// </param>
        /// <returns>
        ///   If the function succeeds, the return value is 
        ///   nonzero.
        /// </returns>
        [DllImport("KERNEL32")]
        public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        /// <summary>
        ///   The QueryPerformanceFrequency function retrieves the 
        ///   frequency of the high-resolution performance counter, 
        ///   if one exists. The frequency cannot change while the 
        ///   system is running.
        /// </summary>
        /// <param name = "x">
        ///   Pointer to a variable that receives 
        ///   the current performance-counter frequency, in counts 
        ///   per second. If the installed hardware does not support 
        ///   a high-resolution performance counter, this parameter 
        ///   can be zero.
        /// </param>
        /// <returns>
        ///   If the installed hardware supports a 
        ///   high-resolution performance counter, the return value 
        ///   is nonzero.
        /// </returns>
        [DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceFrequency(out long lpFrequency);
    }
}
