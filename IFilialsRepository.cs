using System.Linq;
using WebApplication_v._1._1.Models;

namespace WebApplication_v._1._1.Repositories.Abstract
{
    public interface IFilialsRepository
    {
        IQueryable<Филиалы> GetFilials();
        Филиалы GetFilialById(int id);
        void SaveFilial(Филиалы entity);
        void DeleteFilial(int id);
    }
}
