using Product_PCategory.Models;

namespace Product_PCategory.DataAccess
{
    public interface ICategory
    {
        public List<ProductCategory> GetAllCategories();

        public ProductCategory GetCategoryById(int id);

        public List<ProductCategory> GetCategoryByName(string name);

        public List<ProductCategory> GetCategoryBySubCategoryName(string name);

        public string AddNewCategory(ProductCategory newCategory);

        public string DeleteCategory(int id);

        public string UpdateCategory(ProductCategory newCategory);
    }
}
