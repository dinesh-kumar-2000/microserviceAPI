namespace Ecommerce.Catalog.Application.DTOs.Product;

public class PagedResultDto<T>
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public List<T> Items { get; set; } = new();
}
