using InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Context
{
    public class InventoryContext: DbContext
    {
        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                 @"Server=DESKTOP-G99OQ90;Database=InventoryTable;Trusted_Connection=True;Encrypt=false");
        }
    }
}
