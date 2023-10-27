using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMSBlog.Core.Domain.Content
{
    [Table("PostTags")]
    public class PostTag
    {
        public Guid PostId { set; get; }

        public Guid TagId { set; get; }
    }
}
