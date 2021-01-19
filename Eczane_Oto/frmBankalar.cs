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
    public partial class frmBankalar : Form
    {
        public frmBankalar()
        {
            InitializeComponent();
        }

        SqlBaglantısı bgl = new SqlBaglantısı();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("prBanka", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void hepTemizle()
        {
            id.Text = "";
            banka.Text = "";
            sube.Text = "";
            subeKod.Text = "";
            paraBirim.Text = "";
            hesapTur.Text = "";
            IBAN.Text = "";
            hesapNo.Text = "";
            yetkili.Text = "";
            tarih.Text = "";
            lueFirma.Properties.NullText = "Lütfen Firma Seçin";
        }

        void firmaListele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,FIR_ISIM from FIRMA", bgl.baglanti());
            da.Fill(dt);
            lueFirma.Properties.ValueMember = "ID";
            lueFirma.Properties.DisplayMember = "FIR_ISIM";
            lueFirma.Properties.DataSource = dt;
        }

        private void frmBankalar_Load(object sender, EventArgs e)
        {
            listele();
            firmaListele();
            hepTemizle();
            timer1.Start();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                id.Text = dr["ID"].ToString();
                banka.Text = dr["BANKA_AD"].ToString();
                sube.Text = dr["SUBE"].ToString();
                subeKod.Text = dr["SUBE_KODU"].ToString();
                paraBirim.Text = dr["PARA_BIRIM"].ToString();
                hesapTur.Text = dr["HESAP_TUR"].ToString();
                IBAN.Text = dr["IBAN"].ToString();
                hesapNo.Text = dr["HESAP_NO"].ToString();
                yetkili.Text = dr["YETKILI"].ToString();
                tarih.Text = dr["TARIH"].ToString();
                lueFirma.Text = dr["FIR_ISIM"].ToString();
            }           
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            hepTemizle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (banka.Text != "" && sube.Text != "" && subeKod.Text != "" && paraBirim.Text != "" && hesapTur.Text != "" && IBAN.Text != "" && hesapNo.Text != "" && yetkili.Text != "" && tarih.Text != "" && lueFirma.Text != "")
            {
                try
                {
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into BANKALAR(BANKA_AD,SUBE,SUBE_KODU,PARA_BIRIM,HESAP_TUR,IBAN,HESAP_NO,YETKILI,TARIH,FIRMA_ID) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", banka.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@p2", sube.Text);
                    komut.Parameters.AddWithValue("@p3", subeKod.Text);
                    komut.Parameters.AddWithValue("@p4", paraBirim.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@p5", hesapTur.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@p6", IBAN.Text);
                    komut.Parameters.AddWithValue("@p7", hesapNo.Text);
                    komut.Parameters.AddWithValue("@p8", yetkili.Text);
                    komut.Parameters.AddWithValue("@p9", tarih.Text);
                    komut.Parameters.AddWithValue("@p10",lueFirma.EditValue);

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
                SqlCommand kontrol = new SqlCommand("Select COUNT(ID) From BANKALAR Where ID=@k1", bgl.baglanti());
                kontrol.Parameters.AddWithValue("@k1", int.Parse(id.Text));
                int gelen = Convert.ToInt32(kontrol.ExecuteScalar());

                if (gelen != 0)
                {
                    bgl.baglanti().Close();
                    SqlCommand sil = new SqlCommand("Delete from BANKALAR where ID=@s1", bgl.baglanti());
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
            if (banka.Text != "" && sube.Text != "" && subeKod.Text != "" && paraBirim.Text != "" && hesapTur.Text != "" && IBAN.Text != "" && hesapNo.Text != "" && yetkili.Text != "" && tarih.Text != "" && lueFirma.Text != "")
            {
                try
                {
                    SqlCommand guncelle = new SqlCommand("Update BANKALAR set BANKA_AD=@G1,SUBE=@G2,SUBE_KODU=@G3,PARA_BIRIM=@G4,HESAP_TUR=@G5,IBAN=@G6,HESAP_NO=@G7,YETKILI=@G8,TARIH=@G9,FIRMA_ID=@G10 Where ID=@G11", bgl.baglanti());
                    guncelle.Parameters.AddWithValue("@G1", banka.SelectedItem.ToString());
                    guncelle.Parameters.AddWithValue("@G2", sube.Text);
                    guncelle.Parameters.AddWithValue("@G3", subeKod.Text);
                    guncelle.Parameters.AddWithValue("@G4", paraBirim.SelectedItem.ToString());
                    guncelle.Parameters.AddWithValue("@G5", hesapTur.SelectedItem.ToString());
                    guncelle.Parameters.AddWithValue("@G6", IBAN.Text);
                    guncelle.Parameters.AddWithValue("@G7", hesapNo.Text);
                    guncelle.Parameters.AddWithValue("@G8", yetkili.Text);
                    guncelle.Parameters.AddWithValue("@G9", tarih.Text);
                    guncelle.Parameters.AddWithValue("@G10",lueFirma.EditValue);

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
                    MessageBox.Show(hata.ToString(),"HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
