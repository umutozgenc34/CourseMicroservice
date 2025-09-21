﻿using CourseManagementSystemMicroservice.Payment.Api.Repositories;

namespace CourseManagementSystemMicroservice.Payment.Api.Features.Payment.GetAllPaymentsByUserId;

public record GetAllPaymentsByUserIdResponse(Guid Id, string OrderCode,string Amount,DateTime Created,PaymentStatus Status);

