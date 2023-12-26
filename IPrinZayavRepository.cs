using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_v._1._1.Models;

namespace WebApplication_v._1._1.Domain.Repositories.Abstract
{
    public interface IPrinZayavRepository
    {
        IQueryable<Принятые_заявления> GetPrinZayav();
        Принятые_заявления GetPrinZayavById(int id);
        void SavePrinZayav(Принятые_заявления entity);
        void DeletePrinZayav(int id);
    }
}
