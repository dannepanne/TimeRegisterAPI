using Microsoft.EntityFrameworkCore;
using TimeRegisterAPI.Data;
using TimeRegisterAPI.Infrastructure.DTOReturners;
using TimeRegisterAPI.Infrastructure.Profiles;
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
builder.Services.AddTransient<ICustomerDTOReturner, CustomerDTOReturner>();
builder.Services.AddTransient<IProjectDTOReturner, ProjectDTOReturner>();
builder.Services.AddTransient<ITimeRegDTOReturner, TimeRegDTOReturner>();
builder.Services.AddTransient<IMathHelpers, MathHelpers>();
builder.Services.AddTransient<IDbObjectMethods, DbObjectMethods>();
builder.Services.AddTransient<IDBErrorHandlers, DBErrorHandlers>();
builder.Services.AddAutoMapper(typeof(CustomerProfile));


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
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();