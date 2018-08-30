using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class FormType
    {
        public FormType()
        {
            Form = new HashSet<Form>();
        }

        public int FormTypeId { get; set; }
        public string FormTypeDescription { get; set; }

        public ICollection<Form> Form { get; set; }
    }
}
