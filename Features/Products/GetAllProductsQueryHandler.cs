using MediatR;
using MediatRWithEFCoreDemo.Data;
using MediatRWithEFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatRWithEFCoreDemo.Features.Products
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, (List<Product>, int)>
    {
        private readonly AppDbContext _context;

        public GetAllProductsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(List<Product>, int)> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Product> query = _context.Products.AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(request.FilterName))
            {
                query = query.Where(p => p.Name.Contains(request.FilterName));
            }
            if (request.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= request.MinPrice.Value);
            }
            if (request.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= request.MaxPrice.Value);
            }

            // Apply sorting
            if (!string.IsNullOrEmpty(request.SortBy))
            {
                query = request.Ascending
                    ? query.OrderBy(p => EF.Property<object>(p, request.SortBy)) // Ascending sort
                    : query.OrderByDescending(p => EF.Property<object>(p, request.SortBy)); // Descending sort
            }

            // Get total count before pagination
            int totalCount = await query.CountAsync(cancellationToken);

            // Apply pagination
            query = query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize);

            // Get paginated result
            var products = await query.ToListAsync(cancellationToken);

            return (products, totalCount);
        }
    }
}

