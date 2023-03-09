using BackendProduct.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackendProduct.CQRS.Products.Command.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly AppDbContext _dbContext;

        public DeleteProductHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// Deletes a "product" from its "id"
        public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancel)
        {
            try
            {
                // Does the requested "product" exist?
                Product? foundProduct = await _dbContext.Products
                    .Where(x => x.Id == command.Id)
                    .FirstOrDefaultAsync(cancel);
                if (foundProduct != null)
                {
                    // Removes the found "product"
                    _dbContext.Products.Remove(foundProduct);
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
    }
}
