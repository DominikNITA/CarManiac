using CarManiac.Server.Models;
using CarManiac.Shared;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManiac.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<CarData> CarsData { get; set; }
        public DbSet<EngineData> EnginesData { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarType> CarType { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CarData>().Property(carData => carData.Nicknames).HasConversion(cd => JsonConvert.SerializeObject(cd), cd => JsonConvert.DeserializeObject<List<string>>(cd));
            builder.Entity<CarData>().Property(carData => carData.Images).HasConversion(cd => JsonConvert.SerializeObject(cd), cd => JsonConvert.DeserializeObject<List<string>>(cd));
            builder.Entity<CarData>().Property(carData => carData.YearsOfProduction).HasConversion(cd => JsonConvert.SerializeObject(cd), cd => JsonConvert.DeserializeObject<List<int>>(cd));
            //builder.Entity<CarData>().HasKey(e => new { e.FullName });
            //builder.Entity<EngineData>().HasKey(e => new { e.FullName });
            //builder.Entity<CarBrand>().HasKey(e => new { e.Name });
            //builder.Entity<CarType>().HasKey(e => new { e.Name });
            builder.Entity<CarBrand>().HasMany(b => b.Cars).WithOne(c => c.Brand);
            builder.Entity<CarType>().HasMany(b => b.Cars).WithOne(c => c.Type);

            base.OnModelCreating(builder);
        }
    }
}
