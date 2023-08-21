using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LazyLib
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class GameVersionAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string _clientVersion;
        readonly int _build;
        readonly ProcessorArchitecture _architecture;
        // This is a positional argument
        public GameVersionAttribute(string clientVersion, int build, ProcessorArchitecture architecture = ProcessorArchitecture.X86)
        {
            this._clientVersion = clientVersion;
            this._build = build;
            _architecture = architecture;
        }

        /// <summary>
        /// Build Number of the client. x.y.z.buildNumber
        /// </summary>
        public int Build => _build;

        /// <summary>
        /// Client Version, x.y.z
        /// </summary>
        public string ClientVersion => _clientVersion;
        
        public ProcessorArchitecture Architecture => _architecture;
    }
}
