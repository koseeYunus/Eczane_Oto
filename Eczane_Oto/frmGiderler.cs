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
    public partial class frmGiderler : Form
    {
        public frmGiderler()
        {
            InitializeComponent();
        }

        SqlBaglantısı bgl = new SqlBaglantısı();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void hepTemizle()
        {
            id.Text = "";
            ay.Text = "";
            yil.Text = "";
            elektrik.Value = 0;
            su.Value = 0;
            dogalgaz.Value = 0;
            internet.Value = 0;
            maas.Value = 0;
            ekstra.Value = 0;
            ekstraNot.Text = "";
        }

        private void frmGiderler_Load(object sender, EventArgs e)
        {
            listele();
            hepTemizle();
            timer1.Start();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                id.Text = dr["ID"].ToString();
                ay.Text = dr["AY"].ToString();
                yil.Text = dr["YIL"].ToString();
                elektrik.Value = decimal.Parse(dr["ELEKTRIK"].ToString());
                su.Value = decimal.Parse(dr["SU"].ToString());
                dogalgaz.Value = decimal.Parse(dr["DOGALGAZ"].ToString());
                internet.Value = decimal.Parse(dr["INTERNET"].ToString());
                maas.Value = decimal.Parse(dr["MAASLAR"].ToString());
                ekstra.Value = decimal.Parse(dr["EKSTRA"].ToString());
                ekstraNot.Text = dr["NOTLAR"].ToString();
            }           
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (ay.Text != "" && yil.Text != "" && elektrik.Value.ToString() != "" && su.Value.ToString() != "" && dogalgaz.Value.ToString() != "" && internet.Value.ToString() != "" && maas.Value.ToString() != "" && ekstra.Value.ToString() != "")
            {
                try
                {
                    bgl.baglanti();
                    SqlCommand komut = new SqlCommand("insert into GIDERLER(AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR,KAYIT_TAR) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", ay.Text);
                    komut.Parameters.AddWithValue("@p2", yil.Text);
                    komut.Parameters.AddWithValue("@p3", decimal.Parse(elektrik.Value.ToString()));
                    komut.Parameters.AddWithValue("@p4", decimal.Parse(su.Value.ToString()));
                    komut.Parameters.AddWithValue("@p5", decimal.Parse(dogalgaz.Value.ToString()));
                    komut.Parameters.AddWithValue("@p6", decimal.Parse(internet.Value.ToString()));
                    komut.Parameters.AddWithValue("@p7", decimal.Parse(maas.Value.ToString()));
                    komut.Parameters.AddWithValue("@p8", decimal.Parse(ekstra.Value.ToString()));
                    komut.Parameters.AddWithValue("@p9", ekstraNot.Text);
                    komut.Parameters.AddWithValue("@p10", DateTime.Now.ToString());

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
                SqlCommand kontrol = new SqlCommand("Select COUNT(ID) From GIDERLER Where ID=@k1", bgl.baglanti());
                kontrol.Parameters.AddWithValue("@k1", int.Parse(id.Text));
                int gelen = Convert.ToInt32(kontrol.ExecuteScalar());

                if (gelen != 0)
                {
                    bgl.baglanti().Close();
                    SqlCommand sil = new SqlCommand("Delete from GIDERLER where ID=@s1", bgl.baglanti());
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
                SqlCommand guncelle = new SqlCommand("Update GIDERLER set AY=@G1,YIL=@G2,ELEKTRIK=@G3,SU=@G4,DOGALGAZ=@G5,INTERNET=@G6,MAASLAR=@G7,EKSTRA=@G8,NOTLAR=@G9,KAYIT_TAR=@G10 Where ID=@G11", bgl.baglanti());
                guncelle.Parameters.AddWithValue("@G1", ay.Text);
                guncelle.Parameters.AddWithValue("@G2", yil.Text);
                guncelle.Parameters.AddWithValue("@G3", decimal.Parse(elektrik.Value.ToString()));
                guncelle.Parameters.AddWithValue("@G4", decimal.Parse(su.Value.ToString()));
                guncelle.Parameters.AddWithValue("@G5", decimal.Parse(dogalgaz.Value.ToString()));
                guncelle.Parameters.AddWithValue("@G6", decimal.Parse(internet.Value.ToString()));
                guncelle.Parameters.AddWithValue("@G7", decimal.Parse(maas.Value.ToString()));
                guncelle.Parameters.AddWithValue("@G8", decimal.Parse(ekstra.Value.ToString()));
                guncelle.Parameters.AddWithValue("@G9", ekstraNot.Text);
                guncelle.Parameters.AddWithValue("@G10", DateTime.Now.ToString());
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
                MessageBox.Show("Günecelleme Yapmak İstediğiniz Alanda Hata / Hatalar Var !"+hata, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            hepTemizle();
        }
    }
}
