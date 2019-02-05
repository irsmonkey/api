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
                    .Select(pi => new {ItemName = pi.ItemName, ItemPrice = pi.Price}).ToList();
                var upSaleProducts = _context.Item.Where(x => x.ParentItem == productId)
                    .Select(piu => new {ItemName = piu.ItemName, ItemPrice = piu.Price}).ToList();
                var selectedProduct = new ItemProductDto
                {
                    ProductName = productItem[0].ItemName,
                    ProductPrice = Convert.ToDouble(productItem[0].ItemPrice.ToString())
                        
                };
                foreach (var upSaleProduct in upSaleProducts)
                {
                    var itemUpSale = new UpsaleProduct {Name = upSaleProduct.ItemName, Price = upSaleProduct.ItemPrice};
                    selectedProduct.UpSales.Add(itemUpSale);
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