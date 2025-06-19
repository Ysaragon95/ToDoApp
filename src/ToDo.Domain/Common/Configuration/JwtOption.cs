namespace ToDo.Domain.Common.Configuration
{
    public sealed class JwtOption
    {
        public const string SectionName = "JwtOptions";
        public string ValidIssuer { get; set; } = string.Empty;
        public string ValidAudience { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
    }
}
