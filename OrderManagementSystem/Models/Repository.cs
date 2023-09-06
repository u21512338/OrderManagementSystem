using System;
using System.Linq;
using System.Threading.Tasks;
using OrderManagementSystem.ViewModel;
using Microsoft.EntityFrameworkCore;


namespace OrderManagementSystem.Models
{
    public class Repository : IRepository
    {

        private readonly AppDbContext _DbContext;

        public Repository(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<Product[]> GetAllProductAsync()
        {
            IQueryable<Product> query = _DbContext.Products;
            return await query.ToArrayAsync();
        }

        public async Task<ProductViewModel> GetProductAsync(int ProductId)
        {
            ProductViewModel product = new ProductViewModel();

            Product query = await _DbContext.Products.Where(x => x.ProductID == ProductId).FirstOrDefaultAsync();

            if (query == null)
            {
                product.response = 404;
            }
            else
            {
                product.ProductID = query.ProductID;
                product.ProductName = query.ProductName;
                product.Description = query.Description;
                product.Price = query.Price;
                product.Quantity = query.Quantity;
                product.response = 200;
            }
            return product;

        }


        public async Task<int> AddProductAsync(ProductViewModel product)
        {
            int code = 200;
            try
            {
                Product ProductAdd = new Product();
                ProductAdd.ProductName = product.ProductName;
                ProductAdd.Description = product.Description;
                ProductAdd.Price = product.Price;
                ProductAdd.Quantity = product.Quantity;
                await _DbContext.Products.AddAsync(ProductAdd);
                await _DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                code = 500;
            }
            return code;
        }

        public async Task<int> UpdateProductAsync(int productId, ProductViewModel product)
        {
            int code = 200;
            //Find the object in the db 
            Product attemptToFindInDb = await _DbContext.Products.Where(x => x.ProductID == productId).FirstOrDefaultAsync();
            if (attemptToFindInDb == null)
            {
                code = 404;
            }
            else
            {
                attemptToFindInDb.ProductName = product.ProductName;
                attemptToFindInDb.Description = product.Description;
                attemptToFindInDb.Price = product.Price;
                attemptToFindInDb.Quantity = product.Quantity;
                _DbContext.Products.Update(attemptToFindInDb);
                await _DbContext.SaveChangesAsync();
            }
            return code;
        }

        public async Task<int> DeleteProductAsync(int productId)
        {
            int code = 200;

            //Find the object in the db 
            Product attemptToFindInDb = await _DbContext.Products.Where(x => x.ProductID == productId).FirstOrDefaultAsync();

            if (attemptToFindInDb == null)
            {
                code = 404;
            }
            else
            {
                _DbContext.Products.Remove(attemptToFindInDb);
                await _DbContext.SaveChangesAsync();
            }
            return code;
        }




    }
}
