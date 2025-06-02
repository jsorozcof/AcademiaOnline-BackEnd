using AcademiaOnline.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AcademiaOnline.Infrastructure.Seguridad.TokenSeguridad
{
    public class UsuarioSesion : IUsuarioSesion
    {
        public readonly IHttpContextAccessor _httpContextAccessor;
        public UsuarioSesion(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string ObtenerUsuarioSesion()
        {
            var userName = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return userName;
        }
    }
}
