using System.IO;
using System.Windows.Forms;
using WMPLib;

namespace Strawberry
{
    class songManager
    {
        // 재생되는 노래 관리
        // 노래 불러오기, 다음 노래 재생, 이전 노래 재생, 현재 노래 재생

        public delegate void addUserlist(string songName);
        public event addUserlist userlist;

        public delegate void nextSong(int beforeIndex, int nextIndex, int nowIndex);
        public event nextSong playNext;


        public void loaditems()
        {
            string path = Application.StartupPath + @"\Data";
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists) { di.Create(); }
            else
            {
                foreach (var i in di.GetFiles())
                {
                    userlist(i.Name.Replace(".mp4", ""));                    
                }
            }
        }

        public void playNextSong(int index, int totalItem)
        {

            index++;

            if (index >= totalItem)
            {
                index = 0;
            }

            int beforeIndex, nextIndex;
            beforeIndex = index - 1;
            nextIndex = index + 1;

            if (index == 0)
            {
                beforeIndex = totalItem - 1;
            }

            else if (index == totalItem - 1)
            {
                nextIndex = 0;
            }

            playNext(beforeIndex, nextIndex, index);
          
        }

        public void playBeforeSong(int index, int totalItem)
        {
            index--;


            if (index < 0)
            {
                index = totalItem - 1;

            }

            int beforeIndex, nextIndex;

            beforeIndex = index - 1;
            nextIndex = index + 1;



            if (index == totalItem - 1)
            {
                nextIndex = 0;
            }

            else if (index == 0)
            {
                beforeIndex = totalItem - 1;
            }

            playNext(beforeIndex, nextIndex, index);
        }


        public void playNowSong(int index, int totalItem)
        {
            int beforeIndex, nextIndex;

            beforeIndex = index - 1;
            nextIndex = index + 1;

            if (index == 0)
            {
                beforeIndex = totalItem - 1;
            }

            else if (index == totalItem - 1)
            {
                nextIndex = 0;
            }

            playNext(beforeIndex, nextIndex, index);
        }

    }
}
