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
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-H998I6S\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        public void Temizle()
        {
            txt_PersonelID.Text = "";
            txt_PerAd.Text = "";
            txt_soyad.Text = "";
            txt_sehir.Text = "";
            txt_meslek.Text = "";
            txt_maas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txt_PerAd.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet1.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);

        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) VALUES(@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txt_PerAd.Text);
            komut.Parameters.AddWithValue("@p2", txt_soyad.Text);
            komut.Parameters.AddWithValue("@p3", txt_sehir.Text);
            komut.Parameters.AddWithValue("@p4", txt_maas.Text);
            komut.Parameters.AddWithValue("@p5", txt_meslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_meslek_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txt_PersonelID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_PerAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_soyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txt_sehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txt_maas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txt_meslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if(label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if(label8.Text == "False") 
            {
                radioButton2.Checked = true;
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("DELETE FROM Tbl_Personel WHERE PerID = @k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1", txt_PersonelID.Text);
            komutsil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Kayıt silindi");

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("UPDATE Tbl_Personel SET PerAd=@c1,PerSoyad=@c2,PerSehir=@c3,PerMaas=@c4,PerDurum=@c5,PerMeslek=@c6 WHERE PerID=@c7", baglanti);
            komutguncelle.Parameters.AddWithValue("@c1", txt_PerAd.Text);
            komutguncelle.Parameters.AddWithValue("@c2", txt_soyad.Text);
            komutguncelle.Parameters.AddWithValue("@c3", txt_sehir.Text);
            komutguncelle.Parameters.AddWithValue("@c4", txt_maas.Text);
            komutguncelle.Parameters.AddWithValue("@c5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@c6", txt_meslek.Text);
            komutguncelle.Parameters.AddWithValue("@c7", txt_PersonelID.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgiler güncellendi");
        }

        private void btn_istatistik_Click(object sender, EventArgs e)
        {
            İstatistik ist = new İstatistik();
            ist.Show();
        }

        private void btn_grafik_Click(object sender, EventArgs e)
        {
            Grafikler grafikler = new Grafikler();
            grafikler.Show();
        }
    }
}
