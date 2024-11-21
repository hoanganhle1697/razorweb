using Entity_Razor.Helper;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Entity_Razor.Models
{

    public class MyBlogContext : DbContext
    {
        public DbSet<Article> articles { get; set; }


        public MyBlogContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int>SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Article>())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    // Nếu Slug chưa có giá trị, tạo giá trị cho Slug từ Title
                    if (string.IsNullOrEmpty(entry.Entity.Slug) && !string.IsNullOrEmpty(entry.Entity.Title))
                    {
                        entry.Entity.Slug = SlugHelper.GetSlug(entry.Entity.Title, articles);
                    }
                }
            }

            return await base.SaveChangesAsync();
        }

    }
}