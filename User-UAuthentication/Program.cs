using JwtConfig;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using User_UAuthentication.DataAccess;
using User_UAuthentication.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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


builder.Services.AddDbContext<UserUAuthContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")));

builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddMediatR(typeof(UserRepo).Assembly);
builder.Services.AddScoped<IAuth, AuthRepo>();
builder.Services.AddMediatR(typeof(AuthRepo).Assembly);

//calling for configuring in middleware
builder.Services.AddJwtConfiguration();

//CORS implementation
builder.Services.AddCors(options =>
{
    options.AddPolicy("user", builde =>
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
    

app.UseCors("user");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
