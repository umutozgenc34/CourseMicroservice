using CourseManagementSystemMicroservice.Shared;

namespace CourseManagementSystemMicroservice.File.Api.Features.File.Upload;

public record UploadFileCommand(IFormFile File) : IRequestByServiceResult<UploadFileCommandResponse>;
