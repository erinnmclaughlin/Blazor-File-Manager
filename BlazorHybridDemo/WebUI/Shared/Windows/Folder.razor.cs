using Microsoft.AspNetCore.Components;

namespace BlazorHybridDemo.WebUI.Shared.Windows
{
    public partial class Folder
    {
        [CascadingParameter] public FileManager FileManager { get; set; }

        [Parameter] public string FolderPath { get; set; }

        private string FolderPathText => FolderPath.Length > 23 ? $"{FolderPath.Substring(0, 20)}..." : FolderPath;

        private void HandleClick()
        {
            FileManager.Directory = FolderPath;
        }

        private string GetCss()
        {
            return $"color: {FileManager.ThemeColor}; background-color: {FileManager.ThemeColorLight}; border: 1px solid {FileManager.ThemeColor};";
        }
    }
}
