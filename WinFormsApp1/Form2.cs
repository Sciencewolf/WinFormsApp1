using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        static Form1 form1 = new Form1();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// метод FillGrid заповнює таблицю з даними з файлу
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        /*private bool FillGrid(DataGridView grid, string filename = "")
        {
            openFileDialog1.InitialDirectory = @"C:\users\aron1\desktop";
            openFileDialog1.Title = "Select file";
            openFileDialog1.Filter = "TXT files|*.txt";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return false;

            grid.Rows.Clear();
            var scanner = new StreamReader(openFileDialog1.FileName);
            var firstLine = scanner.ReadLine();
            var row = firstLine?.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int columnCount = row?.Length ?? 0;

            if (columnCount == 0)
            {
                MessageBox.Show($"{openFileDialog1.FileName} or first line is null", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            grid.ColumnCount = columnCount;
            grid.Rows.Add(row);

            while (!scanner.EndOfStream)
            {
                var line = scanner.ReadLine();
                row = Regex.Split(line, @"\s+");
                if (row.Length != columnCount)
                {
                    int lineId = grid.RowCount + 1;
                    grid.Rows.Clear();
                    grid.Columns.Clear();
                    MessageBox.Show($"Incorrect data in {openFileDialog1.FileName}, id of line: {lineId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                columnCount = row.Length;
                grid.Rows.Add(row);
            }

            return true;
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
