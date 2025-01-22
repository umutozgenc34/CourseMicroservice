
namespace CourseManagementSystemMicroservice.Shared.Services;

public class IdentityServiceFake : IIdentityService
{
    public Guid GetUserId => Guid.Parse("143ab6cd-f7f2-92fb-13a5-7fca265c2315");

    public string UserName => "umutozgenc34";
}
