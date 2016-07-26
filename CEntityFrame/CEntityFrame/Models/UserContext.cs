using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CEntityFrame.Models
{
    public class UserContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Friendship> FriendShips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "User.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }
            catch (InvalidOperationException) { }

            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder.Entity<Blog>()
            //.Property(b => b.Url)
            //.IsRequired();    
            modelBuilder.Entity<UserProfile>().HasIndex(p => p.UserId);
            modelBuilder.Entity<UserProfile>().HasIndex(p => p.Email);
            modelBuilder.Entity<UserProfile>().HasMany(p => p.Friendships)
                        .WithOne(f => f.Friend)
                        .HasForeignKey(f => new { f.UserId, f.FriendId })
                        .OnDelete(Microsoft.Data.Entity.Metadata.DeleteBehavior.Cascade);

            modelBuilder.Entity<Friendship>().HasKey(k => new { k.UserId, k.FriendId });
            modelBuilder.Entity<Friendship>().HasOne(u => u.User)
                    .WithMany(u => u.Friendships)
                    .HasForeignKey(fs => fs.UserId);
            modelBuilder.Entity<Friendship>().HasOne(u => u.Friend)
                    .WithMany(f => f.Friendships)
                    .HasForeignKey(fs => fs.FriendId);
        }
    }
}
