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
using System.Xml;

namespace Eczane_Oto
{
    public partial class frmAnasayfa : Form
    {
        public frmAnasayfa()
        {
            InitializeComponent();
        }

        SqlBaglantısı bgl = new SqlBaglantısı();

        private DataTable veriGoster(string sqlIfade)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlIfade, bgl.baglanti());
            da.Fill(dt);
            return dt;
        }

        void haberler()
        {
            XmlTextReader oku = new XmlTextReader("https://www.cnnturk.com/feed/rss/saglik/news");
            while (oku.Read())
            {
                if (oku.Name == "title")
                {
                    listBox1.Items.Add(oku.ReadString());
                    listBox1.Items.Add("");
                }
                if (oku.Name == "description")
                {
                    listBox1.Items.Add(oku.ReadString());
                    listBox1.Items.Add("");
                    listBox1.Items.Add("");
                }
            }
        }

        private void frmAnasayfa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = veriGoster("select URUN.URUN,sum(URUN.ADET) as 'KALAN ADET' from URUN group by URUN having sum(ADET)<=15 order by sum(ADET)");
            gridControl2.DataSource = veriGoster("select top 18 NOTLAR.TARIH,NOTLAR.SAAT,NOTLAR.BASLIK from NOTLAR order by NOTLAR.ID desc");
            gridControl3.DataSource = veriGoster("Exec ANASAYFA_HAREKET");
            gridControl4.DataSource = veriGoster("select FIRMA.FIR_ISIM,FIRMA.TELEFON from FIRMA");

            try
            {
                haberler();
                webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
            }
            catch (Exception hata)
            {
                MessageBox.Show("INTERNET BAĞLANTINIZ OLMADIĞINDAN HABER VERİLERİ ÇEKİLEMEMİŞTİR."+ hata.ToString(), "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } 
        }

        private void listBox1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                //MessageBox.Show(index.ToString());
                MessageBox.Show(listBox1.Items[index].ToString(), "HABER AYRINTI");
            }
        }

    }
}
