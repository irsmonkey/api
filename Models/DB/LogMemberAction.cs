using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class LogMemberAction
    {
        public int LogMemberAction1 { get; set; }
        public Guid MemberId { get; set; }
        public DateTime DateAdded { get; set; }
        public string Ip { get; set; }
        public string ServerName { get; set; }
        public int LogActionTypeId { get; set; }
        public string Object { get; set; }
        public string OldValue { get; set; }
        public string Comments { get; set; }
        public string NewValue { get; set; }

        public LogActionType LogActionType { get; set; }
        public Member Member { get; set; }
    }
}
