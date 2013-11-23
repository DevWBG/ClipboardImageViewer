using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string Folderpath;
        string FilePath;
        int InFolderFileIndex = 0;
        int FolderIndex = 0;
        int TempIndex = 0;
        string[] files;
        string[] strtemp;
        string[] extensions = { "png", "jpg", "gif" };
        string temp;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ImageFilePath = new OpenFileDialog();
            ImageFilePath.Filter = "Image File|*.jpg;*.png;*.gif|AllFiles|*.*";
            ImageFilePath.Title = "파일 선택";
            if(ImageFilePath.ShowDialog() == DialogResult.OK)
            {
                FilePath = ImageFilePath.FileName;
                Folderpath = System.IO.Path.GetDirectoryName(ImageFilePath.FileName);
                files = System.IO.Directory.GetFiles(@Folderpath, "*.*")
                    .Where(f => extensions.Contains(f.Split('.').Last().ToLower())).ToArray();
                InFolderFileIndex = files.Length;
                
                Array.Sort(files);
                FolderIndex = Array.IndexOf(files, FilePath);

                pictureBox1.ImageLocation = files[FolderIndex];
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Image imgToCopy = Image.FromFile(files[FolderIndex]);
            Clipboard.SetImage(imgToCopy);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FolderIndex < InFolderFileIndex - 1)
            {
                FolderIndex++;
                pictureBox1.ImageLocation = @files[FolderIndex];
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
                MessageBox.Show("다음 파일이 존재하지 않습니다.", "오류");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (FolderIndex > 0)
            {
                FolderIndex--;
                pictureBox1.ImageLocation = @files[FolderIndex];
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
                MessageBox.Show("이전 파일이 존재하지 않습니다.", "오류");
        }
    }
}
