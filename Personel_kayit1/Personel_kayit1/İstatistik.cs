using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personel_kayit1
{
    public partial class İstatistik : Form
    {
        public İstatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-H998I6S\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void İstatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbl_Toplamper.Text = dr1[0].ToString();
            }

            baglanti.Close();

            //Evli personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel WHERE PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lbl_evliper.Text = dr2[0].ToString();
            }

            baglanti.Close();

            //Bekar personel sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel WHERE PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lbl_bekarper.Text = dr3[0].ToString();
            }

            baglanti.Close();

            //Şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("SELECT COUNT(distinct(PerSehir)) FROM Tbl_Personel", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lbl_sehirsayisi.Text = dr4[0].ToString();
            }

            //Toplam maas
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("SELECT SUM(PerMaas) FROM Tbl_Personel",baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbl_toplammaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Ortalama maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("SELECT AVG(PerMaas) FROM Tbl_Personel",baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lbl_ortmaas.Text = dr6[0].ToString();
            }
            baglanti.Close();

        }
    }
}
