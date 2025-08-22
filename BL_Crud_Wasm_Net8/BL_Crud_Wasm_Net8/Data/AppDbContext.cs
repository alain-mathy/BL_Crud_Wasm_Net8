using BL_Crud_Wasm_Net8.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BL_Crud_Wasm_Net8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "T1",
                    Publisher = "P1",
                    ReleaseYear = 2000
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "T2",
                    Publisher = "P2",
                    ReleaseYear = 2010
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "T3",
                    Publisher = "P3",
                    ReleaseYear = 2020
                }
                );
        }
        public DbSet<VideoGame> VideoGames { get; set; }
    }
}
