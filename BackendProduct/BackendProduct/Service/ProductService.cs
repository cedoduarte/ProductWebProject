using BackendProduct.CQRS.Products.Command.DeleteProduct;
using BackendProduct.CQRS.Products.Command.InsertProduct;
using BackendProduct.CQRS.Products.Command.UpdateProduct;
using BackendProduct.CQRS.Products.Query.GetProductById;
using BackendProduct.CQRS.Products.Query.GetProductList;
using BackendProduct.CQRS.Products.ViewModel;
using BackendProduct.Service.Interface;
using MediatR;

namespace BackendProduct.Service
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// Inserts new "product" into "database"
        public async Task<bool> InsertProduct(InsertProductCommand command)
        {
            try 
            {
                return await _mediator.Send(command);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Updates a "product" from its "id"
        public async Task<bool> UpdateProduct(UpdateProductCommand command)
        {
            try
            {
                return await _mediator.Send(command);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Deletes a "product" from its "id"
        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                return await _mediator.Send(new DeleteProductCommand()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Returns the found "products"
        public async Task<IEnumerable<ProductViewModel>> GetProductList(GetProductListQuery query)
        {
            try
            {
                return await _mediator.Send(query);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Returns the found "product" by its "id"
        public async Task<ProductViewModel> GetProductById(int id)
        {
            try
            {
                return await _mediator.Send(new GetProductByIdQuery()
                {
                    Id = id
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}