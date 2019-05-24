using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace YurtOtomasyonn
{
    public partial class FrmOgrenciEkle : Form
    {
        public FrmOgrenciEkle()
        {
            InitializeComponent();
        }
        sqlBaglanti bgl = new sqlBaglanti();

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmOgrenciEkle_Load(object sender, EventArgs e)
        {
            //Bölümleri Comboboxa çeker
            SqlCommand komut = new SqlCommand("select BolumAd from Bolum",bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbOgrBolum.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();

            //Oda No ları Combobox a çeker 
            SqlCommand komut2 = new SqlCommand("select OdaNo from Odalar where OdaKapasite != OdaAktif",bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbOgrOdaNo.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into Ogrenci(OgrAd,OgrSoyad,OgrTC,OgrDogum,OgrTelefon,OgrBolum,OgrOdaNo,OgrMail,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtOgrAd.Text);
                komut.Parameters.AddWithValue("@p2", txtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p3", mskOgrTC.Text);
                komut.Parameters.AddWithValue("@p4", mskOgrDogumT.Text);
                komut.Parameters.AddWithValue("@p5", mskOgrTel.Text);
                komut.Parameters.AddWithValue("@p6", cmbOgrBolum.Text);
                komut.Parameters.AddWithValue("@p7", cmbOgrOdaNo.Text);
                komut.Parameters.AddWithValue("@p8", txtOgrMail.Text);
                komut.Parameters.AddWithValue("@p9", txtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@p10", mskVeliTel.Text);
                komut.Parameters.AddWithValue("@p11", rchAdres.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Başarıyla Kaydedildi...");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata! Kaydedilemedi!!!");
            }
        }
    }
}
