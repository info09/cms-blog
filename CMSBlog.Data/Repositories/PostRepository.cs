using CMSBlog.Core.Domain.Content;
using CMSBlog.Core.Repositories;
using CMSBlog.Data.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace CMSBlog.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
    {
        public PostRepository(CMSBlogContext context) : base(context)
        {
        }

        public async Task<List<Post>> GetPopularPostsAsync(int count)
        {
            return await _context.Posts.OrderByDescending(i => i.ViewCount).Take(count).ToListAsync();
        }
    }
}
