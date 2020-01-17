using MetroFramework.Forms;
using System.IO;
using System.Windows.Forms;

namespace Strawberry
{
    class fileManager
    {
        // 파일 관리
        // 파일 지우기, 파일 이름 변경

        public void Delete_File(string fileName)
        {   
            string path = Directory.GetCurrentDirectory() + @"\Data\" + fileName + ".mp4";
            FileInfo file = new FileInfo(path);

            file.Delete();
        }

        public void Rename_File(string fileName)
        {
            string path = Directory.GetCurrentDirectory() + @"\Data\" + fileName + ".mp4";
            FileInfo file = new FileInfo(path);

            string rename = InputBox();

            if (!string.IsNullOrEmpty(rename))
            {
                try
                {
                    file.MoveTo(Directory.GetCurrentDirectory() + @"\Data\" + rename + ".mp4");
                }

                catch
                {
                    MessageBox.Show("이미 존재하는 이름입니다.", "알림");
                }
            }

        }

        private string InputBox()
        {
            // 바꿀 이름 입력받기 위한 새 폼

            MetroForm form = new MetroForm();
            Label label = new Label();
            TextBox textbox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.ClientSize = new System.Drawing.Size(400, 100);
            form.Controls.AddRange(new Control[] { label, textbox, buttonOk, buttonCancel });
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            label.Text = "바꿀 이름을 입력하세요";
            textbox.Text = "";
            buttonOk.Text = "확인";
            buttonCancel.Text = "취소";

            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(65, 17, 200, 20);
            textbox.SetBounds(65, 40, 220, 20);
            buttonOk.SetBounds(135, 70, 70, 20);
            buttonCancel.SetBounds(215, 70, 70, 20);

            form.ShowDialog();

            string Rename = textbox.Text;

            return Rename;
        }

    }
}
