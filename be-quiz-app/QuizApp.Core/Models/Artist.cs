using System.Collections.ObjectModel;

namespace QuizApp.Core.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Music> Musics { get; set; }
        public Artist()
        {
            Musics = new Collection<Music>();
        }
    }
}