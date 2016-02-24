using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace MangaFoxScrapper
{
    public static class Common_Objects
    {
        public class Volumes : List<Volume> { }

        public class Volume
        {
            public Chapters Chapters { get; set; }
            public String Volume_Name { get; set; }
        }

        public class Chapters : List<Chapter> { }

        public class Chapter
        {
            public Volume Volume { get; set; }
            public String Chapter_Name { get; set; }
            public String Title { get; set; }
            public String Url { get; set; }
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
