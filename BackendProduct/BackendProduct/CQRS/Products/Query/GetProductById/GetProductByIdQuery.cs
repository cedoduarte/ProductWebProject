using BackendProduct.CQRS.Products.ViewModel;
using MediatR;

namespace BackendProduct.CQRS.Products.Query.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }
}
