namespace LazyLib
{
    public interface IGamePointers
    {
        int PlayerName { get; }
        int InGame { get; }
        int CurMgrPointer { get; }
        int CurMgrOffset { get; }
        int NextObject { get; }
        int FirstObject { get; }
        int LocalGUID { get; }
        int AutoLootPointer { get; }
        int AutoLootOffset { get; }
        int ClickToMovePointer { get; }
        int ClickToMoveOffset { get; }
    }
}