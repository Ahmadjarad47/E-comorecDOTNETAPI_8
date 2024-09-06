using E_commorec.core.DTO;
using E_commorec.core.Entity;

namespace E_commorec.core.InterFace
{
    public interface ISupport : IGenericRepositry<Support>
    {
        Task CreateResponseFromAdmin(SupportResponse support);
        Task WhenTheUserReadAsync(int id, string email);
        Task UpdateTheResponse(int id, string response);
        Task UpdateTheMessage(int id, string email, string message);
        Task<Support> getSupportByEmail(int id, string email);
        Task<List<Support>> getSupportsByEmail(string email);
    }
}
