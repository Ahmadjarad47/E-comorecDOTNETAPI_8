using E_commorec.core.Entity;

namespace E_commorec.core.Services
{
    public interface IGenerateTokenService
    {
        Task<string> GetAndCreateToken(AppUsers token);

    }
}
