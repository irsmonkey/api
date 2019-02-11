using System;
using System.Linq;
using IrsMonkeyApi.Models.DB;
using IrsMonkeyApi.Models.Dto;

namespace IrsMonkeyApi.Models.DAL
{
    public class ProductItemDal : IProductItemDal
    {
        private readonly IRSMonkeyContext _context;
        
        public ProductItemDal(IRSMonkeyContext context)
        {
            _context = context;
        }
        
        public ItemProductDto GetProductItems(int productId)
        {
            try
            {
                var productItem = _context.Item.Where(x => x.ItemId == productId)
                    .Select(pi => new {ItemName = pi.ItemName, ItemPrice = pi.Price, Description = pi.Description}).ToList();
                var upSaleProducts = _context.Item.Where(x => x.ParentItem == productId)
                    .Select(piu => new {ItemName = piu.ItemName, ItemPrice = piu.Price, Description = piu.Description}).ToList();
                var selectedProduct = new ItemProductDto
                {
                    Name = productItem[0].ItemName,
                    Price = Convert.ToDouble(productItem[0].ItemPrice.ToString()),
                    Description = productItem[0].Description
                        
                };
                foreach (var upSaleProduct in upSaleProducts)
                {
                    var itemUpSale = new UpsaleProduct
                    {
                        Name = upSaleProduct.ItemName, 
                        Price = upSaleProduct.ItemPrice, 
                        Description = upSaleProduct.Description
                    };
                    selectedProduct.AdditionalProducts.Add(itemUpSale);
                }

                return selectedProduct;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}