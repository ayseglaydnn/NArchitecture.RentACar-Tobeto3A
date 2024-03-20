namespace Application.Features.Models.Commands.Delete;

public class DeleteModelResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedDate { get; set; }
}
