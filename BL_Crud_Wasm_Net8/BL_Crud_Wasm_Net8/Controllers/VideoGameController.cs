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

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetGameById(int id)
        {
            var result = await _context.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            if(result is null)
            {
                return NotFound("Game not found");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VideoGame>> DeleteGame(int id)
        {
            var result = await _context.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
            {
                return NotFound("Game not found");
            }

            _context.VideoGames.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VideoGame>> UpdateGame(int id, VideoGame game)
        {
            var result = await _context.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null)
            {
                return NotFound("Game not found");
            }

            result.Title = game.Title;
            result.Publisher = game.Publisher;
            result.ReleaseYear = game.ReleaseYear;

            await _context.SaveChangesAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddGame(VideoGame game)
        {
            _context.VideoGames.Add(game);
            await _context.SaveChangesAsync();

            return Ok(game);
        }
    }
}
