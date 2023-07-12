//using Tranzact.Premium.Application.Contracts.Identity;
using Tranzact.Premium.Domain;
using Tranzact.Premium.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Tranzact.Premium.Persistence.DatabaseContext
{
    public class PremiumDatabaseContext : DbContext
    {
        public PremiumDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        //private readonly IUserService _userService;

        //public PremumDatabaseContext(DbContextOptions<PremumDatabaseContext> options, IUserService userService) : base(options)
        //{
        //    this._userService = userService;
        //}

        public DbSet<Carrier> Carrier { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<PremiumData> PremiumData { get; set; }
        public DbSet<PremiumDataPlan> PremiumDataPlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PremiumDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PremiumDataPlan>()
            .HasKey(o => new { o.PremiumDataId, o.PlanId });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseAuditableEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.LastModified = DateTime.Now;
                //entry.Entity.LastModifiedBy = _userService.UserId;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Created = DateTime.Now;
                    //entry.Entity.CreatedBy = _userService.UserId;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
