using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace MangaFoxScrapper
{
    public class MangaScrapper_MangaFox : Interface_MangaScrapper
    {
        public Common_Objects.Volumes GetVolumes(string Url, string IPAddress_EndPoint)
        {
            throw new NotImplementedException();
        }

        public Common_Objects.Chapters GetChapters(string Url, string IPAddress_EndPoint)
        {
            /*
            String HtmlSource;
            using (var wc = new Common_Objects.GZipWebClient(IPAddress_EndPoint))
            { HtmlSource = wc.DownloadString(Url); }

            HtmlAgilityPack.HtmlDocument Hd = new HtmlAgilityPack.HtmlDocument();
            Hd.LoadHtml(HtmlSource);
            */

            HtmlWeb Hw = new HtmlWeb();
            var Hd = Hw.Load(Url);

            var Nodes = Hd.DocumentNode.SelectNodes("//div");
            var Node_Chapters =
                Nodes.FirstOrDefault(O =>
                    O.Attributes.Contains("id")
                    && O.Attributes["id"].Value == "chapters");

            List<String> List_Links = new List<String>();

            var Links = Node_Chapters.SelectNodes(".//a");
            foreach (var Item_Link in Links)
            {
                if (Item_Link.Attributes.Contains("href"))
                {
                    if (Item_Link.Attributes["href"].Value.StartsWith(@"https://mangafox.me/manga/")
                        || Item_Link.Attributes["href"].Value.StartsWith(@"//mangafox.me/manga/"))
                    {
                        if (Item_Link.Attributes["href"].Value.StartsWith(@"https://mangafox.me/manga/"))
                        {
                            List_Links.Add(Item_Link.Attributes["href"].Value);
                        }
                        else
                        {
                            //Uri Uri_Source = new Uri(Url);
                            //List_Links.Add("https://" + Uri_Source.Host + Item_Link.Attributes["href"].Value);

                            List_Links.Add("https:" + Item_Link.Attributes["href"].Value);
                        }
                    }
                }
            }

            var List_Chapters =
                List_Links
                    .OrderBy(O => O)
                    .Select(O =>
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

            String html;
            using (var wc = new Common_Objects.GZipWebClient(IPAddress_EndPoint))
            { html = wc.DownloadString(Url); }

            HtmlAgilityPack.HtmlDocument Hd = new HtmlAgilityPack.HtmlDocument();
            Hd.LoadHtml(html);
            
            /*
            HtmlWeb Hw = new HtmlWeb();
            var Hd = Hw.Load(Url);
            */

            var Nds_Script = Hd.DocumentNode.SelectNodes("//script");
            var Nd_Script = Nds_Script.FirstOrDefault(O => O.InnerText.Contains("var total_pages"));
            Regex R = new Regex(@"var total_pages=[0-9]*;");
            var Matches = R.Matches(Nd_Script.InnerText);
            R = new Regex(@"=[0-9]*");
            Int32 Pages = Convert.ToInt32(R.Matches(Matches[0].Value)[0].Value.TrimStart('='));

            String Chapter_Url = Strings.Mid(Url, 1, Strings.InStrRev(Url, @"/"));

            String Tmp = Strings.Mid(Chapter_Url, 1, Strings.InStrRev(Chapter_Url, @"/") - 1);
            String Chapter = Strings.Mid(Tmp, Strings.InStrRev(Tmp, @"/") + 1);

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
                    String IPEndPoint_IPAddress = this.mDownloadPage_Params.IPAddress_EndPoint;

                    /*
                    var Hw = new HtmlWeb();
                    var Hd = Hw.Load(Chapter_Url + Page_Ct + @".html");
                    */

                    
                    String html;
                    using (var wc = new Common_Objects.GZipWebClient(IPEndPoint_IPAddress))
                    //using (var wc = new WebClient() { BaseAddress = IPEndPoint_IPAdress })
                    { html = wc.DownloadString(Chapter_Url + Page_Ct + @".html"); }

                    HtmlAgilityPack.HtmlDocument Hd = new HtmlAgilityPack.HtmlDocument();
                    Hd.LoadHtml(html);
                    

                    var Nds = Hd.DocumentNode.SelectNodes("//div");
                    var Nd_Viewer =
                        Nds.FirstOrDefault(O =>
                            O.Attributes.Contains("id")
                            && O.Attributes["id"].Value == "viewer");

                    var Img_Url = Nd_Viewer.SelectSingleNode("//img").Attributes["src"].Value;

                    using (WebClient Wc = new WebClient())
                    {
                        Uri Uri_Source = new Uri(Url);

                        String FileName_Source = Strings.Mid(Img_Url, Strings.InStrRev(Img_Url, @"/") + 1);
                        if (FileName_Source.Contains(@"?"))
                        { FileName_Source = Strings.Mid(FileName_Source, 1, Strings.InStrRev(FileName_Source, @"?") - 1); }

                        FileInfo Fi_Source = new FileInfo(FileName_Source);
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
