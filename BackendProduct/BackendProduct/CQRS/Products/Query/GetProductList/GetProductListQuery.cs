using BackendProduct.CQRS.Products.ViewModel;
using MediatR;

namespace BackendProduct.CQRS.Products.Query.GetProductList
{
    public class GetProductListQuery : IRequest<IEnumerable<ProductViewModel>>
    {
        public string? Keyword { get; set; }
        public bool GetAll { get; set; }
    }
}
