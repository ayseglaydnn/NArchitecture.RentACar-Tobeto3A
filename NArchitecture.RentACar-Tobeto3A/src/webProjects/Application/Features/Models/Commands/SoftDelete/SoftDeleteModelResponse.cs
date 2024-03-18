
namespace Application.Features.Models.Commands.SoftDelete;

public class SoftDeleteModelResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedDate { get; set; }
}
