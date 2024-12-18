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
        public FrmAnasayfa()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0R2ACEE\SQLEXPRESS01;
        Initial Catalog=PersonelVeritabani;
        Persist Security Info=True;User ID=sa; Password= 1234");


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
            komut.Parameters.AddWithValue("@p6", labelGizli.Text);
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }


        #region Metodlar 

        private void Temizle()
        {
            txtAd.Text = string.Empty;
            txtId.Text = string.Empty;
            txtMeslek.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            maskedTxtMaas.Text = string.Empty;
            cmbxSehir.Text = string.Empty;
            radioButtonEvli.Checked = false;
            radioButtonBekar.Checked = false;
            txtAd.Focus();
        }

        #endregion


        private void dataGridViewKayitlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridViewKayitlar.SelectedCells[0].RowIndex;

            txtId.Text = dataGridViewKayitlar.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridViewKayitlar.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridViewKayitlar.Rows[secilen].Cells[2].Value.ToString();
            cmbxSehir.Text = dataGridViewKayitlar.Rows[secilen].Cells[3].Value.ToString();
            maskedTxtMaas.Text = dataGridViewKayitlar.Rows[secilen].Cells[4].Value.ToString();
            labelGizli.Text = dataGridViewKayitlar.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text = dataGridViewKayitlar.Rows[secilen].Cells[6].Value.ToString();

            if (labelGizli.Text == "True")
            {
                radioButtonEvli.Checked = true;
                radioButtonBekar.Checked = false;

            }
            else
            {
                radioButtonEvli.Checked = false;
                radioButtonBekar.Checked = true;

            }


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand silKomutu = new SqlCommand("Delete from Tbl_Personel where Perid=@k1", baglanti);
            silKomutu.Parameters.AddWithValue("@k1", txtId.Text);

            int Deger = silKomutu.ExecuteNonQuery();//insert ,Update ,Delete'de kullanılıyor

            baglanti.Close();
            if (Deger > 0)
            {
                MessageBox.Show("silindi");
            }
            else
            {
                MessageBox.Show("olmadı");
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelleKomutu = new SqlCommand("Update Tbl_Personel Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3," +
                                                                               "PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6" +
                                                                               " where Perid=@id",baglanti);
            guncelleKomutu.Parameters.AddWithValue("@a1", txtAd.Text);
            guncelleKomutu.Parameters.AddWithValue("@a2", txtSoyad.Text);
            guncelleKomutu.Parameters.AddWithValue("@a3", cmbxSehir.Text);
            guncelleKomutu.Parameters.AddWithValue("@a4", maskedTxtMaas.Text);
            guncelleKomutu.Parameters.AddWithValue("@a5", labelGizli.Text);
            guncelleKomutu.Parameters.AddWithValue("@a6", txtMeslek.Text);
            guncelleKomutu.Parameters.AddWithValue("@id", txtId.Text);
            guncelleKomutu.ExecuteNonQuery();
            baglanti.Close();

        }

        private void btnİstatistik_Click(object sender, EventArgs e)
        {
            FormIstatistik formIstatistik= new FormIstatistik();
            formIstatistik.Show();
        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            FormGrafikler formGrafikler= new FormGrafikler();
            formGrafikler.Show();
        }
    }
}
