using BlazorHybridDemo.Helpers;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BlazorHybridDemo.WebUI.Shared.Windows
{
    public partial class FileManager : ComponentBase
    {
        public string ThemeColor { get; set; }
        public string ThemeColorLight { get; set; }

        private List<string> Folders { get; set; }
        private List<string> Files { get; set; }

        private string _directory = "C:\\";
        public string Directory
        {
            get => _directory;
            set
            {
                _directory = value;
                LoadDirectory();
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                SetTheme();
                LoadDirectory();
            }

            base.OnAfterRender(firstRender);
        }

        private void GoTo(string path)
        {
            if (!IsDirectory(path))
                Directory = Directory.Substring(0, Directory.LastIndexOf(path) + path.Length + 1);
        }

        private bool IsDirectory(string path)
        {
            var result = path == Directory || path + '\\' == Directory;
            return result;
        }

        private void LoadDirectory()
        {
            Folders = System.IO.Directory.GetDirectories(_directory).Where(x => !new DirectoryInfo(x).Attributes.HasFlag(FileAttributes.Hidden)).ToList();
            Files = System.IO.Directory.GetFiles(_directory).ToList();
            StateHasChanged();
        }

        public void OpenCommandPrompt()
        {
            new System.Diagnostics.Process()
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WorkingDirectory = Directory,
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                    FileName = "cmd.exe",
                    UseShellExecute = false
                }
            }.Start();
        }

        private void OpenFileExplorer()
        {
            System.Diagnostics.Process.Start("explorer.exe", Directory);
        }

        private void SetTheme()
        {
            var themeColor = SystemThemeHelper.GetThemeColor();
            ThemeColor = themeColor.ToHex();
            ThemeColorLight = themeColor.AddLuminosity(0.5f).ToHex();
        }        
    }
}
