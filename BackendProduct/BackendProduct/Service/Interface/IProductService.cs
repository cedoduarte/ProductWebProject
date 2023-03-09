using BackendProduct.CQRS.Products.Command.DeleteProduct;
using BackendProduct.CQRS.Products.Command.InsertProduct;
using BackendProduct.CQRS.Products.Command.UpdateProduct;
using BackendProduct.CQRS.Products.Query.GetProductList;
using BackendProduct.CQRS.Products.ViewModel;

namespace BackendProduct.Service.Interface
{
    public interface IProductService
    {
        Task<bool> InsertProduct(InsertProductCommand command);
        Task<bool> UpdateProduct(UpdateProductCommand command);
        Task<bool> DeleteProduct(int id);
        Task<IEnumerable<ProductViewModel>> GetProductList(GetProductListQuery query);
        Task<ProductViewModel> GetProductById(int id);
    }
}
