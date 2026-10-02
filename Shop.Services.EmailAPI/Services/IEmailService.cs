using Shop.Services.EmailAPI.Models.Dto;

namespace Shop.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
    }
}
