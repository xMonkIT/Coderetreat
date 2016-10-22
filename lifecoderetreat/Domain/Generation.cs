using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifecoderetreat.Domain
{
    class Generation
    {
        private HashSet<Cell> _aliveCells = new HashSet<Cell>();

        public IEnumerable<Cell> AliveCells => _aliveCells;

        public Generation(IEnumerable<Cell> aliveCells)
        {
            aliveCells.ToList().ForEach(x => _aliveCells.Add(x));
        }

        public IEnumerable<Cell> GetNeighbours(Cell cell)
        {
            return new List<Cell>
            {
                new Cell(-1, -1), new Cell(-1, 0), new Cell(-1, 1),
                new Cell( 0, -1),                  new Cell( 0, 1),
                new Cell( 1, -1), new Cell( 1, 0), new Cell( 1, 1)
            }.Select(x => new Cell(cell.X + x.X, cell.Y + x.Y));
        }

        public bool WillBeAlive(Cell cell)
        {
            var aliveNeghboursCount = GetNeighbours(cell).Count(_aliveCells.Contains);
            return aliveNeghboursCount == 3 || aliveNeghboursCount == 2 && _aliveCells.Contains(cell);
        }

        public Generation GetNextGeneration()
        {
            return new Generation(_aliveCells.SelectMany(GetNeighbours).Where(WillBeAlive));
        }
    }
}
