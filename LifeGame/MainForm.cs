using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LifeGame
{
    public partial class MainForm : Form
    {
        private const int CellSize = 10;

        private Generation _generation;
        private readonly IList<Cell> _tempCells = new List<Cell>();

        private Graphics _graphics;
        private readonly Brush _aliveBrush = new Pen(Color.BlueViolet).Brush;
        private readonly Color _backgroundColor = Color.FromArgb(0xFE, 0xFE, 0xE1);

        public MainForm()
        {
            InitializeComponent();

            _generation = new Generation(new List<Cell>
            {
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(2, 2),
                new Cell(1, 2),
                new Cell(0, 1),
            });

            Invalidate(true);
        }

        private void pField_Paint(object sender, PaintEventArgs e)
        {
            _graphics = pField.CreateGraphics();
            _graphics.Clear(_backgroundColor);

            _generation
                .AliveCells
                .ToList()
                .ForEach(y => _graphics.FillRectangle(_aliveBrush, y.X*CellSize, y.Y*CellSize, CellSize + 1, CellSize + 1));

            _tempCells
                .ToList()
                .ForEach(x => _graphics.FillRectangle(_aliveBrush, x.X*CellSize, x.Y*CellSize, CellSize + 1, CellSize + 1));
        }

        private void MainForm_Resize(object sender, EventArgs e) => Invalidate(true);

        private void pField_MouseClick(object sender, MouseEventArgs e)
        {
            new List<Cell> {new Cell(e.X/CellSize, e.Y/CellSize)}
                .ForEach(x => {if (_tempCells.Contains(x)) _tempCells.Remove(x); else _tempCells.Add(x);});
            pField.Invalidate(true);
        }

        private void bToggle_Click(object sender, EventArgs e)
        {
            tDelay.Enabled = !tDelay.Enabled;
            bToggle.Text = tDelay.Enabled ? "Стоп" : "Старт";
        }

        private void tDelay_Tick(object sender, EventArgs e)
        {
            _generation = new Generation(_generation.AliveCells.Concat(_tempCells)).GetNextGeneration();
            _tempCells.Clear();
            pField.Invalidate(true);
        }

        private void hsbDelay_Scroll(object sender, ScrollEventArgs e) => tDelay.Interval = hsbDelay.Value;
    }
}
