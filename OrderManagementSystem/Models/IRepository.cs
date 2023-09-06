using OrderManagementSystem.ViewModel;

namespace OrderManagementSystem.Models
{
    public interface IRepository
    {

        Task<int> AddProductAsync(ProductViewModel product);

        Task<Product[]> GetAllProductAsync();

        Task<ProductViewModel> GetProductAsync(int ProductId);

        Task<int> UpdateProductAsync(int productId, ProductViewModel product);

        Task<int> DeleteProductAsync(int productId);
    }
}
