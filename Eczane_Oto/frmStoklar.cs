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
    public partial class frmStoklar : Form
    {
        public frmStoklar()
        {
            InitializeComponent();
        }

        SqlBaglantısı bgl = new SqlBaglantısı();

        private void frmStoklar_Load(object sender, EventArgs e)
        {
            SqlDataAdapter  da= new SqlDataAdapter("SELECT URUN,SUM(ADET) AS MİKTAR FROM URUN GROUP BY URUN", bgl.baglanti());
            //SqlDataAdapter da = new SqlDataAdapter("SELECT ID,URUN,SUM(ADET) AS MİKTAR FROM URUN GROUP BY ID,URUN", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            SqlDataAdapter da2 = new SqlDataAdapter("SELECT URUN.ID,URUN,URUN.ADET,URUN.SON_KUL_TAR FROM URUN ORDER BY CONVERT(date,URUN.SON_KUL_TAR,104) ASC", bgl.baglanti());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;

            SqlCommand komut = new SqlCommand("SELECT TOP 10 URUN,SUM(ADET) AS MİKTAR FROM URUN GROUP BY URUN ORDER BY MİKTAR ASC", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            bgl.baglanti().Close();
        }
    }
}
