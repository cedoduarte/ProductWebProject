using AutoMapper;
using BackendProduct.CQRS.Products.ViewModel;
using BackendProduct.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackendProduct.CQRS.Products.Query.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public GetProductByIdHandler(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        
        /// Returns the found "product" by its "id"
        public async Task<ProductViewModel> Handle(GetProductByIdQuery query, CancellationToken cancel)
        {
            try
            {
                // Does the requested "product" exist?
                Product? foundProduct = await _dbContext.Products
                    .Where(x => x.Id == query.Id)
                    .FirstOrDefaultAsync(cancel);
                if (foundProduct != null)
                {
                    // Returns the found "product" by its "id"
                    return _mapper.Map<ProductViewModel>(foundProduct);
                }
                throw new Exception($"{nameof(Product)} with ID {query.Id} not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
