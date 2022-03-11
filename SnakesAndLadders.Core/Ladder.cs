using SnakesAndLadders.Core.Interface;

namespace SnakesAndLadders.Core
{
    public class Ladder : CellType, ICellType
    {
        public int GetNextPosition(int currentPosition)
        {
            if (currentPosition == Start)
            {
                return End;
            }
            else if (currentPosition == End)
            {
                return End;
            }

            return currentPosition;
        }
    }
}
