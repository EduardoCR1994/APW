using APW.Data.MSSQL;
using APW.Models;

namespace APW.Data.Repositories
{
    public interface IRoleRepository
    {
        Task<bool> UpsertAsync(Role entity, bool isUpdating);
        Task<bool> CreateAsync(Role entity);
        Task<bool> DeleteAsync(Role entity);
        Task<IEnumerable<Role>> ReadAsync();
        Task<Role> FindAsync(int id);
        Task<bool> UpdateAsync(Role entity);
        Task<bool> UpdateManyAsync(IEnumerable<Role> entities);
        Task<bool> ExistsAsync(Role entity);
    }
    public class RoleRepository(ProductDb2Context context) : RepositoryBase<Role>(context), IRoleRepository
    {
    }
}
