using CourseManagementSystemMicroservice.Catalog.Api;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses;
using CourseManagementSystemMicroservice.Catalog.Api.Options;
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;
using CourseManagementSystemMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseServiceExtensions();
builder.Services.AddCommonServiceExtension(typeof(CatalogAssembly));
builder.Services.AddOptionExtensions();

var app = builder.Build();

app.AddSeedDataExtension().ContinueWith(x => // uygulama hýzlý ayaða kalksýn diye await yok
{
    Console.WriteLine(x.IsFaulted ? x.Exception?.Message : "Seed data has been saved successfully");
});

app.AddCategoryGroupEndpointExtension();
app.AddCourseGroupEndpointExtension();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();


