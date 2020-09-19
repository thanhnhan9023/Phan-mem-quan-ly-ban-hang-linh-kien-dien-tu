namespace QuanLyVatLieuXayDung
{
    partial class hanghoa
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dshanghoa = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dshanghoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dshanghoa
            // 
            this.dshanghoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dshanghoa.Location = new System.Drawing.Point(0, 0);
            this.dshanghoa.MainView = this.gridView1;
            this.dshanghoa.Name = "dshanghoa";
            this.dshanghoa.Size = new System.Drawing.Size(1064, 651);
            this.dshanghoa.TabIndex = 0;
            this.dshanghoa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dshanghoa.Click += new System.EventHandler(this.dshanghoa_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dshanghoa;
            this.gridView1.Name = "gridView1";
            // 
            // hanghoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dshanghoa);
            this.Name = "hanghoa";
               this.Load += new System.EventHandler(this.hangh
            this.Size = new System.Drawing.Size(1064, 651);
            ((System.ComponentModel.ISupportInitialize)(this.dshanghoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dshanghoa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
