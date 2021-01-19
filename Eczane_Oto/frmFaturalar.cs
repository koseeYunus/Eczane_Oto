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
    public partial class frmFaturalar : Form
    {
        public frmFaturalar()
        {
            InitializeComponent();
            timer1.Start();
            listele();
            firmaListele();
            calisanListele();
            hepTemizle();
        }

        string tutar="";
        string firmaId = "";
        string personel = "";
        frmFaturaUrunler faturaUrun;

        SqlBaglantısı bgl = new SqlBaglantısı();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select FAT_BIL_ID,SERINO,SIRANO,VERGI_DAIRE,FIR_ID,TARIH,SAAT,ALICI,TESLIM_EDEN,TESLIM_ALAN,FAT_NOT,FAT_TUTAR from FATURA_BILGI", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void hepTemizle()
        {
            id.Text = "";
            seriNo.Text = "";
            siraNo.Text = "";
            vDaire.Text = "";
            tarih.Text = "";
            saat.Text = "";
            alici.Text = "";
            tEden.Text = "";
            tAlan.Text = "";
            not.Text = "";
        }

        void calisanListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,AD,SOYAD from PERSONEL", bgl.baglanti());
            da.Fill(dt);
            tAlan.Properties.ValueMember = "ID";
            tAlan.Properties.DisplayMember = "AD";
            tAlan.Properties.DataSource = dt;
            bgl.baglanti().Close();
        }

        void firmaListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,FIR_ISIM from FIRMA", bgl.baglanti());
            da.Fill(dt);
            firma.Properties.ValueMember = "ID";
            firma.Properties.DisplayMember = "FIR_ISIM";
            firma.Properties.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                id.Text = dr["FAT_BIL_ID"].ToString();
                seriNo.Text = dr["SERINO"].ToString();
                siraNo.Text = dr["SIRANO"].ToString();
                vDaire.Text = dr["VERGI_DAIRE"].ToString();
                firmaId = dr["FIR_ID"].ToString();
                tarih.Text = dr["TARIH"].ToString();
                saat.Text = dr["SAAT"].ToString();
                alici.Text = dr["ALICI"].ToString();
                tEden.Text = dr["TESLIM_EDEN"].ToString();
                personel = dr["TESLIM_ALAN"].ToString();
                not.Text = dr["FAT_NOT"].ToString();
                tutar = dr["FAT_TUTAR"].ToString();
            }  
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            if (seriNo.Text != "" && siraNo.Text != "" && vDaire.Text != "" && tarih.Text != "" && saat.Text != "" && alici.Text != "" && tEden.Text != "" && tAlan.Text != "")
            {
                try
                {
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into FATURA_BILGI(SERINO,SIRANO,VERGI_DAIRE,TARIH,SAAT,ALICI,TESLIM_EDEN,TESLIM_ALAN,FIR_ID,FAT_NOT,FAT_TUTAR) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", seriNo.Text);
                    komut.Parameters.AddWithValue("@p2", siraNo.Text);
                    komut.Parameters.AddWithValue("@p3", vDaire.Text);
                    komut.Parameters.AddWithValue("@p4", tarih.Text);
                    komut.Parameters.AddWithValue("@p5", saat.Text);
                    komut.Parameters.AddWithValue("@p6", alici.Text);
                    komut.Parameters.AddWithValue("@p7", tEden.Text);
                    komut.Parameters.AddWithValue("@p8", tAlan.EditValue);
                    komut.Parameters.AddWithValue("@p9", firma.EditValue);
                    komut.Parameters.AddWithValue("@p10", not.Text);
                    komut.Parameters.AddWithValue("@p11", decimal.Parse("00,00"));

                    DialogResult gunCik = new DialogResult();
                    gunCik = MessageBox.Show("Faturayı kaydetmek istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (gunCik == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Fatura kaydetme işlemi gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        hepTemizle();
                    }
                    else
                    {
                        MessageBox.Show("Fatura kaydetme işlemi Yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        bgl.baglanti().Close();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.ToString());
                    MessageBox.Show("Lütfen Doğru Giriş Yapınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Lütfen gerekli olan bilgileri girdiğinizden emin olunuz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            hepTemizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand kontrol1 = new SqlCommand("Select COUNT(FAT_BIL_ID) From FATURA_BILGI Where FAT_BIL_ID=@k1", bgl.baglanti());
                kontrol1.Parameters.AddWithValue("@k1", int.Parse(id.Text));
                int gelen1 = Convert.ToInt32(kontrol1.ExecuteScalar());
                bgl.baglanti().Close();
                SqlCommand kontrol2 = new SqlCommand("Select COUNT(FATURA_ID) From FATURA_DETAY Where FATURA_ID=@k1", bgl.baglanti());
                kontrol2.Parameters.AddWithValue("@k1", int.Parse(id.Text));
                int gelen2 = Convert.ToInt32(kontrol2.ExecuteScalar());

                if (gelen1 != 0 || gelen2!=0)
                {
                    bgl.baglanti().Close();
                    SqlCommand sil = new SqlCommand("Delete from FATURA_BILGI where FAT_BIL_ID=@s1", bgl.baglanti());
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
                else
                {
                    MessageBox.Show("Lütfen Faturayı Silmeden Önce Faturaya Ait Ürünleri siliniz ! ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (seriNo.Text != "" && siraNo.Text != "" && vDaire.Text != "" && tarih.Text != "" && saat.Text != "" && alici.Text != "" && tEden.Text != "" && tAlan.Text != "")
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("Update FATURA_BILGI set SERINO=@G1,SIRANO=@G2,VERGI_DAIRE=@G3,TARIH=@G4,SAAT=@G5,ALICI=@G6,TESLIM_EDEN=@G7,TESLIM_ALAN=@G8,FIR_ID=@G9,FAT_NOT=@G10 Where FAT_BIL_ID=@G11", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@G1", seriNo.Text);
                    guncelle.Parameters.AddWithValue("@G2", siraNo.Text);
                    guncelle.Parameters.AddWithValue("@G3", vDaire.Text);
                    guncelle.Parameters.AddWithValue("@G4", tarih.Text);
                    guncelle.Parameters.AddWithValue("@G5", saat.Text);
                    guncelle.Parameters.AddWithValue("@G6", alici.Text);
                    guncelle.Parameters.AddWithValue("@G7", tEden.Text);
                    guncelle.Parameters.AddWithValue("@G8", tAlan.EditValue);
                    guncelle.Parameters.AddWithValue("@G9", firma.EditValue);
                    guncelle.Parameters.AddWithValue("@G10", not.Text);
                    guncelle.Parameters.AddWithValue("@G11", int.Parse(id.Text));

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
                catch (Exception hata)
                {
                    MessageBox.Show(hata.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Günecelleme Yapmak İstediğiniz Alanda Hata / Hatalar Var !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Lütfen gerekli olan bilgileri girdiğinizden emin olunuz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (id.Text!="")
            {
                SqlCommand kontrol3 = new SqlCommand("Select COUNT(FAT_BIL_ID) From FATURA_BILGI Where FAT_BIL_ID=@k1", bgl.baglanti());
                kontrol3.Parameters.AddWithValue("@k1", int.Parse(id.Text));
                int gelen3 = Convert.ToInt32(kontrol3.ExecuteScalar());
                bgl.baglanti().Close();

                if (gelen3!=0)
                {
                    faturaUrun = new frmFaturaUrunler(personel,firmaId,tutar, id.Text.Trim());                  
                    faturaUrun.Show();
                }
                else
                {
                    MessageBox.Show("Girilen ID Bulunamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                }
            }
            else
            {
                MessageBox.Show("Lütfen ID Kısmını Giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
        }
    }
    
}
