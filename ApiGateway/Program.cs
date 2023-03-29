using JwtConfig;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//CORS implementation
builder.Services.AddCors(options =>
{
    options.AddPolicy("gatewayApi", builde =>
    {
        builde.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddJwtConfiguration();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseCors("gatewayApi");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
await app.UseOcelot();

app.Run();
