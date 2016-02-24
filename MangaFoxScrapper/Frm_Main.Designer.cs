namespace MangaFoxScrapper
{
    partial class Frm_Main
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
            this.Txt_EndPointIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_Download = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Txt_Path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Chapters = new System.Windows.Forms.TextBox();
            this.Btn_Chapters = new System.Windows.Forms.Button();
            this.Btn_Scrape = new System.Windows.Forms.Button();
            this.Txt_Url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Cmb_Site = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Txt_EndPointIPAddress
            // 
            this.Txt_EndPointIPAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_EndPointIPAddress.Location = new System.Drawing.Point(12, 26);
            this.Txt_EndPointIPAddress.Name = "Txt_EndPointIPAddress";
            this.Txt_EndPointIPAddress.Size = new System.Drawing.Size(259, 20);
            this.Txt_EndPointIPAddress.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "IP Address to be used (Blank if default)";
            // 
            // Btn_Download
            // 
            this.Btn_Download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Btn_Download.Location = new System.Drawing.Point(195, 377);
            this.Btn_Download.Name = "Btn_Download";
            this.Btn_Download.Size = new System.Drawing.Size(75, 23);
            this.Btn_Download.TabIndex = 8;
            this.Btn_Download.Text = "Download!";
            this.Btn_Download.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Path";
            // 
            // Txt_Path
            // 
            this.Txt_Path.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Txt_Path.Location = new System.Drawing.Point(11, 351);
            this.Txt_Path.Name = "Txt_Path";
            this.Txt_Path.Size = new System.Drawing.Size(259, 20);
            this.Txt_Path.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Chapters";
            // 
            // Txt_Chapters
            // 
            this.Txt_Chapters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Chapters.Location = new System.Drawing.Point(11, 202);
            this.Txt_Chapters.Multiline = true;
            this.Txt_Chapters.Name = "Txt_Chapters";
            this.Txt_Chapters.Size = new System.Drawing.Size(259, 130);
            this.Txt_Chapters.TabIndex = 5;
            // 
            // Btn_Chapters
            // 
            this.Btn_Chapters.Location = new System.Drawing.Point(196, 126);
            this.Btn_Chapters.Name = "Btn_Chapters";
            this.Btn_Chapters.Size = new System.Drawing.Size(75, 23);
            this.Btn_Chapters.TabIndex = 4;
            this.Btn_Chapters.Text = "Chapters!";
            this.Btn_Chapters.UseVisualStyleBackColor = true;
            // 
            // Btn_Scrape
            // 
            this.Btn_Scrape.Location = new System.Drawing.Point(11, 126);
            this.Btn_Scrape.Name = "Btn_Scrape";
            this.Btn_Scrape.Size = new System.Drawing.Size(75, 23);
            this.Btn_Scrape.TabIndex = 13;
            this.Btn_Scrape.Text = "Scrape!";
            this.Btn_Scrape.UseVisualStyleBackColor = true;
            this.Btn_Scrape.Visible = false;
            // 
            // Txt_Url
            // 
            this.Txt_Url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Url.Location = new System.Drawing.Point(12, 100);
            this.Txt_Url.Name = "Txt_Url";
            this.Txt_Url.Size = new System.Drawing.Size(259, 20);
            this.Txt_Url.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "URL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Site";
            // 
            // Cmb_Site
            // 
            this.Cmb_Site.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Site.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Site.FormattingEnabled = true;
            this.Cmb_Site.Location = new System.Drawing.Point(43, 52);
            this.Cmb_Site.Name = "Cmb_Site";
            this.Cmb_Site.Size = new System.Drawing.Size(227, 21);
            this.Cmb_Site.TabIndex = 2;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 412);
            this.Controls.Add(this.Cmb_Site);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Txt_EndPointIPAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Btn_Download);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_Path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Chapters);
            this.Controls.Add(this.Btn_Chapters);
            this.Controls.Add(this.Btn_Scrape);
            this.Controls.Add(this.Txt_Url);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(300, 450);
            this.Name = "Frm_Main";
            this.Text = "Frm_Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_EndPointIPAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Btn_Download;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_Path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Chapters;
        private System.Windows.Forms.Button Btn_Chapters;
        private System.Windows.Forms.Button Btn_Scrape;
        private System.Windows.Forms.TextBox Txt_Url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Cmb_Site;
    }
}