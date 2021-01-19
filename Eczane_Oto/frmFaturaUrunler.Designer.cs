namespace Eczane_Oto
{
    partial class frmFaturaUrunler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFaturaUrunler));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.btnBul = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.tutar = new System.Windows.Forms.NumericUpDown();
            this.fiyat = new System.Windows.Forms.NumericUpDown();
            this.miktar = new System.Windows.Forms.NumericUpDown();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.urun = new DevExpress.XtraEditors.TextEdit();
            this.urunID = new DevExpress.XtraEditors.TextEdit();
            this.LBL16 = new DevExpress.XtraEditors.LabelControl();
            this.LBL15 = new DevExpress.XtraEditors.LabelControl();
            this.LBL14 = new DevExpress.XtraEditors.LabelControl();
            this.LBL17 = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urun.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1086, 589);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // groupControl5
            // 
            this.groupControl5.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl5.CaptionImageOptions.Image")));
            this.groupControl5.Controls.Add(this.btnBul);
            this.groupControl5.Controls.Add(this.btnKaydet);
            this.groupControl5.Controls.Add(this.tutar);
            this.groupControl5.Controls.Add(this.fiyat);
            this.groupControl5.Controls.Add(this.miktar);
            this.groupControl5.Controls.Add(this.btnTemizle);
            this.groupControl5.Controls.Add(this.btnGuncelle);
            this.groupControl5.Controls.Add(this.btnSil);
            this.groupControl5.Controls.Add(this.btnEkle);
            this.groupControl5.Controls.Add(this.labelControl2);
            this.groupControl5.Controls.Add(this.urun);
            this.groupControl5.Controls.Add(this.urunID);
            this.groupControl5.Controls.Add(this.LBL16);
            this.groupControl5.Controls.Add(this.LBL15);
            this.groupControl5.Controls.Add(this.LBL14);
            this.groupControl5.Controls.Add(this.LBL17);
            this.groupControl5.Location = new System.Drawing.Point(1112, 12);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(305, 589);
            this.groupControl5.TabIndex = 42;
            this.groupControl5.Text = "ÜRÜN BİLGİLERİ";
            // 
            // btnBul
            // 
            this.btnBul.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBul.Appearance.Options.UseFont = true;
            this.btnBul.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBul.ImageOptions.Image")));
            this.btnBul.Location = new System.Drawing.Point(196, 56);
            this.btnBul.Name = "btnBul";
            this.btnBul.Size = new System.Drawing.Size(87, 28);
            this.btnBul.TabIndex = 55;
            this.btnBul.Text = "BUL";
            this.btnBul.Click += new System.EventHandler(this.btnBul_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(103, 525);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(180, 40);
            this.btnKaydet.TabIndex = 54;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tutar
            // 
            this.tutar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tutar.Location = new System.Drawing.Point(103, 196);
            this.tutar.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.tutar.Name = "tutar";
            this.tutar.Size = new System.Drawing.Size(180, 26);
            this.tutar.TabIndex = 5;
            // 
            // fiyat
            // 
            this.fiyat.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.fiyat.Location = new System.Drawing.Point(103, 161);
            this.fiyat.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.fiyat.Name = "fiyat";
            this.fiyat.Size = new System.Drawing.Size(180, 26);
            this.fiyat.TabIndex = 4;
            this.fiyat.ValueChanged += new System.EventHandler(this.fiyat_ValueChanged);
            // 
            // miktar
            // 
            this.miktar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.miktar.Location = new System.Drawing.Point(103, 126);
            this.miktar.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.miktar.Name = "miktar";
            this.miktar.Size = new System.Drawing.Size(180, 26);
            this.miktar.TabIndex = 3;
            this.miktar.ValueChanged += new System.EventHandler(this.miktar_ValueChanged);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTemizle.Appearance.Options.UseFont = true;
            this.btnTemizle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTemizle.ImageOptions.Image")));
            this.btnTemizle.Location = new System.Drawing.Point(103, 415);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(180, 40);
            this.btnTemizle.TabIndex = 9;
            this.btnTemizle.Text = "TEMİZLE";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Appearance.Options.UseFont = true;
            this.btnGuncelle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuncelle.ImageOptions.Image")));
            this.btnGuncelle.Location = new System.Drawing.Point(103, 360);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(180, 40);
            this.btnGuncelle.TabIndex = 8;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSil.ImageOptions.Image")));
            this.btnSil.Location = new System.Drawing.Point(103, 304);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(180, 40);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "SİL";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.Appearance.Options.UseFont = true;
            this.btnEkle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEkle.ImageOptions.Image")));
            this.btnEkle.Location = new System.Drawing.Point(103, 249);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(180, 40);
            this.btnEkle.TabIndex = 6;
            this.btnEkle.Text = "EKLE";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(36, 198);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 18);
            this.labelControl2.TabIndex = 53;
            this.labelControl2.Text = "Tutar :";
            // 
            // urun
            // 
            this.urun.Location = new System.Drawing.Point(103, 93);
            this.urun.Name = "urun";
            this.urun.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urun.Properties.Appearance.Options.UseFont = true;
            this.urun.Size = new System.Drawing.Size(180, 24);
            this.urun.TabIndex = 2;
            // 
            // urunID
            // 
            this.urunID.Location = new System.Drawing.Point(103, 60);
            this.urunID.Name = "urunID";
            this.urunID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunID.Properties.Appearance.Options.UseFont = true;
            this.urunID.Size = new System.Drawing.Size(87, 24);
            this.urunID.TabIndex = 1;
            // 
            // LBL16
            // 
            this.LBL16.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL16.Appearance.Options.UseFont = true;
            this.LBL16.Location = new System.Drawing.Point(33, 128);
            this.LBL16.Name = "LBL16";
            this.LBL16.Size = new System.Drawing.Size(49, 18);
            this.LBL16.TabIndex = 45;
            this.LBL16.Text = "Miktar :";
            // 
            // LBL15
            // 
            this.LBL15.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL15.Appearance.Options.UseFont = true;
            this.LBL15.Location = new System.Drawing.Point(41, 96);
            this.LBL15.Name = "LBL15";
            this.LBL15.Size = new System.Drawing.Size(41, 18);
            this.LBL15.TabIndex = 47;
            this.LBL15.Text = "Ürün :";
            // 
            // LBL14
            // 
            this.LBL14.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL14.Appearance.Options.UseFont = true;
            this.LBL14.Location = new System.Drawing.Point(20, 63);
            this.LBL14.Name = "LBL14";
            this.LBL14.Size = new System.Drawing.Size(62, 18);
            this.LBL14.TabIndex = 46;
            this.LBL14.Text = "Ürün ID :";
            // 
            // LBL17
            // 
            this.LBL17.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LBL17.Appearance.Options.UseFont = true;
            this.LBL17.Location = new System.Drawing.Point(41, 163);
            this.LBL17.Name = "LBL17";
            this.LBL17.Size = new System.Drawing.Size(41, 18);
            this.LBL17.TabIndex = 45;
            this.LBL17.Text = "Fiyat :";
            // 
            // frmFaturaUrunler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1429, 612);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.gridControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFaturaUrunler";
            this.Text = "FATURA ÜRÜNLER";
            this.Load += new System.EventHandler(this.frmFaturaUrunler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tutar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urun.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit urun;
        private DevExpress.XtraEditors.TextEdit urunID;
        private DevExpress.XtraEditors.LabelControl LBL16;
        private DevExpress.XtraEditors.LabelControl LBL15;
        private DevExpress.XtraEditors.LabelControl LBL14;
        private DevExpress.XtraEditors.LabelControl LBL17;
        private System.Windows.Forms.NumericUpDown tutar;
        private System.Windows.Forms.NumericUpDown fiyat;
        private System.Windows.Forms.NumericUpDown miktar;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.SimpleButton btnGuncelle;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnBul;
        private System.Windows.Forms.Timer timer1;
    }
}