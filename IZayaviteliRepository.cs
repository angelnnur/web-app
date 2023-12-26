using System.Linq;
using WebApplication_v._1._1.Models;

namespace WebApplication_v._1._1.Repositories.Abstract
{
    public interface IZayaviteliRepository
    {
        IQueryable<Заявители> GetZayaviteli();
        Заявители GetZayaviteliById(int id);
        void SaveZayaviteli(Заявители entity);
        void DeleteZayaviteli(int id);
    }
}
