using MediatR;
using Microsoft.EntityFrameworkCore;
using Orders.DataAccess;
using Orders.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrdersDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));
builder.Services.AddScoped<IOrders, OrdersRepo>();
builder.Services.AddMediatR(typeof(OrdersRepo).Assembly);
//FOR-HTTP-COMMUNICATION
builder.Services.AddHttpClient();

//CORS implementation
builder.Services.AddCors(options =>
{
    options.AddPolicy("orders", builde =>
    {
        builde.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

//Add Service for JSON-Serializer
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("orders");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
