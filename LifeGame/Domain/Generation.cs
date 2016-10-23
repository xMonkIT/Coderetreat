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
            new Generation(_aliveCells.SelectMany(GetNeighbours).Where(x => WillBeAlive(x)));

        IEnumerable<Cell> GetNeighbours(Cell cell) =>
            Enumerable
                .Range(-1, 3)
                .SelectMany(i => Enumerable
                        .Range(-1, 3)
                        .Select(j => new Cell(cell.X + i, cell.Y + j))
                )
                .Where(x => !Equals(x, cell));

        bool WillBeAlive(Cell cell) =>
            WillBeAlive(cell, GetNeighbours(cell).Count(_aliveCells.Contains));

        bool WillBeAlive(Cell cell, int aliveNeighboursCount) =>
            aliveNeighboursCount == 3 || aliveNeighboursCount == 2 && _aliveCells.Contains(cell);
    }
}