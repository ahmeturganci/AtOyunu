using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtOyunu
{
    public partial class Form1 : Form
    {
        int X, Y;
        public Form1()
        {
            InitializeComponent();
        }


        public void Kontrol(int x, int y)
        {
            //kontrol

            if (y + 1 <= Y && x - 2 >= X)
                dgvPanel.Rows[y + 1].Cells[x - 2].Value = "a";

            if (y + 1 <= Y && x + 2 <= X)
                dgvPanel.Rows[y + 1].Cells[x + 2].Value = "a";

            if (y - 1 >= 0 && x + 2 <= X)
                dgvPanel.Rows[y - 1].Cells[x + 2].Value = "a";

            if (y - 1 >= 0 && x - 2 >= 0)
                dgvPanel.Rows[y - 1].Cells[x - 2].Value = "a";

            if (y - 2 >= 0 && x + 1 <= X)
                dgvPanel.Rows[y - 2].Cells[x + 1].Value = "a";

            if (y - 2 >= 0 && x - 1 >= 0)
                dgvPanel.Rows[y - 2].Cells[x - 1].Value = "a";

            if (y + 2 <= Y && x - 1 >= 0)
                dgvPanel.Rows[y + 2].Cells[x - 1].Value = "a";

            if (y + 2 <= Y && x + 1 <= X)
                dgvPanel.Rows[y + 2].Cells[x + 1].Value = "a";





        }
        private void btnOlustur_Click(object sender, EventArgs e)
        {

            MessageBox.Show(X.ToString());
            DataTable dt = new DataTable();
            for (int i = 0; i < X; i++)
            {
                dt.Columns.Add();
            }
            for (int i = 0; i < Y; i++)
            {
                dt.Rows.Add();
            }
            // bos hatalı şuan

            dgvPanel.DataSource = dt;
            foreach (DataGridViewRow row in dgvPanel.Rows)
            {
                row.Height = 50;

            }
            foreach (DataGridViewColumn col in dgvPanel.Columns)
            {
                col.Width = 50;



                dgvPanel.ColumnHeadersVisible = false;
                dgvPanel.RowHeadersVisible = false;
                dgvPanel.DefaultCellStyle.SelectionBackColor = dgvPanel.DefaultCellStyle.BackColor;
            }
            //dgvPanel.Rows[curY].Cells[curX].Value = yildiz;

            dgvPanel.ColumnHeadersVisible = false;
            dgvPanel.RowHeadersVisible = false;

            dgvPanel.AutoSize = true;

            // arr = komut.ToCharArray();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvPanel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dgvPanel.CurrentCellAddress.X.ToString() + " " + dgvPanel.CurrentCellAddress.Y.ToString());
            Kontrol(dgvPanel.CurrentCellAddress.X, dgvPanel.CurrentCellAddress.Y);

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            X = 5;
            Y = 5;
        }
    }
}
