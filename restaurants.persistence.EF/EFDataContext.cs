using Microsoft.EntityFrameworkCore;
using News.Entitis.Categorys;
using News.Entitis.News;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.persistence.EF
{
    public class EFDataContext : DbContext
    {
        public DbSet<Newss> News { get; set; }
        public DbSet<Category> categories { get; set; }

        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly
                (typeof(EFDataContext).Assembly);
        }
    }
}
