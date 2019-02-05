using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class HousingStandard
    {
        public Guid HousingStandardId { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public int? Family1 { get; set; }
        public int? Family2 { get; set; }
        public int? Family3 { get; set; }
        public int? Family4 { get; set; }
        public int? Family5 { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
