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
            windowsMedia.controls.currentPosition = playTrack.Value;
        }

        private void volumeTrack_MouseWheel(object sender, MouseEventArgs e)
        {
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
            startButton.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            startButton.Style = MetroFramework.MetroColorStyle.White;
        }

        private void pauseButton_MouseEnter(object sender, EventArgs e)
        {
            pauseButton.Style = MetroFramework.MetroColorStyle.Red;
        }

        private void pauseButton_MouseLeave(object sender, EventArgs e)
        {
            pauseButton.Style = MetroFramework.MetroColorStyle.White;
        }

        private void top100Tile_Click(object sender, EventArgs e)
        {
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
            SearchListview.Items.Clear();
            top100Tile.Style = MetroFramework.MetroColorStyle.Silver;
            searchTile.Style = MetroFramework.MetroColorStyle.Blue;
            columnHeader1.Text = "검색 목록";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
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
            index = userListview.Items.IndexOf(userListview.SelectedItems[0]);

            songManager song = new songManager();
            song.playNext += new songManager.nextSong(playNextsong);

            song.playNowSong(index, userListview.Items.Count);

        }

        private void SearchTextbox_Keypress(object sender, KeyPressEventArgs e)
        {
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
            if (playTrack.Value >= playTrack.Maximum)
            {
                playtrackTimer.Stop();
                playTrack.Value = 0;
                songManager song = new songManager();
                song.playNext += new songManager.nextSong(playNextsong);

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
            StringBuilder sb = new StringBuilder();
            int duration = playTrack.Value;
            sb.AppendFormat("{0}{1}:{2}{3}", duration / 60 / 10, duration / 60 % 10, duration % 60 / 10, duration % 60 % 10);
            windowsMedia.controls.currentPosition = playTrack.Value;

        }

        private void playtrack_MouseDown(object sender, MouseEventArgs e)
        {
            windowsMedia.controls.pause();
        }

        private void playtrack_MouseUp(object sender, MouseEventArgs e)
        {
            windowsMedia.controls.play();
        }

        private void songLengthLabel_Change()
        {           
            int duration = (int)mediaInfo.duration;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:{2}{3}", duration / 60 / 10, duration / 60 % 10, duration % 60 / 10, duration % 60 % 10);

            songLengthLabel.Text = sb.ToString();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(songLabel.Text))
            {
                songManager song = new songManager();
                song.playNext += new songManager.nextSong(playNextsong);

                song.playNextSong(index, userListview.Items.Count);
             
            }

        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(songLabel.Text))
            {
                songManager song = new songManager();
                song.playNext += new songManager.nextSong(playNextsong);
                song.playBeforeSong(index, userListview.Items.Count);

            }
         
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           this.Visible = true;
        }

        private void strawberry_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void 창띄우기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            volumeTrack.Value = 0;
            windowsMedia.settings.volume = 0;
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            volumeTrack.Value = 100;
            windowsMedia.settings.volume = 100;
        }

        private void userListview_MouseClick(object sender, MouseEventArgs e)
        {
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
            windowsMedia.settings.volume = volumeTrack.Value;
        }

        private void shuffleTile_Click(object sender, EventArgs e)
        {
            shuffleTile.Visible = false;
            repeatTile.Visible = true;
            shuffle = true;
           
        }

        private void repeatTile_Click(object sender, EventArgs e)
        {
            shuffleTile.Visible = true;
            repeatTile.Visible = false;
            shuffle = false;
        }


        // 이 밑으로 전부 다
        // delegate 전용 모음집

        private void addSearchListview(string videoId, string videoTitle)
        {
            SearchListview.Items.Add(videoId, videoTitle, 0);
        }


        private void addUserListview(string videoName)
        {
            userListview.Items.Add(videoName, 0);
        }

        private void playNextsong(int before, int next, int now)
        {
            index = now;
            int beforeIndex = before;
            int nextIndex = next;

            if(shuffle)
            {
                Random random = new Random();
                index = random.Next(0, userListview.Items.Count - 1);

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