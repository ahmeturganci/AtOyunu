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
    public partial class frmAt : Form
    {
        int X, Y, curX, curY, k = 0, skor = 1;
        public frmAt()
        {
            InitializeComponent();
        }
        public void Temizle()
        {
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    dgvPanel.Rows[j].Cells[i].Style.BackColor = Color.White;
                }
            }
        }
        public bool sayiMi(int x, int y)
        {
            string s;
            int n;
            bool sayiMi = false;
            try
            {
                s = dgvPanel.Rows[y].Cells[x].Value.ToString();
                if (!string.IsNullOrEmpty(s))
                    sayiMi = int.TryParse(s, out n);
            }
            catch
            {
                s = null;
                sayiMi = true;
            }

            return sayiMi;
        }
        public void Kontrol(int x, int y)
        {
            //tanımlama
            int[] skorKontrol = new int[8];
            int sayac = 0;

            //kontrol
            //
            Temizle();
            if (y + 1 <= Y && x - 2 >= 0)
            {
                if (!sayiMi(x - 2, y + 1))
                {
                    dgvPanel.Rows[y + 1].Cells[x - 2].Style.BackColor = Color.PaleVioletRed;
                    skorKontrol[0] = 1;
                }
            }
            if (y + 1 <= Y && x + 2 <= X)
            {
                if (!sayiMi(x + 2, y + 1))
                {
                    dgvPanel.Rows[y + 1].Cells[x + 2].Style.BackColor = Color.PaleVioletRed;
                    skorKontrol[1] = 1;
                }
            }
            if (y - 1 >= 0 && x + 2 <= X)
            {
                if (!sayiMi(x + 2, y - 1))
                {
                    dgvPanel.Rows[y - 1].Cells[x + 2].Style.BackColor = Color.PaleVioletRed;
                    skorKontrol[2] = 1;
                }
            }
            if (y - 1 >= 0 && x - 2 >= 0)
            {
                if (!sayiMi(x - 2, y - 1))
                {
                    dgvPanel.Rows[y - 1].Cells[x - 2].Style.BackColor = Color.PaleVioletRed;
                    skorKontrol[3] = 1;
                }
            }
            if (y - 2 >= 0 && x + 1 <= X)
            {
                if (!sayiMi(x + 1, y - 2))
                {
                    dgvPanel.Rows[y - 2].Cells[x + 1].Style.BackColor = Color.PaleVioletRed; 
                    skorKontrol[4] = 1;
                }
            }
            if (y - 2 >= 0 && x - 1 >= 0)
            {
                if (!sayiMi(x - 1, y - 2))
                {
                    dgvPanel.Rows[y - 2].Cells[x - 1].Style.BackColor = Color.PaleVioletRed;
                    skorKontrol[5] = 1;
                }
            }
            if (y + 2 <= Y && x - 1 >= 0)
            {
                if (!sayiMi(x - 1, y + 2))
                {
                    dgvPanel.Rows[y + 2].Cells[x - 1].Style.BackColor = Color.PaleVioletRed;
                    skorKontrol[6] = 1;
                }
            }
            if (y + 2 <= Y && x + 1 <= X)
            {
                if (!sayiMi(x + 1, y + 2))
                {
                    dgvPanel.Rows[y + 2].Cells[x + 1].Style.BackColor = Color.PaleVioletRed;
                    skorKontrol[7] = 1;
                }
            }

            //dizi elemanlarının hepsi sıfır ise oyun biter skoru ekrana yazdır...
            for (int i = 0; i < 8; i++)
            {
                if (skorKontrol[i] == 0)
                    sayac++;
            }
            if (sayac >= 8)
            {
                MessageBox.Show("Oyun Bitti.\n Skorunuz : " + (skor - 1).ToString(), "Oyun");
                MessageBox.Show("Yeni Sahne Yükleniyor . . .", "Oyun");
                Application.Restart();
            }
        }
        private void btnOlustur_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < X; i++)
                dt.Columns.Add();
            for (int j = 0; j < Y; j++)
                dt.Rows.Add();

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
            dgvPanel.ColumnHeadersVisible = false;
            dgvPanel.RowHeadersVisible = false;
            dgvPanel.AutoSize = true;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            radioButton6.Enabled = false;
            radioButton7.Enabled = false;
            btnOlustur.Enabled = false;
            if(X>8 && Y>8)
                this.WindowState = FormWindowState.Maximized;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            X = 5;
            Y = 5;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            X = 6;
            Y = 6;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            X = 7;
            Y = 7;
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            X = 8;
            Y = 8;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            X = 9;
            Y = 9;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            X = 10;
            Y = 10;
        }

        private void dgvPanel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            curX = dgvPanel.CurrentCellAddress.X;
            curY = dgvPanel.CurrentCellAddress.Y;
            if (k == 0) // program ilk çalıştığında
            {
                dgvPanel.Rows[curY].Cells[curX].Value = skor;
                skor++;
                Kontrol(curX, curY);
                k++;
            }
            if (dgvPanel.Rows[curY].Cells[curX].Style.BackColor == Color.PaleVioletRed && !sayiMi(curX, curY))
            {
                dgvPanel.Rows[curY].Cells[curX].Value = skor;
                skor++;
                Kontrol(curX, curY);
            }
        }
    }
}