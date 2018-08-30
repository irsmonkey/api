using System;
using System.Collections.Generic;

namespace IrsMonkeyApi.Models.DB
{
    public partial class LienType
    {
        public int LienTypeId { get; set; }
        public string Title { get; set; }
        public string Descripcion { get; set; }
        public int ResolutionCategoryId { get; set; }
    }
}
