namespace ECommerce.Client.ViewModels;

public class CategoryViewModel
{
    public string CategoryName { get; set; }
    public string CategoryId { get; set; }

    public bool IsEditing { get; set; }
    public string EditedCategoryName { get; set; }

}