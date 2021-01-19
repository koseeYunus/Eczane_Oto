namespace Eczane_Oto
{
    partial class frmRaporlar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRaporlar));
            this.R_Firma = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.R_Kasa = new DevExpress.XtraTab.XtraTabPage();
            this.R_Gider = new DevExpress.XtraTab.XtraTabPage();
            this.R_Personel = new DevExpress.XtraTab.XtraTabPage();
            this.eczane_otomasyonDataSet = new Eczane_Oto.eczane_otomasyonDataSet();
            this.fIRMABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fIRMATableAdapter = new Eczane_Oto.eczane_otomasyonDataSetTableAdapters.FIRMATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eczane_otomasyonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIRMABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // R_Firma
            // 
            this.R_Firma.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.R_Firma.Appearance.Header.Options.UseFont = true;
            this.R_Firma.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("R_Firma.ImageOptions.Image")));
            this.R_Firma.Name = "R_Firma";
            this.R_Firma.Size = new System.Drawing.Size(1898, 794);
            this.R_Firma.Text = "Firma Raporları";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xtraTabControl1.Appearance.Options.UseFont = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.MultiLine = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.R_Kasa;
            this.xtraTabControl1.Size = new System.Drawing.Size(1904, 841);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.R_Kasa,
            this.R_Gider,
            this.R_Firma,
            this.R_Personel});
            // 
            // R_Kasa
            // 
            this.R_Kasa.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.R_Kasa.Appearance.Header.Options.UseFont = true;
            this.R_Kasa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("R_Kasa.ImageOptions.Image")));
            this.R_Kasa.Name = "R_Kasa";
            this.R_Kasa.Size = new System.Drawing.Size(1898, 794);
            this.R_Kasa.Text = "Kasa Rapoları";
            // 
            // R_Gider
            // 
            this.R_Gider.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.R_Gider.Appearance.Header.Options.UseFont = true;
            this.R_Gider.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("R_Gider.ImageOptions.Image")));
            this.R_Gider.Name = "R_Gider";
            this.R_Gider.Size = new System.Drawing.Size(1898, 794);
            this.R_Gider.Text = "Gider Raporları";
            // 
            // R_Personel
            // 
            this.R_Personel.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.R_Personel.Appearance.Header.Options.UseFont = true;
            this.R_Personel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("R_Personel.ImageOptions.Image")));
            this.R_Personel.Name = "R_Personel";
            this.R_Personel.Size = new System.Drawing.Size(1898, 794);
            this.R_Personel.Text = "Personel Raporları";
            // 
            // eczane_otomasyonDataSet
            // 
            this.eczane_otomasyonDataSet.DataSetName = "eczane_otomasyonDataSet";
            this.eczane_otomasyonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fIRMABindingSource
            // 
            this.fIRMABindingSource.DataMember = "FIRMA";
            this.fIRMABindingSource.DataSource = this.eczane_otomasyonDataSet;
            // 
            // fIRMATableAdapter
            // 
            this.fIRMATableAdapter.ClearBeforeFill = true;
            // 
            // frmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 841);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "frmRaporlar";
            this.Text = "RAPORLAR";
            this.Load += new System.EventHandler(this.frmRaporlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eczane_otomasyonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fIRMABindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTab.XtraTabPage R_Firma;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage R_Gider;
        private DevExpress.XtraTab.XtraTabPage R_Personel;
        private DevExpress.XtraTab.XtraTabPage R_Kasa;
        private eczane_otomasyonDataSet eczane_otomasyonDataSet;
        private System.Windows.Forms.BindingSource fIRMABindingSource;
        private eczane_otomasyonDataSetTableAdapters.FIRMATableAdapter fIRMATableAdapter;
    }
}