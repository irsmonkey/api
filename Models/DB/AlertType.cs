using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class AlertType
    {
        public AlertType()
        {
            Alert = new HashSet<Alert>();
        }

        public int AlertTypeId { get; set; }
        public string AlertTypeName { get; set; }
        public string AlertTypeIconClass { get; set; }

        public ICollection<Alert> Alert { get; set; }
    }
}
