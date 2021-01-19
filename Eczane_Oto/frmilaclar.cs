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
    public partial class frmilaclar : Form
    {
        public frmilaclar()
        {
            InitializeComponent();
        }


        SqlBaglantısı bgl = new SqlBaglantısı();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from urun",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void ilacListele()
        {
            SqlCommand komut = new SqlCommand("Select DISTINCT FIR_ISIM from FIRMA", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ilacMarka.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void hepTemizle()
        {
            id.Text = "";
            barkod.Text = "";
            atcKod.Text = "";
            ilac.Text = "";
            ilacMarka.Text = "";
            etkinMad.Text = "";
            recDurum.Text = "";
            mskUretim.Text = "";
            mskSonTar.Text = "";
            numAlıs.Value = 0;
            numSatıs.Value = 0;
            aciklama.Text = "";
            dolap.Text = "";
            numRaf.Value = 0;
            numSıra.Value = 0;
            numAdet.Value = 0;
        }

        private void frmilaclar_Load(object sender, EventArgs e)
        {
            listele();
            hepTemizle();
            ilacListele();
            timer1.Start();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (barkod.Text!="" && atcKod.Text!="" && ilac.Text!="" && numAdet.Value.ToString()!="")
            {
                try
                {
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into urun(URUN,MARKA,URETIM_YIL,SON_KUL_TAR,ALIS_FIYAT,SATIS_FIYAT,ACIKLAMA,DOLAP,ADET,BARKOD,ATC_KOD,ETKIN_MADDE,RECETE_DURUM,RAF,SIRA,KAYIT_TAR) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", ilac.Text);
                    komut.Parameters.AddWithValue("@p2", ilacMarka.Text);
                    komut.Parameters.AddWithValue("@p3", mskUretim.Text);
                    komut.Parameters.AddWithValue("@p4", mskSonTar.Text);
                    komut.Parameters.AddWithValue("@p5", decimal.Parse(numAlıs.Value.ToString()));
                    komut.Parameters.AddWithValue("@p6", decimal.Parse(numSatıs.Value.ToString()));
                    komut.Parameters.AddWithValue("@p7", aciklama.Text);
                    komut.Parameters.AddWithValue("@p8", dolap.Text);
                    komut.Parameters.AddWithValue("@p9", int.Parse(numAdet.Value.ToString()));
                    komut.Parameters.AddWithValue("@p10", barkod.Text);
                    komut.Parameters.AddWithValue("@p11", atcKod.Text);
                    komut.Parameters.AddWithValue("@p12", etkinMad.Text);
                    komut.Parameters.AddWithValue("@p13", recDurum.Text);
                    komut.Parameters.AddWithValue("@p14", int.Parse(numRaf.Value.ToString()));
                    komut.Parameters.AddWithValue("@p15", int.Parse(numSıra.Value.ToString()));
                    komut.Parameters.AddWithValue("@p16", DateTime.Now.ToString());


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

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand kontrol = new SqlCommand("Select COUNT(ID) From URUN Where ID=@k1", bgl.baglanti());
                kontrol.Parameters.AddWithValue("@k1", int.Parse(id.Text));
                int gelen = Convert.ToInt32(kontrol.ExecuteScalar());

                if (gelen != 0)
                {
                    bgl.baglanti().Close();
                    SqlCommand sil = new SqlCommand("Delete from URUN where ID=@s1", bgl.baglanti());
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
                MessageBox.Show("Lütfen ID Kısmını Doldurunuz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand guncelle = new SqlCommand("Update URUN set BARKOD=@G1,URUN=@G2,MARKA=@G3,URETIM_YIL=@G4,SON_KUL_TAR=@G5,ALIS_FIYAT=@G6,SATIS_FIYAT=@G7,ACIKLAMA=@G8,DOLAP=@G9,ADET=@G10,ATC_KOD=@G12,ETKIN_MADDE=@G13,RECETE_DURUM=@G14,RAF=@G15,SIRA=@G16 Where ID=@G11", bgl.baglanti());
                guncelle.Parameters.AddWithValue("@G1", barkod.Text);
                guncelle.Parameters.AddWithValue("@G2", ilac.Text);
                guncelle.Parameters.AddWithValue("@G3", ilacMarka.Text);
                guncelle.Parameters.AddWithValue("@G4", mskUretim.Text);
                guncelle.Parameters.AddWithValue("@G5", mskSonTar.Text);
                guncelle.Parameters.AddWithValue("@G6", decimal.Parse(numAlıs.Value.ToString()));
                guncelle.Parameters.AddWithValue("@G7", decimal.Parse(numSatıs.Value.ToString()));
                guncelle.Parameters.AddWithValue("@G8", aciklama.Text);
                guncelle.Parameters.AddWithValue("@G9", dolap.Text);
                guncelle.Parameters.AddWithValue("@G10", int.Parse(numAdet.Value.ToString()));
                guncelle.Parameters.AddWithValue("@G11", int.Parse(id.Text));
                guncelle.Parameters.AddWithValue("@G12", atcKod.Text);
                guncelle.Parameters.AddWithValue("@G13", etkinMad.Text);
                guncelle.Parameters.AddWithValue("@G14", recDurum.Text);
                guncelle.Parameters.AddWithValue("@G15", int.Parse(numRaf.Value.ToString()));
                guncelle.Parameters.AddWithValue("@G16", int.Parse(numSıra.Value.ToString()));

                DialogResult gunCik = new DialogResult();
                gunCik = MessageBox.Show("Güncellemeyi yapmak istediğinize eminmisiniz ?","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
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
                MessageBox.Show("Günecelleme Yapmak İstediğiniz Alanda Hata / Hatalar Var !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }       
        }

        private void labelControl11_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            hepTemizle();
        }

        private void btnTukendi_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (id.Text!="" && barkod.Text != "" && atcKod.Text != "" && ilac.Text != "" && numAdet.Value.ToString() != "")
            {
                try
                {
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into TUKENEN_URUN(URUN,MARKA,URETIM_YIL,SON_KUL_TAR,ALIS_FIYAT,SATIS_FIYAT,ACIKLAMA,DOLAP,ADET,BARKOD,ATC_KOD,ETKIN_MADDE,RECETE_DURUM,RAF,SIRA,KAYIT_TAR) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", dr["ID"].ToString());
                    komut.Parameters.AddWithValue("@p2", dr["URUN"].ToString());
                    komut.Parameters.AddWithValue("@p3", dr["URETIM_YIL"].ToString());
                    komut.Parameters.AddWithValue("@p4", dr["SON_KUL_TAR"].ToString());
                    komut.Parameters.AddWithValue("@p5", decimal.Parse(dr["ALIS_FIYAT"].ToString()));
                    komut.Parameters.AddWithValue("@p6", decimal.Parse(dr["SATIS_FIYAT"].ToString()));
                    komut.Parameters.AddWithValue("@p7", dr["ACIKLAMA"].ToString());
                    komut.Parameters.AddWithValue("@p8", dr["DOLAP"].ToString());
                    komut.Parameters.AddWithValue("@p9", int.Parse(dr["ADET"].ToString()));
                    komut.Parameters.AddWithValue("@p10", dr["BARKOD"].ToString());
                    komut.Parameters.AddWithValue("@p11", dr["ATC_KOD"].ToString());
                    komut.Parameters.AddWithValue("@p12", dr["ETKIN_MADDE"].ToString());
                    komut.Parameters.AddWithValue("@p13", dr["RECETE_DURUM"].ToString());
                    komut.Parameters.AddWithValue("@p14", int.Parse(dr["RAF"].ToString()));
                    komut.Parameters.AddWithValue("@p15", int.Parse(dr["SIRA"].ToString()));
                    komut.Parameters.AddWithValue("@p16", DateTime.Now.ToString());


                    DialogResult gunCik = new DialogResult();
                    gunCik = MessageBox.Show("Ürünü tükendi olarak işleme alınmasını onaylıyor musunuz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (gunCik == DialogResult.Yes)
                    {
                        SqlCommand sil = new SqlCommand("Delete from URUN where ID=@s1", bgl.baglanti());
                        sil.Parameters.AddWithValue("@s1", id.Text);
                        sil.ExecuteNonQuery();
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Ürün tükendi olarak işaretlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        hepTemizle();
                    }
                    else
                    {
                        MessageBox.Show("İşlem iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        bgl.baglanti().Close();
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.ToString());
                    MessageBox.Show("Bir sorun oluştu.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Lütfen Silenecek Ürünü Seçiniz veya Id sini giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                id.Text = dr["ID"].ToString();
                barkod.Text = dr["BARKOD"].ToString();
                ilac.Text = dr["URUN"].ToString();
                ilacMarka.Text = dr["MARKA"].ToString();
                mskUretim.Text = dr["URETIM_YIL"].ToString();
                mskSonTar.Text = dr["SON_KUL_TAR"].ToString();
                numAlıs.Value = decimal.Parse(dr["ALIS_FIYAT"].ToString());
                numSatıs.Value = decimal.Parse(dr["SATIS_FIYAT"].ToString());
                aciklama.Text = dr["ACIKLAMA"].ToString();
                dolap.Text = dr["DOLAP"].ToString();
                numAdet.Value = int.Parse(dr["ADET"].ToString());
                atcKod.Text = dr["ATC_KOD"].ToString();
                etkinMad.Text = dr["ETKIN_MADDE"].ToString();
                recDurum.Text = dr["RECETE_DURUM"].ToString();
                numRaf.Value = int.Parse(dr["RAF"].ToString());
                numSıra.Value = int.Parse(dr["SIRA"].ToString());
            }
        }
    }
}
