using Lms.Data;
using Lms.Data.Data;
namespace Lms.API.Extensions
{
  

        public static class ApplicationBuilderExtensions
        {
            public static async Task SeedDataAsync(this IApplicationBuilder app)
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;
                    var db = serviceProvider.GetRequiredService<LmsAPIContext>();


                    try
                    {
                        await SeedData.InitAsync(db);
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }

            }
        }




 }

