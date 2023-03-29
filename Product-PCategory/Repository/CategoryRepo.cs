using Product_PCategory.DataAccess;
using Product_PCategory.Models;

namespace Product_PCategory.Repository
{
    public class CategoryRepo : ICategory
    {
        private readonly ProductContext _context;

        public CategoryRepo(ProductContext context)
        {
            _context= context;
        }
        public string AddNewCategory(ProductCategory newCategory)
        {
            var checkCategoryPresent = _context.ProductsCategory.FirstOrDefault(o => o.SubCategory == newCategory.SubCategory);
           
            if(checkCategoryPresent==null)
            {
                _context.ProductsCategory.Add(newCategory);
                _context.SaveChanges();
                return "succefully added";

            }
            return "Category already present";

        }

        public string DeleteCategory(int id)
        {
            var getCategoryId = _context.ProductsCategory.Find(id);
            if (getCategoryId != null)
            {
                _context.ProductsCategory.Remove(getCategoryId);
                _context.SaveChanges();
                return "deleted successfully";
            }
            else
            {
                return "Not found";
            }
        }

        public List<ProductCategory> GetAllCategories()
        {
            return _context.ProductsCategory.ToList();
        }

        public ProductCategory GetCategoryById(int id)
        {
            return _context.ProductsCategory.FirstOrDefault(o => o.CategoryId == id);
        }

        public List<ProductCategory> GetCategoryByName(string name)
        {
            var categoryByName =  _context.ProductsCategory.Where(o=>o.Category==name).ToList();
            return categoryByName;
        }

        public List<ProductCategory> GetCategoryBySubCategoryName(string name)
        {
            var categoryByName = _context.ProductsCategory.Where(o => o.SubCategory == name).ToList();
            return categoryByName;
        }

        public string UpdateCategory(ProductCategory newCategory)
        {
            var getCategoryId = _context.ProductsCategory.Find(newCategory.CategoryId);
            if (getCategoryId != null)
            {
                getCategoryId.Category = newCategory.Category;
                getCategoryId.SubCategory = newCategory.SubCategory;
                
                _context.SaveChanges();
                return "updated succefully";

            }
            else
            {
                return "Not found";
            }
        }
    }
}
