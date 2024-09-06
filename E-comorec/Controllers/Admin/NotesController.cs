using AutoMapper;
using E_commorec.core.Entity;
using E_commorec.core.InterFace;
using E_comorec.API.Helper;
using Microsoft.AspNetCore.Mvc;

namespace E_comorec.API.Controllers.Admin
{
    public class NotesController : BaseAdminController
    {
        public NotesController(IUnitOfWork service, IMapper mapper) : base(service, mapper)
        {
        }

        [HttpGet("Get-All-Async")]
        public async Task<IActionResult> get()
        => Ok(await _service.note.GetAllAsync());

        [HttpGet("get-notes-for-person")]
        public async Task<IActionResult> get(string email)
        {
            var getNoteFromMemory = await _service.note.GetAllFromMemoryAsync("Notes");
            if (getNoteFromMemory == null)
            {
                await _service.note.AddToMemoryCache("Notes", getNoteFromMemory.ToList());
            }

            return Ok(value: getNoteFromMemory.Where(m => m.EmailForWho == email));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        [HttpPost("add-new-note")]
        public async Task<ActionResult> add([FromBody] Notes notes)
        {
            await _service.note.AddAsync(notes);
            await _service.note.DeleteFromMemoryCache("Notes");
            return Ok(new BaseResponse(200, "item-Added"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete-note/{id}")]
        public async Task<IActionResult> delete(int id)
        {
            await _service.note.DeleteFromMemoryCache("Note");
            await _service.note.DeleteAsync(id);
            return Ok(new BaseResponse(200, "item-Deleted"));

        }
    }
}
