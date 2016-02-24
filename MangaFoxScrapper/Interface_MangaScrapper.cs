using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangaFoxScrapper
{
    public interface Interface_MangaScrapper
    {
        Common_Objects.Volumes GetVolumes(String Url, String IPAddress_EndPoint);

        Common_Objects.Chapters GetChapters(String Url, String IPAddress_EndPoint);

        void DownloadChapter(String Url, String Download_FilePath, String IPAddress_EndPoint);
    }
}
