using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

            public static SerialFileDto MapTo(DbFile file)
            {
                return new SerialFileDto
                {
                    Id = file.Id,
                    Name = file.Name,
                    FileContent = file.FileContent,
                    Extension = file.Extension
                };
            }

            public static DbFile MapTo(SerialFileDto file)
            {
                return new DbFile
                {
                    Id = file.Id,
                    Name = file.Name,
                    FileContent = file.FileContent,
                    Extension = file.Extension
                };
            }
        }
}
