using ECommerce.Domain.Common;
using System;

namespace ECommerce.Domain.Entities
{
    public class Review : AuditableEntity
    {
        private Review(string reviewText, int rating, Guid productId, Guid customerId)
        {
            ReviewId = Guid.NewGuid();
            ReviewText = reviewText;
            Rating = rating;
            ProductId = productId;
            CustomerId = customerId;
        }

        public Guid ReviewId { get; private set; }
        public string ReviewText { get; private set; }
        public int Rating { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid CustomerId { get; private set; }

        public static Result<Review> Create(string reviewText, int rating, Guid productId, Guid customerId)
        {
            if (string.IsNullOrWhiteSpace(reviewText) || rating < 1 || rating > 5)
            {
                return Result<Review>.Failure("Invalid review data.");
            }
            return Result<Review>.Success(new Review(reviewText, rating, productId, customerId));
        }
    }
}