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
    public partial class FormGrafikler : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-0R2ACEE\SQLEXPRESS01;
        Initial Catalog=PersonelVeritabani;
        Persist Security Info=True;User ID=sa; Password= 1234");


        public FormGrafikler()
        {
            InitializeComponent();
        }

        private void FormGrafikler_Load(object sender, EventArgs e)
        {
            SehirGrafigiGetir();
            MaasMeslekGrafigiGetir();

        }

        private void MaasMeslekGrafigiGetir()
        {
            //Maaş grafiği
            baglanti.Open();
            SqlCommand komutGrafikMaas = new SqlCommand("Select PerMeslek,Avg(PerMaas) From Tbl_Personel group by PerMeslek", baglanti);
            SqlDataReader drGrafikMaas = komutGrafikMaas.ExecuteReader();
            while (drGrafikMaas.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(drGrafikMaas[0], drGrafikMaas[1]);
            }
            baglanti.Close();
        }

        private void SehirGrafigiGetir()
        {
            //Şehirlerin grafiği
            baglanti.Open();
            SqlCommand komutGrafikSehir = new SqlCommand("Select PerSehir,Count(*) From Tbl_Personel Group By PerSehir", baglanti);
            SqlDataReader drGrafikSehir = komutGrafikSehir.ExecuteReader();
            while (drGrafikSehir.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(drGrafikSehir[0], drGrafikSehir[1]);
            }
            baglanti.Close();
        }
    }
}
