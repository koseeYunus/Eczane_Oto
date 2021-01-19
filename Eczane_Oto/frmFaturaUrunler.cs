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
    public partial class frmFaturaUrunler : Form
    {
        public string personel_id="";
        public string firma_id="";
        public string toplam_tutar="";
        public string gelen_Id = "";

        public frmFaturaUrunler(string personelId, string firmaId, string toplamTutar, string gelenId)
        {
            InitializeComponent();
            timer1.Start();
            personel_id = personelId;
            firma_id = firmaId;
            toplam_tutar = toplamTutar;
            gelen_Id = gelenId;
            listele();
        }

        SqlBaglantısı bgl = new SqlBaglantısı();

        void listele()
        {
            frmFaturalar frmurun = new frmFaturalar();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select FAT_URUN_ID,URUN,MIKTAR,FIYAT,TUTAR from FATURA_DETAY Where FATURA_ID='" + gelen_Id+"'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void hepTemizle()
        {
            urunID.Text = "";
            urun.Text = "";
            miktar.Text = "";
            fiyat.Text = "";
            tutar.Text = "";          
        }

        void hareketEkle(string islem)
        {
            SqlCommand hareket = new SqlCommand("insert into HAREKETLER_FIRMA(URUN_ID,ADET,PERSONEL_ID,FIRMA_ID,FIYAT,TOPLAM,FATURA_ID,TARIH,ISLEM) values(@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8,@h9)", bgl.baglanti());
            hareket.Parameters.AddWithValue("@h1", int.Parse(urunID.Text));
            hareket.Parameters.AddWithValue("@h2", int.Parse(miktar.Value.ToString()));
            hareket.Parameters.AddWithValue("@h3", int.Parse(personel_id));
            hareket.Parameters.AddWithValue("@h4", int.Parse(firma_id));
            hareket.Parameters.AddWithValue("@h5", decimal.Parse(fiyat.Value.ToString()));
            hareket.Parameters.AddWithValue("@h6", decimal.Parse(toplam_tutar));
            hareket.Parameters.AddWithValue("@h7", int.Parse(gelen_Id));
            hareket.Parameters.AddWithValue("@h8", DateTime.Now.ToString());
            hareket.Parameters.AddWithValue("@h9", islem);
            hareket.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (urun.Text != "" && miktar.Text != "" && fiyat.Text != "" && tutar.Text != "")
            {
                try
                {         
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into FATURA_DETAY(FAT_URUN_ID,URUN,MIKTAR,FIYAT,TUTAR,FATURA_ID) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", urunID.Text);
                    komut.Parameters.AddWithValue("@p2", urun.Text);
                    komut.Parameters.AddWithValue("@p3", decimal.Parse(miktar.Value.ToString()));
                    komut.Parameters.AddWithValue("@p4", decimal.Parse(fiyat.Value.ToString()));
                    komut.Parameters.AddWithValue("@p5", decimal.Parse(tutar.Value.ToString()));
                    komut.Parameters.AddWithValue("@p6", int.Parse(gelen_Id));

                    DialogResult gunCik = new DialogResult();
                    gunCik = MessageBox.Show("Eklemek istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (gunCik == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        hareketEkle("Ekleme Yapıldı");

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
                catch (Exception hata)
                {
                    MessageBox.Show("Lütfen Doğru Giriş Yapınız."+hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SqlCommand kontrol = new SqlCommand("Select COUNT(FAT_URUN_ID) From FATURA_DETAY Where FAT_URUN_ID=@k1", bgl.baglanti());
                kontrol.Parameters.AddWithValue("@k1", int.Parse(urunID.Text));
                int gelen = Convert.ToInt32(kontrol.ExecuteScalar());

                if (gelen != 0)
                {
                    bgl.baglanti().Close();
                    SqlCommand sil = new SqlCommand("Delete from FATURA_DETAY where FAT_URUN_ID=@s1 and FATURA_ID=@s2", bgl.baglanti());
                    sil.Parameters.AddWithValue("@s1", urunID.Text);
                    sil.Parameters.AddWithValue("@s2", int.Parse(gelen_Id));

                    DialogResult gunCik = new DialogResult();
                    gunCik = MessageBox.Show("Silmek istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (gunCik == DialogResult.Yes)
                    {
                        sil.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        hareketEkle("Silme Yapıldı");

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
                MessageBox.Show("Lütfen ID Kısmını Doldurunuz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                urunID.Text = dr["FAT_URUN_ID"].ToString();
                urun.Text = dr["URUN"].ToString();
                miktar.Value = decimal.Parse(dr["MIKTAR"].ToString());
                fiyat.Value = decimal.Parse(dr["FIYAT"].ToString());
                tutar.Value = decimal.Parse(dr["TUTAR"].ToString());
            }           
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            hepTemizle();
        }

        private void miktar_ValueChanged(object sender, EventArgs e)
        {
            tutar.Value = miktar.Value * fiyat.Value;
        }

        private void fiyat_ValueChanged(object sender, EventArgs e)
        {
            tutar.Value = miktar.Value * fiyat.Value;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (urunID.Text != "" && urun.Text != "" && miktar.Text != "" && fiyat.Text != "" && tutar.Text != "")
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("Update FATURA_DETAY set FAT_URUN_ID=@G1,URUN=@G2,MIKTAR=@G3,FIYAT=@G4,TUTAR=@G5 Where FAT_URUN_ID=@G6 and FATURA_ID=@G7", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@G1", urunID.Text);
                    guncelle.Parameters.AddWithValue("@G2", urun.Text);
                    guncelle.Parameters.AddWithValue("@G3", decimal.Parse(miktar.Value.ToString()));
                    guncelle.Parameters.AddWithValue("@G4", decimal.Parse(fiyat.Value.ToString()));
                    guncelle.Parameters.AddWithValue("@G5", decimal.Parse(tutar.Value.ToString()));
                    guncelle.Parameters.AddWithValue("@G6", int.Parse(urunID.Text));
                    guncelle.Parameters.AddWithValue("@G7", int.Parse(gelen_Id));

                    DialogResult gunCik = new DialogResult();
                    gunCik = MessageBox.Show("Güncellemeyi yapmak istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (gunCik == DialogResult.Yes)
                    {
                        guncelle.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        hareketEkle("Güncelleme yapıldı");

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridView1.SelectAll();
            int[] rowhandles = gridView1.GetSelectedRows();

            Decimal toplamTutar = 00.00m;
            foreach (int i in rowhandles)
            {
                toplamTutar = toplamTutar + Decimal.Parse(gridView1.GetRowCellValue(i, gridView1.Columns["TUTAR"]).ToString());
            }

            try
            {
                SqlCommand guncelleFatura = new SqlCommand("Update FATURA_BILGI set FAT_TUTAR=@G1 Where FAT_BIL_ID=@G2", bgl.baglanti());
                guncelleFatura.Parameters.AddWithValue("@G1", toplamTutar);
                guncelleFatura.Parameters.AddWithValue("@G2", int.Parse(gelen_Id));

                DialogResult gunCik = new DialogResult();
                gunCik = MessageBox.Show("Kaydetmek istediğinize emin misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (gunCik == DialogResult.Yes)
                {
                    guncelleFatura.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Kaydedildi ..", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ((frmFaturalar)Application.OpenForms["frmFaturalar"]).listele();
                    hepTemizle();
                }
                else
                {
                    MessageBox.Show("İptal Edildi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    bgl.baglanti().Close();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Kaydetmek İstediğiniz Alanda Hata / Hatalar Var !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            SqlCommand bul = new SqlCommand("Select URUN,ALIS_FIYAT from URUN where ID='"+ int.Parse(urunID.Text) + "'", bgl.baglanti());

            SqlDataReader dr = bul.ExecuteReader();
            while (dr.Read())
            {
                urun.Text = dr["URUN"].ToString();
                fiyat.Value =decimal.Parse(dr["ALIS_FIYAT"].ToString());
            }
        }

        private void frmFaturaUrunler_Load(object sender, EventArgs e)
        {

        }
    }
}
