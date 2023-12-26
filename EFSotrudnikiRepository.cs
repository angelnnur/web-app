using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_v._1._1.Domain.Repositories.Abstract;
using WebApplication_v._1._1.Models;

namespace WebApplication_v._1._1.Domain.Repositories.EntityFramework
{
    public class EFSotrudnikiRepository : ISotrudnikiRepository
    {
        private readonly DBContext context;
        public EFSotrudnikiRepository(DBContext context)
        {
            this.context = context;
        }

        public IQueryable<Сотрудники> GetSotrudniki()
        {
            return context.Сотрудникиs;
        }

        public Сотрудники GetSotrudnikiById(int id)
        {
            return context.Сотрудникиs.FirstOrDefault(x => x.id_s == id);
        }

        public void SaveSotrudniki(Сотрудники entity)
        {
            if (entity.id_s == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteSotrudniki(int id)
        {
            context.Сотрудникиs.Remove(new Сотрудники() { id_s = id });
            context.SaveChanges();
        }
    }
}
