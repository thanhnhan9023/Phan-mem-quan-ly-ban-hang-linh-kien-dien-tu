namespace QuanLyVatLieuXayDung.GUI
{
    partial class ThongKeNhapHang
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dsHoadon = new DevExpress.XtraGrid.GridControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnNam = new DevExpress.XtraEditors.SimpleButton();
            this.btnThang = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnNgay = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsHoadon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dsHoadon;
            this.gridView1.Name = "gridView1";
            // 
            // dsHoadon
            // 
            this.dsHoadon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsHoadon.Location = new System.Drawing.Point(2, 2);
            this.dsHoadon.MainView = this.gridView1;
            this.dsHoadon.Name = "dsHoadon";
            this.dsHoadon.Size = new System.Drawing.Size(988, 225);
            this.dsHoadon.TabIndex = 0;
            this.dsHoadon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.dsHoadon);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 251);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(992, 229);
            this.panelControl2.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(370, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(234, 29);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Thống Kê Bán Hàng";
            // 
            // groupControl2
            // 
            this.groupControl2.Location = new System.Drawing.Point(141, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(28, 10);
            this.groupControl2.TabIndex = 0;
            this.groupControl2.Text = "groupControl2";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(14, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(254, 23);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.dateTimePicker1);
            this.groupControl1.Location = new System.Drawing.Point(5, 73);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(359, 173);
            this.groupControl1.TabIndex = 2;
            // 
            // btnNam
            // 
            this.btnNam.Location = new System.Drawing.Point(38, 119);
            this.btnNam.Name = "btnNam";
            this.btnNam.Size = new System.Drawing.Size(147, 29);
            this.btnNam.TabIndex = 3;
            this.btnNam.Text = "Xem Theo Năm";
            // 
            // btnThang
            // 
            this.btnThang.Location = new System.Drawing.Point(38, 74);
            this.btnThang.Name = "btnThang";
            this.btnThang.Size = new System.Drawing.Size(147, 29);
            this.btnThang.TabIndex = 2;
            this.btnThang.Text = "Xem Theo Theo Tháng";
            this.btnThang.Click += new System.EventHandler(this.btnThang_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(50, 35);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(8, 8);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "simpleButton2";
            // 
            // btnNgay
            // 
            this.btnNgay.Location = new System.Drawing.Point(38, 35);
            this.btnNgay.Name = "btnNgay";
            this.btnNgay.Size = new System.Drawing.Size(147, 29);
            this.btnNgay.TabIndex = 0;
            this.btnNgay.Text = "Xem Theo Ngày";
            this.btnNgay.Click += new System.EventHandler(this.btnNgay_Click);
            // 
            // groupControl4
            // 
            this.groupControl4.Location = new System.Drawing.Point(527, 78);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(28, 10);
            this.groupControl4.TabIndex = 0;
            this.groupControl4.Text = "groupControl4";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btnNam);
            this.groupControl3.Controls.Add(this.btnThang);
            this.groupControl3.Controls.Add(this.simpleButton2);
            this.groupControl3.Controls.Add(this.btnNgay);
            this.groupControl3.Location = new System.Drawing.Point(370, 73);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(229, 178);
            this.groupControl3.TabIndex = 3;
            this.groupControl3.Text = "Mục lựa chọn ";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(58, 74);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(94, 29);
            this.btnXem.TabIndex = 2;
            this.btnXem.Text = "Xem";
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(40, 18);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(8, 8);
            this.simpleButton5.TabIndex = 1;
            this.simpleButton5.Text = "simpleButton5";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.btnXem);
            this.groupControl5.Controls.Add(this.simpleButton5);
            this.groupControl5.Location = new System.Drawing.Point(605, 73);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(229, 173);
            this.groupControl5.TabIndex = 4;
            this.groupControl5.Text = "Xuat thong tin";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl5);
            this.panelControl1.Controls.Add(this.groupControl4);
            this.panelControl1.Controls.Add(this.groupControl3);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(992, 251);
            this.panelControl1.TabIndex = 2;
           // this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // ThongkeBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ThongkeBanHang";
            this.Load += new System.EventHandler(this.ThongKeNhapHang_Load);
            this.Size = new System.Drawing.Size(992, 480);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsHoadon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl dsHoadon;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnNam;
        private DevExpress.XtraEditors.SimpleButton btnThang;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnNgay;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}