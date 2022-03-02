using System;
using Microsoft.EntityFrameworkCore;

namespace WaterProject.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<Donation> Donations { get; set; }
    }
}
