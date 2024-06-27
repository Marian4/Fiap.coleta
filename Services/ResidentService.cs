using Fiap.coleta.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.coleta.Data.Repository
{
    public class ResidentService : IResidentService
    {

        private readonly IResidentRepository _repository;
        public ResidentService(IResidentRepository repository) {
            _repository = repository;
        }        
        
        public void Add(ResidentModel resident)
        {
            _repository.Add(resident);
        }

        public IEnumerable<ResidentModel> findAll()
        {
            return _repository.findAll();
        }

        public ResidentModel findById(int id)
        {
            return _repository.findById(id);
        }

        public ResidentModel Remove(int id)
        {
            var resident = _repository.findById(id);

            if(resident != null) {
                _repository.Remove(resident);
            }
            return resident;

        }

        public void Update(ResidentModel resident)
        {
            _repository.Update(resident);
        }
    }
}