﻿namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedDate { get; set; }
}
