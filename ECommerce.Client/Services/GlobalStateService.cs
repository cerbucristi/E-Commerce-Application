namespace ECommerce.Client.Services;

public class GlobalStateService
{ 
    private int? SavedCartCount { get; set; }
    public int CartCountProperty

    {
        get => SavedCartCount ?? 0;
        set
        {
            SavedCartCount = value;
            NotifyStateChanged();
        }
    }

    private int _wishlistCount;
    public int WishlistCountProperty
    {
        get { return _wishlistCount; }
        set
        {
            _wishlistCount = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}