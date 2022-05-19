using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.SupportMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<DataInitializer>();
builder.Services.AddTransient<IDTOreturner, DTOreturner>();
builder.Services.AddTransient<IMathHelpers, MathHelpers>();
builder.Services.AddTransient<IDbObjectMethods, DbObjectMethods>();
builder.Services.AddTransient<IDBErrorHandlers, DBErrorHandlers>();




var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetService<DataInitializer>().SeedData();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
