using Microsoft.EntityFrameworkCore;

using SimulatorDPS.ClassesWoW;
using SimulatorDPS.Core.Gear;
using SimulatorDPS.Data;

namespace SimulatorDPS.DataBaseEF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions) : base(contextOptions)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}