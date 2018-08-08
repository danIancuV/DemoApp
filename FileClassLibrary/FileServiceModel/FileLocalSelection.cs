using System.IO;


namespace DbCoreLibrary.FileServiceModel
{
    public class FileLocalSelection
    {


        public string ReadFile(string file, string path)
        {

            if (File.Exists(path))
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
            else
            {
                return null;
            }
        }
    }
}
