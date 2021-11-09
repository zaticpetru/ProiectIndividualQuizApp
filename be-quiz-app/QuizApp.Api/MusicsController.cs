using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Resources;
using QuizApp.Core.Models;
using QuizApp.Core.Servicies;

namespace QuizApp.Api
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
    }
}
