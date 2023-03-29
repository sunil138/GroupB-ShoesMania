using Product_PCategory.Models;
using Product_PCategory.Models.DTO;

namespace Product_PCategory.DataAccess
{
    public interface IProduct
    {
        public List<Product> getAllProducts();

        public string AddNewProduct(ProductRequestDto product);

        public string DeleteProduct(int id);

        public Product GetProductById(int id);

        public string UpdateProduct(ProductRequestDto product);
    }
}
