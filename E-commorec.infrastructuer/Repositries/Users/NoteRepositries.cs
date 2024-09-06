using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_commorec.infrastructuer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace E_commorec.infrastructuer.Repositries.Users
{
    public class NoteRepositries : GenericRepositries<Notes>, INote
    {
        private readonly AppDbContext context;
        private readonly IMemoryCache memoryCache;

        public NoteRepositries(AppDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            this.context = context;
            this.memoryCache = memoryCache;
        }

        public async Task<IReadOnlyList<Notes>> GetAllAsync(string email)
        {
            var getNoteFromMemory = memoryCache.TryGetValue("Notes", out IReadOnlyList<Notes>? notes);
            if (!getNoteFromMemory)
            {
                var Notes = await context.Notes.Where(m => m.EmailForWho == email).AsNoTracking().ToListAsync();
                memoryCache.Set("Notes", Notes);
                return Notes;
            }
            return notes;
        }
        public async Task<Notes> GetByIdAsync(string email, int id)
        {
            var MyNote = await context.Notes.AsNoTracking().FirstOrDefaultAsync(m => m.EmailForWho == email && m.Id == id);
            return MyNote;
        }
    }
}
