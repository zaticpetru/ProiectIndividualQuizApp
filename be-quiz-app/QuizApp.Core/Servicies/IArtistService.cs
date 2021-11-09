using QuizApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Core.Servicies
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllArtistis();
        Task<Artist> GetArtistById(int id);
        Task<Artist> CreateArtist(Artist newArtist);
        Task UpdateArtist(Artist artistToBeUpdated, Artist artist);
        Task DeleteArtist(Artist artist);
    }
}
