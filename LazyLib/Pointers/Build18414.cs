using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLib.Pointers
{
    [GameVersion("5.4.8", 18414, System.Reflection.ProcessorArchitecture.X86)]
    public class Build18414 : IGamePointers
    {
        public uint GuidByteArraySize => 8; // uint

        public uint GameHash => 0xA2D96C48;
        public uint GameBuild => 0xB94E74;
        public uint GameState => 0xD65B16;


        public uint CameraStruct => 0xD64E5C;
        public uint CameraOffset => 0x8208;
        public uint CameraOrigin => 0x08;
        public uint CameraMatrix => 0x14;
        public uint CameraFov => 0x38;


        public uint LocalPlayer => 0xCFF49C;
        public uint IsLooting => 0xDD3D44;
        public uint IsTexting => 0xBBE9AC;
        public uint MouseGuid => 0xD65B28;
        public uint TargetGuid => 0xD65B40;


        public uint EntityList => 0xCB47C4;
        public uint FirstEntity => 0x0C;
        public uint NextEntity => 0x34;


        public uint EntityType => 0x0C;
        public uint Descriptors => 0x04;
        public uint GlobalID => 0x00;
        public uint EntityID => 0x14;
        public uint DynFlags => 0x18;


        public uint UnitTransport => 0x830;
        public uint UnitOrigin => 0x838;
        public uint UnitAngle => 0x848;
        public uint UnitCasting => 0xCB8;
        public uint UnitChannel => 0xCD0;
        public uint UnitCreator => 0x48;
        public uint UnitHealth => 0x84;
        public uint UnitPower => 0x88;
        public uint UnitHealthMax => 0x9C;
        public uint UnitPowerMax => 0xA0;
        public uint UnitLevel => 0xDC;
        public uint UnitFlags => 0xF4;


        public uint NpcCache => 0x9B4;
        public uint NpcName => 0x06C;


        public uint ObjectBobbing => 0x0CC;
        public uint ObjectTransport => 0x0F0;
        public uint ObjectOrigin => 0x0F8;
        public uint ObjectRotation => 0x108;
        public uint ObjectTransform => 0x1C4;
        public uint ObjectCache => 0x1C0;
        public uint ObjectName => 0x0B0;
        public uint ObjectCreator => 0x20;
        public uint ObjectDisplay => 0x28;


        public uint NameCacheBase => 0xC86848;
        public uint NameCacheNext => 0x00;
        public uint NameCacheGuid => 0x0C;
        public uint NameCacheName => 0x15;
        public uint NameCacheRace => 0x5C;
        public uint NameCacheClass => 0x64;


        public uint Position => 0xDC1090;
        public uint Buffer => 0xD67918;
        public uint MsgSize => 0x17C8;


        public uint SenderGuid => 0x0000;
        public uint SenderName => 0x0014;
        public uint FullMessage => 0x0045;
        public uint OnlyMessage => 0x0BFD;
        public uint ChannelNumber => 0x17B8;
        public uint TimeStamp => 0x17C4;

    }
}
