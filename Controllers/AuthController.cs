using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TechMarket.Data;
using TechMarket.Dtos;
using TechMarket.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Buffers.Text;
using TechMarket_website.Data;

namespace TechMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        // private DataContext _dataContext;
        private ApplicationSettings _appsetting;

        public AuthController(IAuthRepository repo, IOptions<ApplicationSettings> appsetting)
        {
            _repo = repo;
            _appsetting = appsetting.Value;
        }

        // api/Auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register(CustomerToRegister customerToRegister)
        {
            // lowercase email
            customerToRegister.Email.ToLower();
            // check if email already in database 
            // if (await _dataContext.Customer.AnyAsync(xxx => xxx.Email == customerToRegister.Email))
            if (await _repo.UserExists(customerToRegister.Email))
                return BadRequest(new { message = "This Email is already registered" });
            // Register user if email is not existed 
            else
            {
               
                var newCustomer = _repo.Register(customerToRegister);
                return StatusCode(201);
            }
        }

        // api/Auth/login        
        [HttpPost("login")]
        public async Task<IActionResult> Login(CustomerToLogin customerToLogin)
        {
            // lowercase email
            var lowercaseEmail = customerToLogin.Email.ToLower();
            // find email in database
            // if (await _dataContext.Customer.AnyAsync(xxx => xxx.Email == customerToLogin.Email))
            // If user exits 
            if (await _repo.UserExists(lowercaseEmail))
            {
                // take customer from database
                var user = await _repo.GetCustomer(customerToLogin.Email);
                // decrypt user pass from database             
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                      password: customerToLogin.Password,
                      salt: user.PasswordSalt,
                      prf: KeyDerivationPrf.HMACSHA1,
                      iterationCount: 10000,
                      numBytesRequested: 256 / 8));
                // compare 2 hashed passwords
                if (hashed != user.PasswordHashed)
                    return BadRequest(new { message = "Wrong Password!" });
                else // create token & response to client
                {
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim("CustomerId", user.CustomerId.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appsetting.JWT_Secret)),
                            SecurityAlgorithms.HmacSha256Signature)
                    };
                    // store last login for user is now.
                    //user.LastLogin = DateTime.Now;
                    // store user into database

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var sercurityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(sercurityToken);
                    return Ok(new { token });
                }
            }
            else return BadRequest(new { message = "This email is not registered" });
        }



    }
}