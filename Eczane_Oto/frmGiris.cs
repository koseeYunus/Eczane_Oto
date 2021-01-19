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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        public void cikisYap()
        {
            this.Close();
            Application.Exit();
        }

        SqlBaglantısı bgl = new SqlBaglantısı();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from KULLANICILAR where KUL_AD=@g1 and SIFRE=@g2", bgl.baglanti());
            komut.Parameters.AddWithValue("@g1", kullaniciAdi.Text);
            komut.Parameters.AddWithValue("@g2", sifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                anaForm frm = new anaForm();
                frm.Show();
                this.Hide();
                bgl.baglanti().Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                bgl.baglanti().Close();
            }
        }

        private void simpleButton1_MouseHover(object sender, EventArgs e)
        {
            simpleButton1.BackColor = Color.Blue;
            simpleButton1.ForeColor = Color.Red;
        }

        private void simpleButton1_MouseLeave(object sender, EventArgs e)
        {
            simpleButton1.BackColor=System.Drawing.Color.FromArgb(255, 128, 128);
            simpleButton1.ForeColor = Color.White;
        }
    }
}
