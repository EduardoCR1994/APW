using APW.Data.MSSQL;
using APW.Models;

namespace APW.Data.Repositories
{
    public interface IProductRepository 
    {
        Task<bool> UpsertAsync(Product entity, bool isUpdating);
        Task<bool> CreateAsync(Product entity);
        Task<bool> DeleteAsync(Product entity);
        Task<IEnumerable<Product>> ReadAsync();
        Task<Product> FindAsync(int id);
        Task<bool> UpdateAsync(Product entity);
        Task<bool> UpdateManyAsync(IEnumerable<Product> entities);
        Task<bool> ExistsAsync(Product entity);
    }
    public class ProductRepository(ProductDb2Context context) : RepositoryBase<Product>(context), IProductRepository
    {
    }
}
