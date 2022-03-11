namespace SnakesAndLadders.Core.Interface
{
    public interface ICellType
    {
        int Start { get; set; }
        int End { get; set; }
        int GetNextPosition(int currentPosition);
    }
}
