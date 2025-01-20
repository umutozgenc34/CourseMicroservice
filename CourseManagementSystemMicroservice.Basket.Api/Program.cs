using CourseManagementSystemMicroservice.Basket.Api;
using CourseManagementSystemMicroservice.Basket.Api.Baskets;
using CourseManagementSystemMicroservice.Basket.Api.Baskets.Services;
using CourseManagementSystemMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCommonServiceExtension(typeof(BasketAssembly));
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddScoped<BasketService>();
builder.Services.AddVersioningExtension();

var app = builder.Build();

app.AddBasketGroupEndpointExtension(app.AddVersionSetExtension());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();

