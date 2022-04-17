using SharePaint.Services.Interfaces;

namespace SharePaint.API.Auth
{
    public class AuthorizationSettings : IAuthorizationSettings
    {
        public string Secret { get; set; }
    }
}
