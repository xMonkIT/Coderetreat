using System;
using System.Collections.Generic;
using System.Linq;
using LifeGame.Domain;

namespace LifeGame.Controllers
{
    class LifeController
    {
        private Generation _generation;
        private IEnumerable<Cell> _tempCells = new List<Cell>();

        public Generation Generation => _generation;

        public LifeController(params Tuple<int, int>[] cellsCoords)
        {
            _generation = new Generation(cellsCoords.Select(x => new Cell(x.Item1, x.Item2)));
        }

        public class LifePaintEventArgs : EventArgs { public IEnumerable<Tuple<int, int>> Cells; }

        public delegate void LifePaintEventHandler(object sender, LifePaintEventArgs e);

        public event LifePaintEventHandler Paint;

        public void Invalidate() =>
            Paint?.Invoke(this, new LifePaintEventArgs {Cells = _generation
                .AliveCells
                .Concat(_tempCells)
                .Select(x => new Tuple<int, int>(x.X, x.Y))
            });

        public void Tick()
        {
            _generation = new Generation(_generation.AliveCells.Concat(_tempCells)).GetNextGeneration();
            _tempCells = new List<Cell>();
        }

        public void ToggleCellState(Tuple<int, int> cell) =>
            ToggleCellState(new Cell(cell.Item1, cell.Item2));

        private void ToggleCellState(Cell cell)
        {
            _tempCells = _tempCells.Contains(cell)
                ? _tempCells.Where(y => !y.Equals(cell))
                : _tempCells.Concat(new List<Cell> {cell});
        }
    }
}
