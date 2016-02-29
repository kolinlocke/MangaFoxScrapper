using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace MangaFoxScrapper
{
    public class MangaScrapper_MangaPanda : Interface_MangaScrapper
    {
        public Common_Objects.Volumes GetVolumes(string Url, string IPAddress_EndPoint)
        {
            throw new NotImplementedException();
        }

        public Common_Objects.Chapters GetChapters(string Url, string IPAddress_EndPoint)
        {
            String HtmlSource;
            using (var wc = new Common_Objects.GZipWebClient(IPAddress_EndPoint))
            { HtmlSource = wc.DownloadString(Url); }

            HtmlAgilityPack.HtmlDocument Hd = new HtmlAgilityPack.HtmlDocument();
            Hd.LoadHtml(HtmlSource);

            var Nodes = Hd.DocumentNode.SelectNodes("//div[@id='chapterlist']");
            var Node_Chapters = Nodes.FirstOrDefault();
                
            List<String> List_Links = new List<String>();

            var Links = Node_Chapters.SelectNodes(".//a");
            foreach (var Item_Link in Links)
            {
                if (Item_Link.Attributes.Contains("href"))
                {
                    Uri Uri_Source = new Uri(Url);
                    List_Links.Add("http://" + Uri_Source.Host + Item_Link.Attributes["href"].Value);
                }
            }

            var List_Chapters =
                List_Links.Select(O =>
                new Common_Objects.Chapter()
                {
                    Url = O
                }).ToList();

            Common_Objects.Chapters Chapters = new Common_Objects.Chapters();
            Chapters.AddRange(List_Chapters);

            return Chapters;
        }

        public void DownloadChapter(string Url, string Download_FilePath, string IPAddress_EndPoint)
        {
            String FilePath = Download_FilePath;

            //Get Pages

            String Html;
            using (var wc = new Common_Objects.GZipWebClient(IPAddress_EndPoint))
            { Html = wc.DownloadString(Url); }

            HtmlDocument Hd = new HtmlAgilityPack.HtmlDocument();
            Hd.LoadHtml(Html);

            var Nds_Pages = Hd.DocumentNode.SelectNodes("//div[@id='selectpage']/child::text()");
            var Nd_Page = Nds_Pages.FirstOrDefault();

            Regex R = new Regex(@"[0-9]*$");
            var Matches = R.Matches(Nd_Page.InnerText);
            R = new Regex(@"[0-9]*");
            Int32 Pages = Convert.ToInt32(R.Matches(Matches[0].Value)[0].Value);

            String Chapter_Url = Url;
            String Chapter = Strings.Mid(Chapter_Url, Strings.InStrRev(Chapter_Url, @"/") + 1);

            this.mDownloadPage_Params = new DownloadPage_Params()
            {
                Chapter = Chapter,
                Chapter_Url = Chapter_Url,
                FilePath = FilePath,
                Url = Url,
                IPAddress_EndPoint = IPAddress_EndPoint
            };

            Parallel.For(0, Pages, this.DownloadPage);
        }

        DownloadPage_Params mDownloadPage_Params;
        struct DownloadPage_Params
        {
            public String Url;
            public String Chapter_Url;
            public String FilePath;
            public String Chapter;
            public String IPAddress_EndPoint;
        }
        void DownloadPage(Int32 Ct)
        {
            Int32 Try_Ct = 0;
            Boolean Is_Error = false;
            do
            {
                Is_Error = false;
                try
                {
                    Int32 Page_Ct = Ct + 1;

                    String Url = this.mDownloadPage_Params.Url;
                    String Chapter_Url = this.mDownloadPage_Params.Chapter_Url;
                    String FilePath = this.mDownloadPage_Params.FilePath;
                    String Chapter = this.mDownloadPage_Params.Chapter;
                    String IPEndPoint_IPAdress = this.mDownloadPage_Params.IPAddress_EndPoint;

                    String Html;
                    using (var wc = new Common_Objects.GZipWebClient(IPEndPoint_IPAdress))
                    { Html = wc.DownloadString(Chapter_Url + "/" + Page_Ct); }

                    HtmlDocument Hd = new HtmlDocument();
                    Hd.LoadHtml(Html);

                    /*
                    var Nds = Hd.DocumentNode.SelectNodes("//script/child::text()[contains(.,\"document['pu']\")]");
                    var Nd = Nds.FirstOrDefault();
                    Regex R = new Regex("document\\['pu'\\] = \'(.)+';");
                    var Matches = R.Matches(Nd.InnerText);
                    R = new Regex("= '(.)+';");
                    String Img_Url = R.Matches(Matches[0].Value)[0].Value;
                    Img_Url = Img_Url.Replace("'", "").Replace(";","").TrimStart('=').TrimStart(' ');
                    */

                    String Img_Url = "";

                    var Nds = Hd.DocumentNode.SelectNodes("//div[@id='imgholder']/a/img[@id='img']");
                    var Nd = Nds.FirstOrDefault();
                    Img_Url = Nd.Attributes["src"].Value;

                    using (WebClient Wc = new WebClient())
                    {
                        Uri Uri_Source = new Uri(Url);

                        FileInfo Fi_Source = new FileInfo(Strings.Mid(Img_Url, Strings.InStrRev(Img_Url, @"/") + 1));
                        FileInfo Fi_Target = new FileInfo(FilePath.TrimEnd('\\') + @"\" + Chapter + @"\" + Fi_Source.Name);
                        if (!Fi_Target.Directory.Exists)
                        { Fi_Target.Directory.Create(); }

                        //Wc.DownloadFile(@"http://" + Uri_Source.Host + @"/" + Img_Path, Fi_Target.FullName);
                        Wc.DownloadFile(Img_Url, Fi_Target.FullName);
                    }
                }
                catch (Exception Ex)
                {
                    Is_Error = true;
                    Try_Ct++;
                    if (Try_Ct > 10)
                    { throw Ex; }
                }
            }
            while (Is_Error);
        }
    }
}
