using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Persistence
{
    public class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<TagPost> TagPosts { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PostReply> PostReplies { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            //Many to Many relationship: Tag & Post
            builder.Entity<TagPost>()
                .HasKey(x => new { x.PostId, x.TagId });
            builder.Entity<TagPost>()
                .HasOne(tp => tp.Post)
                .WithMany(p => p.TagPosts)
                .HasForeignKey(tp => tp.PostId);
            builder.Entity<TagPost>()
                .HasOne(tp => tp.Tag)
                .WithMany(t => t.TagPosts)
                .HasForeignKey(tp => tp.TagId);


        }

    }
}