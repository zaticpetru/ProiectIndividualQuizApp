using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Resources;
using QuizApp.Api.Validators;
using QuizApp.Core.Models;
using QuizApp.Core.Servicies;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicsController(
            IMusicService musicService,
            IMapper mapper
            )
        {
            _musicService = musicService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MusicDTO>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllWithArtist();
            var musicDTOs = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicDTO>>(musics);

            return Ok(musicDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicDTO>> GetMusicById(int id)
        {
            var music = await _musicService.GetMusicByIdWithArtist(id);
            var musicDTO = _mapper.Map<MusicDTO>(music);

            return Ok(musicDTO);
        }

        [HttpPost("")]
        public async Task<ActionResult<MusicDTO>> CreateMusic([FromBody] SaveMusicDTO saveMusicDTO)
        {
            var validator = new SaveMusicDTOValidator();
            var validationResult = await validator.ValidateAsync(saveMusicDTO);

            if(!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var musicToCreate = _mapper.Map<SaveMusicDTO, Music>(saveMusicDTO);
            var newMusic = await _musicService.CreateMusic(musicToCreate);
            var music = await _musicService.GetMusicByIdWithArtist(newMusic.Id);

            var musicDTO = _mapper.Map<Music, MusicDTO>(music);

            return Ok(musicDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MusicDTO>> UpdateMusic(int id, [FromBody] SaveMusicDTO saveMusicDTO)
        {
            var validator = new SaveMusicDTOValidator();
            var validationResult = await validator.ValidateAsync(saveMusicDTO);
            var requestIsInvalid = id <= 0 || !validationResult.IsValid;
            if(requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var musicToBeUpdated = await _musicService.GetMusicById(id);
            if (musicToBeUpdated == null)
                return NotFound();

            var newMusic = _mapper.Map<SaveMusicDTO, Music>(saveMusicDTO);
            await _musicService.UpdateMusic(musicToBeUpdated, newMusic);

            var updatedMusic = await _musicService.GetMusicByIdWithArtist(id);
            var updatedMusicDTO = _mapper.Map<Music, MusicDTO>(updatedMusic);
            return Ok(updatedMusicDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusic(int id)
        {
            if (id <= 0)
                return BadRequest();

            var music = await _musicService.GetMusicById(id);
            if (music == null)
                return NotFound();

            await _musicService.DeleteMusic(music);
            return NoContent();
        }
    }
}
