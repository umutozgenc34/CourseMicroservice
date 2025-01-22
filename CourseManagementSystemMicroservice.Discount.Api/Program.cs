using CourseManagementSystemMicroservice.Discount.Api;
using CourseManagementSystemMicroservice.Discount.Api.Options;
using CourseManagementSystemMicroservice.Discount.Api.Repositories;
using CourseManagementSystemMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabaseServiceExtensions();
builder.Services.AddOptionExtensions();

builder.Services.AddVersioningExtension();
builder.Services.AddCommonServiceExtension(typeof(DiscountAssembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

