using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovaCore.Common.Application.Helpers;
using NovaCore.Common.Core.Base;
using NovaCore.Service.Almacen.Core.Entities;

namespace NovaCore.Service.Almacen.Infrastructure
{
    public class AlmacenDbContext : DbContext
    {
        private readonly DateTimeHelper _helper = new DateTimeHelper();

        public AlmacenDbContext(
                DbContextOptions<AlmacenDbContext> options
                ) : base(options)
        {
        }
        //dbSet
        public DbSet<Test> ProcesoCatalogos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            ModelConfig(modelBuilder);
        }
        private void ModelConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().ToTable("Tests");

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _helper.DateTimePst();
                        entry.Entity.Modified = _helper.DateTimePst();
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = _helper.DateTimePst();
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}