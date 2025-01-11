
namespace CourseManagementSystemMicroservice.Shared.Services;

public class IdentityServiceFake : IIdentityService
{
    public Guid GetUserId => Guid.NewGuid();

    public string UserName => "umutozgenc34";
}
