using MediatR;
using MediatRWithEFCoreDemo.Models;

namespace MediatRWithEFCoreDemo.Features.Products
{
    public class GetAllProductsQuery : IRequest<(List<Product>, int)>  // Tuple: List of Products and total count for pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SortBy { get; set; } // Sort by column name
        public bool Ascending { get; set; } = true; // Sort order (ascending or descending)
        public string? FilterName { get; set; } // Optional filter for product name
        public decimal? MinPrice { get; set; } // Optional filter for min price
        public decimal? MaxPrice { get; set; } // Optional filter for max price

        public GetAllProductsQuery(int pageNumber, int pageSize, string? sortBy = null, bool ascending = true, string? filterName = null, decimal? minPrice = null, decimal? maxPrice = null)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SortBy = sortBy;
            Ascending = ascending;
            FilterName = filterName;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
        }
    }
}
