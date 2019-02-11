using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class FormResolution
    {
        public int FormResolutionId { get; set; }
        public int FormId { get; set; }
        public int ResolutionId { get; set; }
        public bool? IsPdf { get; set; }

        public Form Form { get; set; }
        public Resolution Resolution { get; set; }
    }
}
