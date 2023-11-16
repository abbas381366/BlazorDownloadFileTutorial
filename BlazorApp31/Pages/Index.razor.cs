using Microsoft.AspNetCore.Components;
using static BlazorApp31.DownloadTokenService;

namespace BlazorApp31.Pages;

public partial class Index
{
    [Inject] public DownloadTokenService DownloadTokenService { get; set; }
    [Inject] public NavigationManager NV{ get; set; }
    const string FilePath = @"C:\Users\abbas\Downloads\SubtitleEdit-4.0.1-Setup.zip";
    async Task DownloadFile()
    {
        DownloadToken token = new DownloadToken();
        token.Stream = new MemoryStream( await File.ReadAllBytesAsync(FilePath));
        token.FakeName = "CodeeasyMS.zip";
        token.Guid = Guid.NewGuid();
        DownloadTokenService.DownloadTokens.Add(token);
        NV.NavigateTo("Download?id="+token.Guid,true);
    }
}