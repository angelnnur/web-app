using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication_v._1._1.Models;
using WebApplication_v._1._1.Repositories.Abstract;

namespace WebApplication_v._1._1.Repositories.EntityFramework
{
    public class EFFilialsRepository : IFilialsRepository
    {
        private readonly DBContext context;
        public EFFilialsRepository(DBContext context)
        {
            this.context = context;
        }

        public IQueryable<Филиалы> GetFilials()
        {
            return context.Филиалыs;
        }

        public Филиалы GetFilialById(int id)
        {
            return context.Филиалыs.FirstOrDefault(x => x.id_f == id);
        }

        public void SaveFilial(Филиалы entity)
        {
            if (entity.id_f == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteFilial(int id)
        {
            context.Филиалыs.Remove(new Филиалы() { id_f = id });
            context.SaveChanges();
        }
    }
}
