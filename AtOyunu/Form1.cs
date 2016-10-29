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
        public Form1()
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
                s = null; // satır sütun olayından dolayı patlama var burada
                sayiMi = true;
            }

            
           
            return sayiMi;
        }
        public void Kontrol(int x, int y)
        {
            //tanımlama

            Temizle();

            //kontrol
            //
            if (y + 1 <= Y && x - 2 >= 0)
            {
                if (!sayiMi(x - 2, y + 1))
                    dgvPanel.Rows[y + 1].Cells[x - 2].Style.BackColor = Color.PaleVioletRed;
            }
            if (y + 1 <= Y && x + 2 <= X)
            {
                if (!sayiMi(x + 2, y + 1))
                    dgvPanel.Rows[y + 1].Cells[x + 2].Style.BackColor = Color.PaleVioletRed;
            }
            if (y - 1 >= 0 && x + 2 <= X)
            {
                if (!sayiMi(x + 2, y - 1))
                    dgvPanel.Rows[y - 1].Cells[x + 2].Style.BackColor = Color.PaleVioletRed;
            }
            if (y - 1 >= 0 && x - 2 >= 0)
            {
                if (!sayiMi(x - 2, y - 1))
                    dgvPanel.Rows[y - 1].Cells[x - 2].Style.BackColor = Color.PaleVioletRed;
            }
            if (y - 2 >= 0 && x + 1 <= X)
            {
                if (!sayiMi(x + 1, y - 2))
                    dgvPanel.Rows[y - 2].Cells[x + 1].Style.BackColor = Color.PaleVioletRed;
            }
            if (y - 2 >= 0 && x - 1 >= 0)
            {
                if (!sayiMi(x - 1, y - 2))
                    dgvPanel.Rows[y - 2].Cells[x - 1].Style.BackColor = Color.PaleVioletRed;
            }
            if (y + 2 <= Y && x - 1 >= 0)
            {
                if (!sayiMi(x - 1, y + 2))
                    dgvPanel.Rows[y + 2].Cells[x - 1].Style.BackColor = Color.PaleVioletRed;
            }
            if (y + 2 <= Y && x + 1 <= X)
            {
                if (!sayiMi(x + 1, y + 2))
                    dgvPanel.Rows[y + 2].Cells[x + 1].Style.BackColor = Color.PaleVioletRed;
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
            for (int i = 0; i <= X; i++)
                dt.Columns.Add();
            for (int j = 0; j <Y; j++)
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
            //int tempX = -1, tempY = -1;
            curX = dgvPanel.CurrentCellAddress.X;
            curY = dgvPanel.CurrentCellAddress.Y;
            //if(tempX==curX && tempY==curY)
            //    MessageBox.Show("Seçilemez");
            //tempX = curX;
            //tempY = curY;
            MessageBox.Show(curX.ToString() + " " + curY.ToString());
            if (k == 0)
            {
                dgvPanel.Rows[curY].Cells[curX].Value = skor;
                skor++;
                Kontrol(curX, curY);
                k++;
            }
            if (dgvPanel.Rows[curY].Cells[curX].Style.BackColor == Color.PaleVioletRed && !sayiMi(curX,curY))
            {
                dgvPanel.Rows[curY].Cells[curX].Value = skor;
                skor++;
                Kontrol(curX, curY);
            }
            else
            {
                    MessageBox.Show("Seçilemez!");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            X = 4;
            Y = 4;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            X = 5;
            Y = 5;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            X = 6;
            Y = 6;
        }
    }
}