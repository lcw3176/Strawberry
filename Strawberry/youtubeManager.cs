using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace Strawberry
{
    class youtubeManager
    {
        // 유튜브 연결, 노래 검색과 다운로드

        public delegate void addSearchListview(string videoId, string videoTitle);
        public event addSearchListview addSearch;

        public delegate void addUseristview(string videoName);
        public event addUseristview addUser;

        public async void Search(string search)
        {
            var youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "개발자 키",
                ApplicationName = "개발자 프로그램 이름"
            });

            var request = youtube.Search.List("snippet");
            request.Q = search;
            request.MaxResults = 50;

            try
            {
                var result = await request.ExecuteAsync();

                foreach (var item in result.Items)
                {
                    if (item.Id.Kind == "youtube#video")
                    {
                        addSearch(item.Id.VideoId.ToString(), item.Snippet.Title);
                    }
                }

            }

            catch
            {
                MessageBox.Show("인터넷 연결을 확인해 주세요.", "알림");
                return;
            }

            finally
            {
                youtube.Dispose();
            }

        }

        public async void DownloadYoutube(string videoId, string videoName)
        {
            try
            {
                string youtubeUrl = "http://youtube.com/watch?v=" + videoId;
                string fixedName = videoName.Replace("/", " ");
                string writePath = Application.StartupPath + @"\Data\" + fixedName + ".mp4";

                var client = new YoutubeClient();
                var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(videoId);
                var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();

                var ext = streamInfo.Container.GetFileExtension();
                await client.DownloadMediaStreamAsync(streamInfo, writePath);
                addUser(fixedName); 

            }

            catch
            {
                MessageBox.Show("목록 추가가 불가능합니다.", "알림");
                return;
            }

        }
      
    }
}
