using SnakesAndLadders.Core.Interface;

namespace SnakesAndLadders.Core
{
    public class Token
    {
        private Cell _currentCell;
        public Token(Cell currentCell)
        {
            _currentCell = currentCell;
        }
        public Cell GetCurrentCell()
        {
            return _currentCell;
        }

        public void SetCurrentCell(Cell currentCell)
        {
            _currentCell = currentCell;
        }
    }
}
