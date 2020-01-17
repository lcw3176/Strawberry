using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Strawberry
{
    class parseTop
    {
        
        // Top 50 불러오기

        public delegate void addTop100(string videoId, string videoTitle);
        public event addTop100 addTop;

        public Encoding utf;
        public HtmlAgilityPack.HtmlDocument document;

        public WebClient web;
        public Stream streamSource;

        public parseTop()
        {
            utf = Encoding.GetEncoding("utf-8");
            document = new HtmlAgilityPack.HtmlDocument();
            web = new WebClient();
        }

        public void Get_info()
        {
            string url = "https://www.genie.co.kr/chart/top200";
            List<string> songList = new List<string>();
            List<string> artistList = new List<string>();

            streamSource = web.OpenRead(url);
            StreamReader reader = new StreamReader(streamSource, utf);
            string html = reader.ReadToEnd();

            document.LoadHtml(html);

            HtmlAgilityPack.HtmlNodeCollection song = document.DocumentNode.SelectNodes("//td[@class='info']//a[@class='title ellipsis']");
            HtmlAgilityPack.HtmlNodeCollection artist = document.DocumentNode.SelectNodes("//td[@class='info']//a[@class='artist ellipsis']");

            foreach (var i in song)
            {
                songList.Add(i.InnerText.ToString());
            }

            foreach (var i in artist)
            {
                artistList.Add(i.InnerText.ToString());
            }

           
            
            for(int i = 0; i < songList.Count; i++)
            {
                addTop(null, artistList[i] + " - " + songList[i].Trim());
            }
        }

    }
}