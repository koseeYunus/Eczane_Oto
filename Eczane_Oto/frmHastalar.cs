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
using System.Collections;

namespace Eczane_Oto
{
    public partial class frmHastalar : Form
    {
        public frmHastalar()
        {
            InitializeComponent();
        }

        SqlBaglantısı bgl = new SqlBaglantısı();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select HASTA.ID,HASTA.TC,ISIM,SOYISIM,HASTA.TELEFON,HASTA.IL,HASTA.ILCE,PERSONEL.AD+' '+PERSONEL.SOYAD as 'PERSONEL',HASTA.KAYIT_TAR,TOPLAM_TUTAR from HASTA INNER JOIN PERSONEL ON HASTA.VEREN_PER=PERSONEL.ID ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void ilacListele2()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select DISTINCT ID as 'ILAC_ID',URUN,BARKOD,ATC_KOD,MARKA,SATIS_FIYAT from urun", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
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
            tAlan.Text = "";
        }

        void sehirListele()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR from ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
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

        void verIlacListele()
        {
            if (id.Text != "")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT URUN.ID as 'URUN_ID',URUN.URUN,URUN.MARKA,HASTA_DETAY.ILAC_ADET,URUN.SATIS_FIYAT,HASTA_DETAY.ILAC_TUTAR,HASTA_DETAY.HASTA_DETAY_ID as 'ID' FROM HASTA_DETAY INNER JOIN HASTA ON HASTA_DETAY.HASTA_ID=HASTA.ID INNER JOIN URUN ON HASTA_DETAY.ILAC_ID=URUN.ID WHERE HASTA_DETAY.HASTA_ID='" + id.Text + "'", bgl.baglanti());
                da.Fill(dt);
                gridControl3.DataSource = dt;
                bgl.baglanti().Close();
            }
            else
            {
                gridControl3.DataSource = null;
            }
        }

        private void frmHastalar_Load(object sender, EventArgs e)
        {
            listele();
            ilacListele2();
            hepTemizle();
            sehirListele();
            calisanListele();
            timer1.Start();
        }

        void hareketEkle(string islem)
        {
            decimal toplam = (secilen_Ilac_Fiyat * decimal.Parse(ilac_adet.Value.ToString()));
            SqlCommand hareket = new SqlCommand("insert into HAREKETLER_HASTA(URUN_ID,ADET,PERSONEL_ID,HASTA_ID,FIYAT,TOPLAM,TARIH,ISLEM) values(@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", bgl.baglanti());
            hareket.Parameters.AddWithValue("@h1", secilen_Ilac_Id);
            hareket.Parameters.AddWithValue("@h2", int.Parse(ilac_adet.Value.ToString()));
            hareket.Parameters.AddWithValue("@h3", personel_Id);
            hareket.Parameters.AddWithValue("@h4", secilen_Hasta_Id);
            hareket.Parameters.AddWithValue("@h5", secilen_Ilac_Fiyat);
            hareket.Parameters.AddWithValue("@h6", toplam);
            hareket.Parameters.AddWithValue("@h7", DateTime.Now.ToString());
            hareket.Parameters.AddWithValue("@h8", islem);
            hareket.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (tc.Text != "" && isim.Text != "" && soyIsim.Text != "" && mskTelefon.Text!="")
            {
                try
                {
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into HASTA(TC,ISIM,SOYISIM,TELEFON,IL,ILCE,KAYIT_TAR,VEREN_PER) values(@p1,@p2,@p3,@p4,@p5,@p6,@p8,@p9)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", tc.Text);
                    komut.Parameters.AddWithValue("@p2", isim.Text);
                    komut.Parameters.AddWithValue("@p3", soyIsim.Text);
                    komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
                    komut.Parameters.AddWithValue("@p5", cmbil.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@p6", cmbilce.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@p8", DateTime.Now.ToString());
                    komut.Parameters.AddWithValue("@p9", tAlan.EditValue);
                    bgl.baglanti().Close();                  

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

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from ILCELER where SEHIR=@s1", bgl.baglanti());
            komut.Parameters.AddWithValue("@s1",cmbil.SelectedIndex + 1);
            SqlDataReader da = komut.ExecuteReader();
            while (da.Read())
            {
                cmbilce.Properties.Items.Add(da[0]);
            }
            bgl.baglanti().Close();
        }

        int secilen_Hasta_Id;
        int personel_Id;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                id.Text = dr["ID"].ToString();
                secilen_Hasta_Id = int.Parse(dr["ID"].ToString());
                tc.Text = dr["TC"].ToString();
                isim.Text = dr["ISIM"].ToString();
                soyIsim.Text = dr["SOYISIM"].ToString();
                mskTelefon.Text = dr["TELEFON"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                //tAlan.Properties.NullText = dr["PERSONEL"].ToString();

                //DataTable dt = new DataTable();
                //SqlDataAdapter da = new SqlDataAdapter("select ID,AD,SOYAD from PERSONEL where AD+' '+SOYAD='" + dr["PERSONEL"].ToString() + "'", bgl.baglanti());
                //da.Fill(dt);
                //tAlan.Properties.ValueMember = "ID";
                //tAlan.Properties.DisplayMember = "AD";
                //tAlan.Properties.DataSource = dt;
                //bgl.baglanti().Close();

                SqlCommand personelGetir = new SqlCommand("select ID from PERSONEL where AD+' '+SOYAD=@p1", bgl.baglanti());
                personelGetir.Parameters.AddWithValue("@p1", dr["PERSONEL"].ToString());
                SqlDataReader perDR = personelGetir.ExecuteReader();
                if (perDR.Read())
                {
                    personel_Id = int.Parse(perDR["ID"].ToString());
                }

                verIlacListele();
            }           
        }

        int secilen_Ilac_Id ;
        decimal secilen_Ilac_Fiyat;
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow drIlac = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            secilen_Ilac_Id = int.Parse(drIlac["ILAC_ID"].ToString());
            secilen_Ilac_Fiyat = decimal.Parse(drIlac["SATIS_FIYAT"].ToString());
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand kontrol = new SqlCommand("Select COUNT(ID) From HASTA Where ID=@k1", bgl.baglanti());
                kontrol.Parameters.AddWithValue("@k1", int.Parse(id.Text));
                int gelen = Convert.ToInt32(kontrol.ExecuteScalar());

                if (gelen != 0)
                {
                    bgl.baglanti().Close();
                    SqlCommand sil = new SqlCommand("Delete from HASTA where ID=@s1", bgl.baglanti());
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
                    MessageBox.Show("Lütfen ID Kısmını Doldurunuz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Silme işemi yaparken bir hata oluştu !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            hepTemizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (tc.Text != "" && isim.Text != "" && soyIsim.Text != "" && mskTelefon.Text != "")
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("Update HASTA set TC=@G1,ISIM=@G2,SOYISIM=@G3,TELEFON=@G4,IL=@G5,ILCE=@G6,VEREN_PER=@G9 Where ID=@G8", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@G1", tc.Text);
                    guncelle.Parameters.AddWithValue("@G2", isim.Text);
                    guncelle.Parameters.AddWithValue("@G3", soyIsim.Text);
                    guncelle.Parameters.AddWithValue("@G4", mskTelefon.Text);
                    guncelle.Parameters.AddWithValue("@G5", cmbil.SelectedItem.ToString());
                    guncelle.Parameters.AddWithValue("@G6", cmbilce.SelectedItem.ToString());
                    guncelle.Parameters.AddWithValue("@G8", int.Parse(id.Text));
                    guncelle.Parameters.AddWithValue("@G9", tAlan.EditValue);
                    
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
                    MessageBox.Show("Günecelleme Yapmak İstediğiniz Alanda Hata / Hatalar Var !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Lütfen gerekli olan bilgileri girdiğinizden emin olunuz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            try
            {
                if (id.Text != "")
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("select * from HASTA where ID='" + id.Text + "'", bgl.baglanti());
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                    bgl.baglanti().Close();
                }
                else if (tc.Text != "")
                {
                    DataTable dt = new DataTable();
                    string yazım = ("%" + tc.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter("select * from HASTA where TC LIKE '" + yazım + "'", bgl.baglanti());
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                    bgl.baglanti().Close();
                }
                else if (isim.Text != "")
                {
                    DataTable dt = new DataTable();
                    string yazım = ("%" + isim.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter("select * from HASTA where ISIM LIKE '" + yazım + "'", bgl.baglanti());
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                    bgl.baglanti().Close();
                }
                else if (soyIsim.Text != "")
                {
                    DataTable dt = new DataTable();
                    string yazım = ("%" + soyIsim.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter("select * from HASTA where SOYISIM LIKE '" + yazım + "'", bgl.baglanti());
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                    bgl.baglanti().Close();
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı..", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt bulunamadı..", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listele();
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIlacEkle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand kontrol = new SqlCommand("Select COUNT(HASTA_DETAY_ID) From HASTA_DETAY Where HASTA_ID=@k1 AND ILAC_ID=@k2", bgl.baglanti());
                kontrol.Parameters.AddWithValue("@k1", secilen_Hasta_Id);
                kontrol.Parameters.AddWithValue("@k2", secilen_Ilac_Id);
                int varmi = Convert.ToInt32(kontrol.ExecuteScalar());
                if (varmi == 0)
                {
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into HASTA_DETAY(HASTA_ID,ILAC_ID,ILAC_ADET,ILAC_TUTAR) values(@p1,@p2,@p3,@p4)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", secilen_Hasta_Id);
                    komut.Parameters.AddWithValue("@p2", secilen_Ilac_Id);
                    komut.Parameters.AddWithValue("@p3", int.Parse(ilac_adet.Value.ToString()));
                    komut.Parameters.AddWithValue("@p4", ((secilen_Ilac_Fiyat)*decimal.Parse(ilac_adet.Value.ToString())));

                    DialogResult gunCik = new DialogResult();
                    gunCik = MessageBox.Show("Eklemek istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (gunCik == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Ekleme işlemi gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        verIlacListele();

                        hareketEkle("Hastaya İlaç Eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Ekleme işlemi Yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        bgl.baglanti().Close();
                    }
                }
                else
                {
                    string h_detay_id = "";
                    string adet = "";

                    int[] rowhandles2 = gridView3.GetSelectedRows();
                    foreach (int i in rowhandles2)
                    {
                        h_detay_id = gridView3.GetRowCellValue(i, gridView3.Columns["ID"]).ToString();
                        adet = gridView3.GetRowCellValue(i, gridView3.Columns["ILAC_ADET"]).ToString();
                    }

                    foreach (int b in rowhandles2)
                    {
                        h_detay_id = gridView3.GetRowCellValue(b, gridView3.Columns["ID"]).ToString();
                        adet = gridView3.GetRowCellValue(b, gridView3.Columns["ILAC_ADET"]).ToString();
                        int yeni_adet = int.Parse(adet) + int.Parse(ilac_adet.Value.ToString());

                        SqlCommand guncelle = new SqlCommand("Update HASTA_DETAY set ILAC_ADET=@G1,ILAC_TUTAR=@G2 Where HASTA_DETAY_ID=@G3", bgl.baglanti());
                        guncelle.Parameters.AddWithValue("@G1", yeni_adet);
                        guncelle.Parameters.AddWithValue("@G2", ((secilen_Ilac_Fiyat) * decimal.Parse(yeni_adet.ToString())));
                        guncelle.Parameters.AddWithValue("@G3", int.Parse(h_detay_id));
                        guncelle.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        hareketEkle("Hastaya İlaç Eklendi.");
                    }
                    verIlacListele();
                    MessageBox.Show("İlaç Eklendi. Lütfen Kaydedidiniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Lütfen Doğru Giriş Yapınız."+hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTemizle_Click_1(object sender, EventArgs e)
        {
            hepTemizle();
        }

        private void btnIlacSil_Click(object sender, EventArgs e)
        {
            string h_detay_id="";
            string adet = "";

            try
            {
                int[] rowhandles2 = gridView3.GetSelectedRows();
                foreach (int i in rowhandles2)
                {
                    h_detay_id = gridView3.GetRowCellValue(i, gridView3.Columns["ID"]).ToString();
                    adet = gridView3.GetRowCellValue(i, gridView3.Columns["ILAC_ADET"]).ToString();
                }

                SqlCommand kontrol = new SqlCommand("Select COUNT(HASTA_DETAY_ID) From HASTA_DETAY Where HASTA_DETAY_ID=@k1", bgl.baglanti());
                kontrol.Parameters.AddWithValue("@k1", int.Parse(h_detay_id));
                int gelen = Convert.ToInt32(kontrol.ExecuteScalar());

                if (gelen != 0 && adet=="1")
                {
                    bgl.baglanti().Close();

                    foreach (int i in rowhandles2)
                    {
                        h_detay_id = gridView3.GetRowCellValue(i, gridView3.Columns["ID"]).ToString();

                        SqlCommand sil = new SqlCommand("Delete from HASTA_DETAY where HASTA_DETAY_ID=@s1", bgl.baglanti());
                        sil.Parameters.AddWithValue("@s1", int.Parse(h_detay_id));
                        sil.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        hareketEkle("Hastadan İlaç Silindi.");
                    }
                    verIlacListele();
                    MessageBox.Show("İlaç Silindi. Lütfen Kaydediniz .", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (gelen != 0)
                {
                    foreach (int b in rowhandles2)
                    {
                        h_detay_id = gridView3.GetRowCellValue(b, gridView3.Columns["ID"]).ToString();
                        adet = gridView3.GetRowCellValue(b, gridView3.Columns["ILAC_ADET"]).ToString();
                        SqlCommand guncelle = new SqlCommand("Update HASTA_DETAY set ILAC_ADET=@G1 Where HASTA_DETAY_ID=@G2", bgl.baglanti());
                        guncelle.Parameters.AddWithValue("@G1", int.Parse(adet)- int.Parse(ilac_adet.Value.ToString()));
                        guncelle.Parameters.AddWithValue("@G2", int.Parse(h_detay_id));
                        guncelle.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        hareketEkle("Hastadan İlaç Eksiltildi.");
                    }
                    verIlacListele();
                    MessageBox.Show("İlaç Silindi veya Eksiltildi. Lütfen Kaydedidiniz.","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lütfen ID Kısmını Doldurunuz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata+"Silme işemi yaparken bir hata oluştu !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void urunEkle_Click(object sender, EventArgs e)
        {
            gridView3.SelectAll();
            int[] rowhandles = gridView3.GetSelectedRows();

            Decimal toplamTutar= 00.00m;
            foreach (int i in rowhandles)
            {
                toplamTutar =toplamTutar+ Decimal.Parse(gridView3.GetRowCellValue(i, gridView3.Columns["ILAC_TUTAR"]).ToString());
            }

            try
            {
                SqlCommand guncelle = new SqlCommand("Update HASTA set TOPLAM_TUTAR=@G1 Where ID=@G2", bgl.baglanti());
                guncelle.Parameters.AddWithValue("@G1", toplamTutar);
                guncelle.Parameters.AddWithValue("@G2", int.Parse(id.Text));

                DialogResult gunCik = new DialogResult();
                gunCik = MessageBox.Show("İlaçları kaydetmek istediğinize emin misiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (gunCik == DialogResult.Yes)
                {
                    guncelle.ExecuteNonQuery();
                    listele();
                    bgl.baglanti().Close();                                      
                }
                else
                {
                    MessageBox.Show("İlaçlar eklenmedi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    listele();
                    bgl.baglanti().Close();
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("İlaç Eklemek İstediğiniz Alanda Hata / Hatalar Var !"+hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
