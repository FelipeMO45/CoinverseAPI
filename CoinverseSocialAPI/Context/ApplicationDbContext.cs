using CoinverseSocialAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoinverseSocialAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {  }

        public DbSet<UserModel> sUser { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<cTypePost> cTypePost { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<cTypeLike> cTypeLike { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.FkUser)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.TypePost)
                .WithMany(t => t.Posts)
                .HasForeignKey(p => p.FkTypePost);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.SharedPost)
                .WithMany()
                .HasForeignKey(p => p.IdPostShared)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación de Comentarios
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.FkPost)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.FkUser)
                .OnDelete(DeleteBehavior.SetNull);

            // Relación de Seguidores
            modelBuilder.Entity<Follower>()
                .HasOne(f => f.User)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FkUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Follower>()
                .HasOne(f => f.FollowerUser)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.FkFollower)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación de Likes
            modelBuilder.Entity<Like>()
            .HasKey(l => l.PkLike);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.FkUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Like>()
            .HasOne(l => l.Post)
            .WithMany(p => p.Likes)
            .HasForeignKey(l => l.FkPost)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.TypeLike)
                .WithMany(t => t.Likes)
                .HasForeignKey(l => l.FkTypeLike)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<cTypeLike>()
                .HasKey(t => t.PkTypeLike);

            base.OnModelCreating(modelBuilder);
        }
    }
}
