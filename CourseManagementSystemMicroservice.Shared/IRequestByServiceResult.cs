using MediatR;

namespace CourseManagementSystemMicroservice.Shared;

public interface IRequestByServiceResult<T> : IRequest<ServiceResult<T>>;
public interface IRequestByServiceResult : IRequest<ServiceResult>;

