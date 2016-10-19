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
        int X, Y,skor=1;
        public Form1()
        {
            InitializeComponent();
        }
        public void Temizle()
        {
            for (int i = 0; i < X+1; i++)
            {
                for (int j = 0; j < Y+1; j++)
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


            //x ve y koordinatına skor için değer ata

            dgvPanel.Rows[y].Cells[x].Value = skor;
            skor++;

            //kontrol

            //
            if (y + 1 <= Y && x - 2 >= 0)
                dgvPanel.Rows[y + 1].Cells[x - 2].Style.BackColor = Color.PaleVioletRed;

            if (y + 1 <= Y && x + 2 <= X)
                dgvPanel.Rows[y + 1].Cells[x + 2].Style.BackColor = Color.PaleVioletRed;

            if (y - 1 >= 0 && x + 2 <= X)
                dgvPanel.Rows[y - 1].Cells[x + 2].Style.BackColor = Color.PaleVioletRed;

            if (y - 1 >= 0 && x - 2 >= 0)
                dgvPanel.Rows[y - 1].Cells[x - 2].Style.BackColor = Color.PaleVioletRed;
            
            if (y - 2 >= 0 && x + 1 <= X)
                dgvPanel.Rows[y - 2].Cells[x + 1].Style.BackColor = Color.PaleVioletRed;

            if (y - 2 >= 0 && x - 1 >= 0)
                dgvPanel.Rows[y - 2].Cells[x - 1].Style.BackColor = Color.PaleVioletRed;

            if (y + 2 <= Y && x - 1 >= 0)
                dgvPanel.Rows[y + 2].Cells[x - 1].Style.BackColor = Color.PaleVioletRed;
          
            if (y + 2 <= Y && x + 1 <= X)
                dgvPanel.Rows[y + 2].Cells[x + 1].Style.BackColor = Color.PaleVioletRed;


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
            for (int i = 0; i < X+1; i++)
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
            MessageBox.Show(dgvPanel.CurrentCellAddress.X.ToString() + " " + dgvPanel.CurrentCellAddress.Y.ToString());
            Temizle();
            Kontrol(dgvPanel.CurrentCellAddress.X, dgvPanel.CurrentCellAddress.Y);
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
