using BL_Crud_Wasm_Net8.Data;
using BL_Crud_Wasm_Net8.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BL_Crud_Wasm_Net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VideoGameController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetAllVideoGames()
        {
            return await _context.VideoGames.ToListAsync();
        }
    }
}
