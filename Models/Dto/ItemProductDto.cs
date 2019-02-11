using System.Collections.Generic;

namespace IrsMonkeyApi.Models.Dto
{
    public class ItemProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public List<UpsaleProduct> AdditionalProducts = new List<UpsaleProduct>();
    }
}           