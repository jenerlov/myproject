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
    public DbSet<ProductEntity> Products {get; set;}
    public DbSet<TagEntity> Tags {get; set;}
    public DbSet<ProductTagEntity> ProductTags {get; set;}
    public DbSet<ContactFormEntity> Messages {get; set;}



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

                builder.Entity<ProductEntity>().HasData(
                        new ProductEntity { ArticleNumber = "1000", ProductName = "NicePoster1", Ingress ="Very nice poster", Description="A very nice poster for your posterwall", ImageUrl = "https://images.pexels.com/photos/1037992/pexels-photo-1037992.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2", 
        Price = "1000",   },
            new ProductEntity
            {
                ArticleNumber = "1001",
                ProductName = "NicePoster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "",
                Price = "200",
                
            },
                
            new ProductEntity
            {
                ArticleNumber = "1001",
                ProductName = "Nice Poster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "",
                Price = "200",
                
            },
                
            new ProductEntity
            {
                ArticleNumber = "1002",
                ProductName = "Nice Poster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "",
                Price = "200",
                
            },
                
            new ProductEntity
            {
                ArticleNumber = "1003",
                ProductName = "Nice Poster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "",
                Price = "200",
                
            },
                
            new ProductEntity
            {
                ArticleNumber = "1004",
                ProductName = "Nice Poster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "",
                Price = "200",
                
            },
            new ProductEntity
            {
                ArticleNumber = "1005",
                ProductName = "Nice Poster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "",
                Price = "200",
                
            },
            new ProductEntity
            {
                ArticleNumber = "1006",
                ProductName = "Nice Poster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "",
                Price = "200",
                
            },
            new ProductEntity
            {
                ArticleNumber = "1007",
                ProductName = "Nice Poster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "",
                Price = "200",
                
            },
            new ProductEntity
            {
                ArticleNumber = "1008",
                ProductName = "Nice Poster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "https://images.pexels.com/photos/1037999/pexels-photo-1037999.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
                Price = "200",
                
            },
            new ProductEntity
            {
                ArticleNumber = "1009",
                ProductName = "Nice Poster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "https://images.pexels.com/photos/1037999/pexels-photo-1037999.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
                Price = "200",
                
            },
            new ProductEntity
            {
                ArticleNumber = "1010",
                ProductName = "Nice Poster1",
                Ingress = "Very nice poster",
                Description = "Poster for your posterwall",
                ImageUrl = "https://images.pexels.com/photos/1037999/pexels-photo-1037999.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2",
                Price = "200",
                
            }
                );

            
            builder.Entity<TagEntity>().HasData(
                new TagEntity { Id = 4, TagName = "New Posters"},
                // new TagEntity { Id = 5, TagName = "Featured headphones"},
                new TagEntity { Id = 5, TagName = "Popular Posters"}
            
            );

            builder.Entity<ProductTagEntity>().HasData(
                new ProductTagEntity { ArticleNumber = "1000", TagId = 4 },
                new ProductTagEntity { ArticleNumber = "1001", TagId = 4 },
                new ProductTagEntity { ArticleNumber = "1002", TagId = 4 },
                new ProductTagEntity { ArticleNumber = "1003", TagId = 4 },
                new ProductTagEntity { ArticleNumber = "1004", TagId = 4 },
                new ProductTagEntity { ArticleNumber = "1005", TagId = 4 },

                new ProductTagEntity { ArticleNumber = "1006", TagId = 5 },
                new ProductTagEntity { ArticleNumber = "1007", TagId = 5 },
                new ProductTagEntity { ArticleNumber = "1009", TagId = 5 },
                new ProductTagEntity { ArticleNumber = "1010", TagId = 5 }
            

            );


    }
}