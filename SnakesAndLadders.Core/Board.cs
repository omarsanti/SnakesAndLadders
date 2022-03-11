using SnakesAndLadders.Core.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders.Core
{
    public class Board : IBoard
    {
        private static int _size;
        private List<Cell> _cells;
        private List<(int, int)> _snakes;
        private List<(int, int)> _ladders;

        public Board(int size)
        {
            _size = size;
            SetSnakes();
            SetLadders();
            InitializeCells();            
        }

        private void InitializeCells()
        {
            _cells = new List<Cell>();
            for (int i = 1; i<= _size; i++)
            {
                _cells.Add(new Cell(i, GetCellType(i)));
            }
        }

        public Cell GetCell(int number)
        {
            return _cells[number];
        }

        public Cell GetNextCell(Cell currentCell, int spaces)
        {
            var nextCellNumber = currentCell.GetCellNumber() + spaces;
            if (nextCellNumber > _cells.Count)
            {
                return currentCell;
            }
            else
            {
                return GetCell(nextCellNumber - 1);
            }
            
        }

        public Cell GetLastCell()
        {
            return _cells.Last();
        }

        private void SetSnakes()
        {
            _snakes = new List<(int, int)>
            {
                (6,16),
                (11,49),
                (19,62),
                (25,46),
                (53,74),
                (60,64),
                (68,89),
                (75,95),
                (80,99),
                (88,92)
            };
        }

        private void SetLadders()
        {
            _ladders = new List<(int, int)>
            {
                (2,38),
                (7,14),
                (8,31),
                (15,26),
                (21,42),
                (36,44),
                (51,67),
                (71,91),
                (78,98),
                (87,94)
            };
        }

        private ICellType GetCellType(int number)
        {
            ICellType cellType;
            if (_ladders.Any(x => x.Item1 == number || x.Item2 == number))
            {
                cellType = new Ladder
                {
                    Start = _ladders.FirstOrDefault(x => x.Item1 == number || x.Item2 == number).Item1,
                    End = _ladders.FirstOrDefault(x => x.Item1 == number || x.Item2 == number).Item2
                };
            }
            else if (_snakes.Any(x => x.Item1 == number || x.Item2 == number))
            {
                cellType = new Snake
                {
                    Start = _snakes.FirstOrDefault(x => x.Item1 == number || x.Item2 == number).Item1,
                    End = _snakes.FirstOrDefault(x => x.Item1 == number || x.Item2 == number).Item2
                };
            }
            else
            {
                cellType = null;
            }
            return cellType;
        }
    }
}
