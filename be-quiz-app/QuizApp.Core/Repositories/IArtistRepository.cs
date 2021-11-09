using QuizApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Core.Repositories
{
    public interface IArtistRepository :IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithMusicAsync();
        Task<Artist> GetWithMusicsByIdAsync(int id);
    }
}
