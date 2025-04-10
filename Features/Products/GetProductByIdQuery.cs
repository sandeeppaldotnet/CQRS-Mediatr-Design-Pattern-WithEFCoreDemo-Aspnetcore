using MediatR;
using MediatRWithEFCoreDemo.Models;

namespace MediatRWithEFCoreDemo.Features.Products
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int ProductId { get; set; }

        public GetProductByIdQuery(int productId)
        {
            ProductId = productId;
        }
    }
}
