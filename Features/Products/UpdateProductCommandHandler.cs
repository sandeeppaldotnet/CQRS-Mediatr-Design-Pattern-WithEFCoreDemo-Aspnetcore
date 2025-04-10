using MediatR;
using MediatRWithEFCoreDemo.Data;
using MediatRWithEFCoreDemo.Models;

namespace MediatRWithEFCoreDemo.Features.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly AppDbContext _context;

        public UpdateProductCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);

            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            product.Name = request.Name;
            product.Price = request.Price;

            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}
