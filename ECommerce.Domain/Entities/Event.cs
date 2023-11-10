using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities
{
    public class Event : AuditableEntity
    {
        private Event(string eventName, int price, DateTime eventDate)
        {
            EventId = Guid.NewGuid();
            EventName = eventName;
            Price = price;
            EventDate = eventDate;
        }
        public Guid EventId { get; private set; }
        public string EventName { get; private set; } = string.Empty;
        public int Price { get; private set; }
        public string? Artist { get; private set; }
        public DateTime EventDate { get; private set; }
        public string? Description { get; private set; }
        public string? ImageUrl { get; private set; }

        public static Result<Event> Create(string eventName, int price, DateTime eventDate)
        {
            if (string.IsNullOrWhiteSpace(eventName))
            {
                return Result<Event>.Failure("Event Name is required.");
            }
            if (price <= 0)
            {
                return Result<Event>.Failure("Price must be greater than zero.");
            }
            if (eventDate == DateTime.MinValue)
            {
                return Result<Event>.Failure("Event Date is required.");
            }
            return Result<Event>.Success(new Event(eventName, price, eventDate));
        }
        public Guid CategoryId { get; private set; }


        public void AttachArtist(string artist)
        {
            if (!string.IsNullOrWhiteSpace(artist)) 
            {
                Artist = artist;
            }
        }
        public void AttachDescription(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                Description = description;
            }
        }

        public void AttachImageUrl(string imageUrl)
        {
            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                ImageUrl = imageUrl;
            }
        }

        public void AttachCategory(Guid categoryId) 
        {
            if (categoryId != Guid.Empty)
            {
                CategoryId = categoryId;
            }
        }

    }
}