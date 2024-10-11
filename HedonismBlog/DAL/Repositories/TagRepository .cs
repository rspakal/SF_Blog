using HedonismBlog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Threading.Tasks;

namespace HedonismBlog.DataAccess.Repositories
{
    public class TagRepository : ITagRepository
    {
        HedonismBlogContext _context;
        public TagRepository(HedonismBlogContext context)
        {
            _context = context;
        }
        public async Task<Tag> Create(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return await Get(tag.Id);
        }

        public async Task Delete(int id)
        {
            var _tag = await Get(id);
            _context.Tags.Remove(_tag);
        }

        public async Task<Tag> Get(int id)
        {
            return await _context.Tags.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable> GetAll()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> Update(Tag tag)
        {
            var _tag = await Get(tag.Id);
            if (_tag == null) 
            {
                return null;
            }
            _tag = tag;
            _context.Tags.Update(_tag);
            await _context.SaveChangesAsync();
            return await Get(_tag.Id);
        }
    }
}
