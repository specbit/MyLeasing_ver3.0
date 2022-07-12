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
                Document = _random.Next(10000000, 100000000).ToString(),    //Returns a 8 lenght int
                FirstName = name,
                LastName = surname,
                FixedPhone = "92" + _random.Next(10000000, 100000000).ToString(),
                CellPhone = "21" + _random.Next(10000000, 100000000).ToString(),
                Address = "Rua " + GenerateRandStr(),
            });

            //await _context.AddAsync();
        }

        private string GenerateRandStr()
        {
            // Creating object of random class
            Random rand = new Random();

            // Choosing the size of string
            // Using Next() string
            int stringlen = rand.Next(4, 10);
            int randValue;
            string str = "";
            char letter;

            for (int i = 0; i < stringlen; i++)
            {

                // Generating a random number.
                randValue = rand.Next(0, 26);

                // Generating random character by converting
                // the random number into character.
                letter = Convert.ToChar(randValue + 65);

                // Appending the letter to string.
                str = str + letter;
            }

            return str;
        }
    }
}
