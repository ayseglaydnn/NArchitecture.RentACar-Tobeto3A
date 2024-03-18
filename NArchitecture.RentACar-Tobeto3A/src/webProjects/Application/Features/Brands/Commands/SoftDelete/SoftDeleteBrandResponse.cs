
namespace Application.Features.Brands.Commands.SoftDelete;

public class SoftDeleteBrandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DeletedDate { get; set; }
}
