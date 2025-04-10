using MediatR;

namespace MediatRWithEFCoreDemo.Features.Products
{
    public class DeleteProductCommand: IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
