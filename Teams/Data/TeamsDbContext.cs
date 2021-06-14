using Teams.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Teams.Data
{
    public class TeamsDbContext : DbContext
    {
        public TeamsDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
    }
}
