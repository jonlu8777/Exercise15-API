using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lms.Data.Data;
using Lms.Core.Entities;
using Lms.Core.Repositories;

namespace Lms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly LmsAPIContext _context;
        private readonly IUnitOfWork uow;

        public TournamentsController(IUnitOfWork uow) //LmsAPIContext context
        {
            this.uow = uow;
            //_context = context;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
        {

            //if (uow.TournamentRepository == null)
            //{
            //    return NotFound();
            //}
               var tournaments = await uow.TournamentRepository.GetAllAsync();

            if(tournaments == null)
            {
                return NotFound();
            }
            return tournaments.ToList();
            //if (_context.Tournament == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Tournament.ToListAsync();
        }

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournaments = await uow.TournamentRepository.GetAsync(id);

            if (tournaments == null)
            {
                return NotFound();
            }
            return tournaments;
            //if (_context.Tournament == null)
            //{
            //    return NotFound();
            //}
            //  var tournament = await _context.Tournament.FindAsync(id);

            //  if (tournament == null)
            //  {
            //      return NotFound();
            //  }

            //  return tournament;
        }

        // PUT: api/Tournaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, Tournament tournament)
        {

            if (id != tournament.Id)
            {
                return BadRequest();
            } 

            try
            {
                uow.TournamentRepository.Update(tournament);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!TournamentExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
                throw;
            }

            return NoContent();


            //if (id != tournament.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(tournament).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TournamentExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/Tournaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tournament>> PostTournament(Tournament tournament)
        {
            if (await uow.TournamentRepository.GetAllAsync() == null)
            {
                return Problem("Entity set 'LmsAPIContext.Tournament'  is null.");
            }
            uow.TournamentRepository.Add(tournament);
            await _context.SaveChangesAsync();                                                      // SAVECHANGES ASNYC ????

            return CreatedAtAction("GetTournament", new { id = tournament.Id }, tournament);
            //if (_context.Tournament == null)
            //{
            //    return Problem("Entity set 'LmsAPIContext.Tournament'  is null.");
            //}
            //  _context.Tournament.Add(tournament);
            //  await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetTournament", new { id = tournament.Id }, tournament);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {

            if (await uow.TournamentRepository.AnyAsync(id) == false)
            {
                return NotFound();
            }
            var tournament = await uow.TournamentRepository.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            uow.TournamentRepository.Remove(tournament);
            await _context.SaveChangesAsync();                           //SAVE CHANGESS ASYNC kvar??

            return NoContent();
            //if (_context.Tournament == null)
            //{
            //    return NotFound();
            //}
            //var tournament = await _context.Tournament.FindAsync(id);
            //if (tournament == null)
            //{
            //    return NotFound();
            //}

            //_context.Tournament.Remove(tournament);
            //await _context.SaveChangesAsync();

            //return NoContent();
        }

        private async Task<bool> TournamentExists(int id)
        {
            
            return await uow.TournamentRepository.AnyAsync(id);
           //return (_context.Tournament?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
