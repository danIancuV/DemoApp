using System;
using System.Collections.Generic;

namespace DbCoreLibrary
{
    public partial class SerializedFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileContent { get; set; }
        public string Extension { get; set; }    
    }

}
