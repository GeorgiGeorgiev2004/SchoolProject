using CarDealership.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace CarDealership
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            using (CarDealershipContext context = new CarDealershipContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Dispose();
            }
            
        }
        
    }
}