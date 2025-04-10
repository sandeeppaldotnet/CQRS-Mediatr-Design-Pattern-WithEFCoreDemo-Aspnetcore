using MediatR;
using MediatRWithEFCoreDemo.Models;

namespace MediatRWithEFCoreDemo.Features.Products
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public UpdateProductCommand(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
