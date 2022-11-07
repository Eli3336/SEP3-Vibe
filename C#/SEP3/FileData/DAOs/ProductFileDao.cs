using Shared;
using Shared.DTOs;
using ShopApplication.DaoInterfaces;

namespace FileData.DAOs;


    public class ProductFileDao : IProductDao
    {
        private readonly FileContext context;

        public ProductFileDao(FileContext context)
        {
            this.context = context;
        }
        // might be used later 
      /*  public Task<Product> CreateAsync(Product product)
        {
            int productId = 1;
            if (context.Products.Any())
            {
                productId = context.Products.Max(p => p.Id);
                productId++;
            }

            product.Id = productId;

            context.Products.Add(product);
            context.SaveChanges();

            return Task.FromResult(products);
        }
        */


      
/*
      public Task<Product?> GetByNameAsync(string name)
        {
            Product? existing = context.products.FirstOrDefault(p =>
                p.name.Equals(name, StringComparison.OrdinalIgnoreCase)
            );
            return Task.FromResult(existing);
        }

       
    // Revise method
    
        public Task<List<Product>> GetProductsAsync()
        {
        
            IEnumerable<Product> products = context.products.AsEnumerable();

            List<Product> productList = new List<Product>();

            foreach (Product product in products)
            {
                productList.Add(product);
            }

            return Task.FromResult(productList);
        }
*/

        public Task<IEnumerable<Product>> GetAsync(SearchProductsParametersDto searchProductsParametersDto)
        {

            IEnumerable<Product> products = context.products.AsEnumerable();

            if (searchProductsParametersDto.nameContains != null)
            {

                products = context.products.Where(p => p.name.Contains(searchProductsParametersDto.nameContains, StringComparison.OrdinalIgnoreCase));
                
                
            }

            return Task.FromResult(products);
        }
    
    }
