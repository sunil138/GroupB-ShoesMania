//using Microsoft.EntityFrameworkCore;
//using Product_PCategory.DataAccess;
//using Product_PCategory.Models;
//using Product_PCategory.Models.DTO;

//namespace Product_PCategory.Repository
//{
//    public class ProductRepo:IProduct
//    {
//        private readonly ProductContext _context;

//        public ProductRepo(ProductContext context)
//        {
//            _context = context;
//        }

//        public string AddNewProduct(ProductRequestDto product)
//        {
//            Product addProduct= new Product();
//            addProduct.Name=product.Name; 
//            addProduct.Description=product.Description;
//            addProduct.Price=product.Price;
//            addProduct.CategoryId=product.CategoryId;

//            _context.Products.Add(addProduct);
//            _context.SaveChanges();
//            return "Added Succefully";
//        }

//        public string DeleteProduct(int id)
//        {
//            var getProductId = _context.Products.Find(id);
//            if (getProductId != null)
//            {
//                _context.Products.Remove(getProductId);
//                _context.SaveChanges();
//                return "deleted successfully";
//            }
//            else
//            {
//                return "Not found";
//            }
//        }

//        public List<Product> getAllProducts()
//        {
//            return _context.Products.Include(x=> x.Category).ToList();
//        }

//        public Product GetProductById(int id)
//        {
//            return _context.Products.Include(x => x.Category).FirstOrDefault(p => p.ProductId == id);
//        }

//        public string UpdateProduct(ProductRequestDto product)
//        {
//            var getProductId = _context.Products.Find(product.ProductId);
//            if (getProductId != null)
//            {
//                getProductId.Name = product.Name;
//                getProductId.Description = product.Description;
//                getProductId.CategoryId = product.CategoryId;
//                getProductId.Price = product.Price;
//                _context.SaveChanges();
//                return "update successfully";

//            }
//            else
//            {
//                return "cannot update the details.";
//            }
//        }
//    }
//}



using Microsoft.EntityFrameworkCore;
using Product_PCategory.DataAccess;
using Product_PCategory.Models;
using Product_PCategory.Models.DTO;
using System;

namespace Product_PCategory.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly ProductContext _context;

        public ProductRepo(ProductContext context)
        {
            _context = context;
        }

        public string AddNewProduct(ProductRequestDto product)
        {
            try
            {
                Product addProduct = new Product();
                addProduct.Name = product.Name;
                addProduct.Description = product.Description;
                addProduct.Price = product.Price;
                addProduct.CategoryId = product.CategoryId;

                _context.Products.Add(addProduct);
                _context.SaveChanges();
                return "Added Successfully";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public string DeleteProduct(int id)
        {
            try
            {
                var getProductId = _context.Products.Find(id);
                if (getProductId != null)
                {
                    _context.Products.Remove(getProductId);
                    _context.SaveChanges();
                    return "Deleted Successfully";
                }
                else
                {
                    return "Product Not Found";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public List<Product> getAllProducts()
        {
            try
            {
                return _context.Products.Include(x => x.Category).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public Product GetProductById(int id)
        {
            try
            {
                return _context.Products.Include(x => x.Category).FirstOrDefault(p => p.ProductId == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public string UpdateProduct(ProductRequestDto product)
        {
            try
            {
                var getProductId = _context.Products.Find(product.ProductId);
                if (getProductId != null)
                {
                    getProductId.Name = product.Name;
                    getProductId.Description = product.Description;
                    getProductId.CategoryId = product.CategoryId;
                    getProductId.Price = product.Price;
                    _context.SaveChanges();
                    return "Updated Successfully";
                }
                else
                {
                    return "Product Not Found";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
