using Microsoft.EntityFrameworkCore;
using TransactionSample.Model;

namespace TransactionSample
{
    public class PeopleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=People;Trusted_Connection=True;");
        }

        public virtual DbSet<Person> People { get; set; }
    }
}