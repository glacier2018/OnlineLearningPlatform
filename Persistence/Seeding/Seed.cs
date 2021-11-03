using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Seeding
{
    public static class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<ApplicationUser>
                {
                    new ApplicationUser {
                        UserName = "Cam@email.com",
                        FirstName = "Charles",
                        LastName = "Xavier",
                        Email = "Cam@email.com",
                        UserType = 0,
                        Photo = null,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Today.AddHours(4)
                    },
                    new ApplicationUser {
                        UserName = "Tim@email.com",
                        FirstName = "James",
                        LastName = "Logan",
                        Email = "Tim@email.com",
                        UserType = 0,
                        Photo = null,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Today.AddHours(23)
                    },
                    new ApplicationUser {
                        UserName = "Bob@email.com",
                        FirstName = "Charles",
                        LastName = "Bob",
                        Email = "Bob@email.com",
                        UserType = 0,
                        Photo = null,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Today.AddHours(12)
                    }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "password");
                }
            }
            if (!context.Posts.Any())
            {
                var posts = new List<Post>
                {
                    new Post
                    {
                        Title = "How to learn HTML",
                        Description = "learning skills",
                        Content = "How can I learn HTML so effictively that I can master everything within a day?",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsActive = true,
                    },
                    new Post
                    {
                        Title = "How to learn CSS",
                        Description = "learning skills",
                        Content = "How can I learn CSS so effictively that I can master everything within a day?",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsActive = true,
                    },
                    new Post
                    {
                        Title = "How to learn Javascript",
                        Description = "learning skills",
                        Content = "How can I learn Javascript so effictively that I can master everything within a day?",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsActive = true,
                    },
                    new Post
                    {
                        Title = "How to learn React",
                        Description = "learning skills",
                        Content = "How can I learn React so effictively that I can master everything within a day?",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsActive = true,
                    },
                };
                await context.Posts.AddRangeAsync(posts);
                await context.SaveChangesAsync();
            }

        }
    }
}