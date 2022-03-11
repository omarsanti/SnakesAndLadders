using SnakesAndLadders.Core.Interface;

namespace SnakesAndLadders.Core
{
    public class Snake : CellType, ICellType
    {        
        public int GetNextPosition(int currentPosition)
        {
            if (currentPosition == Start)
            {
                return Start;
            }
            else if (currentPosition == End)
            {
                return Start;
            }

            return currentPosition;
        }
    }
}
