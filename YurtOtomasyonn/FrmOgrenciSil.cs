using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YurtOtomasyonn
{
    public partial class FrmOgrenciSil : Form
    {
        public FrmOgrenciSil()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();
        private void FrmOgrenciSil_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtOtomasyonDataSet1.Ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenciTableAdapter1.Fill(this.yurtOtomasyonDataSet1.Ogrenci);
            // TODO: Bu kod satırı 'yurtOtomasyonDataSet.Ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenciTableAdapter.Fill(this.yurtOtomasyonDataSet.Ogrenci);

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("delete from Ogrenci where Ogrid=@p1  ", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtOgrID.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Başarılı Bir Şekilde Silindi...");
                this.ogrenciTableAdapter.Fill(this.yurtOtomasyonDataSet.Ogrenci);
            }
            catch (Exception)
            {
                MessageBox.Show("Hata! Silinemedi !!!");
            }
        }
        int secilen;
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string OgrID;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            OgrID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            

            txtOgrID.Text = OgrID;
            

        }
    }
}
