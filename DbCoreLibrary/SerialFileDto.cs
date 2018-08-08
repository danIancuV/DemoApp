using DbCoreLibrary.SerializedFileModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace DbCoreLibrary
{
    [Serializable]
    public class SerialFileDto
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FileContent { get; set; }
        [Required]
        [RegularExpression("[.][a-z]{0,4}$", ErrorMessage = "It has to start with '.' character, max 4 characters a-z")]
        public string Extension { get; set; }

        public static SerialFileDto MapTo(SerializedFile file)
        {
            return new SerialFileDto
            {
                Id = file.Id,
                Name = file.Name,
                FileContent = file.FileContent,
                Extension = file.Extension
            };
        }

        public static SerializedFile MapTo(SerialFileDto fileModel)
        {
            return new SerializedFile
            {
                Id = fileModel.Id,
                Name = fileModel.Name,
                FileContent = fileModel.FileContent,
                Extension = fileModel.Extension
            };
        }

    }
}
