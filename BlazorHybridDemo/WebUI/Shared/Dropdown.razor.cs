using Microsoft.AspNetCore.Components;

namespace BlazorHybridDemo.WebUI.Shared
{
    public partial class Dropdown
    {
        private bool _showMenu;

        [Parameter] public string Text { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
