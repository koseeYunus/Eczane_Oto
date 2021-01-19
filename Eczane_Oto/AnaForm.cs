using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Eczane_Oto
{
    public partial class anaForm : DevExpress.XtraEditors.XtraForm
    {
        public anaForm()
        {
            InitializeComponent();
        }

        private void anaForm_Load(object sender, EventArgs e)
        {
            if (anaSayfa == null || anaSayfa.IsDisposed)
            {
                anaSayfa = new frmAnasayfa();
                anaSayfa.MdiParent = this;
                anaSayfa.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){}private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){}private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){}private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){}private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }

        frmilaclar ilac;
        frmHastalar hasta;
        frmFirmalar firma;
        frmPersoneller personel;
        frmMail destek;
        frmGiderler gider;
        frmBankalar banka;
        frmFaturalar fatura;
        frmNotlar not;
        frmHareketler hareket;
        frmRaporGoster rapor;
        frmStoklar stok;
        frmKasa kasam;
        frmAnasayfa anaSayfa;

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (hasta == null || hasta.IsDisposed)
            {
                hasta = new frmHastalar();
                hasta.MdiParent = this;
                hasta.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ilac == null || ilac.IsDisposed)
            {
                ilac = new frmilaclar();
                ilac.MdiParent = this;
                ilac.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnFirmalar_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (firma == null || firma.IsDisposed)
            {
                firma = new frmFirmalar();
                firma.MdiParent = this;
                firma.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (banka == null || banka.IsDisposed)
            {
                banka = new frmBankalar();
                banka.MdiParent = this;
                banka.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (personel == null || personel.IsDisposed)
            {
                personel = new frmPersoneller();
                personel.MdiParent = this;
                personel.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gider == null || gider.IsDisposed)
            {
                gider = new frmGiderler();
                gider.MdiParent = this;
                gider.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barButtonItem1_ItemClick_2(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fatura==null || fatura.IsDisposed)
            {
                fatura = new frmFaturalar();
                fatura.MdiParent = this;
                fatura.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (destek == null || destek.IsDisposed)
            {
                destek = new frmMail();
                destek.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (not == null || not.IsDisposed)
            {
                not = new frmNotlar();
                not.MdiParent = this;
                not.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (hareket == null || hareket.IsDisposed)
            {
                hareket = new frmHareketler();
                hareket.MdiParent = this;
                hareket.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRapor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (rapor == null || rapor.IsDisposed)
            {
                rapor = new frmRaporGoster();              
                rapor.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnStok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (stok == null || stok.IsDisposed)
            {
                stok = new frmStoklar();
                stok.MdiParent = this;
                stok.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnKasa_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (kasam == null || kasam.IsDisposed)
            {
                kasam = new frmKasa();
                kasam.MdiParent = this;
                kasam.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (anaSayfa == null || anaSayfa.IsDisposed)
            {
                anaSayfa = new frmAnasayfa();
                anaSayfa.MdiParent = this;
                anaSayfa.Show();
            }
            else
            {
                MessageBox.Show("Seçtiğiniz Sekme Açık Durumda.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        frmGiris gecis = new frmGiris();
        private void anaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkış Yapmak İstediğinize Eminmisiniz ?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (sonuc==DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            gecis.cikisYap();
            gecis.Close();
        }
    }
}
