using Fiap.coleta.Models;
namespace Fiap.coleta.Data.Repository
{
    public interface IResidentRepository {
        IEnumerable<ResidentModel> findAll();
        ResidentModel findById(int id);
        void Add(ResidentModel resident);
        void Update(ResidentModel resident);
        void Remove(ResidentModel resident);
    }
}