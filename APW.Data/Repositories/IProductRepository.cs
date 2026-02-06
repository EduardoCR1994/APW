namespace APW.Data.Repositories
{
  public interface IProductRepository
  {
    IEnumerable<Product> GetProducts();
    Product GetProductByID(int studentId);
    void InsertProduct(Product student);
    void DeleteProduct(int studentID);
    void UpdateProduct(Product student);
    void Save();
  }
}
