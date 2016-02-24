using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaFoxScrapper
{
    public class MangaScrapper_MangaHere: Interface_MangaScrapper
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

            var Nodes = Hd.DocumentNode.SelectNodes("//div");
            var Node_Chapters =
                Nodes.FirstOrDefault(O =>
                    O.Attributes.Contains("class")
                    && O.Attributes["class"].Value == "detail_list");

            List<String> List_Links = new List<String>();

            var Links = Node_Chapters.SelectNodes(".//a");
            foreach (var Item_Link in Links)
            {
                if (Item_Link.Attributes.Contains("href"))
                {
                    if (Item_Link.Attributes["href"].Value.StartsWith(@"http://www.mangahere.co/manga/"))
                    {
                        if (Item_Link.Attributes["href"].Value.StartsWith(@"http://www.mangahere.co/manga/"))
                        {
                            List_Links.Add(Item_Link.Attributes["href"].Value);
                        }
                        else
                        {
                            Uri Uri_Source = new Uri(Url);
                            List_Links.Add("http://" + Uri_Source.Host + Item_Link.Attributes["href"].Value);
                        }
                    }
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
            throw new NotImplementedException();
        }
    }
}
