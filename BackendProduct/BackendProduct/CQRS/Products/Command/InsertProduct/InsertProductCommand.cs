using MediatR;

namespace BackendProduct.CQRS.Products.Command.InsertProduct
{
    public class InsertProductCommand : IRequest<bool>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
    }
}
