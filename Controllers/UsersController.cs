using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TechMarket.Data;
using TechMarket.Dtos;
using TechMarket.Model;
using TechMarket_website.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;

namespace TechMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly DataContext _dataContext;

        public UsersController(IUserRepository repo, DataContext context)
        {
            _repo = repo;
            _dataContext = context;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            // take user from database who has customerId  = {id}
            var user = await _repo.getProfile(id);
            return Ok(user);
        }

        [HttpGet("{id}/addresses")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var user = await _repo.getAddress(id);
            return Ok(user);
        }

        [HttpGet("{id}/cart")]
        public async Task<IActionResult> GetCart(int id)
        {
            var cart = await _dataContext.Cart.Where(x => x.CustomerId == id).ToListAsync();
            return Ok(cart);
        }

        [HttpPost("{id}/savecart")]
        public async Task<IActionResult> SaveCart(int id, List<CartToSave> CartData)
        {
            //remove cart to update new cart
            foreach (var e in _dataContext.Cart.Where(x => x.CustomerId == id))
            {
                _dataContext.Cart.Remove(e);
            }
            await _dataContext.SaveChangesAsync();
            foreach (var item in CartData)
            {
                var itemTosave = new Cart();
                itemTosave.CustomerId = id;
                itemTosave.productId = item.productId;
                itemTosave.productName = item.productName;
                itemTosave.productInformation = item.productInformation;
                itemTosave.productImageUrl = item.productImageUrl;
                itemTosave.quantity = item.quantity;
                itemTosave.productPrice = item.productPrice;
                await _dataContext.Cart.AddAsync(itemTosave);
            }
            await _dataContext.SaveChangesAsync();
            return Ok("save successful");
        }




        [HttpGet("{id}/ordershistory")]
        public async Task<IActionResult> GetOrdersHistory(int id)
        {
            var history = await _repo.GetOrderHistory(id);
            return Ok(history);
        }

        [HttpPost("{id}/lastlogin")]
        public async Task<IActionResult> LastLogin(int id)
        {
            var user = await _repo.getProfile(id);
            user.LastLogin = DateTime.Now;
            _repo.SaveAllChange();
            return Ok("last login saved");
        }

    }    
}