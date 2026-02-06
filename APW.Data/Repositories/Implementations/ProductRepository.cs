using Microsoft.EntityFrameworkCore;

namespace APW.Data.Repositories.Implementations
{
  public class ProductRepository : IProductRepository, IDisposable
  {
    private ProductDbContext context;

    public ProductRepository(ProductDbContext context)
    {
      this.context = context;
    }

    public IEnumerable<Product> GetProducts()
    {
      return context.Products
                .Include(p => p.Inventory)
                .Include (p => p.Category)
                .ToList();
    }

    public Product GetProductByID(int id) => context.Products.Find(id);

    public void InsertProduct(Product student) => context.Products.Add(student);

    public void DeleteProduct(int studentID)
    {
      Product student = context.Products.Find(studentID);
      context.Products.Remove(student);
    }

    public void UpdateProduct(Product student) => context.Entry(student).State = EntityState.Modified;

    public void Save()
    {
      context.SaveChanges();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          context.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
