namespace FreshWall
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabCtrlMain = new MetroFramework.Controls.MetroTabControl();
            this.tabPgeWallSettings = new MetroFramework.Controls.MetroTabPage();
            this.btnSaveKeywords = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtBxKeywords = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPgeSettings = new MetroFramework.Controls.MetroTabPage();
            this.chkBxAutomatic = new MetroFramework.Controls.MetroCheckBox();
            this.tabCtrlMain.SuspendLayout();
            this.tabPgeWallSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPgeSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Controls.Add(this.tabPgeWallSettings);
            this.tabCtrlMain.Controls.Add(this.tabPgeSettings);
            this.tabCtrlMain.FontSize = MetroFramework.MetroTabControlSize.Tall;
            this.tabCtrlMain.Location = new System.Drawing.Point(23, 63);
            this.tabCtrlMain.Multiline = true;
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 1;
            this.tabCtrlMain.Size = new System.Drawing.Size(764, 364);
            this.tabCtrlMain.Style = MetroFramework.MetroColorStyle.Yellow;
            this.tabCtrlMain.TabIndex = 0;
            this.tabCtrlMain.UseSelectable = true;
            // 
            // tabPgeWallSettings
            // 
            this.tabPgeWallSettings.Controls.Add(this.btnSaveKeywords);
            this.tabPgeWallSettings.Controls.Add(this.metroLabel1);
            this.tabPgeWallSettings.Controls.Add(this.txtBxKeywords);
            this.tabPgeWallSettings.Controls.Add(this.pictureBox1);
            this.tabPgeWallSettings.HorizontalScrollbarBarColor = true;
            this.tabPgeWallSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPgeWallSettings.HorizontalScrollbarSize = 10;
            this.tabPgeWallSettings.Location = new System.Drawing.Point(4, 44);
            this.tabPgeWallSettings.Name = "tabPgeWallSettings";
            this.tabPgeWallSettings.Size = new System.Drawing.Size(756, 316);
            this.tabPgeWallSettings.TabIndex = 0;
            this.tabPgeWallSettings.Text = "Wallpaper Settings";
            this.tabPgeWallSettings.VerticalScrollbarBarColor = true;
            this.tabPgeWallSettings.VerticalScrollbarHighlightOnWheel = false;
            this.tabPgeWallSettings.VerticalScrollbarSize = 10;
            // 
            // btnSaveKeywords
            // 
            this.btnSaveKeywords.Highlight = true;
            this.btnSaveKeywords.Location = new System.Drawing.Point(500, 80);
            this.btnSaveKeywords.Name = "btnSaveKeywords";
            this.btnSaveKeywords.Size = new System.Drawing.Size(180, 40);
            this.btnSaveKeywords.Style = MetroFramework.MetroColorStyle.Yellow;
            this.btnSaveKeywords.TabIndex = 6;
            this.btnSaveKeywords.Text = "Save Keywords";
            this.btnSaveKeywords.UseCustomBackColor = true;
            this.btnSaveKeywords.UseSelectable = true;
            this.btnSaveKeywords.Click += new System.EventHandler(this.btnSaveKeywords_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(500, 13);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(116, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Set your Keywords";
            // 
            // txtBxKeywords
            // 
            // 
            // 
            // 
            this.txtBxKeywords.CustomButton.Image = null;
            this.txtBxKeywords.CustomButton.Location = new System.Drawing.Point(228, 1);
            this.txtBxKeywords.CustomButton.Name = "";
            this.txtBxKeywords.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtBxKeywords.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBxKeywords.CustomButton.TabIndex = 1;
            this.txtBxKeywords.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBxKeywords.CustomButton.UseSelectable = true;
            this.txtBxKeywords.CustomButton.Visible = false;
            this.txtBxKeywords.Lines = new string[] {
        "Landscape; Dogs; Trees;"};
            this.txtBxKeywords.Location = new System.Drawing.Point(500, 38);
            this.txtBxKeywords.MaxLength = 32767;
            this.txtBxKeywords.Name = "txtBxKeywords";
            this.txtBxKeywords.PasswordChar = '\0';
            this.txtBxKeywords.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBxKeywords.SelectedText = "";
            this.txtBxKeywords.SelectionLength = 0;
            this.txtBxKeywords.SelectionStart = 0;
            this.txtBxKeywords.ShortcutsEnabled = true;
            this.txtBxKeywords.ShowClearButton = true;
            this.txtBxKeywords.Size = new System.Drawing.Size(250, 23);
            this.txtBxKeywords.Style = MetroFramework.MetroColorStyle.Yellow;
            this.txtBxKeywords.TabIndex = 4;
            this.txtBxKeywords.Text = "Landscape; Dogs; Trees;";
            this.txtBxKeywords.UseSelectable = true;
            this.txtBxKeywords.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBxKeywords.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(429, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // tabPgeSettings
            // 
            this.tabPgeSettings.Controls.Add(this.chkBxAutomatic);
            this.tabPgeSettings.HorizontalScrollbarBarColor = true;
            this.tabPgeSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPgeSettings.HorizontalScrollbarSize = 10;
            this.tabPgeSettings.Location = new System.Drawing.Point(4, 44);
            this.tabPgeSettings.Name = "tabPgeSettings";
            this.tabPgeSettings.Size = new System.Drawing.Size(756, 316);
            this.tabPgeSettings.TabIndex = 1;
            this.tabPgeSettings.Text = "Settings";
            this.tabPgeSettings.VerticalScrollbarBarColor = true;
            this.tabPgeSettings.VerticalScrollbarHighlightOnWheel = false;
            this.tabPgeSettings.VerticalScrollbarSize = 10;
            // 
            // chkBxAutomatic
            // 
            this.chkBxAutomatic.AutoSize = true;
            this.chkBxAutomatic.Location = new System.Drawing.Point(3, 30);
            this.chkBxAutomatic.Name = "chkBxAutomatic";
            this.chkBxAutomatic.Size = new System.Drawing.Size(195, 15);
            this.chkBxAutomatic.Style = MetroFramework.MetroColorStyle.Yellow;
            this.chkBxAutomatic.TabIndex = 2;
            this.chkBxAutomatic.Text = "Automatically change Wallpaper";
            this.chkBxAutomatic.UseSelectable = true;
            this.chkBxAutomatic.CheckStateChanged += new System.EventHandler(this.chkBxAutomatic_CheckStateChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabCtrlMain);
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Text = "FreshWall";
            this.tabCtrlMain.ResumeLayout(false);
            this.tabPgeWallSettings.ResumeLayout(false);
            this.tabPgeWallSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPgeSettings.ResumeLayout(false);
            this.tabPgeSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tabCtrlMain;
        private MetroFramework.Controls.MetroTabPage tabPgeWallSettings;
        private MetroFramework.Controls.MetroTabPage tabPgeSettings;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton btnSaveKeywords;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtBxKeywords;
        private MetroFramework.Controls.MetroCheckBox chkBxAutomatic;
    }
}

