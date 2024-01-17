namespace ECommerce.Client.Contracts
{
    public interface IWishlistDataService
    {
        Task<List<Guid>> GetWishlistAsync();
        Task<bool> AddToWishlistAsync(Guid productId);
        Task<bool> RemoveFromWishlistAsync(Guid productId);
    }


}
