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

namespace Eczane_Oto
{
    public partial class frmPersoneller : Form
    {
        public frmPersoneller()
        {
            InitializeComponent();
        }
        SqlBaglantısı bgl = new SqlBaglantısı();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from PERSONEL", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource=dt;
            bgl.baglanti().Close();
        }

        void hepTemizle()
        {
            id.Text = "";
            tc.Text = "";
            isim.Text = "";
            soyIsim.Text = "";
            mskTelefon.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";
            adres.Text = "";
            gorev.SelectedIndex = 0;
            mailPer.Text = "";
        }

        void sehirListele()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void frmPersoneller_Load(object sender, EventArgs e)
        {
            listele();
            hepTemizle();
            sehirListele();
            timer1.Start();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from ILCELER where SEHIR=@s1", bgl.baglanti());
            komut.Parameters.AddWithValue("@s1", cmbil.SelectedIndex + 1);
            SqlDataReader da = komut.ExecuteReader();
            while (da.Read())
            {
                cmbilce.Properties.Items.Add(da[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                id.Text = dr["ID"].ToString();
                tc.Text = dr["TC"].ToString();
                isim.Text = dr["AD"].ToString();
                soyIsim.Text = dr["SOYAD"].ToString();
                mskTelefon.Text = dr["TELEFON"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                adres.Text = dr["ADRES"].ToString();
                gorev.Text = dr["GOREV"].ToString();
                mailPer.Text = dr["MAIL"].ToString();
                maas.Text = dr["MAAS"].ToString();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (mailPer.Text != "" && tc.Text != "" && isim.Text != "" && soyIsim.Text != "" && mskTelefon.Text != "" && gorev.Text != "" && gorev.Text != "Seçiniz")
            {
                try
                {
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into PERSONEL(TC,AD,SOYAD,TELEFON,IL,ILCE,GOREV,ADRES,KAYIT_TAR,MAIL,MAAS) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", tc.Text);
                    komut.Parameters.AddWithValue("@p2", isim.Text);
                    komut.Parameters.AddWithValue("@p3", soyIsim.Text);
                    komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
                    komut.Parameters.AddWithValue("@p5", cmbil.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@p6", cmbilce.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@p7", gorev.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@p8", adres.Text);
                    komut.Parameters.AddWithValue("@p9", DateTime.Now.ToString());
                    komut.Parameters.AddWithValue("@p10", mailPer.Text);
                    komut.Parameters.AddWithValue("@p11", decimal.Parse(maas.Value.ToString()));

                    DialogResult gunCik = new DialogResult();
                    gunCik = MessageBox.Show("Eklemek istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (gunCik == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Ekleme işlemi gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        hepTemizle();
                    }
                    else
                    {
                        MessageBox.Show("Ekleme işlemi Yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        bgl.baglanti().Close();
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(hata.ToString());
                    MessageBox.Show("Lütfen Doğru Giriş Yapınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Lütfen gerekli olan bilgileri girdiğinizden emin olunuz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand kontrol = new SqlCommand("Select COUNT(ID) From PERSONEL Where ID=@k1", bgl.baglanti());
                kontrol.Parameters.AddWithValue("@k1", int.Parse(id.Text));
                int gelen = Convert.ToInt32(kontrol.ExecuteScalar());

                if (gelen != 0)
                {
                    bgl.baglanti().Close();
                    SqlCommand sil = new SqlCommand("Delete from PERSONEL where ID=@s1", bgl.baglanti());
                    sil.Parameters.AddWithValue("@s1", id.Text);

                    DialogResult gunCik = new DialogResult();
                    gunCik = MessageBox.Show("Silmek istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (gunCik == DialogResult.Yes)
                    {
                        sil.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Silme işlemi gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        hepTemizle();
                    }
                    else
                    {
                        MessageBox.Show("Silme işlemi Yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        bgl.baglanti().Close();
                    }
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(hata.ToString());
                MessageBox.Show("Lütfen ID Kısmını Doldurunuz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (tc.Text != "" && isim.Text != "" && soyIsim.Text != "" && mskTelefon.Text != "" && gorev.Text != "" && gorev.Text != "Seçiniz")
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("Update PERSONEL set TC=@G1,AD=@G2,SOYAD=@G3,TELEFON=@G4,IL=@G5,ILCE=@G6,GOREV=@G7,ADRES=@G8,MAIL=@G10,MAAS=@G11 Where ID=@G9", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@G1", tc.Text);
                    guncelle.Parameters.AddWithValue("@G2", isim.Text);
                    guncelle.Parameters.AddWithValue("@G3", soyIsim.Text);
                    guncelle.Parameters.AddWithValue("@G4", mskTelefon.Text);
                    guncelle.Parameters.AddWithValue("@G5", cmbil.SelectedItem.ToString());
                    guncelle.Parameters.AddWithValue("@G6", cmbilce.SelectedItem.ToString());
                    guncelle.Parameters.AddWithValue("@G7", gorev.SelectedItem.ToString());
                    guncelle.Parameters.AddWithValue("@G8", adres.Text);
                    guncelle.Parameters.AddWithValue("@G9", int.Parse(id.Text));
                    guncelle.Parameters.AddWithValue("@G10", mailPer.Text);
                    guncelle.Parameters.AddWithValue("@G11", decimal.Parse(maas.Value.ToString()));

                    DialogResult gunCik = new DialogResult();
                    gunCik = MessageBox.Show("Güncellemeyi yapmak istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (gunCik == DialogResult.Yes)
                    {
                        guncelle.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Güncelleme işlemi gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        hepTemizle();
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme Yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        bgl.baglanti().Close();
                    }

                }
                catch (Exception)
                {
                    //MessageBox.Show(hata.ToString(),"HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    MessageBox.Show("Günecelleme Yapmak İstediğiniz Alanda Hata / Hatalar Var !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Lütfen gerekli olan bilgileri girdiğinizden emin olunuz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            hepTemizle();
        }
    }
}
