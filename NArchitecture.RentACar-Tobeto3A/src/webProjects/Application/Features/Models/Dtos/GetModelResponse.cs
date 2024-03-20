namespace Application.Features.Models.Dtos;

public class GetModelResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string BrandName { get; set; }
    public DateTime CreatedDate { get; set; }

}
