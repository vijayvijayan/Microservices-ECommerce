using Shop.Services.OrderAPI.Models.Dto;

namespace Shop.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
