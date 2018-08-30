using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class GarnishmentType
    {
        public int GarnishmentTypeId { get; set; }
        public string GarnishmentTypeName { get; set; }
        public bool? Levy { get; set; }
        public int? ResolutionCategoryId { get; set; }
        public string Content { get; set; }
        public int? Order { get; set; }
    }
}
