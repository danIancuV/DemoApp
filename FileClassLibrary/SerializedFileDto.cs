using System;
using System.ComponentModel.DataAnnotations;

namespace DbCoreLibrary
{
    [Serializable]
    public class SerializedFileDto
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FileContent { get; set; }
        [Required]
        [RegularExpression("[.][a-z]{0,4}$", ErrorMessage = "It has to start with '.' character, max 4 characters a-z")]
        public string Extension { get; set; }

        public static SerializedFileDto MapTo(SerializedFile file)
        {
            return new SerializedFileDto
            {
                Id = file.Id,
                Name = file.Name,
                FileContent = file.FileContent,
                Extension = file.Extension
            };
        }

        public static SerializedFile MapTo(SerializedFileDto fileModel)
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
