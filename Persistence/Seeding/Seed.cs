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
        public static async Task SeedData(DataContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User {
                        UserName = "Cam",
                        FirstName = "Charles",
                        LastName = "Xavier",
                        Email = "Cam@email.com",
                        UserType = 0,
                        Photo = null,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Today.AddHours(4)
                    },
                    new User {
                        UserName = "Tim",
                        FirstName = "James",
                        LastName = "Logan",
                        Email = "Tim@email.com",
                        UserType = 0,
                        Photo = null,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Today.AddHours(23)
                    },
                    new User {
                        UserName = "Bob",
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
        }
    }
}