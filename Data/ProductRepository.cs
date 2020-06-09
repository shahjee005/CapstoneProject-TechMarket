using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMarket.Data;
using TechMarket.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TechMarket_website.Data
{
    public class ProductRepository : IProductRepository
    {
         private readonly DataContext _dataContext;
        public ProductRepository(DataContext context)
        {
            _dataContext = context;
        }
        public List<Products>  GetAllProduct()
        {
            return _dataContext.Products.ToList();
        }

        public async Task<Products> GetOneProduct(int id)
        {
            // Fetch product based on id 
            var product = await _dataContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            return product;
        }

        public async Task<ProductDetails> GetProductDetail(int id)
        {
            var detail = await _dataContext.ProductDetails.FirstOrDefaultAsync(x => x.ProductId == id);
            return detail;
        }
    }
}