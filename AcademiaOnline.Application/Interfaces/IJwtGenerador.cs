using AcademiaOnline.Domain.Entities;

namespace AcademiaOnline.Application.Interfaces
{
    public interface IJwtGenerador
    {
        string CrearToken(TbUsuario usuario, List<string> roles);
    }
}
