using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLib.Interfaces
{
    public interface IPqrOffsets
    {
        int CurrentWoWVersion { get; set; }
        int WoWVersionOffset { get; set; }
        int PlayerName { get; set; }
        int PlayerClass { get; set; }
        int GetCurrentKeyBoardFocus { get; set; }
        int GameState { get; set; }
        int Lua_DoStringAddress { get; set; }
        int Lua_GetLocalizedTextAddress { get; set; }
        int CVarBaseMgr { get; set; }
        int CVarArraySize { get; set; }
        int ObjMgr { get; set; }
        int CurMgr { get; set; }
        int ClntObjMgrGetActivePlayerObjAddress { get; set; }
        int LocalGUID { get; set; }
        int FirstObject { get; set; }
        int NextObject { get; set; }
        int Descriptors { get; set; }
        int Obj_TypeOffset { get; set; }
        int Obj_X { get; set; }
        int Obj_TargetGUID { get; set; }
        int ClickTerrain { get; set; }
    }

}
