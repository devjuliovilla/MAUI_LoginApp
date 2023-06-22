using LoginApp2.models;

namespace LoginApp2.services
{
    public interface ILoginService
    {
        string HelloWorld(LoginRequest request);
        Task<LoginResponse> Login(LoginRequest request);
    }
}
