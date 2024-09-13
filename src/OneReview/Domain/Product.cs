namespace OneReview.Domain;

public class Product
{
    // the get and set and init are property accessors
    // and these attributes are properties
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Name { get; init; }
    public required string Category { get; init; }
    public required string Subcategory { get; init; }
}