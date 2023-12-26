using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_v._1._1.Models;

namespace WebApplication_v._1._1.Controllers
{
    public class HomeController : Controller
    {
        DBContext db;
        public HomeController(DBContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(string search_text)
        {
            var st = from m in db.Принятые_заявленияs select m;
            if (!String.IsNullOrEmpty(search_text))
            {
                st = st.Where(s => s.num_zayav.Contains(search_text));
            }
            return View(await st.ToListAsync());
        }
        public async Task<IActionResult> Filial(string search_text)
        {
            var st = from m in db.Филиалыs select m;
            if (!String.IsNullOrEmpty(search_text))
            {
                st = st.Where(s => s.id_f.ToString().Contains(search_text) || s.addres.Contains(search_text));
            }
            return View(await st.ToListAsync());
        }
        public async Task<IActionResult> Sotrudniki(string search_text)
        {
            var st = from m in db.Сотрудникиs select m;
            if (!String.IsNullOrEmpty(search_text))
            {
                st = st.Where(s => s.id_s.ToString().Contains(search_text) || s.Familia.Contains(search_text) || s.Imya.Contains(search_text) || s.Otchestvo.Contains(search_text));
            }
            return View(await st.ToListAsync());
        }
        public async Task<IActionResult> Zayaviteli(string search_text)
        {
            var st = from m in db.Заявителиs select m;
            if (!String.IsNullOrEmpty(search_text))
            {
                st = st.Where(s => s.id_z.ToString().Contains(search_text) || s.fio.Contains(search_text));
            }
            return View(await st.ToListAsync());
        }
        
    }
}
