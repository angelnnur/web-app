using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_v._1._1.Domain.Repositories.Abstract;
using WebApplication_v._1._1.Models;

namespace WebApplication_v._1._1.Domain.Repositories.EntityFramework
{
    public class EFPrinZayavRepository : IPrinZayavRepository
    {
        private readonly DBContext context;
        public EFPrinZayavRepository(DBContext context)
        {
            this.context = context;
        }

        public IQueryable<Принятые_заявления> GetPrinZayav()
        {
            return context.Принятые_заявленияs;
        }

        public Принятые_заявления GetPrinZayavById(int id)
        {
            return context.Принятые_заявленияs.FirstOrDefault(x => x.id_pz == id);
        }

        public void SavePrinZayav(Принятые_заявления entity)
        {
            if (entity.id_pz == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeletePrinZayav(int id)
        {
            context.Принятые_заявленияs.Remove(new Принятые_заявления() { id_pz = id });
            context.SaveChanges();
        }
    }
}
