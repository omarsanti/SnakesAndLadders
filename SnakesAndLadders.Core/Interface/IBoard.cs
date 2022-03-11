namespace SnakesAndLadders.Core.Interface
{
    public interface IBoard
    {
        Cell GetCell(int number);
        Cell GetNextCell(Cell currentCell, int spaces);
        Cell GetLastCell();

    }
}
