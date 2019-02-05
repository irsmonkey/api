using IrsMonkeyApi.Models.Dto;

namespace IrsMonkeyApi.Models.DAL
{
    public interface IProductItemDal
    {
        ItemProductDto GetProductItems(int productId);
    }
}