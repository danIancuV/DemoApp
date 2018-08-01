using System.IO;
using System.Windows.Forms;

namespace FileClassLibrary.FileServiceModel
{
    public class FileSelection
    {
        public string BrowseFile()
        {
            OpenFileDialog openFd = new OpenFileDialog();

            if (openFd.ShowDialog() == DialogResult.OK)
            {
                return Path.GetFileName(openFd.FileName);
            }

            return null;
        }

        public string ReadFile(string file, string path)
        {
            using (var stream = File.OpenRead(path))
            {
                using (var reader = new StreamReader(stream))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }

        }
    }
}
