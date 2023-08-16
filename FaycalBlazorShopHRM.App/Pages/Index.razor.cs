using FaycalBlazorShopHRM.App.Components.Widgets;

namespace FaycalBlazorShopHRM.App.Pages;

public partial class Index
{
    public List<Type> Widgets { get; set; } = new List<Type>() { typeof(EmployeeCountWidget), typeof(InboxWidget) };

}
