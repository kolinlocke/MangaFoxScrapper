using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace MangaFoxScrapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Btn_Scrape.Click += new EventHandler(Btn_Scrape_Click);
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

                this.DownloadChapter_FilePath = FilePath;

                foreach (String Item_Chapter in Chapters)
                { this.DownloadChapter(Item_Chapter, this.Txt_EndPointIPAddress.Text); }

                //Parallel.ForEach(Chapters, this.DownloadChapter);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void Btn_Chapters_Click(object sender, EventArgs e)
        {
            this.GetChapters(this.Txt_Url.Text, this.Txt_EndPointIPAddress.Text);
        }

        void Btn_Scrape_Click(object sender, EventArgs e)
        {
            /*
            HtmlWeb Hw = new HtmlWeb();
            var Hd = Hw.Load(this.Txt_Url.Text);
            var Links = Hd.DocumentNode.SelectNodes("//a");
            foreach (var Item_Link in Links)
            {
                if (Item_Link.Attributes.Contains("href"))
                {
                    if (Item_Link.Attributes["href"].Value.StartsWith(@"http://mangafox.me/manga/"))
                    { Debug.WriteLine(Item_Link.Attributes["href"].Value); }
                }
            }
            */

            String Url = this.Txt_Url.Text;
            String IPEndPoint_IPAddress = this.Txt_EndPointIPAddress.Text;

            String html;
            using (var wc = new GZipWebClient(IPEndPoint_IPAddress))
            { html = wc.DownloadString(Url); }

            this.Txt_Chapters.Text = html;
        }

        void GetChapters(String Url, String IPEndPoint_IPAddress)
        {
            //HtmlWeb Hw = new HtmlWeb();
            //var Hd = Hw.Load(Url);

            String html;
            using (var wc = new GZipWebClient(IPEndPoint_IPAddress))
            { html = wc.DownloadString(Url); }

            HtmlAgilityPack.HtmlDocument Hd = new HtmlAgilityPack.HtmlDocument();
            Hd.LoadHtml(html);

            var Nodes = Hd.DocumentNode.SelectNodes("//div");
            var Node_Chapters =
                Nodes.FirstOrDefault(O =>
                    O.Attributes.Contains("id")
                    && O.Attributes["id"].Value == "chapters");

            List<String> List_Links = new List<String>();
            //var Links = Hd.DocumentNode.SelectNodes("//a");
            var Links = Node_Chapters.SelectNodes(".//a");
            foreach (var Item_Link in Links)
            {
                if (Item_Link.Attributes.Contains("href"))
                {
                    if (Item_Link.Attributes["href"].Value.StartsWith(@"http://mangafox.me/manga/")
                        || Item_Link.Attributes["href"].Value.StartsWith(@"/mangafox.me/manga/"))
                    {
                        if (Item_Link.Attributes["href"].Value.StartsWith(@"http://mangafox.me/manga/"))
                        {
                            List_Links.Add(Item_Link.Attributes["href"].Value);
                            Debug.WriteLine(Item_Link.Attributes["href"].Value); 
                        }
                        else
                        {
                            Uri Uri_Source = new Uri(Url);
                            List_Links.Add("http://" + Uri_Source.Host + Item_Link.Attributes["href"].Value);
                            Debug.WriteLine("http://" + Uri_Source.Host + Item_Link.Attributes["href"].Value);
                        }
                    }
                }
            }

            StringBuilder Sb_Links = new StringBuilder();
            List_Links.OrderBy(O => O).ToList().ForEach(O => Sb_Links.AppendLine(O));

            this.Txt_Chapters.Text = Sb_Links.ToString().Trim();
        }

        String DownloadChapter_FilePath = "";
        void DownloadChapter(String Url, String IPEndPoint_IPAdress)
        {
            String FilePath = this.DownloadChapter_FilePath;

            //Get Pages

            String html;
            using (var wc = new GZipWebClient(IPEndPoint_IPAdress))
            { html = wc.DownloadString(Url); }

            HtmlAgilityPack.HtmlDocument Hd = new HtmlAgilityPack.HtmlDocument();
            Hd.LoadHtml(html);

            //HtmlWeb Hw = new HtmlWeb();            
            //var Hd = Hw.Load(Url);

            //var Nds = Hd.DocumentNode.SelectNodes("//form");
            //var Nd_Form = Nds.FirstOrDefault(O => O.Attributes.Contains("id") && O.Attributes["id"].Value == "top_bar");
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
                IPEndPoint_IPAdress = IPEndPoint_IPAdress
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
            public String IPEndPoint_IPAdress;
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
                    String IPEndPoint_IPAdress = this.mDownloadPage_Params.IPEndPoint_IPAdress;

                    //var Hw = new HtmlWeb();
                    //var Hd = Hw.Load(Chapter_Url + Page_Ct + @".html");

                    String html;
                    using (var wc = new GZipWebClient(IPEndPoint_IPAdress))
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

        public class GZipWebClient : WebClient
        {
            String mIPEndPoint_IPAddress;

            public GZipWebClient(String IPEndPoint_IPAddress)
            {
                this.mIPEndPoint_IPAddress = IPEndPoint_IPAddress;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
                request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                return request;
            }

            IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
            {
                if (this.mIPEndPoint_IPAddress == "")
                { return null; }

                if (remoteEndPoint.AddressFamily == AddressFamily.InterNetwork)
                {
                    //return new IPEndPoint(IPAddress.Parse("10.32.56.28"), 0);
                    return new IPEndPoint(IPAddress.Parse(this.mIPEndPoint_IPAddress), 0);
                }
                // Just use the default endpoint.
                return null;
            }
        }
    }
}
