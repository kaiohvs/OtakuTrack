using Microsoft.AspNetCore.Mvc;
using OtakuTrack.Domain.DTOs;
using OtakuTrack.Services.Interfaces;

namespace OtakuTrack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _service;

        public GenreController(IGenreService genreService)
        {
            _service = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _service.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenreById(int id)
        {
            var genre = await _service.GetGenreByIdAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(genre);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreDTO genreDto)
        {
            var createdGenre = await _service.AddGenreAsync(genreDto);
            return CreatedAtAction(nameof(GetGenreById), new { id = createdGenre.Id }, createdGenre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, [FromBody] UpdateGenreDTO genreDto)
        {           

            var updatedgenre = await _service.UpdateGenreAsync(id, genreDto);
            if (updatedgenre == null)
            {
                return NotFound();
            }
            return Ok(updatedgenre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var deleted = await _service.DeleteGenreAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
