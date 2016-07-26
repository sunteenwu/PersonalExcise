using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CEntityFrameRc.Model
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
            modelBuilder.Entity<UserProfile>().HasIndex(p => p.Username);
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

    public class Friendship
    {
        public string UserId { get; set; }
        public UserProfile User { get; set; }
        public string FriendId { get; set; }
        public UserProfile Friend { get; set; }
        public ulong Since { get; set; }
        public uint Rank { get; set; }
    }

    public class UserProfile
    {
        [DataMember(Name = "uid"), Key]
        public string UserId { get; set; }
        [DataMember(Name = "un")]
        public string Username { get; set; }
        [DataMember(Name = "em")]
        public string Email { get; set; }
        [DataMember(Name = "fn")]
        public string FullName { get; set; }
        [DataMember]
        public List<Friendship> Friendships { get; set; }
    }
}
