using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppTemplate.Database.Database
{
    public sealed class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddConfigurationsFromAssembly();
            builder.Seed();
        }
    }
}
