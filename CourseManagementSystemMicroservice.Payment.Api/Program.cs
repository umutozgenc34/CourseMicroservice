using CourseManagementSystemMicroservice.Payment.Api;
using CourseManagementSystemMicroservice.Payment.Api.Features.Payment;
using CourseManagementSystemMicroservice.Payment.Api.Repositories;
using CourseManagementSystemMicroservice.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCommonServiceExtension(typeof(PaymentAssembly));
builder.Services.AddVersioningExtension();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseInMemoryDatabase("payment-inmemory-db");
});

var app = builder.Build();

app.AddPaymentGroupEndpointExt(app.AddVersionSetExtension());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

