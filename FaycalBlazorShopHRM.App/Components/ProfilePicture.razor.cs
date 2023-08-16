using Microsoft.AspNetCore.Components;

namespace FaycalBlazorShopHRM.App.Components;

public partial class ProfilePicture
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
