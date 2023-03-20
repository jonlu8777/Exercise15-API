
using Lms.Core.Entities;
using Lms.Data.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Data
{
    public class SeedData
    {
        private static LmsAPIContext db = default!;
        //private static RoleManager<IdentityRole> roleManager = default!;
        //private static UserManager<ApplicationUser> userManager = default!;
        public static async Task InitAsync(LmsAPIContext context)
        {
            ArgumentNullException.ThrowIfNull(nameof(context));
            db = context;
            
            var game1 = new Game()
            {
                  Time= DateTime.Now,
                  Title= "game1"

            };
            var game2 = new Game()
            {
                Time = DateTime.Now,
                Title = "game2"

            };

            var tournamentA = new Tournament()
            {
                StartDate = DateTime.Now,
                Title = "tournamentA",
                Games = new List<Game>() {game1,game2 }
            };

            db.Add(game1);
            db.Add(game2);
            db.Add(tournamentA);
            await db.SaveChangesAsync();

        }

    
    }
}