using MediatR;

namespace BackendProduct.CQRS.Products.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
