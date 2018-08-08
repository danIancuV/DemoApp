using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileDemoApp
{
    [Serializable]
    public class SerializedFileModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileContent { get; set; }
        public string Extension { get; set; }

        public static SerializedFileModel MapTo(SerializedFile file)
        {
            return new SerializedFileModel
            {
                Id = file.Id,
                Name = file.Name,
                FileContent = file.FileContent,
                Extension = file.Extension
            };
        }

        public static SerializedFile MapTo(SerializedFileModel fileModel)
        {
            return new SerializedFile
            {
                Id = fileModel.Id,
                Name = fileModel.Name,
                FileContent = fileModel.FileContent,
                Extension = fileModel.Extension
            };
        }

        //public SerializedFile(string name, string fileContent, string extension)
        //{

        //    Name = name;
        //    FileContent = fileContent;
        //    Extension = extension;
        //}

    }
}
