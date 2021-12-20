using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VYSodev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Odev; user ID=postgres; password=Melek123");
        private void tabPage6_Click(object sender, EventArgs e)
        {

        }


        private void musteriEkle_Click(object sender, EventArgs e)
        {

            NpgsqlCommand komut = new NpgsqlCommand("select public.\"musteriekle\"(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(musteriId.Text));
            komut.Parameters.AddWithValue("@p2", musteriAd.Text);
            komut.Parameters.AddWithValue("@p3", musteriSoyad.Text);
            komut.Parameters.AddWithValue("@p4", kimlikNo.Text);
            komut.Parameters.AddWithValue("@p5", musteriTelefon.Text);
            komut.Parameters.AddWithValue("@p6", eMail.Text);
            komut.ExecuteNonQuery();
            NpgsqlCommand komut2 = new NpgsqlCommand("select public.\"islemgecmisi\"(@p1,@p2)", baglanti);
            komut2.Parameters.AddWithValue("@p2", int.Parse(musteriId.Text));
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
            komut2.ExecuteNonQuery();
            string sorgu = "select " +
                "public.\"Musteri\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Musteri\".\"ad\" as \"Ad\"," +
                "public.\"Musteri\".\"soyAd\" as \"Soyad\"," +
                "public.\"Musteri\".\"adresSayisi\" as \"Adres Sayısı\"," +
                "public.\"Musteriiletisim\".\"telNo\" as \"Telefon\"," +
                "public.\"Musteriiletisim\".\"e-mail\" as \"E-posta\"" +
                " from public.\"Musteri\" inner join public.\"Musteriiletisim\" on public.\"Musteri\".\"musteriNo\"=public.\"Musteriiletisim\".\"musteriNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView1.DataSource = vk.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select " +
                "public.\"Musteri\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Musteri\".\"ad\" as \"Ad\"," +
                "public.\"Musteri\".\"soyAd\" as \"Soyad\"," +
                "public.\"Musteri\".\"adresSayisi\" as \"Adres Sayısı\"," +
                "public.\"Musteriiletisim\".\"telNo\" as \"Telefon\"," +
                "public.\"Musteriiletisim\".\"e-mail\" as \"E-posta\"" +
                " from public.\"Musteri\" inner join public.\"Musteriiletisim\" on public.\"Musteri\".\"musteriNo\"=public.\"Musteriiletisim\".\"musteriNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView1.DataSource = vk.Tables[0];
        }

        private void musterSil_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand("select public.\"musterisil\"(@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(musteriId.Text));
            komut.ExecuteNonQuery();
            string sorgu = "select " +
                "public.\"Musteri\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Musteri\".\"ad\" as \"Ad\"," +
                "public.\"Musteri\".\"soyAd\" as \"Soyad\"," +
                "public.\"Musteri\".\"adresSayisi\" as \"Adres Sayısı\"," +
                "public.\"Musteriiletisim\".\"telNo\" as \"Telefon\"," +
                "public.\"Musteriiletisim\".\"e-mail\" as \"E-posta\"" +
                " from public.\"Musteri\" inner join public.\"Musteriiletisim\" on public.\"Musteri\".\"musteriNo\"=public.\"Musteriiletisim\".\"musteriNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView1.DataSource = vk.Tables[0];
        }

        private void musteriGuncelle_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand("select public.\"musteriguncelle\"(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(musteriId.Text));
            komut.Parameters.AddWithValue("@p2", musteriAd.Text);
            komut.Parameters.AddWithValue("@p3", musteriSoyad.Text);
            komut.Parameters.AddWithValue("@p4", kimlikNo.Text);
            komut.Parameters.AddWithValue("@p5", musteriTelefon.Text);
            komut.Parameters.AddWithValue("@p6", eMail.Text);
            komut.ExecuteNonQuery();
            string sorgu = "select " +
                "public.\"Musteri\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Musteri\".\"ad\" as \"Ad\"," +
                "public.\"Musteri\".\"soyAd\" as \"Soyad\"," +
                "public.\"Musteri\".\"adresSayisi\" as \"Adres Sayısı\"," +
                "public.\"Musteriiletisim\".\"telNo\" as \"Telefon\"," +
                "public.\"Musteriiletisim\".\"e-mail\" as \"E-posta\"" +
                " from public.\"Musteri\" inner join public.\"Musteriiletisim\" on public.\"Musteri\".\"musteriNo\"=public.\"Musteriiletisim\".\"musteriNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView1.DataSource = vk.Tables[0];
        }

        private void musteriAra_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from public.\"Musteri\" where \"musteriNo\"=" + int.Parse(musteriId.Text);
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView1.DataSource = vk.Tables[0];
        }

        private void telSigorta_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand("select public.\"telsigorta\"(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(sigortaNo.Text));
            komut.Parameters.AddWithValue("@p2", int.Parse(musteriId2.Text));
            komut.Parameters.AddWithValue("@p3", bitis.Text);
            komut.Parameters.AddWithValue("@p4", model.Text);
            komut.Parameters.AddWithValue("@p5", renk.Text);
            komut.Parameters.AddWithValue("@p6", imei.Text);
            komut.ExecuteNonQuery();

            string sorgu = "select " +
                "public.\"Sigorta\".\"sigortaNo\" as \"Sigorta ID\"," +
                "public.\"Sigorta\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Sigorta\".\"bitisTarihi\" as \"Bitiş Tarihi\"," +
                "public.\"TelefonSigortasi\".\"model\" as \"Model\"," +
                "public.\"TelefonSigortasi\".\"imei\" as \"imei\"," +
                "public.\"TelefonSigortasi\".\"renk\" as \"Renk\"" +
                " from public.\"Sigorta\" inner join public.\"TelefonSigortasi\" on public.\"Sigorta\".\"sigortaNo\"=public.\"TelefonSigortasi\".\"sigortaNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView1.DataSource = vk.Tables[0];
        }

        private void telefonListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select " +
                "public.\"Sigorta\".\"sigortaNo\" as \"Sigorta ID\"," +
                "public.\"Sigorta\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Sigorta\".\"bitisTarihi\" as \"Bitiş Tarihi\"," +
                "public.\"TelefonSigortasi\".\"model\" as \"Model\"," +
                "public.\"TelefonSigortasi\".\"imei\" as \"imei\"," +
                "public.\"TelefonSigortasi\".\"renk\" as \"Renk\"" +
                " from public.\"Sigorta\" inner join public.\"TelefonSigortasi\" on public.\"Sigorta\".\"sigortaNo\"=public.\"TelefonSigortasi\".\"sigortaNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView2.DataSource = vk.Tables[0];
        }

        private void arabaekle_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand("select public.\"arabasigorta\"(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(sigortaNo2.Text));
            komut.Parameters.AddWithValue("@p2", int.Parse(musteriId3.Text));
            komut.Parameters.AddWithValue("@p3", bitis2.Text);
            komut.Parameters.AddWithValue("@p4", model2.Text);
            komut.Parameters.AddWithValue("@p5", renk2.Text);
            komut.Parameters.AddWithValue("@p6", sasi.Text);
            komut.ExecuteNonQuery();

            string sorgu = "select " +
                "public.\"Sigorta\".\"sigortaNo\" as \"Sigorta ID\"," +
                "public.\"Sigorta\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Sigorta\".\"bitisTarihi\" as \"Bitiş Tarihi\"," +
                "public.\"ArabaSigortasi\".\"model\" as \"Model\"," +
                "public.\"ArabaSigortasi\".\"sasiNo\" as \"Şasi No\"," +
                "public.\"ArabaSigortasi\".\"renk\" as \"Renk\"" +
                " from public.\"Sigorta\" inner join public.\"ArabaSigortasi\" on public.\"Sigorta\".\"sigortaNo\"=public.\"ArabaSigortasi\".\"sigortaNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView3.DataSource = vk.Tables[0];
        }

        private void arabalistele_Click(object sender, EventArgs e)
        {
            string sorgu = "select " +
                "public.\"Sigorta\".\"sigortaNo\" as \"Sigorta ID\"," +
                "public.\"Sigorta\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Sigorta\".\"bitisTarihi\" as \"Bitiş Tarihi\"," +
                "public.\"ArabaSigortasi\".\"model\" as \"Model\"," +
                "public.\"ArabaSigortasi\".\"sasiNo\" as \"Şasi No\"," +
                "public.\"ArabaSigortasi\".\"renk\" as \"Renk\"" +
                " from public.\"Sigorta\" inner join public.\"ArabaSigortasi\" on public.\"Sigorta\".\"sigortaNo\"=public.\"ArabaSigortasi\".\"sigortaNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView3.DataSource = vk.Tables[0];
        }

        private void evEkle_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand("select public.\"evsigorta\"(@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(sigortaNo4.Text));
            komut.Parameters.AddWithValue("@p2", int.Parse(textBox22.Text));
            komut.Parameters.AddWithValue("@p3", textBox21.Text);
            komut.Parameters.AddWithValue("@p4", textBox20.Text);
            komut.ExecuteNonQuery();

            string sorgu = "select " +
                "public.\"Sigorta\".\"sigortaNo\" as \"Sigorta ID\"," +
                "public.\"Sigorta\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Sigorta\".\"bitisTarihi\" as \"Bitiş Tarihi\"," +
                "public.\"EvSigortasi\".\"adres\" as \"Adres\"" +
                " from public.\"Sigorta\" inner join public.\"EvSigortasi\" on public.\"Sigorta\".\"sigortaNo\"=public.\"EvSigortasi\".\"sigortaNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView5.DataSource = vk.Tables[0];
        }

        private void saglikEkle_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand("select public.\"sagliksigorta\"(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@p2", int.Parse(textBox25.Text));
            komut.Parameters.AddWithValue("@p3", textBox24.Text);
            komut.Parameters.AddWithValue("@p4", textBox23.Text);
            komut.Parameters.AddWithValue("@p5", textBox19.Text);
            komut.Parameters.AddWithValue("@p6", textBox18.Text);
            komut.ExecuteNonQuery();

            string sorgu = "select " +
                "public.\"Sigorta\".\"sigortaNo\" as \"Sigorta ID\"," +
                "public.\"Sigorta\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Sigorta\".\"bitisTarihi\" as \"Bitiş Tarihi\"," +
                "public.\"SaglikSigortasi\".\"ad\" as \"Sigortalı Adı\"," +
                "public.\"SaglikSigortasi\".\"soyAd\" as \"Sigortalı Soyadı\"," +
                "public.\"SaglikSigortasi\".\"kimlikNo\" as \"Sigortalı Kimlik\"" +
                " from public.\"Sigorta\" inner join public.\"SaglikSigortasi\" on public.\"Sigorta\".\"sigortaNo\"=public.\"SaglikSigortasi\".\"sigortaNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView5.DataSource = vk.Tables[0];
        }

        private void personelAdresEkle_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand("select public.\"personeladresekle\"(@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox26.Text));
            komut.Parameters.AddWithValue("@p2", textBox28.Text);
            komut.ExecuteNonQuery();

            string sorgu = "select * from public.\"PersonelAdres\"";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView6.DataSource = vk.Tables[0];
        }

        private void eskipersonel_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from public.\"EskiPersonel\"";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView7.DataSource = vk.Tables[0];
        }

        private void eskiMusteri_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from public.\"EskiMusteri\"";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView7.DataSource = vk.Tables[0];
        }

        private void evListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select " +
                "public.\"Sigorta\".\"sigortaNo\" as \"Sigorta ID\"," +
                "public.\"Sigorta\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Sigorta\".\"bitisTarihi\" as \"Bitiş Tarihi\"," +
                "public.\"EvSigortasi\".\"adres\" as \"Adres\"" +
                " from public.\"Sigorta\" inner join public.\"EvSigortasi\" on public.\"Sigorta\".\"sigortaNo\"=public.\"EvSigortasi\".\"sigortaNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView4.DataSource = vk.Tables[0];
        }

        private void saglikListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select " +
                "public.\"Sigorta\".\"sigortaNo\" as \"Sigorta ID\"," +
                "public.\"Sigorta\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Sigorta\".\"bitisTarihi\" as \"Bitiş Tarihi\"," +
                "public.\"SaglikSigortasi\".\"ad\" as \"Sigortalı Adı\"," +
                "public.\"SaglikSigortasi\".\"soyAd\" as \"Sigortalı Soyadı\"," +
                "public.\"SaglikSigortasi\".\"kimlikNo\" as \"Sigortalı Kimlik\"" +
                " from public.\"Sigorta\" inner join public.\"SaglikSigortasi\" on public.\"Sigorta\".\"sigortaNo\"=public.\"SaglikSigortasi\".\"sigortaNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView5.DataSource = vk.Tables[0];
        }

        private void musteriAdresEkle_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand("select public.\"musteriadresekle\"(@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox26.Text));
            komut.Parameters.AddWithValue("@p2", textBox28.Text);
            komut.ExecuteNonQuery();

            string sorgu = "select * from public.\"MusteriAdres\"";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView6.DataSource = vk.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from public.\"MusteriAdres\"";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView6.DataSource = vk.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from public.\"PersonelAdres\"";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView6.DataSource = vk.Tables[0];
        }

        private void islemGecmisi_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from public.\"Hizmet\"";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView7.DataSource = vk.Tables[0];
        }

        private void musteriListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select " +
                "public.\"Musteri\".\"musteriNo\" as \"Müşteri ID\"," +
                "public.\"Musteri\".\"ad\" as \"Ad\"," +
                "public.\"Musteri\".\"soyAd\" as \"Soyad\"," +
                "public.\"Musteri\".\"adresSayisi\" as \"Adres Sayısı\"," +
                "public.\"Musteriiletisim\".\"telNo\" as \"Telefon\"," +
                "public.\"Musteriiletisim\".\"e-mail\" as \"E-posta\"" +
                " from public.\"Musteri\" inner join public.\"Musteriiletisim\" on public.\"Musteri\".\"musteriNo\"=public.\"Musteriiletisim\".\"musteriNo\";";
            NpgsqlDataAdapter veri = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet vk = new DataSet();
            veri.Fill(vk);
            dataGridView1.DataSource = vk.Tables[0];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
