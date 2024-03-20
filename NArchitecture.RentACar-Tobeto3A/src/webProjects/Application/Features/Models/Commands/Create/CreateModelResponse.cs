namespace Application.Features.Models.Commands.Create;

public class CreateModelResponse
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Name { get; set; }
}
