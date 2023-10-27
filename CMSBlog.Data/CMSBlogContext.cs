using CMSBlog.Core.Domain.Content;
using CMSBlog.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMSBlog.Data
{
    public class CMSBlogContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public CMSBlogContext(DbContextOptions options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostActivityLog> PostActivityLogs { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<PostInSeries> PostInSeries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(i => i.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(i => i.Id);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(i => i.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(i => new { i.UserId, i.RoleId });
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(i => i.UserId);

            builder.Entity<PostInSeries>().HasKey(i => new { i.SeriesId, i.PostId });
            builder.Entity<PostTag>().HasKey(i => new { i.TagId, i.PostId });
        }

        //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

        //    foreach (var entityEntry in entries)
        //    {
        //        var dateCreateProp = entityEntry.Entity.GetType().GetProperty("DateCreated");
        //        if (entityEntry.State == EntityState.Added && dateCreateProp != null)
        //        {
        //            dateCreateProp.SetValue(entityEntry.Entity, DateTime.Now);
        //        }

        //        var modifiedDateProp = entityEntry.Entity.GetType().GetProperty("ModifiedDate");
        //        if (entityEntry.State == EntityState.Modified && modifiedDateProp != null)
        //        {
        //            modifiedDateProp.SetValue(entityEntry.Entity, DateTime.Now);
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
