using QuizApp.Core;
using QuizApp.Core.Repositories;
using QuizApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizAppDbContext _context;
        private MusicRepository _musicRepository;
        private ArtistRepository _artistRepository;

        public UnitOfWork(QuizAppDbContext context)
        {
            _context = context;
        }

        public IMusicRepository Musics =>
            _musicRepository ??= new MusicRepository(_context);
            //_musicRepository = _musicRepository ?? new MusicRepository(_context);
            // same as above

        public IArtistRepository Artists =>
            _artistRepository = _artistRepository ?? new ArtistRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
