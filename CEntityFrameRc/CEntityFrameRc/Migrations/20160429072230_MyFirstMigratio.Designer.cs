using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CEntityFrameRc.Model;

namespace CEntityFrameRc.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20160429072230_MyFirstMigratio")]
    partial class MyFirstMigratio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("CEntityFrameRc.Model.Friendship", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("FriendId");

                    b.Property<uint>("Rank");

                    b.Property<ulong>("Since");

                    b.Property<string>("UserUserId");

                    b.HasKey("UserId", "FriendId");
                });

            modelBuilder.Entity("CEntityFrameRc.Model.UserProfile", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.HasIndex("Email");

                    b.HasIndex("Username");
                });

            modelBuilder.Entity("CEntityFrameRc.Model.Friendship", b =>
                {
                    b.HasOne("CEntityFrameRc.Model.UserProfile")
                        .WithMany()
                        .HasForeignKey("FriendId");

                    b.HasOne("CEntityFrameRc.Model.UserProfile")
                        .WithMany()
                        .HasForeignKey("UserUserId");
                });
        }
    }
}
