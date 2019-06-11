using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;

namespace ProjectManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Methodologies> Methodologies { get; set; }
        public DbSet<Phases> Phases { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectPhase> ProjectPhases { get; set; }
        public DbSet<Task> Tasks { get; set; }

    }
}
