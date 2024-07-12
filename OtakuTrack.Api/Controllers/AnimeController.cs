using Microsoft.AspNetCore.Mvc;
using OtakuTrack.Domain.DTOs;
using OtakuTrack.Services.Implementations;
using OtakuTrack.Services.Interfaces;
using OtakuTrack.Services.Interfaces.LogError;

namespace OtakuTrack.Api.Controllers
{
    [ApiController]
    [Route("api/animes")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _service;
        private readonly IErrorLogService _errorLog;
        public AnimeController(IAnimeService service, IErrorLogService errorLog)
        {
            _service = service;
            _errorLog = errorLog;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeDTO>> GetAnimeById(int id)
        {
            try
            {
                var anime = _service.GetAnimeByIdAsync(id);

                if (anime == null)
                {
                    return NotFound();
                }

                return Ok(anime);
            }
            catch (Exception ex)
            {
                await LogErrorAndHandleException(ex);
                return StatusCode(500, "Ocorreu um erro ao obter todos os animes.");
            }
        }
        [HttpGet]       
        public async Task<ActionResult<IEnumerable<AnimeDTO>>> GetAllAnimes()
        {
            try
            {
                var animes = await _service.GetAllAnimesAsync();

                return Ok(animes);
            }
            catch (Exception ex)
            {
                await LogErrorAndHandleException(ex);
                return StatusCode(500, "Ocorreu um erro ao obter todos os animes.");
            }
        }
        [HttpPost]        
        public async Task<ActionResult<AnimeDTO>> CreateAnime(CreateAnimeDTO animeCreateDto)
        {
            try
            {
                var createdAnime = await _service.CreateAnimeAsync(animeCreateDto);
                return CreatedAtAction(nameof(GetAnimeById), new { id = createdAnime.Id }, createdAnime);
            }
            catch (Exception ex)
            {
                await LogErrorAndHandleException(ex);
                return StatusCode(500, "Ocorreu um erro ao criar o anime.");
            }
        }

        [HttpPut("{id}")]        
        public async Task<ActionResult<AnimeDTO>> UpdateAnime(int id, UpdateAnimeDTO animeUpdateDto)
        {
            try
            {
                var updatedAnime = await _service.UpdateAnimeAsync(id, animeUpdateDto);
                if (updatedAnime == null)
                {
                    return NotFound();
                }
                return Ok(updatedAnime);
            }
            catch (Exception ex)
            {
                await LogErrorAndHandleException(ex);
                return StatusCode(500, "Ocorreu um erro ao atualizar o anime.");
            }
        }

        [HttpDelete("{id}")]        
        public async Task<ActionResult> DeleteAnime(int id)
        {
            try
            {
                var result = await _service.DeleteAnimeAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                await LogErrorAndHandleException(ex);
                return StatusCode(500, "Ocorreu um erro ao excluir o anime.");
            }
        }

        private async Task LogErrorAndHandleException(Exception ex)
        {
            await _errorLog.LogErrorAsync(ex.Message, ex.StackTrace);
        }
    }
}