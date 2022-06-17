using DanskeBank.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DanskeBank.DAL.Context
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //adding configuration while create the table
            builder.ApplyConfiguration(new RuleSetEntityConfig());
            builder.ApplyConfiguration(new RuleEntityConfig());
        }
        public DbSet<RuleSet> RuleSets { get; set; }
        public DbSet<Rule> Rules { get; set; }
    }
}
