using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EFCodeFirstWithMapping.Utilities;

namespace EFCodeFirstWithMapping.Controller
{
    public class CityController : ApiController
    {
        public IEnumerable<CityModel> GetAll()
        {
            MyContext db = new MyContext();
            return db.Cities.Select(x => new CityModel()
                                             {
                                                 ID = x.ID,
                                                 Name = x.Name
                                             }).ToList();
        }
        public void Post(CityModel model)
        {

            if (!String.IsNullOrEmpty(model.Name))
            {
                MyContext db = new MyContext();
                if (!db.Cities.Any(x => x.Name == model.Name))
                {
                    City city = new City();
                    city.Name = model.Name;
                    city.CreateDate = DateTime.Now;
                    db.Cities.Add(city);
                    db.SaveChanges();
                }
            }


        }

        public void Delete(int id)
        {
            MyContext db = new MyContext();
            City city = db.Cities.FirstOrDefault(x => x.ID == id);
            db.Cities.Remove(city);
            db.SaveChanges();
        }
    }
}