using CourseManagementSystemMicroservice.File.Api;
using CourseManagementSystemMicroservice.File.Api.Features.File;
using CourseManagementSystemMicroservice.Shared.Extensions;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

builder.Services.AddCommonServiceExtension(typeof(FileAssembly));
builder.Services.AddVersioningExtension();


var app = builder.Build();
app.AddFileGroupEndpointExt(app.AddVersionSetExtension());
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();