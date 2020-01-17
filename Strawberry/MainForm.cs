using MetroFramework.Forms;
using System;
using System.Text;
using System.Windows.Forms;
using WMPLib;


namespace Strawberry
{
    public partial class MainForm : MetroForm
    {

        WindowsMediaPlayer windowsMedia = new WindowsMediaPlayer();
        IWMPMedia mediaInfo;
        int index;
        bool shuffle = false;

        public MainForm()
        {
            InitializeComponent();
            playTrack.Minimum = 0;
            playTrack.MouseWheel += playTrack_MouseWheel;
            volumeTrack.MouseWheel += volumeTrack_MouseWheel;
            songManager song = new songManager();
            song.userlist += new songManager.addUserlist(addUserListview);
            song.loaditems();
        }
       

        private void playTrack_MouseWheel(object seder, MouseEventArgs e)
        {
            // 마우스 휠을 통한 음악 재생 위치 조절
            windowsMedia.controls.currentPosition = playTrack.Value;
        }

        private void volumeTrack_MouseWheel(object sender, MouseEventArgs e)
        {
            // 마우스 휠을 통한 볼륨 조절
            windowsMedia.settings.volume = volumeTrack.Value;
        }


        private void startButton_Click(object sender, EventArgs e)
        {
            start_pauseButton();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            start_pauseButton();
        }

        private void start_pauseButton()
        {
            // 재생, 정지 버튼 전환 효과
            // 재생 시작 혹은 정지
            // 곡 이름 label이 등록되지 않으면 작동되지 않음

            if (!string.IsNullOrEmpty(songLabel.Text) && startButton.Visible)
            {
                startButton.Visible = false;
                pauseButton.Visible = true;
                playtrackTimer.Start();
                windowsMedia.controls.play();
            }

            else
            {
                startButton.Visible = true;
                pauseButton.Visible = false;
                playtrackTimer.Stop();
                windowsMedia.controls.pause();
            }
           
        }

        private void startButton_MouseEnter(object sender, EventArgs e)
        {
            // 디자인 효과
            // 재생 버튼 안에 마우스가 들어오면 배경 빨간색 전환
            startButton.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            // 디자인 효과
            // 재생 버튼 안에 마우스가 나가면 배경 흰색 전환
            startButton.Style = MetroFramework.MetroColorStyle.White;
        }

