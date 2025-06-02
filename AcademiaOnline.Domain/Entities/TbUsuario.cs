

using Microsoft.AspNetCore.Identity;

namespace AcademiaOnline.Domain.Entities
{

    public class TbUsuario : IdentityUser
    {
        public string NombreCompleto { get; set; } = string.Empty;
    }
}
