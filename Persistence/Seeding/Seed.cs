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
                        Title = "Javascrit is the Best?",
                        Description = "Is Javascript  really the best?!",
                        Content = "Can any one explain why javascript is the best language in the whole world?",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        IsActive = true,
                    },
                };
                await context.Posts.AddRangeAsync(posts);
                await context.SaveChangesAsync();
            }
            if (!await context.Tags.AnyAsync())
            {
                var tags = new List<Tag>
                {
                    new Tag { TagName = "SideProjects", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                    new Tag { TagName = "Crypto", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                    new Tag { TagName = "JobSeeking", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                    new Tag { TagName = "ProgramingLanguages", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now},
                };
                await context.Tags.AddRangeAsync(tags);
                await context.SaveChangesAsync();
            }
            if (!await context.PostCategories.AnyAsync())
            {
                var postCategories = new List<PostCategory>
                {
                    new PostCategory{ CategoryName = "Frontend",CategoryDescription = "Here we talk about frontend technologies",CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PhotoUrl = null},
                    new PostCategory{ CategoryName = "Backend",CategoryDescription = "Here we talk about backend technologies",CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PhotoUrl = null},
                    new PostCategory{ CategoryName = "Interview experience",CategoryDescription = "Here we talk about interview experiences",CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PhotoUrl = null},
                    new PostCategory{ CategoryName = "Non-tech",CategoryDescription = "Here we talk about non-tech related stuff: gaming sports and whatever you like",CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, PhotoUrl = null}
                };
                await context.PostCategories.AddRangeAsync(postCategories);
                await context.SaveChangesAsync();
            }

        }
    }
}