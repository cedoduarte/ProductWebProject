using BackendProduct.Model;
using MediatR;

namespace BackendProduct.CQRS.Products.Command.InsertProduct
{
    public class InsertProductHandler : IRequestHandler<InsertProductCommand, bool>
    {
        private readonly AppDbContext _dbContext;

        public InsertProductHandler(AppDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        /// Inserts new "product" into "database"
        public async Task<bool> Handle(InsertProductCommand command, CancellationToken cancel)
        {
            try
            {
                await _dbContext.Products.AddAsync(Map(command), cancel);
                await _dbContext.SaveChangesAsync(cancel);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Maps "product" from "command"
        private Product Map(InsertProductCommand command)
        {
            return new Product()
            {
                Name = command.Name ?? "none",
                Description = command.Description ?? "none",
                Price = command.Price,
                StockCount = command.StockCount
            };
        }
    }
}
