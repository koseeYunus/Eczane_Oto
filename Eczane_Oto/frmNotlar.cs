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
    public partial class frmNotlar : Form
    {
        public frmNotlar()
        {
            InitializeComponent();
            listele();
            calisanListele();
            hepTemizle();
        }

        SqlBaglantısı bgl = new SqlBaglantısı();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from NOTLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void hepTemizle()
        {
            id.Text = "";
            olusturan.Properties.DisplayMember = "Lütfen Seçiniz";
            kimIcin.Properties.DisplayMember = "Lütfen Seçiniz";
            tarih.Text = "";
            saat.Properties.NullText = "";
            baslik.Text = "";
            detay.Text = "";
            calisanListele();
        }

        void calisanListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,(AD+' '+SOYAD) as AD_SOYAD from PERSONEL", bgl.baglanti());
            da.Fill(dt);
            olusturan.Properties.ValueMember = "ID";
            olusturan.Properties.DisplayMember = "AD_SOYAD";
            olusturan.Properties.DataSource = dt;

            kimIcin.Properties.ValueMember = "ID";
            kimIcin.Properties.DisplayMember = "AD_SOYAD";
            kimIcin.Properties.DataSource = dt;
        }
        string olusturanPersonel;
        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                id.Text = dr["ID"].ToString();
                olusturanPersonel= dr["OLUSTURAN"].ToString();
                //kimIcin.Properties.NullText = dr["KIM_ICIN"].ToString();
                tarih.Text = dr["TARIH"].ToString();
                saat.EditValue = dr["SAAT"].ToString();
                baslik.Text = dr["BASLIK"].ToString();
                detay.Text = dr["DETAY"].ToString();
            }  
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (olusturan.Text != "" && kimIcin.Text != "" && baslik.Text != "" && detay.Text != "")
            {
                try
                {
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into NOTLAR(OLUSTURAN,KIM_ICIN,TARIH,SAAT,BASLIK,DETAY) values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", olusturan.EditValue+" - "+olusturan.Text);
                    komut.Parameters.AddWithValue("@p2", kimIcin.EditValue+" - "+kimIcin.Text);
                    komut.Parameters.AddWithValue("@p3", tarih.Text);
                    komut.Parameters.AddWithValue("@p4", saat.Text);
                    komut.Parameters.AddWithValue("@p5", baslik.Text);
                    komut.Parameters.AddWithValue("@p6", detay.Text);

                    DialogResult gunCik = new DialogResult();
                    gunCik = MessageBox.Show("Notu kaydetmek istediğinize eminmisiniz ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (gunCik == DialogResult.Yes)
                    {
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Not kaydetme işlemi gerçekleştirildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        hepTemizle();
                    }
                    else
                    {
                        MessageBox.Show("Not kaydetme işlemi Yapılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        listele();
                        bgl.baglanti().Close();
                    }
                }
                catch (Exception)
                {
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
                SqlCommand kontrol1 = new SqlCommand("Select COUNT(ID) From NOTLAR Where ID=@k1", bgl.baglanti());
                kontrol1.Parameters.AddWithValue("@k1", int.Parse(id.Text));
                int gelen1 = Convert.ToInt32(kontrol1.ExecuteScalar());
                bgl.baglanti().Close();
              
                if (gelen1 != 0)
                {
                    SqlCommand sil = new SqlCommand("Delete from NOTLAR where ID=@s1", bgl.baglanti());
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
                MessageBox.Show("Lütfen ID Kısmını Doldurunuz !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (id.Text != "" && olusturan.Text != "" && olusturan.Text != "Lütfen Seçiniz" && kimIcin.Text != "" && baslik.Text != "" && detay.Text != "")
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("Update NOTLAR set OLUSTURAN=@G1,KIM_ICIN=@G2,TARIH=@G3,SAAT=@G4,BASLIK=@G5,DETAY=@G6 Where ID=@G7", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@G1", olusturan.EditValue+" - "+olusturan.Text);
                    guncelle.Parameters.AddWithValue("@G2", kimIcin.EditValue+" - "+kimIcin.Text);
                    guncelle.Parameters.AddWithValue("@G3", tarih.Text);
                    guncelle.Parameters.AddWithValue("@G4", saat.Text);
                    guncelle.Parameters.AddWithValue("@G5", baslik.Text);
                    guncelle.Parameters.AddWithValue("@G6", detay.Text);

                    guncelle.Parameters.AddWithValue("@G7", int.Parse(id.Text));

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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            hepTemizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            notDetay not = new notDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr!=null)
            {
                not.metin = dr["DETAY"].ToString();
            }
            not.Show();
        }
    }
}
