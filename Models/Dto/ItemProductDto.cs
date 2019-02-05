using System.Collections.Generic;

namespace IrsMonkeyApi.Models.Dto
{
    public class ItemProductDto
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public List<UpsaleProduct> UpSales = new List<UpsaleProduct>();
    }
}       