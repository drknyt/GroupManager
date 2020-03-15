using CRUD.UserManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace CRUD.UserManagement.Infrastructure
{
    public class UserManagementContext : DbContext
    {

        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>().HasKey(t => new { t.UserId, t.GroupId });
            modelBuilder.Entity<UserGroup>()
                          .HasOne(pc => pc.Group)
                          .WithMany(p => p.UserGroups)
                          .HasForeignKey(pc => pc.GroupId);
            modelBuilder.Entity<UserGroup>()
                        .HasOne(pc => pc.User)
                        .WithMany(c => c.UserGroups)
                        .HasForeignKey(pc => pc.UserId);

            User user1 = new User
            {
                UserId = 1,
                FirstName = "Bassem",
                UserName = "bassem.wadie",
                Password = "1234",
                LastName ="Wadie"
            };
            User user2 = new User
            {
                UserId = 2,
                FirstName = "Ahmed",
                UserName = "ahmed.adel",
                Password = "1234",
                LastName = "Adel"
            };
         

            Group group1 = new Group
            {
                GroupId = 1,
                GroupName = "IT",
                GroupAdmin = 1
            };

            Group group2 = new Group
            {
                GroupId =2,
                GroupName = "Sales" , 
                GroupAdmin = 1
            };

            modelBuilder.Entity<User>().HasData(user1,user2);

            modelBuilder.Entity<Group>().HasData(
            group1,group2);

        }
    }
}
