using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Repositories
{
    public interface IUnitOfWork
    {
       public ITournamentRepository TournamentRepository { get; }
        public IGameRepository GameRepository { get; }
        public Task CompleteAsync();

    }
}
