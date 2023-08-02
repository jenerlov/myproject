using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myproject.Models.Entities;
namespace myproject.Contexts;

public class DataContext : IdentityDbContext<UserEntity>
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
        
    }

    public DbSet<AddressEntity> Addresses {get; set;} = null!;
    public DbSet<UserAddressEntity> UserAddresses {get; set;} = null!;
    // public DbSet<ProductEntity> Products {get; set;}
    // public DbSet<ContactFormEntity> Messages {get; set;}



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var adminRoleId = Guid.NewGuid().ToString();

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole {
                Id = adminRoleId, 
                Name = "Admin", 
                NormalizedName = "ADMIN", 
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                },

            new IdentityRole {
                Id = Guid.NewGuid().ToString(), 
                Name = "User", 
                NormalizedName = "USER", 
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                
            });

            var passwordHasher = new PasswordHasher<UserEntity>();
            var userEntity = new UserEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin@domain.com",
                    NormalizedUserName = "ADMIN@DOMAIN.COM",
                    Email = "admin@domain.com",
                    NormalizedEmail = "ADMIN@DOMAIN.COM",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                };
                
                userEntity.PasswordHash = passwordHasher.HashPassword(userEntity, "Bytlosen123!");
                builder.Entity<UserEntity>().HasData(userEntity);


                builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                {
                    UserId = userEntity.Id,
                    RoleId = Guid.NewGuid().ToString(),
                });
    }
}