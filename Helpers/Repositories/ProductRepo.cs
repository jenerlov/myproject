using myproject.Contexts;
using myproject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace myproject.Helpers.Repositories
{
    public class ProductRepo : GeneralRepo<ProductEntity>
    {
        private readonly DataContext _dataContext;
        public ProductRepo(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            var products = await _dataContext.Products
            .Include(p => p.Tags)
            .ThenInclude(p => p.Tag)
            .ToListAsync();

            return products;
        }
        public override async Task<IEnumerable<ProductEntity>> GetAllAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var products = await _dataContext.Products
                .Include(p => p.Tags)
                .ThenInclude(p => p.Tag)
                .Where(expression)
                .ToListAsync();

            return products;
        }
        public async Task<IEnumerable<ProductEntity>> GetAllByTagNameAsync(string tagName)
        {
            var products = await _dataContext.Products
                .Where(p => p.Tags.Any(t => t.Tag.TagName == tagName))
                .ToListAsync();

            return products;
        }
                public async override Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var product = await _dataContext.Products
                .Include(p => p.Tags)
                .ThenInclude(p => p.Tag)
                .FirstOrDefaultAsync(expression);

            return product!;
        }





    }
}