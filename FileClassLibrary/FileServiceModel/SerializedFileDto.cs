using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileClassLibrary.FileServiceModel
{
    [Serializable]
    public class SerializedFileDto
    {
        public string Name { get; set; }

        public string FileContent { get; set; }

        public string Extension { get; set; }
    }
}
