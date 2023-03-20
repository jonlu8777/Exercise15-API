using Lms.Core.Entities;
using Lms.Core.Repositories;
using Lms.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        LmsAPIContext db;
        public TournamentRepository(LmsAPIContext context) 
        {
            db = context;
        
        }

       public async Task<IEnumerable<Tournament>> GetAllAsync() 
        {
            return await db.Tournament.ToListAsync();
        }
        public async Task<Tournament> GetAsync(int id)
        {
            ArgumentNullException.ThrowIfNull(id, nameof(id));
            return await db.Tournament.FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<bool> AnyAsync(int id)
        { 
         return await db.Tournament.AnyAsync(m => m.Id == id);
        }
       public void Add(Tournament tournament)
        {
        db.Add(tournament);
        }
       public void Update(Tournament tournament)
        { 
         db.Update(tournament);
        }
       public void Remove(Tournament tournament)
        { 
        db.Remove(tournament);
        }

    }
}
