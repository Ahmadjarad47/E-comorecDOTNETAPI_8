using E_commorec.core.Entity;

namespace E_commorec.core.InterFace
{
    public interface INote : IGenericRepositry<Notes>
    {
        Task<IReadOnlyList<Notes>> GetAllAsync(string email);
        Task<Notes> GetByIdAsync(string email, int id);
    }
}
