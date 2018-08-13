using System;
using System.ComponentModel.DataAnnotations;

namespace FileClassLibrary
{
    [Serializable]
    public class SerializedFileDto
    {
        
        public int Id { get; set; }
     
        public string Name { get; set; }
     
        public string FileContent { get; set; }
        
        public string Extension { get; set; }

    }
}
