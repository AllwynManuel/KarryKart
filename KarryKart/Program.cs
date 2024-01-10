using Authentication.Auth;
using Categorynamespace;
using Contracts.IServices;
using Entities.Data;
using Entities.Models.ProductClass;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Parentcategory;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(optionsAction: options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDb")));
builder.Services.AddDbContext<AppDbContext>(optionsAction: options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDb")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IParentCategory, ParentCategoryRepo>();
builder.Services.AddScoped<IManufactures, ManufacturerRepo>();
builder.Services.AddScoped<ICategory, CategoryRepo>();
builder.Services.AddScoped<IVendors, VendorRepo>();
builder.Services.AddScoped<ITax, TaxRepo>();
builder.Services.AddScoped<IDiscount, DiscountRepo>();
builder.Services.AddScoped<IProduct, ProductRepo>();
builder.Services.AddScoped<IShipping, ShippingRepo>();
builder.Services.AddScoped<IRental, RentalRepository>();
builder.Services.AddScoped<IRecurringProduct, RecurringProductRepo>();
builder.Services.AddScoped<IInventory, InventoryRepository >();
builder.Services.AddScoped<IGiftCard, GiftCardRepo>();
builder.Services.AddScoped<IDownload, DownloadRepos>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
