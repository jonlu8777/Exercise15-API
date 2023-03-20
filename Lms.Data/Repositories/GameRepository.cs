using Lms.Core.Entities;
using Lms.Core.Repositories;
using Lms.Data.Data;
using Microsoft.EntityFrameworkCore;


namespace Lms.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        LmsAPIContext db;
        public GameRepository(LmsAPIContext context)
        {
            db = context;

        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await db.Game.ToListAsync();
        }
        public async Task<Game> GetAsync(int id)
        {
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            return await db.Game.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<bool> AnyAsync(int id)
        {
            return await db.Game.AnyAsync(m => m.Id == id);
        }
        public void Add(Game game)
        {
            db.Add(game);
        }
        public void Update(Game game)
        {
            db.Update(game);
        }
        public void Remove(Game game)
        {
            db.Remove(game);
        }
    }
}
