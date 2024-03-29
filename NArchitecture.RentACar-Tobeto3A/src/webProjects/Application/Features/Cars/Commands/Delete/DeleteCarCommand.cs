﻿using MediatR;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommand : IRequest<DeleteCarResponse>
{
    public Guid Id { get; set; }
}
