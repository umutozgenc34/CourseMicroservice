using CourseManagementSystemMicroservice.File.Api;
using CourseManagementSystemMicroservice.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCommonServiceExtension(typeof(FileAssembly));
builder.Services.AddVersioningExtension();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();