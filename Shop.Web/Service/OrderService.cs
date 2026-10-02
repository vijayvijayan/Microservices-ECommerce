using Shop.Web.Models;
using Shop.Web.Models.Dto;
using Shop.Web.Service.IService;
using Shop.Web.Utility;

namespace Shop.Web.Service
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;
        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;

        }

        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(
               new RequestDto()
               {
                   ApiType = SD.ApiType.POST,
                   Data = cartDto,
                   Url = SD.OrderAPIBase + "/api/order/CreateOrder"
               }
           );
        }

        public async Task<ResponseDto?> CreateStripeSession(StripeRequestDto stripeRequestDto)
        {
            return await _baseService.SendAsync(
               new RequestDto()
               {
                   ApiType = SD.ApiType.POST,
                   Data = stripeRequestDto,
                   Url = SD.OrderAPIBase + "/api/order/CreateStripeSession"
               }
           );
        }

        public async Task<ResponseDto?> ValidateStripeSession(int orderHeaderId)
        {
            return await _baseService.SendAsync(
               new RequestDto()
               {
                   ApiType = SD.ApiType.POST,
                   Data = orderHeaderId,
                   Url = SD.OrderAPIBase + "/api/order/ValidateStripeSession"
               }
           );
        }
    }
}
