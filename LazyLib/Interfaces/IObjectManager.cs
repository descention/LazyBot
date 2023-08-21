using LazyLib.Wow;
using System;
using System.Collections.Generic;

namespace LazyLib
{
    public interface IObjectManager
    {
        List<PGameObject> GetGameObject { get; }
        PPlayerSelf MyPlayer { get; }
        bool ShouldDefend { get; }
        List<PUnit> GetUnits { get; }
        IntPtr WowHandle { get; set; }
    }
}