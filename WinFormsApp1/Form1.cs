using System;
using System.IO;
using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    /// <summary>
    /// Варіант 38
    /// </summary>
    public partial class Form1 : Form
    {
        static DataGridView grid = new DataGridView();
        //public int[,] result = new int[grid.RowCount, grid.ColumnCount];
        static Form2 form2 = new Form2();
        //public string path = @"c:\users\aron1\desktop\matrix5.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// вибираємо файли 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select the first file", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var is_correct_matrix1 = FillGrid(dataGridView1, "matrix1.txt");
            var is_correct_matrix2 = false;
            var is_correct_matrix3 = false;
            var is_correct_matrix4 = false;
            if (is_correct_matrix1)
            {
                MessageBox.Show("Select second file", "Information", MessageBoxButtons.OK);
                is_correct_matrix2 = FillGrid(dataGridView2, "matrix2.txt");
            }
            if (is_correct_matrix2) {
                MessageBox.Show("Select third file", "Information", MessageBoxButtons.OK);
                is_correct_matrix3 = FillGrid(dataGridView3, "matrix3.txt");
            }
            if (is_correct_matrix3) {
                MessageBox.Show("Select fourth file", "Information", MessageBoxButtons.OK);
                is_correct_matrix4 = FillGrid(dataGridView4, "matrix4.txt");
            }
            if (is_correct_matrix4) MessageBox.Show("File choosing is completed!", "Information", MessageBoxButtons.OK);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool FillGrid(DataGridView grid, string filename = "")
        {
            openFileDialog1.InitialDirectory = @"C:\users\aron1\desktop";
            openFileDialog1.Title = "Select file";
            openFileDialog1.Filter = "TXT files|*.txt";
            openFileDialog1.ShowDialog();
            if(openFileDialog1.ShowDialog() != DialogResult.OK) return false;

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
                    MessageBox.Show($"Incorrect data in {openFileDialog1.FileName}, id of line: {lineId}", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                columnCount = row.Length;
                grid.Rows.Add(row);
            }

            return true;
        }
        /// <summary>
        /// парсим дані що знаходяться у файлі
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private bool ParseGrid(DataGridView grid, out int[,] matrix)
        {
            matrix = new int[grid.RowCount, grid.ColumnCount];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    try
                    {
                        matrix[i, j] = Convert.ToInt32(grid[j, i].Value);
                        //result[i, j] = Convert.ToInt32(Math.Pow(matrix[i, j], 2));
                    }
                    catch
                    {
                        MessageBox.Show($"Invalid value in cell ({i}, {j}) of {grid.Name}");
                        grid[j, i].Selected = true;
                        return false;
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// тут я хотів вивести результат першого завдання 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            form2.Show();
        }

    }
}