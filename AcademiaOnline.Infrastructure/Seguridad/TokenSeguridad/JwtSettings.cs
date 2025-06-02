namespace AcademiaOnline.Infrastructure.Seguridad.TokenSeguridad
{
    public class JwtSettings
    {
        public string PrivateKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpireMinutes { get; set; } 
    }
}