        private void pauseButton_MouseEnter(object sender, EventArgs e)
        {
            // 디자인 효과
            // 재생 버튼 안에 마우스가 들어오면 배경 빨간색 전환
            pauseButton.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void pauseButton_MouseLeave(object sender, EventArgs e)
        {
            // 디자인 효과
            // 재생 버튼 안에 마우스가 나가면 배경 흰색 전환
            pauseButton.Style = MetroFramework.MetroColorStyle.White;
        }

        private void top100Tile_Click(object sender, EventArgs e)
        {
            // top 50 불러오기
            // 현재 눌린 타일을 파란색으로 전환

            SearchListview.Items.Clear();
            parseTop parse = new parseTop();
            parse.addTop += new parseTop.addTop100(addSearchListview);

            parse.Get_info();
            top100Tile.Style = MetroFramework.MetroColorStyle.Blue;
            searchTile.Style = MetroFramework.MetroColorStyle.Silver;
            columnHeader1.Text = "Top 50";

        }
 
        private void searchTile_Click(object sender, EventArgs e)
        {
            // 현재 눌린 타일을 파란색으로 전환
            SearchListview.Items.Clear();
            top100Tile.Style = MetroFramework.MetroColorStyle.Silver;
            searchTile.Style = MetroFramework.MetroColorStyle.Blue;
            columnHeader1.Text = "검색 목록";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            // 노래 검색 버튼
            youtubeManager youtube = new youtubeManager();
            youtube.addSearch += new youtubeManager.addSearchListview(addSearchListview);
            SearchListview.Items.Clear();

            if(!string.IsNullOrEmpty(SearchTextbox.Text))
            {
                youtube.Search(SearchTextbox.Text);
            }
            
        }

        private void searchListview_DoubleClick(object sender, MouseEventArgs e)
        {
            // 검색된 노래를 내 목록에 추가하는 기능
            // searchTile이 활성화 되어있을 때는 내 목록에 노래를 추가함
            // 만약 Top50 에서 더블클릭을 하면 그 노래를 검색해줌

            if(searchTile.Style == MetroFramework.MetroColorStyle.Blue)
            {
                youtubeManager youtube = new youtubeManager();
                youtube.addUser += new youtubeManager.addUseristview(addUserListview);

                if (SearchListview.SelectedItems.Count > 0)
                {
                    youtube.DownloadYoutube(SearchListview.SelectedItems[0].Name, SearchListview.SelectedItems[0].Text);
                }
            }

            else
            {
                youtubeManager youtube = new youtubeManager();
                youtube.addSearch += new youtubeManager.addSearchListview(addSearchListview);

                SearchTextbox.Text = SearchListview.SelectedItems[0].Text;
                
                youtube.Search(SearchListview.SelectedItems[0].Text);
                searchTile_Click(sender, e);
            }
        
        }

      
        private void userListview_DoubleClick(object sender, MouseEventArgs e)
        {
            // 노래 재생 기능
            // 유저의 재생목록에 있는 노래 클릭 시 해당 노래 재생

            index = userListview.Items.IndexOf(userListview.SelectedItems[0]);

            songManager song = new songManager();
            song.playNext += new songManager.nextSong(playSong);

            song.playNowSong(index, userListview.Items.Count);

        }

        private void SearchTextbox_Keypress(object sender, KeyPressEventArgs e)
        {
            // 노래 검색 기능
            // 노래 제목을 입력하고 엔터키를 누르면 노래 검색
            // 경고음 소리 제거를 위해 e.Handled 코드를 삽입

            if(e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(SearchTextbox.Text))
            {
                e.Handled = true;
                youtubeManager youtube = new youtubeManager();
                youtube.addSearch += new youtubeManager.addSearchListview(addSearchListview);
                SearchListview.Items.Clear();
                youtube.Search(SearchTextbox.Text);
            }
        }

        private void playtrackTimer_Tick(object sender, EventArgs e)
        {
            // 노래 진행 상황 나타내기 & 다음 곡 자동 재생
            // trackBar 1초씩 이동
            // 텍스트로 현재 곡의 재생 현황 표현
            
            if (playTrack.Value >= playTrack.Maximum)
            {
                playtrackTimer.Stop();
                playTrack.Value = 0;
                songManager song = new songManager();
                song.playNext += new songManager.nextSong(playSong);
                song.playNextSong(index, userListview.Items.Count);
            }

            playTrack.Value += 1;

            StringBuilder sb = new StringBuilder();
            int duration = playTrack.Value;
            sb.AppendFormat("{0}{1}:{2}{3}", duration / 60 / 10, duration / 60 % 10, duration % 60 / 10, duration % 60 % 10);

            songNowLabel.Text = sb.ToString();

        }

        private void playTrack_Scroll(object sender, ScrollEventArgs e)
        {
            // 유저에 의한 trackBar 재생 위치 조절

            StringBuilder sb = new StringBuilder();
            int duration = playTrack.Value;
            sb.AppendFormat("{0}{1}:{2}{3}", duration / 60 / 10, duration / 60 % 10, duration % 60 / 10, duration % 60 % 10);
            windowsMedia.controls.currentPosition = playTrack.Value;

        }

        private void playtrack_MouseDown(object sender, MouseEventArgs e)
        {
            // 유저가 재생 위치 조절 시, 노래가 드래그와 같은 속도로 되감기거나 배속이 되어 재생됨
            // 이를 방지하기 위해 trackBar 조절 시 노래 정지

            windowsMedia.controls.pause();
        }

        private void playtrack_MouseUp(object sender, MouseEventArgs e)
        {
            // trackBar 조절이 끝나면 다시 노래 플레이

            windowsMedia.controls.play();
        }

        private void songLengthLabel_Change()
        {           
            // 노래 총 길이 label 등록
            // 재생이 끝날 때 까지 그대로

            int duration = (int)mediaInfo.duration;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:{2}{3}", duration / 60 / 10, duration / 60 % 10, duration % 60 / 10, duration % 60 % 10);

            songLengthLabel.Text = sb.ToString();
        }

        private void goNext_Click(object sender, EventArgs e)
        {
            // 다음곡으로 넘어가기

            if(!string.IsNullOrEmpty(songLabel.Text))
            {
                songManager song = new songManager();
                song.playNext += new songManager.nextSong(playSong);

                song.playNextSong(index, userListview.Items.Count);
             
            }

        }

        private void goBefore_Click(object sender, EventArgs e)
        {
            // 이전곡으로 돌아가기

            if(!string.IsNullOrEmpty(songLabel.Text))
            {
                songManager song = new songManager();
                song.playNext += new songManager.nextSong(playSong);
                song.playBeforeSong(index, userListview.Items.Count);

            }
         
        }

        private void strawberry_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 창 축소

            e.Cancel = true;
            this.Visible = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 축소된 아이콘 더블 클릭 시 창 띄우기

           this.Visible = true;
        }


        private void 창띄우기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 우클릭시 나온 메뉴로 창 띄우기

