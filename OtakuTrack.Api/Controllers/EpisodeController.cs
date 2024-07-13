using Microsoft.AspNetCore.Mvc;
using OtakuTrack.Domain.DTOs;
using OtakuTrack.Services.Interfaces;

namespace OtakuTrack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;

        public EpisodeController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEpisodes()
        {
            var episodes = await _episodeService.GetAllEpisodesAsync();
            return Ok(episodes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEpisodeById(int id)
        {
            var episode = await _episodeService.GetEpisodeByIdAsync(id);
            if (episode == null)
            {
                return NotFound();
            }
            return Ok(episode);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEpisode([FromBody] CreateEpisodeDTO episodeDto)
        {
            var createdEpisode = await _episodeService.AddEpisodeAsync(episodeDto);
            return CreatedAtAction(nameof(GetEpisodeById), new { id = createdEpisode.Id }, createdEpisode);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEpisode(int id, [FromBody] UpdateEpisodeDTO episodeDto)
        {           

            var updatedEpisode = await _episodeService.UpdateEpisodeAsync(id, episodeDto);
            if (updatedEpisode == null)
            {
                return NotFound();
            }
            return Ok(updatedEpisode);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEpisode(int id)
        {
            var deleted = await _episodeService.DeleteEpisodeAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
