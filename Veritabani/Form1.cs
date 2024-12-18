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
namespace Veritabani
{
    public partial class FrmAnasayfa : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0R2ACEE\SQLEXPRESS01;
        Initial Catalog=PersonelVeritabani;
        Persist Security Info=True;User ID=sa; Password= 1234");

        public FrmAnasayfa()
        {
            InitializeComponent();
        }


        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeritabaniDataSet.Tbl_Personel);

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) " +
                                                                        "values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);

            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbxSehir.Text);
            komut.Parameters.AddWithValue("@p4", maskedTxtMaas.Text);
            komut.Parameters.AddWithValue("@p5", txtMeslek.Text);
            komut.Parameters.AddWithValue("@p6",labelGizli.Text);
            komut.ExecuteNonQuery();//insert ,Update ,Delete'de kullanılıyor
            MessageBox.Show("Eklendi");
            baglanti.Close();
        }

        private void radioButtonEvli_CheckedChanged(object sender, EventArgs e)
        {
            labelGizli.Text = "True";

        }

        private void radioButtonBekar_CheckedChanged(object sender, EventArgs e)
        {
            labelGizli.Text = "False";

        }
    }
}
