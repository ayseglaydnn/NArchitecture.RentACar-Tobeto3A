﻿namespace Application.Features.Cars.Commands.Update;

public class UpdateCarResponse
{
    public Guid Id { get; set; }
    public Guid ModelId { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }
    public double DailyPrice { get; set; }
}
