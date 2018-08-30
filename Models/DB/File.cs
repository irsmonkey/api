using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public DateTime DateStamp { get; set; }
        public string Alias { get; set; }
        public int FolderId { get; set; }

        public Folder Folder { get; set; }
    }
}
