namespace LazyLib;

public interface IGamePointers
{
    int PlayerName { get; }
    int InGame { get; }
    int ObjectManagerCurMgrPointer { get; }
    int ObjectManagerCurMgrOffset { get; }
    int ObjectManagerNextObject { get; }
    int ObjectManagerFirstObject { get; }
    int ObjectManagerLocalGUID { get; }
    int AutoLootPointer { get; }
    int AutoLootOffset { get; }
    int ClickToMovePointer { get; }
    int ClickToMoveOffset { get; }
}
