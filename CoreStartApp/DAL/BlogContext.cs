﻿using Microsoft.EntityFrameworkCore;
using CoreStartApp.Models.Entities;

namespace CoreStartApp.DAL
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPost> UserPosts { get; set; }

        public DbSet<Request> Requests { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
    }
}