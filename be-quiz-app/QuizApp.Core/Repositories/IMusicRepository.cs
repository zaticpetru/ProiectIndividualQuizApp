using QuizApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Core.Repositories
{
    public interface IMusicRepository : IRepository<Music>
    {
        Task<IEnumerable<Music>> GetAllWithArtistAsync();
        Task<Music> GetWithArtistByIdAsync(int id);
        Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artisId);
    }
}
