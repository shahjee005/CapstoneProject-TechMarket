using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TechMarket.Model;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace TechMarket.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedCustomers(this ModelBuilder modelBuilder)
        {
            byte[] salted = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salted);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: "password",
                salt: salted,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));


            _ = modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    Fullname = "",
                    Email = "",
                    PasswordHashed = hashed,
                    PasswordSalt = salted,
                    DateCreated = DateTime.Now            
                
               
                }
            );
        }     
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                   ProductId = 1,
                    ProductName = "",
                    ProductPrice = 0 ,
                    ProductImageUrl = "",
                    ProductInformation = "", 
                } 
               
            );
        }
        public static void SeedProductDetails(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDetails>().HasData(
                new ProductDetails
                {
                    ProductDetailId = 1,
                    Name = "",
                    ProductId=1,
                    ImgUrl1= "",
                    ImgUrl2= "",
                    ImgUrl3= "",
                    OperatingSystem= "",
                    Manufacturer= "",
                    Cpu= "",
                    CpuSpeed= "",
                    NumCores= "",
                    ChipsetType= "",
                    CacheSize= "",
                    CacheType= "",
                    Features= "",
                    RamType= "",
                    RamSize= "",
                    DisplayTech= "",
                    DisplayResolution= "",
                    DisplaySize= "",
                    DisplayType= "",
                    GraphicName= "",
                    GraphicSize="",
                    Webcam="",
                    Sound= "",
                    AudioCodec= "",
                    HardDriveType="",
                    HardDriveSize="",
                    InputType= "",
                    WirelessProtocol= "",
                    WirelessController= "",
                    Bluetooth="",
                    CardReaderType= "",
                    CardReaderSupport= "",
                    BatterySize= "",
                    BaterryCells= "",
                    Dimensions= "",
                    Mainboard= "",
                    Weight= "",
                    Backlight="" 
                }
               
            );
        }
    }
}
