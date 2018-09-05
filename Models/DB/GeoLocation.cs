using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class GeoLocation
    {
        public int GeoLocationId { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string StateName { get; set; }
    }
}
