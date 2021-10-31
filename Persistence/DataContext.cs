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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Entity<ActivityAttendee>(x => x.HasKey(aa => new { aa.ActivityId, aa.AppUserId }));

            // builder.Entity<ActivityAttendee>()
            //     .HasOne(aa => aa.AppUser)
            //     .WithMany(au => au.Activities)
            //     .HasForeignKey(aa => aa.AppUserId);

            // builder.Entity<ActivityAttendee>()
            //     .HasOne(aa => aa.Activity)
            //     .WithMany(a => a.Attendees)
            //     .HasForeignKey(aa => aa.ActivityId);
            builder.Entity<ApplicationUser>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();
        }

    }
}