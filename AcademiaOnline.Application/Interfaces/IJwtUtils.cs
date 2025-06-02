namespace AcademiaOnline.Application.Interfaces
{
    public interface IJwtUtils
    {
        string GenerateToken(string userId, string fullName, string userName, string email, List<string> roles);
    }
}
