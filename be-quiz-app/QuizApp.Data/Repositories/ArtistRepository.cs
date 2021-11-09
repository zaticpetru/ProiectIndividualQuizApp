using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Models;
using QuizApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {

        public ArtistRepository(QuizAppDbContext context)
            :base(context)
        { }

        private QuizAppDbContext quizAppDbContext
        {
            get { return context as QuizAppDbContext; }
        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
            return await quizAppDbContext.Artists
                    .Include(a => a.Musics)
                    .ToListAsync();
        }

        public Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return quizAppDbContext.Artists
                    .Include(a => a.Musics)
                    .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
