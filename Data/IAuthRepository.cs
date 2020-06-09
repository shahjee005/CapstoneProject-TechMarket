using System.Threading.Tasks;
using TechMarket.Dtos;
using TechMarket.Model;

namespace TechMarket_website.Data
{
    public interface IAuthRepository
    {
         Task<Customer> Register(CustomerToRegister customerToRegister);
         Task<Customer>GetCustomer(string email);
         Task<bool> UserExists(string email);
    }
}