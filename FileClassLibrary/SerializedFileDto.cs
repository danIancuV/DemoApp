using System;


namespace FileClassLibrary
{
    [Serializable]
    public class SerializedFileDto
    {
     
        public string Name { get; set; }
     
        public string FileContent { get; set; }
        
        public string Extension { get; set; }

    }
}
