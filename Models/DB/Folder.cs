using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Folder
    {
        public Folder()
        {
            File = new HashSet<File>();
        }

        public int FolderId { get; set; }
        public Guid MemberId { get; set; }
        public string Name { get; set; }
        public DateTime DateStamp { get; set; }
        public bool? Predefined { get; set; }
        public int? MembershipTypeId { get; set; }

        public Member Member { get; set; }
        public ICollection<File> File { get; set; }
    }
}
