using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Data;
using Hasan_Ayman_Hasan_ELbadry_3025312__Holistic_MS_.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<ApplicationDbContext>(x => x
    .UseSqlServer(builder.Configuration
    .GetConnectionString("Default")));

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<IBranchRepository, BranchRepository>();

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
