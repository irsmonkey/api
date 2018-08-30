using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class LogActionType
    {
        public LogActionType()
        {
            LogMemberAction = new HashSet<LogMemberAction>();
            LogUserAction = new HashSet<LogUserAction>();
        }

        public int LogActionTypeId { get; set; }
        public string LogActionDescription { get; set; }

        public ICollection<LogMemberAction> LogMemberAction { get; set; }
        public ICollection<LogUserAction> LogUserAction { get; set; }
    }
}
