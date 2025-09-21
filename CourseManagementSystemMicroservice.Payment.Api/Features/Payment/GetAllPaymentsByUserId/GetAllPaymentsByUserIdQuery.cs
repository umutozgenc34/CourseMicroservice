using CourseManagementSystemMicroservice.Shared;

namespace CourseManagementSystemMicroservice.Payment.Api.Features.Payment.GetAllPaymentsByUserId;

public record GetAllPaymentsByUserIdQuery : IRequestByServiceResult<List<GetAllPaymentsByUserIdResponse>>;

