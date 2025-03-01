using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapplicationCntStaCtyReg_Layout.Data;
using System.Data.Entity;
using webapplicationCntStaCtyReg_Layout.Models;

namespace webapplicationCntStaCtyReg_Layout.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext context;
        public RegisterController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Register
        public ActionResult Index()
        {
            var userList = context.Registers.Include(r=>r.City).Include(r => r.City.State).Include(r => r.City.State.Country).ToList();
            return View(userList);
        }
        public ActionResult Upsert(int? id)
        {
            ViewBag.countryList = context.Countries.ToList();
            ViewBag.stateList = context.States.ToList();
            ViewBag.cityList = context.Cities.ToList();
            //***
            Register register = new Register();
            if (id == null) return View(register);//create
            //edit
            register = context.Registers.Find(id.GetValueOrDefault());
            if (register == null) return HttpNotFound();
            register.StateId = register.City.State.Id;
            register.CountryId = register.City.State.Country.Id;
            return View(register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Upsert(Register register)
        {
            if (register == null) return HttpNotFound();
            if(!ModelState.IsValid)
            {
                ViewBag.countryList = context.Countries.ToList();
                ViewBag.stateList = context.States.ToList();
                ViewBag.cityList = context.Cities.ToList();
                return View(register);
            }
            if (register.Id == 0)
                context.Registers.Add(register);
            else
            {
                var userInDb = context.Registers.Find(register.Id);
                if (userInDb == null) return HttpNotFound();
                userInDb.Name = register.Name;
                userInDb.Address = register.Address;
                userInDb.Email = register.Email;
                userInDb.Gender = register.Gender;
                userInDb.IsSubscribe = register.IsSubscribe;
                userInDb.CityId = register.CityId;
                userInDb.PhoneNumber = register.PhoneNumber;
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int id)
        {
            var userFromDb = context.Registers.Include(r => r.City).Include(r => r.City.State).Include(r => r.City.State.Country).FirstOrDefault(r => r.Id == id);
            if (userFromDb == null) return HttpNotFound();
            return View(userFromDb);
        }
        public ActionResult Delete(int id)
        {
            var userInDb = context.Registers.Find(id);
            if (userInDb == null) return HttpNotFound();
            context.Registers.Remove(userInDb);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #region APIs
        private List<State> GetStates(int countryId)
        {
            return context.States.Where(s => s.CountryId == countryId).ToList();
        }
        private List<City> GetCity(int stateId)
        {
            return context.Cities.Where(c => c.StateId == stateId).ToList();
        }
        public ActionResult LoadStateByCountry(int countryId)
        {
            var states = GetStates(countryId);
            var stateListData = states.Select(s1 => new SelectListItem()
            {
                Text = s1.Name,
                Value = s1.Id.ToString()
            });
            return Json(stateListData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadCityByStateId(int stateId)
        {
            var city = GetCity(stateId);
            var cityListData = city.Select(c1 => new SelectListItem()
            {
                Text = c1.Name,
                Value=c1.Id.ToString()
            });
            return Json(cityListData, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}