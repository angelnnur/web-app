using System.Linq;
using WebApplication_v._1._1.Models;

namespace WebApplication_v._1._1.Domain.Repositories.Abstract
{
    public interface ISotrudnikiRepository
    {
        IQueryable<Сотрудники> GetSotrudniki();
        Сотрудники GetSotrudnikiById(int id);
        void SaveSotrudniki(Сотрудники entity);
        void DeleteSotrudniki(int id);
    }
}
