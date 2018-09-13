using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class FormSubmittedStatus
    {
        public FormSubmittedStatus()
        {
            FormSubmitted = new HashSet<FormSubmitted>();
        }

        public int FormSubmittedStatusId { get; set; }
        public string StatusDescription { get; set; }

        public ICollection<FormSubmitted> FormSubmitted { get; set; }
    }
}
