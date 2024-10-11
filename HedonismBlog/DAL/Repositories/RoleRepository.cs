using HedonismBlog.DataAccess;
using HedonismBlog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading.Tasks;
using static HedonismBlog.Models.Role;

namespace HedonismBlog.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HedonismBlogContext _context;
        public RoleRepository(HedonismBlogContext context)
        {
            _context = context;
        }
        public Task<IEnumerable> GetAllUsers(Role role)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Role> GetRolesByName(Roles role)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == role.ToString());
        }
    }
}
