using Fiap.coleta.Models;
namespace Fiap.coleta.Data.Repository
{
    public interface IResidentRepository {
        IEnumerable<ResidentModel> findAll(int page, int limit);
        ResidentModel findById(int id);
        void Add(ResidentModel resident);
        void Update(ResidentModel resident);
        void Remove(ResidentModel resident);
        int Count();
    }
}