using HedonismBlog.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Collections;
using System.Threading.Tasks;
using static HedonismBlog.DAL.Repositories.RoleRepository;
using static HedonismBlog.Models.Role;

namespace HedonismBlog.DAL.Repositories
{
    public interface IRoleRepository
    {
        public Task<IEnumerable> GetAllUsers (Role role);
        public Task<Role> GetRolesByName(Roles role);
    }
}
