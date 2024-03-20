namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarResponse
{
    public Guid Id { get; set; }
    public string Plate { get; set; }
    public DateTime DeletedDate { get; set; }
}
