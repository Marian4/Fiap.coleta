using Fiap.coleta.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.coleta.Data.Repository
{
    public class ResidentRepository : IResidentRepository
    {

        private readonly DatabaseContext _databaseContext;
        public ResidentRepository(DatabaseContext databaseContext) {
            _databaseContext = databaseContext;
        }        
        
        public void Add(ResidentModel resident)
        {
            _databaseContext.Residents.Add(resident);
            _databaseContext.SaveChanges();
        }

        public IEnumerable<ResidentModel> findAll()
        {
            return _databaseContext.Residents.Include(r => r.Address).ToList();
        }

        public ResidentModel findById(int id)
        {
            var residents = _databaseContext.Residents.Include(r => r.Address).ToList();
            return residents.Where(r => r.id == id).FirstOrDefault();
        }

        public void Remove(ResidentModel resident)
        {
            _databaseContext.Residents.Remove(resident);
            _databaseContext.SaveChanges();
        }

        public void Update(ResidentModel resident)
        {
            _databaseContext.Residents.Update(resident);
            _databaseContext.SaveChanges();
        }
    }
}