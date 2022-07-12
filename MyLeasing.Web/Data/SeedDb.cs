using MyLeasing.Web.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync() 
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Owners.Any())
            {
                AddOwner("Zé", "Boi");
                AddOwner("Maria", "Couta");
                AddOwner("Ester", "Feiosa");
                AddOwner("Keanu", "Reeves");
                AddOwner("Margot", "Robbie");
                AddOwner("Drácula", "Boi");
                AddOwner("Cinha", "Jardim");
                AddOwner("Tó", "Bacuro");
                AddOwner("Débora", "Secco");
                AddOwner("Charlize", "Theron");

                await _context.SaveChangesAsync();
            }
        }

        private void AddOwner(string name, string surname)
        {
            _context.Owners.Add(new Owner
            {
                Document = _random.Next(100000000).ToString(),
                FirstName = name,
                LastName = surname,
                FixedPhone = "92" + _random.Next(10000000).ToString(),
                CellPhone = "21" + _random.Next(10000000).ToString(),
            });

            //await _context.AddAsync();
        }
    }
}
