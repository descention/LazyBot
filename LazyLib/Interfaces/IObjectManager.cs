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
        List<PUnit> GetAttackers { get; }
        List<PObject> GetObjects { get; }
        List<PContainer> GetContainers { get; }
        List<PItem> GetItems { get; }
        List<PPlayer> GetPlayers { get; }

        void Refresh();
    }
}