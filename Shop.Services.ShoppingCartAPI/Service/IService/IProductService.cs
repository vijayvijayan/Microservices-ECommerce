using Shop.Services.ShoppingCartAPI.Models.Dto;

namespace Shop.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
