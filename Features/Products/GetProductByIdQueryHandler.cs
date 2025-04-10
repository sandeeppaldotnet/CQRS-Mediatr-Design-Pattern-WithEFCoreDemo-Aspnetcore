using MediatR;
using MediatRWithEFCoreDemo.Data;
using MediatRWithEFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatRWithEFCoreDemo.Features.Products
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly AppDbContext _context;

        public GetProductByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);
        }
    }
}
