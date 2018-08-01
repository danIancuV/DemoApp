using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextFileDemoApp;

namespace FormLibrary
{
    public class SelectedFile : Form1
    {
        public void BrowseFile()
        {
            OpenFileDialog openFd = new OpenFileDialog();

            if (openFd.ShowDialog() == DialogResult.OK)
            {
                fileNameBox.Text = Path.GetFileName(openFd.FileName);
            }
        }

        public void ReadFile()
        {
            using (var reader = new StreamReader(fileNameBox.Text))
            {
                string text = reader.ReadToEnd();
                fileContentBox.Text = text;
            }
        }

        public SerializedFile CreateFile(string ext)
        {
            return new SerializedFile
            {
                Name = fileNameBox.Text.Split('.')[0],
                FileContent = fileContentBox.Text,
                Extension = ext
            };
        }
    }
}
