using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Entities;

namespace Hospital_Management_System.Cores.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> Register(RegisterModelDto model);
        Task<AuthModel> Login(LoginModelDto model);
    }
}
