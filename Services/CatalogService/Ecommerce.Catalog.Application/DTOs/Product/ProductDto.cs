namespace Ecommerce.Catalog.Application.DTOs.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? Brand { get; set; }
    public Guid? CategoryId { get; set; }
    public string? ProductType { get; set; }
    public decimal? CostPrice { get; set; } // The cost to acquire the product
    public decimal? SalePrice { get; set; } // A discounted price, if applicable
    public DateTime? SaleStartDate { get; set; } // Optional start date for a sale
    public DateTime? SaleEndDate { get; set; } // Optional end date for a sale
    public bool IsTaxable { get; set; } // Flag to indicate if taxes apply
    public Guid? TaxClassId { get; set; } // Foreign key to a tax class/rate

    // === Inventory & Stock ===
    public bool ManageStock { get; set; } = true; // Whether to track inventory for this product
    public bool IsAvailable { get; set; } // Overall availability, can be independent of stock
    public int? LowStockThreshold { get; set; } // Threshold for "low stock" warnings

    // === Shipping ===
    public bool IsShippable { get; set; } = true; // False for virtual or downloadable products[2]
    public decimal? Weight { get; set; } // Product weight for shipping calculations
    public decimal? Height { get; set; } // Product dimensions
    public decimal? Width { get; set; }
    public decimal? Length { get; set; }

    // === Product Variants & Attributes ===
    // For products with options like size or color[7]
    public Guid? ParentProductId { get; set; } // If this is a variant, links to the main (primary) product[6]
    public string? Attributes { get; set; } // JSON or serialized dictionary of attributes (e.g., {"Color": "Blue", "Size": "L"})[7]

    // === Media ===
    public string? MainImageUrl { get; set; } // URL for the primary product image
    public string? ImageGalleryUrls { get; set; } // JSON or comma-separated list of additional image URLs

    // === SEO (Search Engine Optimization) ===
    public string? MetaTitle { get; set; } // Custom title for browser tabs and search engine results
    public string? MetaKeywords { get; set; } // SEO keywords
    public string? MetaDescription { get; set; } // SEO description
    public string? UrlSlug { get; set; } // User-friendly URL (e.g., "blue-cotton-t-shirt")

    // === Status & Timestamps ===
    public bool IsPublished { get; set; } // Whether the product is visible on the storefront
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
