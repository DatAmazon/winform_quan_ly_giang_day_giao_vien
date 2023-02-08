
namespace BTL
{
    partial class FrmCha
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemLichDay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemMon = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemThoiGian = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemGiangVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuQuanLy});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1587, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemLogin,
            this.mnuItemExit});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(85, 24);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuItemLogin
            // 
            this.mnuItemLogin.Name = "mnuItemLogin";
            this.mnuItemLogin.Size = new System.Drawing.Size(165, 26);
            this.mnuItemLogin.Text = "Đăng nhập";
            this.mnuItemLogin.Click += new System.EventHandler(this.mnuItemLogin_Click);
            // 
            // mnuItemExit
            // 
            this.mnuItemExit.Name = "mnuItemExit";
            this.mnuItemExit.Size = new System.Drawing.Size(165, 26);
            this.mnuItemExit.Text = "Thoát";
            this.mnuItemExit.Click += new System.EventHandler(this.mnuItemExit_Click);
            // 
            // mnuQuanLy
            // 
            this.mnuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemLichDay,
            this.mnuItemMon,
            this.mnuItemThoiGian,
            this.mnuItemGiangVien});
            this.mnuQuanLy.Name = "mnuQuanLy";
            this.mnuQuanLy.Size = new System.Drawing.Size(73, 24);
            this.mnuQuanLy.Text = "Quản lý";
            this.mnuQuanLy.Click += new System.EventHandler(this.mnuQuanLy_Click);
            // 
            // mnuItemLichDay
            // 
            this.mnuItemLichDay.Name = "mnuItemLichDay";
            this.mnuItemLichDay.Size = new System.Drawing.Size(164, 26);
            this.mnuItemLichDay.Text = "Lịch Dạy";
            this.mnuItemLichDay.Click += new System.EventHandler(this.mnuItemLichDay_Click);
            // 
            // mnuItemMon
            // 
            this.mnuItemMon.Name = "mnuItemMon";
            this.mnuItemMon.Size = new System.Drawing.Size(164, 26);
            this.mnuItemMon.Text = "Môn";
            this.mnuItemMon.Click += new System.EventHandler(this.mnuItemMon_Click);
            // 
            // mnuItemThoiGian
            // 
            this.mnuItemThoiGian.Name = "mnuItemThoiGian";
            this.mnuItemThoiGian.Size = new System.Drawing.Size(164, 26);
            this.mnuItemThoiGian.Text = "Thời Gian";
            this.mnuItemThoiGian.Click += new System.EventHandler(this.mnuItemThoiGian_Click);
            // 
            // mnuItemGiangVien
            // 
            this.mnuItemGiangVien.Name = "mnuItemGiangVien";
            this.mnuItemGiangVien.Size = new System.Drawing.Size(164, 26);
            this.mnuItemGiangVien.Text = "Giảng Viên";
            this.mnuItemGiangVien.Click += new System.EventHandler(this.mnuItemGiangVien_Click);
            // 
            // FrmCha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 732);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmCha";
            this.Text = "Quản lý giảng dạy giảng viên - Kiều Đức Đạt - 1810A03";
            this.Load += new System.EventHandler(this.FrmCha_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem mnuItemLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExit;
        private System.Windows.Forms.ToolStripMenuItem mnuItemLichDay;
        private System.Windows.Forms.ToolStripMenuItem mnuItemMon;
        private System.Windows.Forms.ToolStripMenuItem mnuItemThoiGian;
        private System.Windows.Forms.ToolStripMenuItem mnuItemGiangVien;
    }
}

