using Lms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Repositories
{
    public interface IGameRepository
    {
        public Task<IEnumerable<Game>> GetAllAsync();
        public Task<Game> GetAsync(int id);
        public Task<bool> AnyAsync(int id);
        public void Add(Game game);
        public void Update(Game game);
        public void Remove(Game game);

    }
}
