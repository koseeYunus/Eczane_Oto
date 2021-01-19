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
using System.Net;
using System.Net.Mail;
//using System.Security.Cryptography.X509Certificates;
//using System.Net.Security;

namespace Eczane_Oto
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }
        SqlBaglantısı bgl = new SqlBaglantısı();

        void mailListele()
        {
            SqlCommand komut = new SqlCommand("Select DISTINCT MAIL from PERSONEL", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                mail.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gonder_Click(object sender, EventArgs e)
        {
            if (mail.Text!="")
            {
                MailMessage ePosta = new MailMessage();
                ePosta.From = new MailAddress(mail.SelectedItem.ToString());
                ePosta.To.Add("kose.yunus.55@gmail.com");
                //ePosta.Attachments.Add(new Attachment(@"C:\deneme.txt"));
                string srn = mail.Text + " --> " + sorun.Text;
                ePosta.Subject = srn;
                ePosta.Body = mesaj.Text;
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential("yunuskose55000@gmail.com", "bcbgna5548.");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                object userState = ePosta;
                try
                {
                    smtp.SendAsync(ePosta, (object)ePosta);
                    MessageBox.Show("İşlem başarı ile gerçekleştirilmiştir.","BAŞARILI",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (SmtpException ex)
                {
                    MessageBox.Show(ex.Message, "Mail Gönderme Hatasi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Mail ve Şifre Kısmını Doldurunuz.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void frmMail_Load(object sender, EventArgs e)
        {
            mailListele();
        }
    }
}
