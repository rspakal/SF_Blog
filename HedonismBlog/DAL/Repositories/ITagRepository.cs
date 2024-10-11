using HedonismBlog.Models;
using System.Collections;
using System.Threading.Tasks;

namespace HedonismBlog.DataAccess.Repositories
{
    public interface ITagRepository
    {
        public Task<Tag> Create(Tag tag);
        public Task<Tag> Get(int id);
        public Task<IEnumerable> GetAll();
        public Task<Tag> Update(Tag tag);
        public Task Delete(int id);
    }
}
