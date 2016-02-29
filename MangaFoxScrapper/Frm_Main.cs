using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MangaFoxScrapper
{
    public partial class Frm_Main : Form
    {
        const String Cns_MangaFox = "MangaFox";
        const String Cns_MangaHere = "MangaHere";
        const String Cns_MangaPanda = "MangaPanda";
        const String Cns_QuestionableContent = "QuestionableContent";

        Interface_MangaScrapper mMangaScrapper;

        public Frm_Main()
        {
            this.InitializeComponent();
            this.Setup();            
        }

        void Setup()
        {
            this.Setup_EventHandlers();

            List<String> Sites = new List<String>();
            Sites.Add(Cns_MangaFox);
            Sites.Add(Cns_MangaHere);
            Sites.Add(Cns_MangaPanda);
            Sites.Add(Cns_QuestionableContent);

            this.Cmb_Site.DataSource = Sites;
        }

        void Setup_EventHandlers()
        {
            this.Btn_Chapters.Click += new EventHandler(Btn_Chapters_Click);
            this.Btn_Download.Click += new EventHandler(Btn_Download_Click);
        }

        void Btn_Download_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> Chapters = new List<String>();
                Chapters = this.Txt_Chapters.Text.Split(new String[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();

                String FilePath = this.Txt_Path.Text;

                var MangaScrapper = this.Get_Implementation();
                foreach (String Chapter in Chapters)
                { MangaScrapper.DownloadChapter(Chapter, FilePath, this.Txt_EndPointIPAddress.Text); }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void Btn_Chapters_Click(object sender, EventArgs e)
        {
            try
            {
                var MangaScrapper = this.Get_Implementation();
                var Chapters = MangaScrapper.GetChapters(this.Txt_Url.Text, this.Txt_EndPointIPAddress.Text);

                StringBuilder ChapterLinks = new StringBuilder();
                Chapters
                    //.OrderBy(O => O.Url)
                    .ToList()
                    .ForEach(O => ChapterLinks.AppendLine(O.Url));

                this.Txt_Chapters.Text = ChapterLinks.ToString().Trim();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        Interface_MangaScrapper Get_Implementation()
        {
            Interface_MangaScrapper MangaScrapper = null;
            String Selected_Site = (String)this.Cmb_Site.SelectedItem;
            switch (Selected_Site)
            { 
                case Cns_MangaFox:
                    MangaScrapper = new MangaScrapper_MangaFox();
                    break;
                case Cns_MangaHere:
                    MangaScrapper = new MangaScrapper_MangaHere();
                    break;
                case Cns_MangaPanda:
                    MangaScrapper = new MangaScrapper_MangaPanda();
                    break;
                case Cns_QuestionableContent:
                    MangaScrapper = new MangaScrapper_QuestionableContent();
                    break;
            }

            return MangaScrapper;
        }        
    }
}
