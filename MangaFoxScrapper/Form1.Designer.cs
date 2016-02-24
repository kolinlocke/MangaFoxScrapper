namespace MangaFoxScrapper
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Url = new System.Windows.Forms.TextBox();
            this.Btn_Scrape = new System.Windows.Forms.Button();
            this.Btn_Chapters = new System.Windows.Forms.Button();
            this.Txt_Chapters = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Path = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_Download = new System.Windows.Forms.Button();
            this.Txt_EndPointIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // Txt_Url
            // 
            this.Txt_Url.Location = new System.Drawing.Point(13, 81);
            this.Txt_Url.Name = "Txt_Url";
            this.Txt_Url.Size = new System.Drawing.Size(259, 20);
            this.Txt_Url.TabIndex = 2;
            // 
            // Btn_Scrape
            // 
            this.Btn_Scrape.Location = new System.Drawing.Point(12, 107);
            this.Btn_Scrape.Name = "Btn_Scrape";
            this.Btn_Scrape.Size = new System.Drawing.Size(75, 23);
            this.Btn_Scrape.TabIndex = 3;
            this.Btn_Scrape.Text = "Scrape!";
            this.Btn_Scrape.UseVisualStyleBackColor = true;
            this.Btn_Scrape.Visible = false;
            // 
            // Btn_Chapters
            // 
            this.Btn_Chapters.Location = new System.Drawing.Point(197, 107);
            this.Btn_Chapters.Name = "Btn_Chapters";
            this.Btn_Chapters.Size = new System.Drawing.Size(75, 23);
            this.Btn_Chapters.TabIndex = 4;
            this.Btn_Chapters.Text = "Chapters!";
            this.Btn_Chapters.UseVisualStyleBackColor = true;
            // 
            // Txt_Chapters
            // 
            this.Txt_Chapters.Location = new System.Drawing.Point(12, 182);
            this.Txt_Chapters.Multiline = true;
            this.Txt_Chapters.Name = "Txt_Chapters";
            this.Txt_Chapters.Size = new System.Drawing.Size(259, 150);
            this.Txt_Chapters.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chapters";
            // 
            // Txt_Path
            // 
            this.Txt_Path.Location = new System.Drawing.Point(12, 351);
            this.Txt_Path.Name = "Txt_Path";
            this.Txt_Path.Size = new System.Drawing.Size(259, 20);
            this.Txt_Path.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Path";
            // 
            // Btn_Download
            // 
            this.Btn_Download.Location = new System.Drawing.Point(196, 377);
            this.Btn_Download.Name = "Btn_Download";
            this.Btn_Download.Size = new System.Drawing.Size(75, 23);
            this.Btn_Download.TabIndex = 8;
            this.Btn_Download.Text = "Download!";
            this.Btn_Download.UseVisualStyleBackColor = true;
            // 
            // Txt_EndPointIPAddress
            // 
            this.Txt_EndPointIPAddress.Location = new System.Drawing.Point(13, 26);
            this.Txt_EndPointIPAddress.Name = "Txt_EndPointIPAddress";
            this.Txt_EndPointIPAddress.Size = new System.Drawing.Size(259, 20);
            this.Txt_EndPointIPAddress.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "IP Address to be used (Blank if default)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 412);
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
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MangaFox Scrapper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Url;
        private System.Windows.Forms.Button Btn_Scrape;
        private System.Windows.Forms.Button Btn_Chapters;
        private System.Windows.Forms.TextBox Txt_Chapters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_Download;
        private System.Windows.Forms.TextBox Txt_EndPointIPAddress;
        private System.Windows.Forms.Label label4;
    }
}

