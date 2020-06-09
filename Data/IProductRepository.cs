using System.Collections.Generic;
using System.Threading.Tasks;
using TechMarket.Data;
using TechMarket.Model;
using Microsoft.AspNetCore.Mvc;

namespace TechMarket_website.Data
{
    public interface IProductRepository
    {
        public List<Products>  GetAllProduct();
         public Task<Products> GetOneProduct(int id);
         public Task<ProductDetails>GetProductDetail(int id);
    }
}