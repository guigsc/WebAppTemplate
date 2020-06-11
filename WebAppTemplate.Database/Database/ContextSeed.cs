using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAppTemplate.Database.Database
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.SeedUsers();
        }

        public static void SeedUsers(this ModelBuilder builder)
        {
            builder.Entity<UserEntity>(x =>
            {
                x.HasData(new
                {
                    Id = 1L,
                    Status = Status.Active
                });

                x.OwnsOne(y => y.FullName).HasData(new
                {
                    UserEntityId = 1L,
                    Name = "Administrator",
                    Surname = "Administrator"
                });
            });
        }
    }
}
