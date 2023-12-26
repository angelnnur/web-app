using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication_v._1._1.Models;
using WebApplication_v._1._1.Repositories.Abstract;

namespace WebApplication_v._1._1
{
    public class EFZayaviteliRepository : IZayaviteliRepository
    {
        private readonly DBContext context;
        public EFZayaviteliRepository(DBContext context)
        {
            this.context = context;
        }

        public IQueryable<Заявители> GetZayaviteli()
        {
            return context.Заявителиs;
        }

        public Заявители GetZayaviteliById(int id)
        {
            return context.Заявителиs.FirstOrDefault(x => x.id_z == id);
        }

        public void SaveZayaviteli(Заявители entity)
        {
            if (entity.id_z == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteZayaviteli(int id)
        {
            context.Заявителиs.Remove(new Заявители() { id_z = id });
            context.SaveChanges();
        }
    }
}
