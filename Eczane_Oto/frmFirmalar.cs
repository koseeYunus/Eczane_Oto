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
    public partial class frmFirmalar : Form
    {
        public frmFirmalar()
        {
            InitializeComponent();
        }

        SqlBaglantısı bgl = new SqlBaglantısı();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from FIRMA", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void hepTemizle()
        {
            id.Text = "";
            frmIsim.Text = "";
            sektor.Text = "";
            tc.Text = "";
            yetkili.Text = "";
            gorev.Text = "";
            mskTel1.Text = "";
            mskTel2.Text = "";
            mskFax.Text = "";
            mail.Text = "";

            kod1.Text = "";
            kod2.Text = "";
            kod3.Text = "";
            rchKod1.Text = "";
            rchKod2.Text = "";
            rchKod3.Text = "";

            cmbil.Text = cmbilce.Text = vergiDaire.Text = adres.Text = "";
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                id.Text = dr["ID"].ToString();
                frmIsim.Text = dr["FIR_ISIM"].ToString();
                sektor.Text = dr["SEKTOR"].ToString();
                tc.Text = dr["YETKILI_TC"].ToString();
                yetkili.Text = dr["YETKILI"].ToString();
                gorev.Text = dr["YETKILI_STATU"].ToString();
                mskTel1.Text = dr["TELEFON"].ToString();
                mskTel2.Text = dr["TELEFON2"].ToString();
                mskFax.Text = dr["FAX"].ToString();
                mail.Text = dr["MAIL"].ToString();

                kod1.Text = dr["KOD1"].ToString();
                kod2.Text = dr["KOD2"].ToString();
                kod3.Text = dr["KOD3"].ToString();

                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                vergiDaire.Text = dr["VERGI_DAIRE"].ToString();
                adres.Text = dr["ADRES"].ToString();
            }            
        }

        void carikodAciklama()
        {
            SqlCommand komut = new SqlCommand("select FIRMAKOD1 from KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rchKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
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

        private void frmFirmalar_Load(object sender, EventArgs e)
        {
            listele();
            hepTemizle();
            sehirListele();
            carikodAciklama();
            timer1.Start();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            hepTemizle();
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (frmIsim.Text != "" && sektor.Text != "" && tc.Text != "" && yetkili.Text != "" && mskTel1.Text != "" && mail.Text!="" && cmbil.Text!="" && vergiDaire.Text!="")
            {
                try
                {
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into FIRMA(FIR_ISIM,SEKTOR,YETKILI_TC,YETKILI,YETKILI_STATU,TELEFON,TELEFON2,FAX,MAIL,KOD1,KOD2,KOD3,IL,ILCE,VERGI_DAIRE,ADRES,KAYIT_TAR) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", frmIsim.Text);
                    komut.Parameters.AddWithValue("@p2", sektor.Text);
                    komut.Parameters.AddWithValue("@p3", tc.Text);
                    komut.Parameters.AddWithValue("@p4", yetkili.Text);
                    komut.Parameters.AddWithValue("@p5", gorev.Text);
                    komut.Parameters.AddWithValue("@p6", mskTel1.Text);
                    komut.Parameters.AddWithValue("@p7", mskTel2.Text);
                    komut.Parameters.AddWithValue("@p8", mskFax.Text);
                    komut.Parameters.AddWithValue("@p9", mail.Text);

                    komut.Parameters.AddWithValue("@p10", kod1.Text);
                    komut.Parameters.AddWithValue("@p11", kod2.Text);
                    komut.Parameters.AddWithValue("@p12", kod3.Text);

                    komut.Parameters.AddWithValue("@p13", cmbil.Text);
                    komut.Parameters.AddWithValue("@p14", cmbilce.Text);
                    komut.Parameters.AddWithValue("@p15", vergiDaire.Text);
                    komut.Parameters.AddWithValue("@p16", adres.Text);

                    komut.Parameters.AddWithValue("@p17", DateTime.Now.ToString());

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

        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand kontrol = new SqlCommand("Select COUNT(ID) From FIRMA Where ID=@k1", bgl.baglanti());
                kontrol.Parameters.AddWithValue("@k1", int.Parse(id.Text));
                int gelen = Convert.ToInt32(kontrol.ExecuteScalar());

                if (gelen != 0)
                {
                    bgl.baglanti().Close();
                    SqlCommand sil = new SqlCommand("Delete from FIRMA where ID=@s1", bgl.baglanti());
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
            if (frmIsim.Text != "" && sektor.Text != "" && tc.Text != "" && yetkili.Text != "" && mskTel1.Text != "" && mail.Text != "" && cmbil.Text != "" && cmbilce.Text != "")
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("Update FIRMA set FIR_ISIM=@G1,SEKTOR=@G2,YETKILI_TC=@G3,YETKILI=@G4,YETKILI_STATU=@G5,TELEFON=@G6,TELEFON2=@G7,FAX=@G8,MAIL=@G9,KOD1=@G10,KOD2=@G11,KOD3=@G12,IL=@G13,ILCE=@G14,VERGI_DAIRE=@G15,ADRES=@G16 Where ID=@G17", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@G1", frmIsim.Text);
                    guncelle.Parameters.AddWithValue("@G2", sektor.Text);
                    guncelle.Parameters.AddWithValue("@G3", tc.Text);
                    guncelle.Parameters.AddWithValue("@G4", yetkili.Text);
                    guncelle.Parameters.AddWithValue("@G5", gorev.Text);
                    guncelle.Parameters.AddWithValue("@G6", mskTel1.Text);
                    guncelle.Parameters.AddWithValue("@G7", mskTel2.Text);
                    guncelle.Parameters.AddWithValue("@G8", mskFax.Text);
                    guncelle.Parameters.AddWithValue("@G9", mail.Text);

                    guncelle.Parameters.AddWithValue("@G10", kod1.Text);
                    guncelle.Parameters.AddWithValue("@G11", kod2.Text);
                    guncelle.Parameters.AddWithValue("@G12", kod3.Text);

                    guncelle.Parameters.AddWithValue("@G13", cmbil.Text);
                    guncelle.Parameters.AddWithValue("@G14", cmbilce.Text);
                    guncelle.Parameters.AddWithValue("@G15", vergiDaire.Text);
                    guncelle.Parameters.AddWithValue("@G16", adres.Text);
                    guncelle.Parameters.AddWithValue("@G17", int.Parse(id.Text));

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
    }
}
