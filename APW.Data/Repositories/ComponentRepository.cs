using APW.Data.MSSQL;
using APW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APW.Data.Repositories
{
    public interface IComponentRepository
    {
        Task<bool> UpsertAsync(Component entity, bool isUpdating);
        Task<bool> CreateAsync(Component entity);
        Task<bool> DeleteAsync(Component entity);
        Task<IEnumerable<Component>> ReadAsync();
        Task<Component> FindAsync(int id);
        Task<bool> UpdateAsync(Component entity);
        Task<bool> UpdateManyAsync(IEnumerable<Component> entities);
        Task<bool> ExistsAsync(Component entity);
    }
    public class ComponentRepository(ProductDb2Context context) : RepositoryBase<Component>(context), IComponentRepository
    {
    }
}
