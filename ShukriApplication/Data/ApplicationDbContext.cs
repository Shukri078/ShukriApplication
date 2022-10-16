using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ShukriApplication.Models;

namespace ShukriApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShukriApplication.Models.ProjectRole> ProjectRole { get; set; }
        public DbSet<ShukriApplication.Models.ScheduleDate> ScheduleDate { get; set; }

        public virtual DbSet<ClassRoom> ClassRooms { get; set; }

    }
}
