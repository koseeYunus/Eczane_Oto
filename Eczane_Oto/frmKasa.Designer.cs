namespace Eczane_Oto
{
    partial class frmKasa
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.RectangleGradientFillOptions rectangleGradientFillOptions1 = new DevExpress.XtraCharts.RectangleGradientFillOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKasa));
            this.label1 = new System.Windows.Forms.Label();
            this.ilacUcret = new System.Windows.Forms.Label();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.ilacKazanc = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.toplamKar = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.perMaas = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.perSayisi = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.ilacSatis = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.hastaSayisi = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.toplamGider = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupControl9 = new DevExpress.XtraEditors.GroupControl();
            this.kiraGider = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.eczaneGider = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.baslik = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).BeginInit();
            this.groupControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(60, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "İlaç Ücret :";
            // 
            // ilacUcret
            // 
            this.ilacUcret.AutoSize = true;
            this.ilacUcret.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ilacUcret.Location = new System.Drawing.Point(167, 58);
            this.ilacUcret.Name = "ilacUcret";
            this.ilacUcret.Size = new System.Drawing.Size(50, 19);
            this.ilacUcret.TabIndex = 1;
            this.ilacUcret.Text = "00 TL";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl3.Controls.Add(this.ilacKazanc);
            this.groupControl3.Controls.Add(this.label6);
            this.groupControl3.Location = new System.Drawing.Point(26, 633);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.ShowCaption = false;
            this.groupControl3.Size = new System.Drawing.Size(301, 71);
            this.groupControl3.TabIndex = 3;
            this.groupControl3.Text = "groupControl3";
            // 
            // ilacKazanc
            // 
            this.ilacKazanc.AutoSize = true;
            this.ilacKazanc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ilacKazanc.Location = new System.Drawing.Point(167, 24);
            this.ilacKazanc.Name = "ilacKazanc";
            this.ilacKazanc.Size = new System.Drawing.Size(54, 19);
            this.ilacKazanc.TabIndex = 5;
            this.ilacKazanc.Text = "00 TL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(22, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "Toplam Gelir :";
            // 
            // groupControl4
            // 
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl4.Controls.Add(this.toplamKar);
            this.groupControl4.Controls.Add(this.label8);
            this.groupControl4.Location = new System.Drawing.Point(26, 733);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.ShowCaption = false;
            this.groupControl4.Size = new System.Drawing.Size(301, 71);
            this.groupControl4.TabIndex = 2;
            this.groupControl4.Text = "groupControl4";
            // 
            // toplamKar
            // 
            this.toplamKar.AutoSize = true;
            this.toplamKar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toplamKar.Location = new System.Drawing.Point(167, 24);
            this.toplamKar.Name = "toplamKar";
            this.toplamKar.Size = new System.Drawing.Size(54, 19);
            this.toplamKar.TabIndex = 1;
            this.toplamKar.Text = "00 TL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(33, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Toplam Kar :";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.perMaas);
            this.groupControl5.Controls.Add(this.label22);
            this.groupControl5.Controls.Add(this.perSayisi);
            this.groupControl5.Controls.Add(this.label16);
            this.groupControl5.Location = new System.Drawing.Point(26, 207);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.ShowCaption = false;
            this.groupControl5.Size = new System.Drawing.Size(301, 113);
            this.groupControl5.TabIndex = 5;
            this.groupControl5.Text = "groupControl5";
            // 
            // perMaas
            // 
            this.perMaas.AutoSize = true;
            this.perMaas.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.perMaas.Location = new System.Drawing.Point(167, 61);
            this.perMaas.Name = "perMaas";
            this.perMaas.Size = new System.Drawing.Size(50, 19);
            this.perMaas.TabIndex = 3;
            this.perMaas.Text = "00 TL";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label22.Location = new System.Drawing.Point(22, 61);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 19);
            this.label22.TabIndex = 2;
            this.label22.Text = "Personel Maaş : ";
            // 
            // perSayisi
            // 
            this.perSayisi.AutoSize = true;
            this.perSayisi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.perSayisi.Location = new System.Drawing.Point(167, 24);
            this.perSayisi.Name = "perSayisi";
            this.perSayisi.Size = new System.Drawing.Size(50, 19);
            this.perSayisi.TabIndex = 1;
            this.perSayisi.Text = "00 TL";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.Location = new System.Drawing.Point(22, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 19);
            this.label16.TabIndex = 0;
            this.label16.Text = "Personel Sayısı :";
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.ilacSatis);
            this.groupControl6.Controls.Add(this.label18);
            this.groupControl6.Controls.Add(this.ilacUcret);
            this.groupControl6.Controls.Add(this.hastaSayisi);
            this.groupControl6.Controls.Add(this.label1);
            this.groupControl6.Controls.Add(this.label12);
            this.groupControl6.Location = new System.Drawing.Point(26, 27);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.ShowCaption = false;
            this.groupControl6.Size = new System.Drawing.Size(301, 146);
            this.groupControl6.TabIndex = 7;
            this.groupControl6.Text = "groupControl6";
            // 
            // ilacSatis
            // 
            this.ilacSatis.AutoSize = true;
            this.ilacSatis.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ilacSatis.Location = new System.Drawing.Point(167, 92);
            this.ilacSatis.Name = "ilacSatis";
            this.ilacSatis.Size = new System.Drawing.Size(50, 19);
            this.ilacSatis.TabIndex = 3;
            this.ilacSatis.Text = "00 TL";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.Location = new System.Drawing.Point(64, 92);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 19);
            this.label18.TabIndex = 2;
            this.label18.Text = "İlaç Satış :";
            // 
            // hastaSayisi
            // 
            this.hastaSayisi.AutoSize = true;
            this.hastaSayisi.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.hastaSayisi.Location = new System.Drawing.Point(167, 24);
            this.hastaSayisi.Name = "hastaSayisi";
            this.hastaSayisi.Size = new System.Drawing.Size(50, 19);
            this.hastaSayisi.TabIndex = 1;
            this.hastaSayisi.Text = "00 TL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(43, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "Hasta Sayısı :";
            // 
            // groupControl7
            // 
            this.groupControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupControl7.Appearance.Options.UseFont = true;
            this.groupControl7.Controls.Add(this.toplamGider);
            this.groupControl7.Controls.Add(this.label14);
            this.groupControl7.Location = new System.Drawing.Point(26, 533);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.ShowCaption = false;
            this.groupControl7.Size = new System.Drawing.Size(301, 71);
            this.groupControl7.TabIndex = 6;
            this.groupControl7.Text = "groupControl7";
            // 
            // toplamGider
            // 
            this.toplamGider.AutoSize = true;
            this.toplamGider.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toplamGider.Location = new System.Drawing.Point(167, 24);
            this.toplamGider.Name = "toplamGider";
            this.toplamGider.Size = new System.Drawing.Size(54, 19);
            this.toplamGider.TabIndex = 1;
            this.toplamGider.Text = "00 TL";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.Location = new System.Drawing.Point(17, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(130, 19);
            this.label14.TabIndex = 0;
            this.label14.Text = "Toplam Gider :";
            // 
            // groupControl9
            // 
            this.groupControl9.Controls.Add(this.kiraGider);
            this.groupControl9.Controls.Add(this.label24);
            this.groupControl9.Controls.Add(this.eczaneGider);
            this.groupControl9.Controls.Add(this.label26);
            this.groupControl9.Location = new System.Drawing.Point(26, 362);
            this.groupControl9.Name = "groupControl9";
            this.groupControl9.ShowCaption = false;
            this.groupControl9.Size = new System.Drawing.Size(301, 116);
            this.groupControl9.TabIndex = 6;
            this.groupControl9.Text = "groupControl9";
            // 
            // kiraGider
            // 
            this.kiraGider.AutoSize = true;
            this.kiraGider.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kiraGider.Location = new System.Drawing.Point(167, 61);
            this.kiraGider.Name = "kiraGider";
            this.kiraGider.Size = new System.Drawing.Size(50, 19);
            this.kiraGider.TabIndex = 3;
            this.kiraGider.Text = "00 TL";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label24.Location = new System.Drawing.Point(35, 61);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 19);
            this.label24.TabIndex = 2;
            this.label24.Text = "Kira Giderleri :";
            // 
            // eczaneGider
            // 
            this.eczaneGider.AutoSize = true;
            this.eczaneGider.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.eczaneGider.Location = new System.Drawing.Point(167, 24);
            this.eczaneGider.Name = "eczaneGider";
            this.eczaneGider.Size = new System.Drawing.Size(50, 19);
            this.eczaneGider.TabIndex = 1;
            this.eczaneGider.Text = "00 TL";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label26.Location = new System.Drawing.Point(14, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(133, 19);
            this.label26.TabIndex = 0;
            this.label26.Text = "Eczane Giderleri :";
            // 
            // chartControl1
            // 
            this.chartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(401, 78);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "Aylar";
            sideBySideBarSeriesView1.BarWidth = 0.8D;
            sideBySideBarSeriesView1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(96)))));
            sideBySideBarSeriesView1.Border.Thickness = 2;
            sideBySideBarSeriesView1.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            sideBySideBarSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(150)))), ((int)(((byte)(148)))));
            sideBySideBarSeriesView1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient;
            rectangleGradientFillOptions1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(141)))), ((int)(((byte)(212)))));
            sideBySideBarSeriesView1.FillStyle.Options = rectangleGradientFillOptions1;
            series1.View = sideBySideBarSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(1435, 653);
            this.chartControl1.TabIndex = 8;
            // 
            // baslik
            // 
            this.baslik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baslik.AutoSize = true;
            this.baslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baslik.ForeColor = System.Drawing.Color.RoyalBlue;
            this.baslik.Location = new System.Drawing.Point(1011, 27);
            this.baslik.Name = "baslik";
            this.baslik.Size = new System.Drawing.Size(154, 31);
            this.baslik.TabIndex = 9;
            this.baslik.Text = "ELEKTRİK";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(964, 754);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 55);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "GERİ";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(1098, 754);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(125, 55);
            this.simpleButton2.TabIndex = 11;
            this.simpleButton2.Text = "DURDUR";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton3.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Appearance.Options.UseForeColor = true;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(1253, 754);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(103, 55);
            this.simpleButton3.TabIndex = 12;
            this.simpleButton3.Text = "İLERİ";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // frmKasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 841);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.baslik);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.groupControl9);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl6);
            this.Controls.Add(this.groupControl7);
            this.Controls.Add(this.groupControl3);
            this.Name = "frmKasa";
            this.Text = "KASA";
            this.Load += new System.EventHandler(this.frmKasa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            this.groupControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).EndInit();
            this.groupControl9.ResumeLayout(false);
            this.groupControl9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ilacUcret;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.Label toplamKar;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private System.Windows.Forms.Label perMaas;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label perSayisi;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private System.Windows.Forms.Label ilacKazanc;
        private System.Windows.Forms.Label ilacSatis;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label hastaSayisi;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private System.Windows.Forms.Label toplamGider;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.GroupControl groupControl9;
        private System.Windows.Forms.Label kiraGider;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label eczaneGider;
        private System.Windows.Forms.Label label26;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Label baslik;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
    }
}