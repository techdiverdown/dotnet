using OneReview.Domain;

namespace OneReview.Services;

public class ReviewsService
{
    private static readonly List<Review> ReviewsRepository = [];

    public void Create(Review review)
    {
        // todo: ensure product exists
        ReviewsRepository.Add(review);
    }

    public Review? Get(Guid productId, Guid reviewId)
    {
        // todo: ensure product exists
        return ReviewsRepository.Find(x => x.Id == reviewId);
    }

    internal IReadOnlyList<Review> List(Guid productId)
    {
        // todo: ensure product exists
        return ReviewsRepository
            .Where(x => x.ProductId == productId)
            .ToList();
    }
}