using application.Interfaces;
using application.Services;
using domain.Interfaces;
using infrastructure.Adapters;
using infrastructure.models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreSampleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conexionSql")));
builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddScoped<ICustomerDomain, CustomerAdapter>();
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddScoped<IOrderDomain, OrderAdapter>();
builder.Services.AddScoped<IShipperDomain, ShipperAdapter>();
builder.Services.AddScoped<IShipper, ShipperService>();
builder.Services.AddScoped<IEmployeeDomain, EmployeeAdapter>();
builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<IProductDomain, ProductAdapter>();
builder.Services.AddScoped<IProduct, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
