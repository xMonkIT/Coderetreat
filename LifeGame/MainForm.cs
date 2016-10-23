using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LifeGame.Controllers;

namespace LifeGame
{
    public partial class MainForm : Form
    {
        private const int CellSize = 10;

        private readonly LifeController _life;

        private Graphics _graphics;
        private readonly Brush _aliveBrush = new Pen(Color.BlueViolet).Brush;
        private readonly Color _backgroundColor = Color.FromArgb(0xFE, 0xFE, 0xE1);

        public MainForm()
        {
            InitializeComponent();

            _life = new LifeController(
                new Tuple<int, int>(2, 0),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(0, 1)
            );

            _life.Paint += (s, e) => e
                .Cells
                .ToList()
                .ForEach(x => _graphics
                    .FillRectangle(_aliveBrush, x.Item1*CellSize, x.Item2*CellSize, CellSize + 1, CellSize + 1)
                );

            pField.Invalidate();
        }

        private void pField_Paint(object sender, PaintEventArgs e)
        {
            _graphics = pField.CreateGraphics();
            _graphics.Clear(_backgroundColor);
            _life.Invalidate();
        }

        private void MainForm_Resize(object sender, EventArgs e) => pField.Invalidate();

        private void pField_MouseClick(object sender, MouseEventArgs e)
        {
            _life.ToggleCellState(new Tuple<int, int>(e.X/CellSize, e.Y/CellSize));
            pField.Invalidate(true);
        }

        private void bToggle_Click(object sender, EventArgs e)
        {
            tDelay.Enabled = !tDelay.Enabled;
            bToggle.Text = tDelay.Enabled ? "Стоп" : "Старт";
        }

        private void tDelay_Tick(object sender, EventArgs e)
        {
            _life.Tick();
            pField.Invalidate();
        }

        private void hsbDelay_Scroll(object sender, ScrollEventArgs e) => tDelay.Interval = hsbDelay.Value;
    }
}
