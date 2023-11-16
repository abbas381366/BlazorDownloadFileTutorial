namespace BlazorApp31;

public class DownloadTokenService
{
    public List<DownloadToken> DownloadTokens { get; set; } = new();
    public class DownloadToken
    {
        public Guid Guid { get; set; }
        public Stream Stream { get; set; }
        public string FakeName { get; set; }
    }
}
