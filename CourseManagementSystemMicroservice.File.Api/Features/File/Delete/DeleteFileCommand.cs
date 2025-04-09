using CourseManagementSystemMicroservice.Shared;

namespace CourseManagementSystemMicroservice.File.Api.Features.File.Delete;

public record DeleteFileCommand(string FileName):IRequestByServiceResult;

