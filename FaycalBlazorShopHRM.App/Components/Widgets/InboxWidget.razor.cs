using Microsoft.AspNetCore.Components;

namespace FaycalBlazorShopHRM.App.Components.Widgets;

public partial class InboxWidget
{
    [Inject]
    private ApplicationState? ApplicationState { get; set; }

    public int MessageCount { get; set; } = 0;

    protected override void OnInitialized()
    {
        MessageCount = ApplicationState!.NumberOfMessages;
    }
}
