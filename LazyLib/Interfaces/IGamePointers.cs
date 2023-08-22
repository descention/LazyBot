namespace LazyLib
{
    public interface IGamePointers
    {
        uint GuidByteArraySize { get; }
        uint GameBuild { get; }
        uint GameState { get; }
        uint CameraStruct { get; }
        uint CameraOffset { get; }
        uint CameraOrigin { get; }
        uint CameraMatrix { get; }
        uint CameraFov { get; }
        uint LocalPlayer { get; }
        uint IsLooting { get; }
        uint IsTexting { get; }
        uint MouseGuid { get; }
        uint TargetGuid { get; }
        uint EntityList { get; }
        uint FirstEntity { get; }
        uint NextEntity { get; }
        uint EntityType { get; }
        uint Descriptors { get; }
        uint GlobalID { get; }
        uint EntityID { get; }
        uint DynFlags { get; }
        uint UnitTransport { get; }
        uint UnitOrigin { get; }
        uint UnitAngle { get; }
        uint UnitCasting { get; }
        uint UnitChannel { get; }
        uint UnitCreator { get; }
        uint UnitHealth { get; }
        uint UnitPower { get; }
        uint UnitHealthMax { get; }
        uint UnitPowerMax { get; }
        uint UnitLevel { get; }
        uint UnitFlags { get; }
        uint NpcCache { get; }
        uint NpcName { get; }
        uint ObjectBobbing { get; }
        uint ObjectTransport { get; }
        uint ObjectOrigin { get; }
        uint ObjectRotation { get; }
        uint ObjectTransform { get; }
        uint ObjectCache { get; }
        uint ObjectName { get; }
        uint ObjectCreator { get; }
        uint ObjectDisplay { get; }
        uint NameCacheBase { get; }
        uint NameCacheNext { get; }
        uint NameCacheGuid { get; }
        uint NameCacheName { get; }
        uint NameCacheRace { get; }
        uint NameCacheClass { get; }
        uint Position { get; }
        uint Buffer { get; }
        uint MsgSize { get; }
        uint SenderGuid { get; }
        uint SenderName { get; }
        uint FullMessage { get; }
        uint OnlyMessage { get; }
        uint ChannelNumber { get; }
        uint TimeStamp { get; }
        uint GameHash { get; }
    }
}