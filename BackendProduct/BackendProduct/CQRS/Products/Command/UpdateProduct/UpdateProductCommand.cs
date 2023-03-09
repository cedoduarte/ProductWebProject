using MediatR;

namespace BackendProduct.CQRS.Products.Command.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; }
    }
}
