using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Security.Encryption;
using Business.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService,ProductManager>();
builder.Services.AddSingleton<IProductDal,EfProductDal>();
builder.Services.AddSingleton<ICategoryService,CategoryManager>();
builder.Services.AddSingleton<ICategoryDal,EfCategoryDal>();
builder.Services.AddSingleton<ICustomerService,CustomerManager>();  
builder.Services.AddSingleton<ICustomerDal,EfCustomerDal>();
builder.Services.AddSingleton<IOrderService,OrderManager>();
builder.Services.AddSingleton<IOrderDal,EfOrderDal>();
builder.Services.AddSingleton<IEmployeeService,EmployeeManager>();
builder.Services.AddSingleton<IEmployeeDal,EfEmployeeDal>();
builder.Services.AddSingleton<IUserDal,EfUserDal>();
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IAuthService,AuthManager>();
builder.Services.AddSingleton<ITokenHelper,JwtHelper>();
builder.Services.AddEndpointsApiExplorer();
var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
