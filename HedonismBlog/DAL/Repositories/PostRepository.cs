using HedonismBlog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace HedonismBlog.DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        HedonismBlogContext _context;
        public PostRepository(HedonismBlogContext context)
        {
            _context = context;
        }
        public async Task<Post> Create(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return await Get(post.Id);
        }

        public async Task Delete(int id)
        {
            var _post = await Get(id);
            _context.Posts.Remove(_post);
        }

        public async Task<Post> Get(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }
        public async Task<IEnumerable> GetByUserId(int userId)
        {
            return await _context.Posts.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<Post> Update(Post post)
        {
            var _post = await Get(post.Id);
            if (_post == null) 
            {
                return null;
            }
            _post = post;
            _context.Posts.Update(_post);
            await _context.SaveChangesAsync();
            return await Get(_post.Id);
        }
    }
}
