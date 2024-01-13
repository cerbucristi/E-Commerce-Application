namespace ECommerce.Client.ViewModels;

public class CategoryViewModel
{
    public string CategoryName { get; set; }
    public Guid CategoryId { get; set; }

    public bool IsEditing { get; set; }
    public string EditedCategoryName { get; set; }

}