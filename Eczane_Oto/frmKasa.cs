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
using DevExpress.Charts;

namespace Eczane_Oto
{
    public partial class frmKasa : Form
    {
        public frmKasa()
        {
            InitializeComponent();
        }

        SqlBaglantısı bgl = new SqlBaglantısı();

        private void frmKasa_Load(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select COUNT(ID) from HASTA", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                hastaSayisi.Text = dr1[0].ToString();
            }
            dr1.Close();
            

            SqlCommand komut2 = new SqlCommand("select SUM(ALIS_FIYAT*ADET) from URUN", bgl.baglanti());
            SqlDataReader dr2= komut2.ExecuteReader();
            while (dr2.Read())
            {
                ilacUcret.Text = dr2[0].ToString();
            }
            dr2.Close();

            SqlCommand komut3 = new SqlCommand("select SUM(SATIS_FIYAT*ADET) from URUN", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                ilacSatis.Text = dr3[0].ToString();
            }
            dr3.Close();

            SqlCommand komut4 = new SqlCommand("select SUM(TOPLAM_TUTAR) from HASTA", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                ilacKazanc.Text = dr4[0].ToString();
            }
            dr4.Close();

            SqlCommand komut5 = new SqlCommand("select COUNT(ID) from PERSONEL", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                perSayisi.Text = dr5[0].ToString();
            }
            dr5.Close();

            SqlCommand komut6 = new SqlCommand("select SUM(MAASLAR) from GIDERLER", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                perMaas.Text = dr6[0].ToString();
            }
            dr6.Close();

            SqlCommand komut7 = new SqlCommand("select (SUM(ELEKTRIK)+SUM(SU)+SUM(DOGALGAZ)+SUM(INTERNET)) FROM GIDERLER", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                eczaneGider.Text = dr7[0].ToString();
            }
            dr7.Close();

            SqlCommand komut8 = new SqlCommand("select SUM(EKSTRA) FROM GIDERLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                kiraGider.Text = dr8[0].ToString();
            }
            dr8.Close();

            toplamGider.Text = (decimal.Parse(ilacUcret.Text)+ decimal.Parse(perMaas.Text)+ decimal.Parse(eczaneGider.Text)+ decimal.Parse(kiraGider.Text)).ToString();

            toplamKar.Text = (decimal.Parse(ilacKazanc.Text)-decimal.Parse(toplamGider.Text)).ToString();

            
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            if (sayac<0)
            {
                sayac = 21;
            }
            if (sayac>0 && sayac<=5)
            {
                baslik.Text = "ELEKTRİK GİDERLERİ";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut9 = new SqlCommand("select top 12 GIDERLER.AY,GIDERLER.ELEKTRIK from GIDERLER order by GIDERLER.ID desc", bgl.baglanti());
                SqlDataReader dr9 = komut9.ExecuteReader();
                while (dr9.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
                }
                dr9.Close();
            }

            if (sayac > 5 && sayac <= 10)
            {
                baslik.Text = "SU GİDERLERİ";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("select top 12 GIDERLER.AY,GIDERLER.SU from GIDERLER order by GIDERLER.ID desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
                }
                dr10.Close();
            }

            if (sayac > 10 && sayac <= 15)
            {
                baslik.Text = "DOĞALGAZ GİDERLERİ";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("select top 12 GIDERLER.AY,GIDERLER.DOGALGAZ from GIDERLER order by GIDERLER.ID desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
                }
                dr11.Close();
            }

            if (sayac > 15 && sayac <= 20)
            {
                baslik.Text = "MAAS GİDERLERİ";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut12 = new SqlCommand("select top 12 GIDERLER.AY,GIDERLER.MAASLAR from GIDERLER order by GIDERLER.ID desc", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
                }
                dr12.Close();
            }

            if (sayac > 20 && sayac <= 25)
            {
                baslik.Text = "EKSTRA GİDERLER";
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut13 = new SqlCommand("select top 12 GIDERLER.AY,GIDERLER.EKSTRA from GIDERLER order by GIDERLER.ID desc", bgl.baglanti());
                SqlDataReader dr13 = komut13.ExecuteReader();
                while (dr13.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr13[0], dr13[1]));
                }
                dr13.Close();
            }

            if (sayac>=26)
            {
                sayac = 0;
            }
            bgl.baglanti().Dispose();
        }
        int gelis = 0;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gelis==0)
            {
                gelis = 1;
                timer1.Stop();
                simpleButton1.Visible = false;
                simpleButton3.Visible = false;
            }
            else
            {
                gelis = 0;
                timer1.Start();
                simpleButton1.Visible = true;
                simpleButton3.Visible = true;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            sayac = sayac + 5;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            sayac = sayac - 5;
        }
    }
}
