namespace OneReview.Domain;

public class Review
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required Guid ProductId { get; init; } = Guid.NewGuid();
    public required int Rating { get; init; } = 0;
    public required string Text { get; init; } = "";
}