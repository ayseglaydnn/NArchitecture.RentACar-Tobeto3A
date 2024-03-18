
namespace Application.Features.Cars.Commands.SoftDelete;

public class SoftDeleteCarResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Plate { get; set; }
    public DateTime DeletedDate { get; set; }
}
