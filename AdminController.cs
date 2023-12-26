using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_v._1._1.Models;
using WebApplication_v._1._1.Repositories.Abstract;
using WebApplication_v._1._1.Service;
using WebApplication_v._1._1.Domain.Repositories.Abstract;

namespace WebApplication_v._1._1.Controllers
{
    public class AdminController : Controller
    {
        DBContext db;

        IZayaviteliRepository zayaviteliRepository;
        IFilialsRepository filialsRepository;
        ISotrudnikiRepository sotrudnikiRepository;
        IPrinZayavRepository prinZayavRepository;

        public AdminController( IFilialsRepository _filialsRepository, IPrinZayavRepository _prinZayavRepository,  IZayaviteliRepository _zayaviteliRepository, ISotrudnikiRepository _sotrudnikiRepository, DBContext context)
        {
            db = context;
            filialsRepository = _filialsRepository;
            zayaviteliRepository = _zayaviteliRepository;
            sotrudnikiRepository = _sotrudnikiRepository;
            prinZayavRepository = _prinZayavRepository;
        }
        //Вывод данных
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
                st = st.Where(s => s.id_f.ToString().Contains(search_text) || s.addres.Contains(search_text) || s.names.Contains(search_text));
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
        public async Task<IActionResult> Sotrudniki(string search_text)
        {
            var st = from m in db.Сотрудникиs select m;
            if (!String.IsNullOrEmpty(search_text))
            {
                st = st.Where(s => s.id_s.ToString().Contains(search_text) || s.Familia.Contains(search_text) || s.Imya.Contains(search_text) || s.Otchestvo.Contains(search_text));
            }
            return View(await st.ToListAsync());
        }
        
        ///

        //Редактирование, удаление, добавление принятых заявлений
        public IActionResult EditPrinZayav(int id)
        {
            var entity = id == default ? new Принятые_заявления() : prinZayavRepository.GetPrinZayavById(id);
            return View(entity);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPrinZayav(Принятые_заявления model)
        {
            if (ModelState.IsValid)
            {
                Принятые_заявления s = await db.Принятые_заявленияs.FirstOrDefaultAsync(u => u.id_s == model.id_s && u.id_z == model.id_z && u.id_f == model.id_f);
                if (s != null)
                {
                    prinZayavRepository.SavePrinZayav(model);

                    return RedirectToAction(nameof(AdminController.Index), nameof(AdminController).CutController());
                }
                ModelState.AddModelError("", "Некорректное/ые значение/я");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeletePrinZayav(int id)
        {
            prinZayavRepository.DeletePrinZayav(id);
            return RedirectToAction(nameof(AdminController.Index), nameof(AdminController).CutController());
        }
        //
        //Редактирование, удаление, добавление филиала
        public IActionResult EditFilial(int id)
        {
            var entity = id == default ? new Филиалы() : filialsRepository.GetFilialById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult EditFilial(Филиалы model)
        {
            if (ModelState.IsValid)
            {
                filialsRepository.SaveFilial(model);
                return RedirectToAction(nameof(AdminController.Filial), nameof(AdminController).CutController());
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteFilial(int id)
        {
            filialsRepository.DeleteFilial(id);
            return RedirectToAction(nameof(AdminController.Filial), nameof(AdminController).CutController());
        }
        ////

        //Редактирование, удаление, добавление заявителей
        public IActionResult EditZayaviteli(int id)
        {
            var entity = id == default ? new Заявители() : zayaviteliRepository.GetZayaviteliById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult EditZayaviteli(Заявители model)
        {
            if (ModelState.IsValid)
            {
                zayaviteliRepository.SaveZayaviteli(model);
                return RedirectToAction(nameof(AdminController.Zayaviteli), nameof(AdminController).CutController());
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteZayaviteli(int id)
        {
            zayaviteliRepository.DeleteZayaviteli(id);
            return RedirectToAction(nameof(AdminController.Zayaviteli), nameof(AdminController).CutController());
        }
        ////

        //Редактирование, удаление, добавление сотрудников
        public IActionResult EditSotrudniki(int id)
        {
            var entity = id == default ? new Сотрудники() : sotrudnikiRepository.GetSotrudnikiById(id);
            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> EditSotrudniki(Сотрудники model)
        {
            if (ModelState.IsValid)
            {
                Сотрудники s = await db.Сотрудникиs.FirstOrDefaultAsync(u => u.id_f == model.id_f);
                if (s != null)
                {
                    sotrudnikiRepository.SaveSotrudniki(model);
                    return RedirectToAction(nameof(AdminController.Sotrudniki), nameof(AdminController).CutController());
                }
                ModelState.AddModelError("", "Некорректное/ые значение/я");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DeleteSotrudniki(int id)
        {
            sotrudnikiRepository.DeleteSotrudniki(id);
            return RedirectToAction(nameof(AdminController.Sotrudniki), nameof(AdminController).CutController());
        }
        ////
        ///
    }
}
