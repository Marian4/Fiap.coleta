using Fiap.coleta.Models;
namespace Fiap.coleta.Data.Repository
{
    public interface IResidentService {
        IEnumerable<ResidentModel> findAll();
        ResidentModel findById(int id);
        void Add(ResidentModel resident);
        void Update(ResidentModel resident);
        ResidentModel Remove(int id);
    }
}