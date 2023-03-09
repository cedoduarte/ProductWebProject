using AutoMapper;
using BackendProduct.CQRS.Products.ViewModel;
using BackendProduct.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackendProduct.CQRS.Products.Query.GetProductList
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public GetProductListHandler(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        /// Returns the found "products"
        public async Task<IEnumerable<ProductViewModel>> Handle(GetProductListQuery query, CancellationToken cancel)
        {
            try
            {
                if (query.GetAll)
                {
                    // Returns all "products"
                    return _mapper.Map<IEnumerable<ProductViewModel>>(await _dbContext.Products
                        .Where(x => true)
                        .ToListAsync(cancel));
                }
                else
                {
                    // Returns matched "products"
                    if (!string.IsNullOrEmpty(query.Keyword))
                    {
                        return _mapper.Map<IEnumerable<ProductViewModel>>(await _dbContext.Products
                            .Where(x => x.Id.ToString().Contains(query.Keyword.ToLower())
                                        || (string.IsNullOrEmpty(x.Name) ? false : x.Name.ToLower().Contains(query.Keyword.ToLower()))
                                        || (string.IsNullOrEmpty(x.Description) ? false : x.Description.ToLower().Contains(query.Keyword.ToLower()))
                                        || x.Price.ToString().Contains(query.Keyword.ToLower())
                                        || x.StockCount.ToString().Contains(query.Keyword.ToLower()))
                            .ToListAsync(cancel));
                    }
                    throw new Exception("Keyword cannot be null or empty");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
