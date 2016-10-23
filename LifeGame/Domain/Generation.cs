using System.Collections.Generic;
using System.Linq;

namespace LifeGame.Domain
{
    class Generation
    {
        private readonly HashSet<Cell> _aliveCells = new HashSet<Cell>();

        public Generation(IEnumerable<Cell> cells)
        {
            cells.ToList().ForEach(x => _aliveCells.Add(x));
        }

        public IEnumerable<Cell> AliveCells => _aliveCells;

        public Generation GetNextGeneration() =>
            new Generation(_aliveCells.SelectMany(GetNeighbours).Where(WillBeAlive));

        IEnumerable<Cell> GetNeighbours(Cell cell) =>
            Enumerable
                .Range(-1, 3)
                .SelectMany(i => Enumerable
                        .Range(-1, 3)
                        .Select(j => new Cell(cell.X + i, cell.Y + j))
                )
                .Where(x => !Equals(x, cell));

        bool WillBeAlive(Cell cell) =>
            WillBeAlive(_aliveCells.Contains(cell), GetNeighbours(cell).Count(_aliveCells.Contains));

        bool WillBeAlive(bool isAlive, int aliveNeighboursCount) =>
            aliveNeighboursCount == 3 || aliveNeighboursCount == 2 && isAlive;
    }
}