            this.Visible = true;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 프로그램 종료

            this.Dispose();
            this.Close();
        }

        private void killVolume_Click(object sender, EventArgs e)
        {
            // 볼륨 죽이기

            volumeTrack.Value = 0;
            windowsMedia.settings.volume = 0;
        }

        private void fullVolume_Click(object sender, EventArgs e)
        {
            // 볼륨 최대치로

            volumeTrack.Value = 100;
            windowsMedia.settings.volume = 100;
        }

        private void userListview_MouseClick(object sender, MouseEventArgs e)
        {
            // 유저 재생목록 마우스 우클릭 시 나타남
            // 목록에서 삭제, 이름 바꾸기 
            // 작업이 완료되면 목록 다시 로드

            if (e.Button.Equals(MouseButtons.Right))
            {
                fileManager file = new fileManager();
                songManager song = new songManager();
                song.userlist += new songManager.addUserlist(addUserListview);

                string selectedNickName = userListview.GetItemAt(e.X, e.Y).Text;

                ContextMenu m = new ContextMenu();

                MenuItem m1 = new MenuItem();
                MenuItem m2 = new MenuItem();

                m1.Text = "삭제하기";
                m2.Text = "이름 바꾸기";

                m.MenuItems.Add(m1);
                m.MenuItems.Add(m2);

                m.Show(userListview, new System.Drawing.Point(e.X, e.Y));

                m1.Click += (senders, es) =>
                {
                    file.Delete_File(selectedNickName);
                    userListview.Items.Clear();
                    song.loaditems();
                };

                m2.Click += (senders, es) =>
                {
                    file.Rename_File(selectedNickName);
                    userListview.Items.Clear();
                    song.loaditems();
                };

            }
        }

        private void volumeTrack_Scroll(object sender, ScrollEventArgs e)
        {
            // 볼륨 조절

            windowsMedia.settings.volume = volumeTrack.Value;
        }

        private void shuffleTile_Click(object sender, EventArgs e)
        {
            // 노래 뒤섞어 재생

            shuffleTile.Visible = false;
            repeatTile.Visible = true;
            shuffle = true;
           
        }

        private void repeatTile_Click(object sender, EventArgs e)
        {
            // 노래 순차적 재생

            shuffleTile.Visible = true;
            repeatTile.Visible = false;
            shuffle = false;
        }


        // 이 밑으로 전부 다
        // delegate 전용

        private void addSearchListview(string videoId, string videoTitle)
        {
            SearchListview.Items.Add(videoId, videoTitle, 0);
        }


        private void addUserListview(string videoName)
        {
            userListview.Items.Add(videoName, 0);
        }

        private void playSong(int before, int next, int now)
        {
            index = now;
            int beforeIndex = before;
            int nextIndex = next;

            if(shuffle)
            {
                Random random = new Random();
                index = random.Next(0, userListview.Items.Count);

                if(index == 0)
                {
                    beforeIndex = userListview.Items.Count - 1;
                    nextIndex = 1;
                }

                else if(index == userListview.Items.Count - 1)
                {
                    beforeIndex = index - 1;
                    nextIndex = 0;
                }

                else
                {
                    beforeIndex = index - 1;
                    nextIndex = index + 1;
                }
            }

            // 디자인 효과 파트
            // 현재 재생중인 곡 제목 상하로 이전곡, 다음곡 배치

            if (userListview.Items.Count >= 3)
            {
                beforeSongLabel.Text = userListview.Items[beforeIndex].Text;
                nextSongLabel.Text = userListview.Items[nextIndex].Text;
            }

            else
            {
                beforeSongLabel.Text = "";
                nextSongLabel.Text = "";
            }

            string path = Application.StartupPath + @"\Data\" + userListview.Items[index].Text + ".mp4";

            playTrack.Value = 0;
            
            // 재생시간 측정
            // 불러온 곡의 재생 길이가 측정되지 않으면
            // 경고 메세지를 던짐

            mediaInfo = windowsMedia.newMedia(path);

            if ((int)mediaInfo.duration != 0)
            {
                playTrack.Maximum = (int)mediaInfo.duration;
            }

            else
            {
                MessageBox.Show("재생시간 측정 불가, 다른 파일 이용을 권장합니다.", "알림");
                playTrack.Maximum = 100000;
            }
            

            windowsMedia.URL = path;
            windowsMedia.controls.play();

            songLabel.Text = userListview.Items[index].Text;

            startButton.Visible = false;
            pauseButton.Visible = true;

            songLengthLabel_Change();
            playtrackTimer.Interval = 1000;
            playtrackTimer.Start();
        }

    }
}