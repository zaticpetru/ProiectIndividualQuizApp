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
    public class MusicRepository : Repository<Music>, IMusicRepository 
    {
        public MusicRepository(QuizAppDbContext context)
            : base(context) 
        { }

        private QuizAppDbContext quizAppDbContext
        {
            get { return context as QuizAppDbContext; }
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
        {
            return await quizAppDbContext.Musics
                .Include(m => m.Artist)
                .ToListAsync();
        }

        public async Task<Music> GetWithArtistByIdAsync(int id)
        {
            return await quizAppDbContext.Musics
                    .Include(m => m.Artist)
                    .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await quizAppDbContext.Musics
                    .Include(m => m.Artist)
                    .Where(m => m.ArtistId == artistId)
                    .ToListAsync();
        }
    }
}
