using AutoMapper;
using CMSBlog.Core.Domain.Content;
using CMSBlog.Core.Models;
using CMSBlog.Core.Models.Content;
using CMSBlog.Core.Repositories;
using CMSBlog.Data.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace CMSBlog.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
    {
        private readonly IMapper _mapper;
        public PostRepository(CMSBlogContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<Post>> GetPopularPostsAsync(int count)
        {
            return await _context.Posts.OrderByDescending(i => i.ViewCount).Take(count).ToListAsync();
        }

        public async Task<PagedResult<PostInListDto>> GetPostsPagingAsync(string keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10)
        {
            var query = _context.Posts.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(i => i.Name.ToLower().Contains(keyword.ToLower()));

            if (categoryId.HasValue)
                query = query.Where(i => i.CategoryId == categoryId.Value);

            var totalRow = await query.CountAsync();

            query = query.OrderByDescending(i => i.DateCreated).Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new PagedResult<PostInListDto>()
            {
                PageSize = pageSize,
                RowCount = totalRow,
                CurrentPage = pageIndex,
                Results = await _mapper.ProjectTo<PostInListDto>(query).ToListAsync()
            };
        }
    }
}
