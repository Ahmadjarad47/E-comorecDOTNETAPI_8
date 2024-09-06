using E_commorec.core.DTO;
using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_commorec.infrastructuer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace E_commorec.infrastructuer.Repositries.Users
{
    public class supportRepositries : GenericRepositries<Support>, ISupport
    {
        private readonly AppDbContext context;

        public supportRepositries(AppDbContext context, IMemoryCache memoryCache) : base(context, memoryCache)
        {
            this.context = context;
        }

        public async Task<List<Support>> getSupportsByEmail(string email)
        => await context.Support.AsNoTracking().Where(m => m.WhoSendMessage == email).ToListAsync();
        public async Task<Support> getSupportByEmail(int id, string email)
     => await context.Support.AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id && m.WhoSendMessage == email);
        public async Task CreateResponseFromAdmin(SupportResponse support)
        {
            var sup = await context.Support.FirstOrDefaultAsync(m => m.Id == support.Id);
            if (sup != null)
            {
                sup.TheResponse = support.TheResponse;
                sup.WhenResponsed = DateTime.Now;
                sup.WhoReponsed = support.WhoReponsed;
                context.Update(sup);
                await context.SaveChangesAsync();

            }
            return;
        }
        public async Task WhenTheUserReadAsync(int id, string email)
        {
            var sup = await context.Support.FirstOrDefaultAsync(i => i.Id == id && i.WhoSendMessage == email);
            sup.ReadTheResponsed = true;
            context.Update(sup);
            await context.SaveChangesAsync();
        }
        public async Task UpdateTheResponse(int id, string response)
        {
            var sup = await context.Support.FirstOrDefaultAsync(i => i.Id == id);
            sup.TheResponse = response;
            sup.ReadTheResponsed = false;
            sup.WhenResponsed = DateTime.Now;
            context.Update(sup);
            await context.SaveChangesAsync();
        }
        public async Task UpdateTheMessage(int id, string email, string message)
        {
            var sup = await context.Support.FirstOrDefaultAsync(i => i.Id == id && i.WhoSendMessage == email);
            sup.TheMessage = message;
            sup.ReadTheResponsed = false;
            sup.WhenResponsed = DateTime.Now;
            context.Update(sup);
            await context.SaveChangesAsync();
        }
    }
}
