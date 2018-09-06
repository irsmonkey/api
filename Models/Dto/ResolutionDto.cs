using System.Collections.Generic;
using IrsMonkeyApi.Models.DB;

namespace IrsMonkeyApi.Models.Dto
{
    public class ResolutionDto
    {
        public string Resolution1 { get; set; }
        public ICollection<FormResolution> FormResolution { get; set; }
        public ICollection<ResolutionLetter> ResolutionLetter { get; set; }
        public ICollection<Wizard> Wizard { get; set; }
    }
}