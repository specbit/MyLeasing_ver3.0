using MyLeasing.Web.Data.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        /*  CRUD - Read   */
        public IEnumerable<Owner> GetOwners()
        {
            return (IEnumerable<Owner>)_context.Owners.OrderBy(p => p.FirstName);
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.Find(id);
        }

        /*  CRUD - Create   */
        public void AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
        }

        /*  CRUD - Update   */
        public void UpdateOwner(Owner owner)
        {
            _context.Owners.Update(owner);
        }

        /*  CRUD - Delete   */
        public void RemoveOwner(Owner owner)
        {
            _context.Owners.Remove(owner);
        }

        /*  Save Async to DB    */
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /*  Finds Existing Owner    */
        public bool OwnerExists(int id)
        {
            return _context.Owners.Any(p => p.Id == id);
        }
    }
}
