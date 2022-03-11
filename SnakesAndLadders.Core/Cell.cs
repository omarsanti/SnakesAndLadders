using SnakesAndLadders.Core.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders.Core
{
    public class Cell
    {        
        private int _number;
        private ICellType _cellType;

        public Cell(int number, ICellType cellType)
        {
            _number = number;
            _cellType = cellType;
        }

        public int GetCellNumber()
        {
            return _number;
        }

        public ICellType GetCellType()
        {
            return _cellType;
        }
    }
}
