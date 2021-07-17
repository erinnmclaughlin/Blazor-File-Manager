using Microsoft.AspNetCore.Components;

namespace BlazorHybridDemo.WebUI.Shared.Windows
{
    public partial class File : ComponentBase
    {
        [Parameter] public string FileName { get; set; }

        private string FileNameText => FileName.Substring(FileName.LastIndexOf("\\") + 1);

        public void OpenFile()
        {
            System.Diagnostics.Process.Start("cmd.exe", $"/c {FileName}");
        }
    }
}
