using Frontend_Inventario.Modelos;
using System.Threading.Tasks;

namespace Frontend_Inventario.Servicios
{
    public interface IAuthService
    {
        Task<LoginResponse?> Login(LoginRequest request);
        Task Logout();
    }
}
