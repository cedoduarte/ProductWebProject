using Microsoft.EntityFrameworkCore;

namespace BackendProduct.Model.Interface
{
    public interface IAppDbContext
    {
        DbSet<Product> Products { get; set; }
    }
}
