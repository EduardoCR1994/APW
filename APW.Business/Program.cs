using APW.Data.Repositories;
using APW.Models;

namespace APW.Business
{
    public interface IProductBusiness
    {
        Task<bool> CreateProductAsync(Product product);
        Task<IEnumerable<Product>> GetProductsAsync();
    }

    public class ProductBusiness(IProductRepository productRepository) : IProductBusiness

    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<bool> CreateProductAsync(Product product)
        {
            return await productRepository.CreateAsync(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await productRepository.ReadAsync();
        }
    }

}
