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
    public partial class AdminPaneli : Form
    {
        public AdminPaneli()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-H998I6S\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void AdminPaneli_Load(object sender, EventArgs e)
        {
           
        }

        private void btn_girisyap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Admin WHERE Kullaniciad=@p1 and Sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",txt_kullaniciadi.Text);
            komut.Parameters.AddWithValue("@p2", txt_sifre.Text);
            SqlDataReader dt1 = komut.ExecuteReader();
            if (dt1.Read())
            {
                Anaform anaform = new Anaform();
                anaform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            baglanti.Close();
        }
    }
}
