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
    public partial class FormIstatistik : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0R2ACEE\SQLEXPRESS01;
        Initial Catalog=PersonelVeritabani;
        Persist Security Info=True;User ID=sa; Password= 1234");

        public FormIstatistik()
        {
            InitializeComponent();
        }

        private void FormIstatistik_Load(object sender, EventArgs e)
        {
            ToplamPersonelSayisiniGetir();

            EvliPersonelSayisiniGetir();

            BekarPersonelSayisiniGetir();

            SehirSayisiniGetir();

            ToplamMaasGetir();

            OrtalamaMaasGetir();

        }

        private void ToplamPersonelSayisiniGetir()
        {
            //Toplam personel sayısı
            baglanti.Open();
            SqlCommand komutToplamPersonel = new SqlCommand("select count(*) From Tbl_Personel ", baglanti);
            SqlDataReader drToplamPersonel = komutToplamPersonel.ExecuteReader();
            while (drToplamPersonel.Read())
            {
                labelToplamPersonel.Text = drToplamPersonel[0].ToString();
            }
            baglanti.Close();
        }

        private void EvliPersonelSayisiniGetir()
        {
            //evli personel sayisini bulma
            baglanti.Open();
            SqlCommand komutToplamEvliPersonel = new SqlCommand("select count(*) From Tbl_Personel where PerDurum=1 ", baglanti);
            SqlDataReader drToplamEvliPersonel = komutToplamEvliPersonel.ExecuteReader();
            while (drToplamEvliPersonel.Read())
            {
                labelEvliPersonel.Text = drToplamEvliPersonel[0].ToString();
            }
            baglanti.Close();
        }

        private void BekarPersonelSayisiniGetir()
        {
            //bekar personel sayisini bulma
            baglanti.Open();
            SqlCommand komutToplamBekarPersonel = new SqlCommand("select count(*) From Tbl_Personel where PerDurum=0 ", baglanti);
            SqlDataReader drToplamBekarPersonel = komutToplamBekarPersonel.ExecuteReader();

            while (drToplamBekarPersonel.Read())
            {
                labelBekarPersonel.Text = drToplamBekarPersonel[0].ToString();
            }
            baglanti.Close();
        }

        private void SehirSayisiniGetir()
        {
            //Şehir sayisini bulma
            baglanti.Open();
            SqlCommand komutSehirSayisi = new SqlCommand("Select Count (distinct(Persehir)) From Tbl_Personel", baglanti);
            SqlDataReader drSehirSayisi = komutSehirSayisi.ExecuteReader();
            while (drSehirSayisi.Read())
            {
                labelSehir.Text = drSehirSayisi[0].ToString();
            }
            baglanti.Close();
        }

        private void ToplamMaasGetir()
        {
            //Toplam maaş
            baglanti.Open();
            SqlCommand komutToplamMaas = new SqlCommand("Select Sum(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader drToplamMaas = komutToplamMaas.ExecuteReader();
            while (drToplamMaas.Read())
            {
                labelToplamMaas.Text = drToplamMaas[0].ToString();
            }
            baglanti.Close();
        }

        private void OrtalamaMaasGetir()
        {
            //ortalama maaş  

            baglanti.Open();
            SqlCommand komutOrtalamaMaas = new SqlCommand("Select Avg(PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader drOrtMaas = komutOrtalamaMaas.ExecuteReader();
            while (drOrtMaas.Read())
            {
                labelOrtMaas.Text = drOrtMaas[0].ToString();
            }
            baglanti.Close();
        }
    }
}
