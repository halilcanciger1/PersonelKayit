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

namespace Personel_kayit1
{
    public partial class Grafikler : Form
    {
        public Grafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-H998I6S\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void Grafikler_Load(object sender, EventArgs e)
        {
            //Grafik 1
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("SELECT PerSehir,Count(*) FROM Tbl_Personel GROUP BY PerSehir",baglanti);
            SqlDataReader g1 = komutg1.ExecuteReader();
            while (g1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(g1[0], g1[1]);
            }
            baglanti.Close();

            //Grafik 2
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("SELECT PerMeslek,Avg(PerMaas) FROM Tbl_Personel GROUP BY PerMeslek",baglanti);
            SqlDataReader g2 = komutg2.ExecuteReader();
            while (g2.Read())
            {
                chart2.Series["Ortalama maas"].Points.AddXY(g2[0], g2[1]);
            }
            baglanti.Close();
        }
    }
}
