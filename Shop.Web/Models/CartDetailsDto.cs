using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Web.Models.Dto
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public CartHeaderDto? CartHeader { get; set; }

        public int ProductId { get; set; }

        [NotMapped]
        public ProductDto? Product { get; set; }

        public int Count { get; set; }
    }
}
