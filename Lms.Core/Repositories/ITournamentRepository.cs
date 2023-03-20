﻿using Lms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Core.Repositories
{
    public interface ITournamentRepository
    {
        public Task<IEnumerable<Tournament>> GetAllAsync();
        public Task<Tournament> GetAsync(int id);
        public Task<bool> AnyAsync(int id); 
        public void Add(Tournament tournament); 
        public void Update(Tournament tournament);
        public void Remove(Tournament tournament);

    }
}
