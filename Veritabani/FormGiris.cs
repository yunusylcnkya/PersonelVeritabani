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
    public partial class FormGiris : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0R2ACEE\SQLEXPRESS01;
        Initial Catalog=PersonelVeritabani;
        Persist Security Info=True;User ID=sa; Password= 1234");
       
        public FormGiris()
        {
            InitializeComponent();
        }

        private void buttonGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@p1 and KullaniciSifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1", textBoxKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2",textBoxSifre.Text);
            SqlDataReader reader = komut.ExecuteReader();

            if (reader.Read())
            {
                FrmAnasayfa frmAnasayfa = new FrmAnasayfa();
                frmAnasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı yada şifre");
            }
            baglanti.Close();
        }
    }
}
