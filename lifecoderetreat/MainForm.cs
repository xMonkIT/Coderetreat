using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using lifecoderetreat.Domain;

namespace lifecoderetreat
{
    public partial class MainForm : Form
    {
        private Generation _generation;

        public MainForm()
        {
            InitializeComponent();
            Enumerable
                .Range(0, 10)
                .ToList()
                .ForEach(i => dgvField.Columns.Add("", ""));
            FieldClear();
        }

        public void FieldClear()
        {
            dgvField.Rows.Clear();
            Enumerable
                .Range(0, 10)
                .ToList()
                .ForEach(i => dgvField.Rows.Add());
        }

        IEnumerable<Cell> ReadFromTable()
        {
            for (int i = 0; i < dgvField.RowCount; i++)
            {
                for (int j = 0; j < dgvField.ColumnCount; j++)
                {
                    if (dgvField[j, i] .Value?.ToString() == "Ж")
                    {
                        yield return new Cell(i, j);
                    }
                }
            }
        }

        void WriteToTable(IEnumerable<Cell> aliveCells)
        {
            FieldClear();
            aliveCells.ToList().ForEach(x =>
            {
                try
                {
                    dgvField[x.Y, x.X].Value = "Ж";
                }
                catch (Exception)
                {
                    // nope
                }
            });
        }

        private async void bStart_Click(object sender, EventArgs e)
        {
            _generation = new Generation(ReadFromTable());
            while (true)
            {
                await Task.Delay(300);
                DoWork();
            }
        }

        private void DoWork()
        {
            _generation = _generation.GetNextGeneration();
            WriteToTable(_generation.AliveCells);
        }
    }
}
