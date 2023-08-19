using Microsoft.AspNetCore.Components;

namespace FaycalBlazorShopHRM.App.Components;

public partial class InboxCounter
{
    private int MessageCount;

    [Inject]
    private ApplicationState? ApplicationState { get; set; }

    protected override void OnInitialized()
    {
        MessageCount = new Random().Next(10);
        ApplicationState!.NumberOfMessages = MessageCount;
    }
}
