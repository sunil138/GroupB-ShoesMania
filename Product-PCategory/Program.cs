using Microsoft.EntityFrameworkCore;
using Product_PCategory.DataAccess;
using Product_PCategory.Repository;
using MediatR;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using JwtConfig;
//using JwtConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authintication using JWT",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http

    }

        );
    opt.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id="Bearer",
                    Type = ReferenceType.SecurityScheme
                }

            },
            new List<string>()
        }

    });


});

builder.Services.AddJwtConfiguration();

builder.Services.AddDbContext<ProductContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));
builder.Services.AddScoped<ICategory, CategoryRepo>();
builder.Services.AddMediatR(typeof(CategoryRepo).Assembly);
builder.Services.AddScoped<IProduct, ProductRepo>();
builder.Services.AddMediatR(typeof(ProductRepo).Assembly);
//Add Service for JSON-Serializer
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

//CORS implementation
builder.Services.AddCors(options =>
{
    options.AddPolicy("product", builde =>
    {
        builde.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("product");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
