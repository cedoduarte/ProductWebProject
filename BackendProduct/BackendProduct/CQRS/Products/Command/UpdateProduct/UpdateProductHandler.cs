using BackendProduct.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackendProduct.CQRS.Products.Command.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly AppDbContext _dbContext;

        public UpdateProductHandler(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        /// Updates a "product" from its "id"
        public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancel)
        {
            try
            {
                // Does the requested product exist?
                Product? foundProduct = await _dbContext.Products
                    .Where(x => x.Id == command.Id)
                    .FirstOrDefaultAsync(cancel);
                if (foundProduct != null)
                {
                    // Updates the found "product"
                    ModifyProduct(ref foundProduct, command);
                    _dbContext.Products.Update(foundProduct);
                    await _dbContext.SaveChangesAsync(cancel);
                    return true;
                }
                throw new Exception($"{nameof(Product)} with ID {command.Id} not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Modifies the found "product" by "command"
        private void ModifyProduct(ref Product foundProduct, UpdateProductCommand command)
        {
            foundProduct.Name = command.Name ?? "none";
            foundProduct.Description = command.Description ?? "none";
            foundProduct.Price = command.Price;
            foundProduct.StockCount = command.StockCount;
        }
    }
}
