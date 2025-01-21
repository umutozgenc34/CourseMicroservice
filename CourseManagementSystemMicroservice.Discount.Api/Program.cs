using CourseManagementSystemMicroservice.Discount.Api;
using CourseManagementSystemMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddVersioningExtension();
builder.Services.AddCommonServiceExtension(typeof(DiscountAssembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

