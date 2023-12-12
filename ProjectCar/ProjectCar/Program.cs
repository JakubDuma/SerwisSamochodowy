using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectCar.Data;
using ProjectCar.Data.RepositoryRegistration;
using ProjectCar.Services.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProjectCarDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectCar"));
    options.EnableSensitiveDataLogging(false);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddService();
builder.Services.AddRepository();

builder.Services.AddAutoMapper(typeof(ServiceRegistration));

var app = builder.Build();

app.Services.GetRequiredService<IMapper>().ConfigurationProvider.AssertConfigurationIsValid();

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