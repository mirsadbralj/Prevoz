using Microsoft.EntityFrameworkCore;

namespace Prevoz.WebAPI.Database
{
    public class Data
    {
        public static void Seed(PrevozContext context)
        {
            context.Database.Migrate();
        }
    }
}
