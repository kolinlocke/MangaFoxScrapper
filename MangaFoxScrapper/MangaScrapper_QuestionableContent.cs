using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Microsoft.VisualBasic;

namespace MangaFoxScrapper
{
    public class MangaScrapper_QuestionableContent : Interface_MangaScrapper
    {
        public Common_Objects.Volumes GetVolumes(string Url, string IPAddress_EndPoint)
        {
            throw new NotImplementedException();
        }

        public Common_Objects.Chapters GetChapters(string Url, string IPAddress_EndPoint)
        {
            HtmlWeb Hw = new HtmlWeb();
            HtmlDocument Hd = Hw.Load(@"http://questionablecontent.net/view.php?comic=1");

            var Node_Latest =
                Hd.DocumentNode
                    .SelectNodes("//ul[@id='comicnav' and ./li/a='Latest']").FirstOrDefault()
                    .SelectNodes(".//a[text()='Latest']").FirstOrDefault();
            var LatestChapter = Node_Latest.Attributes["href"].Value;

            Regex R = new Regex(@"[0-9]*$");
            var Matches = R.Matches(LatestChapter);
            Int32 Latest = Convert.ToInt32(Matches[0].Value);

            Common_Objects.Chapters Chapters = new Common_Objects.Chapters();

            for (Int32 Ct = 1; Ct <= Latest; Ct++)
            {
                String ChapterUrl = String.Format("http://questionablecontent.net/view.php?comic={0}", Ct);
                Chapters.Add(new Common_Objects.Chapter() { Url = ChapterUrl, Chapter_Name = Ct.ToString() });
            }

            return Chapters;
        }

        public void DownloadChapter(string Url, string Download_FilePath, string IPAddress_EndPoint)
        {
            HtmlWeb Hw = new HtmlWeb();
            HtmlDocument Hd = Hw.Load(Url);

            var Img =
                Hd.DocumentNode
                    .SelectNodes("//img[@id='strip']").FirstOrDefault()
                    .Attributes["src"].Value;

            Uri Img_Uri = new Uri(new Uri(Url), Img);

            //Regex R = new Regex(@"[0-9]*$");
            //var Matches = R.Matches(Url);
            //Int32 Ch = Convert.ToInt32(Matches[0].Value);

            //String Img_Url = String.Format("http://questionablecontent.net/comics/{0}.png", Ch);
            //String FilePath = Download_FilePath;

            String Img_Url = Img_Uri.ToString();
            String FilePath = Download_FilePath;

            using (WebClient Wc = new WebClient())
            {
                Uri Uri_Source = new Uri(Url);

                FileInfo Fi_Source = new FileInfo(Strings.Mid(Img_Url, Strings.InStrRev(Img_Url, @"/") + 1));
                FileInfo Fi_Target = new FileInfo(FilePath.TrimEnd('\\') + @"\" + Fi_Source.Name);
                if (!Fi_Target.Directory.Exists)
                { Fi_Target.Directory.Create(); }
                                
                Wc.DownloadFile(Img_Url, Fi_Target.FullName);
            }
        }
    }
}
