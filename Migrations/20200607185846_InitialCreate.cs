using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechMarket.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fullname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHashed = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LastLogin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<double>(nullable: false),
                    ProductImageUrl = table.Column<string>(nullable: true),
                    ProductInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productId = table.Column<int>(nullable: false),
                    productName = table.Column<string>(nullable: true),
                    productImageUrl = table.Column<string>(nullable: true),
                    productInformation = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    productPrice = table.Column<double>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderName = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: true),
                    CardName = table.Column<string>(nullable: true),
                    OrderTotal = table.Column<double>(nullable: false),
                    NumberOfItems = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ProductDetailId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ImgUrl1 = table.Column<string>(nullable: true),
                    ImgUrl2 = table.Column<string>(nullable: true),
                    ImgUrl3 = table.Column<string>(nullable: true),
                    OperatingSystem = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    Cpu = table.Column<string>(nullable: true),
                    CpuSpeed = table.Column<string>(nullable: true),
                    NumCores = table.Column<string>(nullable: true),
                    CacheType = table.Column<string>(nullable: true),
                    CacheSize = table.Column<string>(nullable: true),
                    ChipsetType = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    RamType = table.Column<string>(nullable: true),
                    RamSpeed = table.Column<string>(nullable: true),
                    RamSize = table.Column<string>(nullable: true),
                    DisplayTech = table.Column<string>(nullable: true),
                    DisplayResolution = table.Column<string>(nullable: true),
                    DisplaySize = table.Column<string>(nullable: true),
                    DisplayType = table.Column<string>(nullable: true),
                    GraphicName = table.Column<string>(nullable: true),
                    GraphicSize = table.Column<string>(nullable: true),
                    Webcam = table.Column<string>(nullable: true),
                    Sound = table.Column<string>(nullable: true),
                    AudioCodec = table.Column<string>(nullable: true),
                    HardDriveType = table.Column<string>(nullable: true),
                    HardDriveSize = table.Column<string>(nullable: true),
                    InputType = table.Column<string>(nullable: true),
                    WirelessProtocol = table.Column<string>(nullable: true),
                    WirelessController = table.Column<string>(nullable: true),
                    Bluetooth = table.Column<string>(nullable: true),
                    CardReaderType = table.Column<string>(nullable: true),
                    CardReaderSupport = table.Column<string>(nullable: true),
                    BatterySize = table.Column<string>(nullable: true),
                    BaterryCells = table.Column<string>(nullable: true),
                    Dimensions = table.Column<string>(nullable: true),
                    Mainboard = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Backlight = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.ProductDetailId);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(nullable: false),
                    ProductUrl = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SalePrice = table.Column<double>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.DetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "DateCreated", "Email", "Fullname", "LastLogin", "PasswordHashed", "PasswordSalt" },
                values: new object[] { 1, new DateTime(2020, 6, 7, 11, 58, 45, 923, DateTimeKind.Local).AddTicks(1970), "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JcaVYk4YsSSI82upROY4eCKiZX2hoTkYpDQdzsrPziI=", new byte[] { 129, 194, 226, 241, 99, 46, 164, 240, 115, 36, 96, 174, 4, 187, 104, 128 } });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductImageUrl", "ProductInformation", "ProductName", "ProductPrice" },
                values: new object[] { 1, "", "", "", 0.0 });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "ProductDetailId", "AudioCodec", "Backlight", "BaterryCells", "BatterySize", "Bluetooth", "CacheSize", "CacheType", "CardReaderSupport", "CardReaderType", "ChipsetType", "Cpu", "CpuSpeed", "Dimensions", "DisplayResolution", "DisplaySize", "DisplayTech", "DisplayType", "Features", "GraphicName", "GraphicSize", "HardDriveSize", "HardDriveType", "ImgUrl1", "ImgUrl2", "ImgUrl3", "InputType", "Mainboard", "Manufacturer", "Name", "NumCores", "OperatingSystem", "ProductId", "RamSize", "RamSpeed", "RamType", "Sound", "Webcam", "Weight", "WirelessController", "WirelessProtocol" },
                values: new object[] { 1, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", 1, "", null, "", "", "", "", "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerId",
                table: "Cart",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
