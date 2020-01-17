namespace Strawberry
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.userListview = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SearchButton = new MetroFramework.Controls.MetroButton();
            this.SearchTextbox = new MetroFramework.Controls.MetroTextBox();
            this.searchTile = new MetroFramework.Controls.MetroTile();
            this.top100Tile = new MetroFramework.Controls.MetroTile();
            this.startButton = new MetroFramework.Controls.MetroTile();
            this.pauseButton = new MetroFramework.Controls.MetroTile();
            this.volumeTrack = new MetroFramework.Controls.MetroTrackBar();
            this.goBefore = new MetroFramework.Controls.MetroTile();
            this.goNext = new MetroFramework.Controls.MetroTile();
            this.killVolume = new MetroFramework.Controls.MetroTile();
            this.fullVolume = new MetroFramework.Controls.MetroTile();
            this.playTrack = new MetroFramework.Controls.MetroTrackBar();
            this.songLengthLabel = new MetroFramework.Controls.MetroLabel();
            this.songNowLabel = new MetroFramework.Controls.MetroLabel();
            this.songLabel = new MetroFramework.Controls.MetroLabel();
            this.playtrackTimer = new System.Windows.Forms.Timer(this.components);
            this.nextSongLabel = new System.Windows.Forms.Label();
            this.beforeSongLabel = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.창띄우기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatTile = new MetroFramework.Controls.MetroTile();
            this.shuffleTile = new MetroFramework.Controls.MetroTile();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userListview
            // 
            this.userListview.BackColor = System.Drawing.Color.White;
            this.userListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.userListview.HideSelection = false;
            this.userListview.Location = new System.Drawing.Point(727, 224);
            this.userListview.Name = "userListview";
            this.userListview.Size = new System.Drawing.Size(263, 353);
            this.userListview.TabIndex = 0;
            this.userListview.UseCompatibleStateImageBehavior = false;
            this.userListview.View = System.Windows.Forms.View.Details;
            this.userListview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.userListview_MouseClick);
            this.userListview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.userListview_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "재생 목록";
            this.columnHeader2.Width = 300;
            // 
            // SearchListview
            // 
            this.SearchListview.BackColor = System.Drawing.Color.White;
            this.SearchListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.SearchListview.HideSelection = false;
            this.SearchListview.Location = new System.Drawing.Point(23, 224);
            this.SearchListview.Name = "SearchListview";
            this.SearchListview.Size = new System.Drawing.Size(670, 353);
            this.SearchListview.TabIndex = 1;
            this.SearchListview.UseCompatibleStateImageBehavior = false;
            this.SearchListview.View = System.Windows.Forms.View.Details;
            this.SearchListview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.searchListview_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "검색 목록";
            this.columnHeader1.Width = 900;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(646, 193);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(48, 31);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "검색";
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SearchTextbox
            // 
            this.SearchTextbox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.SearchTextbox.Location = new System.Drawing.Point(256, 193);
            this.SearchTextbox.Name = "SearchTextbox";
            this.SearchTextbox.PromptText = "노래 제목을 입력해 주세요...";
            this.SearchTextbox.Size = new System.Drawing.Size(384, 31);
            this.SearchTextbox.TabIndex = 3;
            this.SearchTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTextbox_Keypress);
            // 
            // searchTile
            // 
            this.searchTile.Location = new System.Drawing.Point(24, 193);
            this.searchTile.Name = "searchTile";
            this.searchTile.Size = new System.Drawing.Size(110, 30);
            this.searchTile.Style = MetroFramework.MetroColorStyle.Blue;
            this.searchTile.TabIndex = 5;
            this.searchTile.Text = "검색하기";
            this.searchTile.Click += new System.EventHandler(this.searchTile_Click);
            // 
            // top100Tile
            // 
            this.top100Tile.Location = new System.Drawing.Point(140, 193);
            this.top100Tile.Name = "top100Tile";
            this.top100Tile.Size = new System.Drawing.Size(110, 30);
            this.top100Tile.Style = MetroFramework.MetroColorStyle.Silver;
            this.top100Tile.TabIndex = 6;
            this.top100Tile.Text = "Top 50";
            this.top100Tile.Click += new System.EventHandler(this.top100Tile_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(824, 83);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(60, 60);
            this.startButton.Style = MetroFramework.MetroColorStyle.White;
            this.startButton.TabIndex = 7;
            this.startButton.TileImage = ((System.Drawing.Image)(resources.GetObject("startButton.TileImage")));
            this.startButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startButton.UseTileImage = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.startButton.MouseEnter += new System.EventHandler(this.startButton_MouseEnter);
            this.startButton.MouseLeave += new System.EventHandler(this.startButton_MouseLeave);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(824, 83);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(60, 60);
            this.pauseButton.Style = MetroFramework.MetroColorStyle.White;
            this.pauseButton.TabIndex = 8;
            this.pauseButton.TileImage = ((System.Drawing.Image)(resources.GetObject("pauseButton.TileImage")));
            this.pauseButton.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pauseButton.UseTileImage = true;
            this.pauseButton.Visible = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            this.pauseButton.MouseEnter += new System.EventHandler(this.pauseButton_MouseEnter);
            this.pauseButton.MouseLeave += new System.EventHandler(this.pauseButton_MouseLeave);
            // 
            // volumeTrack
            // 
            this.volumeTrack.BackColor = System.Drawing.Color.Transparent;
            this.volumeTrack.Location = new System.Drawing.Point(747, 186);
            this.volumeTrack.Name = "volumeTrack";
            this.volumeTrack.Size = new System.Drawing.Size(212, 27);
            this.volumeTrack.TabIndex = 9;
            this.volumeTrack.Text = "metroTrackBar1";
            this.volumeTrack.Value = 100;
            this.volumeTrack.Scroll += new System.Windows.Forms.ScrollEventHandler(this.volumeTrack_Scroll);
            // 
            // goBefore
            // 
            this.goBefore.Location = new System.Drawing.Point(747, 98);
            this.goBefore.Name = "goBefore";
            this.goBefore.Size = new System.Drawing.Size(45, 45);
            this.goBefore.Style = MetroFramework.MetroColorStyle.White;
            this.goBefore.TabIndex = 10;
            this.goBefore.TileImage = ((System.Drawing.Image)(resources.GetObject("goBefore.TileImage")));
            this.goBefore.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.goBefore.UseTileImage = true;
            this.goBefore.Click += new System.EventHandler(this.goBefore_Click);
            // 
            // goNext
            // 
            this.goNext.Location = new System.Drawing.Point(914, 98);
            this.goNext.Name = "goNext";
            this.goNext.Size = new System.Drawing.Size(45, 45);
            this.goNext.Style = MetroFramework.MetroColorStyle.White;
            this.goNext.TabIndex = 11;
            this.goNext.TileImage = ((System.Drawing.Image)(resources.GetObject("goNext.TileImage")));
            this.goNext.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.goNext.UseTileImage = true;
            this.goNext.Click += new System.EventHandler(this.goNext_Click);
            // 
            // killVolume
            // 
            this.killVolume.Location = new System.Drawing.Point(727, 188);
            this.killVolume.Name = "killVolume";
            this.killVolume.Size = new System.Drawing.Size(25, 25);
            this.killVolume.Style = MetroFramework.MetroColorStyle.White;
            this.killVolume.TabIndex = 12;
            this.killVolume.TileImage = ((System.Drawing.Image)(resources.GetObject("killVolume.TileImage")));
            this.killVolume.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.killVolume.UseTileImage = true;
            this.killVolume.Click += new System.EventHandler(this.killVolume_Click);
            // 
            // fullVolume
            // 
            this.fullVolume.Location = new System.Drawing.Point(965, 188);
            this.fullVolume.Name = "fullVolume";
            this.fullVolume.Size = new System.Drawing.Size(25, 25);
            this.fullVolume.Style = MetroFramework.MetroColorStyle.White;
            this.fullVolume.TabIndex = 13;
            this.fullVolume.TileImage = ((System.Drawing.Image)(resources.GetObject("fullVolume.TileImage")));
            this.fullVolume.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fullVolume.UseTileImage = true;
            this.fullVolume.Click += new System.EventHandler(this.fullVolume_Click);
            // 
            // playTrack
            // 
            this.playTrack.BackColor = System.Drawing.Color.Transparent;
            this.playTrack.Location = new System.Drawing.Point(24, 122);
            this.playTrack.Name = "playTrack";
            this.playTrack.Size = new System.Drawing.Size(669, 26);
            this.playTrack.TabIndex = 14;
            this.playTrack.Text = "metroTrackBar2";
            this.playTrack.Value = 0;
            this.playTrack.Scroll += new System.Windows.Forms.ScrollEventHandler(this.playTrack_Scroll);
            this.playTrack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playtrack_MouseDown);
            this.playTrack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.playtrack_MouseUp);
            // 
            // songLengthLabel
            // 
            this.songLengthLabel.AutoSize = true;
            this.songLengthLabel.Location = new System.Drawing.Point(649, 149);
            this.songLengthLabel.Name = "songLengthLabel";
            this.songLengthLabel.Size = new System.Drawing.Size(44, 20);
            this.songLengthLabel.TabIndex = 15;
            this.songLengthLabel.Text = "00:00";
            // 
            // songNowLabel
            // 
            this.songNowLabel.AutoSize = true;
            this.songNowLabel.Location = new System.Drawing.Point(23, 149);
            this.songNowLabel.Name = "songNowLabel";
            this.songNowLabel.Size = new System.Drawing.Size(44, 20);
            this.songNowLabel.TabIndex = 16;
            this.songNowLabel.Text = "00:00";
            // 
            // songLabel
            // 
            this.songLabel.AutoSize = true;
            this.songLabel.Location = new System.Drawing.Point(24, 83);
            this.songLabel.MaximumSize = new System.Drawing.Size(669, 20);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(0, 0);
            this.songLabel.TabIndex = 17;
            // 
            // playtrackTimer
            // 
            this.playtrackTimer.Tick += new System.EventHandler(this.playtrackTimer_Tick);
            // 
            // nextSongLabel
            // 
            this.nextSongLabel.AutoSize = true;
            this.nextSongLabel.Font = new System.Drawing.Font("굴림", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nextSongLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.nextSongLabel.Location = new System.Drawing.Point(46, 108);
            this.nextSongLabel.MaximumSize = new System.Drawing.Size(669, 20);
            this.nextSongLabel.Name = "nextSongLabel";
            this.nextSongLabel.Size = new System.Drawing.Size(0, 14);
            this.nextSongLabel.TabIndex = 18;
            // 
            // beforeSongLabel
            // 
            this.beforeSongLabel.AutoSize = true;
            this.beforeSongLabel.Font = new System.Drawing.Font("굴림", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.beforeSongLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.beforeSongLabel.Location = new System.Drawing.Point(46, 65);
            this.beforeSongLabel.MaximumSize = new System.Drawing.Size(669, 20);
            this.beforeSongLabel.Name = "beforeSongLabel";
            this.beforeSongLabel.Size = new System.Drawing.Size(0, 14);
            this.beforeSongLabel.TabIndex = 19;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "strawBerry";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.창띄우기ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 52);
            // 
            // 창띄우기ToolStripMenuItem
            // 
            this.창띄우기ToolStripMenuItem.Name = "창띄우기ToolStripMenuItem";
            this.창띄우기ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.창띄우기ToolStripMenuItem.Text = "창 띄우기";
            this.창띄우기ToolStripMenuItem.Click += new System.EventHandler(this.창띄우기ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // repeatTile
            // 
            this.repeatTile.Location = new System.Drawing.Point(842, 160);
            this.repeatTile.Name = "repeatTile";
            this.repeatTile.Size = new System.Drawing.Size(20, 20);
            this.repeatTile.TabIndex = 0;
            this.repeatTile.TileImage = ((System.Drawing.Image)(resources.GetObject("repeatTile.TileImage")));
            this.repeatTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.repeatTile.UseTileImage = true;
            this.repeatTile.Visible = false;
            this.repeatTile.Click += new System.EventHandler(this.repeatTile_Click);
            // 
            // shuffleTile
            // 
            this.shuffleTile.Location = new System.Drawing.Point(842, 160);
            this.shuffleTile.Name = "shuffleTile";
            this.shuffleTile.Size = new System.Drawing.Size(20, 20);
            this.shuffleTile.TabIndex = 20;
            this.shuffleTile.TileImage = ((System.Drawing.Image)(resources.GetObject("shuffleTile.TileImage")));
            this.shuffleTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.shuffleTile.UseTileImage = true;
            this.shuffleTile.Click += new System.EventHandler(this.shuffleTile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.shuffleTile);
            this.Controls.Add(this.repeatTile);
            this.Controls.Add(this.beforeSongLabel);
            this.Controls.Add(this.nextSongLabel);
            this.Controls.Add(this.songLabel);
            this.Controls.Add(this.songNowLabel);
            this.Controls.Add(this.songLengthLabel);
            this.Controls.Add(this.playTrack);
            this.Controls.Add(this.fullVolume);
            this.Controls.Add(this.killVolume);
            this.Controls.Add(this.goNext);
            this.Controls.Add(this.goBefore);
            this.Controls.Add(this.volumeTrack);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.top100Tile);
            this.Controls.Add(this.searchTile);
            this.Controls.Add(this.SearchTextbox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchListview);
            this.Controls.Add(this.userListview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "StrawBerry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.strawberry_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView userListview;
        private System.Windows.Forms.ListView SearchListview;
        private MetroFramework.Controls.MetroButton SearchButton;
        private MetroFramework.Controls.MetroTextBox SearchTextbox;
        private MetroFramework.Controls.MetroTile searchTile;
        private MetroFramework.Controls.MetroTile top100Tile;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private MetroFramework.Controls.MetroTile startButton;
        private MetroFramework.Controls.MetroTile pauseButton;
        private MetroFramework.Controls.MetroTrackBar volumeTrack;
        private MetroFramework.Controls.MetroTile goBefore;
        private MetroFramework.Controls.MetroTile goNext;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private MetroFramework.Controls.MetroTile killVolume;
        private MetroFramework.Controls.MetroTile fullVolume;
        private MetroFramework.Controls.MetroTrackBar playTrack;
        private MetroFramework.Controls.MetroLabel songLengthLabel;
        private MetroFramework.Controls.MetroLabel songNowLabel;
        private MetroFramework.Controls.MetroLabel songLabel;
        private System.Windows.Forms.Timer playtrackTimer;
        private System.Windows.Forms.Label nextSongLabel;
        private System.Windows.Forms.Label beforeSongLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 창띄우기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private MetroFramework.Controls.MetroTile repeatTile;
        private MetroFramework.Controls.MetroTile shuffleTile;
    }
}

