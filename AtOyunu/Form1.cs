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
        int X, Y, curX, curY, k = 0, skor = 1;
        bool devamEt = false;
        int[,] kontrol;
        public Form1()
        {
            InitializeComponent();
        }
        public void Temizle()
        {
            for (int i = 0; i < X + 1; i++)
            {
                for (int j = 0; j < Y + 1; j++)
                {
                    dgvPanel.Rows[j].Cells[i].Style.BackColor = Color.White;
                }
            }
        }

        public void Kontrol(int x, int y)
        {
            //tanımlama
            //int[] skorKontrol = new int[7];
            //int sayac=0;

            kontrol = new int[X + 1, Y + 1];
            devamEt = false;
            //x ve y koordinatına skor için değer ata

            dgvPanel.Rows[y].Cells[x].Value = skor;
            skor++;

            //kontrol
            //
            if (y + 1 <= Y && x - 2 >= 0)
            {
                dgvPanel.Rows[y + 1].Cells[x - 2].Style.BackColor = Color.PaleVioletRed;
                kontrol[y + 1, x - 2] = 1;
            }
            if (y + 1 <= Y && x + 2 <= X)
            {
                dgvPanel.Rows[y + 1].Cells[x + 2].Style.BackColor = Color.PaleVioletRed;
                kontrol[y + 1, x + 2] = 1;
            }
            if (y - 1 >= 0 && x + 2 <= X)
            {
                dgvPanel.Rows[y - 1].Cells[x + 2].Style.BackColor = Color.PaleVioletRed;
                kontrol[y - 1, x + 2] = 1;
            }
            if (y - 1 >= 0 && x - 2 >= 0)
            {
                dgvPanel.Rows[y - 1].Cells[x - 2].Style.BackColor = Color.PaleVioletRed;
                kontrol[y - 1, x - 2] = 1;
            }
            if (y - 2 >= 0 && x + 1 <= X)
            {
                dgvPanel.Rows[y - 2].Cells[x + 1].Style.BackColor = Color.PaleVioletRed;
                kontrol[y - 2, x + 1] = 1;
            }
            if (y - 2 >= 0 && x - 1 >= 0)
            {
                dgvPanel.Rows[y - 2].Cells[x - 1].Style.BackColor = Color.PaleVioletRed;
                kontrol[y - 2, x - 1] = 1;
            }
            if (y + 2 <= Y && x - 1 >= 0)
            {
                dgvPanel.Rows[y + 2].Cells[x - 1].Style.BackColor = Color.PaleVioletRed;
                kontrol[y + 2, x - 1] = 1;
            }
            if (y + 2 <= Y && x + 1 <= X)
            {
                dgvPanel.Rows[y + 2].Cells[x + 1].Style.BackColor = Color.PaleVioletRed;
                kontrol[y + 2, x + 1] = 1;
            }



            // dizi elemanlarının hepsi sıfır ise oyun biter skoru ekrana yazdır...
            //for (int i = 0; i < skorKontrol.Length; i++)
            //{
            //    if (skorKontrol[i] == 0)
            //        sayac++;
            //}
            //if (sayac == 7)
            //{
            //    if (skor != x * y)
            //        MessageBox.Show("Oyun Bitti.\n Skorunuz : " + skor.ToString(), "Oyun");
            //}
        }
        private void btnOlustur_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < X + 1; i++)
                dt.Columns.Add();
            for (int i = 0; i < Y; i++)
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
        }

        private void dgvPanel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            curX = dgvPanel.CurrentCellAddress.X;
            curY = dgvPanel.CurrentCellAddress.Y;
            MessageBox.Show(curX.ToString() + " " + curY.ToString());
            if (k == 0)
            {
                Kontrol(curX, curY);
                k++;
            }
            else
            {
                for (int i = 0; i < X + 1; i++)
                {
                    for (int j = 0; j < Y + 1; j++)
                    {
                        if (kontrol[i, j] == 1)
                        {
                            if (i == curX && j == curY)
                            {
                                Kontrol(i, j);
                                devamEt = true;
                            }
                        }
                    }
                }
            }
            if (devamEt == true)
            {
                Temizle();
                devamEt = false;
                Kontrol(curX, curY);
            }
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
    }
}