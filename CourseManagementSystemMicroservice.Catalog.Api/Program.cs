using CourseManagementSystemMicroservice.Catalog.Api;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Categories.Create;
using CourseManagementSystemMicroservice.Catalog.Api.Features.Courses;
using CourseManagementSystemMicroservice.Catalog.Api.Options;
using CourseManagementSystemMicroservice.Catalog.Api.Repositories;
using CourseManagementSystemMicroservice.Shared.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseServiceExtensions();
builder.Services.AddCommonServiceExtension(typeof(CatalogAssembly));
builder.Services.AddOptionExtensions();

var app = builder.Build();

app.AddCategoryGroupEndpointExtension();
app.AddCourseGroupEndpointExtension();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();


