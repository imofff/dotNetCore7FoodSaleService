using Microsoft.EntityFrameworkCore;
using FoodSaleApiService.Entities;
using FoodSaleApiService.Repositories;
using FoodSaleApiService.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options =>
    {
        // Disables SSL verification (not recommended for production)
        Microsoft.Data.SqlClient.SqlConnection.ClearAllPools();

        options.UseSqlServer(connectionString);
    });
builder.Services.AddControllers();
builder.Services.AddScoped<IFoodSaleRepository, FoodSaleRepository>();
// builder.Services.AddSingleton<ApplicationContext>();
builder.Services.AddScoped<ApplicationContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("FoodSaleOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("FoodSaleOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
