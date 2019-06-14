using Microsoft.EntityFrameworkCore;


namespace SimpleGlossary.Models{

    public class DataContext:DbContext    {
        public DataContext(DbContextOptions<DataContext> opts)
            :base(opts){ }
        public DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
