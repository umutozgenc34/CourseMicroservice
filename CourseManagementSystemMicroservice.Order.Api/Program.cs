using CourseManagementSystemMicroservice.Order.Application.Contracts.Repositories;
using CourseManagementSystemMicroservice.Order.Application.Contracts.UnitOfWorks;
using CourseManagementSystemMicroservice.Order.Persistence.Contexts;
using CourseManagementSystemMicroservice.Order.Persistence.Repositories;
using CourseManagementSystemMicroservice.Order.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

