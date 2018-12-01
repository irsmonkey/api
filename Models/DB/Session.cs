using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class Session
    {
        public Guid SessionId { get; set; }
        public Guid? MemberId { get; set; }
        public string AppState { get; set; }
        public DateTime? SassionDate { get; set; }
    }
}
