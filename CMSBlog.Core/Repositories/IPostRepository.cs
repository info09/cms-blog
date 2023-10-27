using CMSBlog.Core.Domain.Content;
using CMSBlog.Core.SeedWorks;

namespace CMSBlog.Core.Repositories
{
    public interface IPostRepository : IRepository<Post, Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
    }
}
