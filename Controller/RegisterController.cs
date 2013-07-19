using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EFCodeFirstWithMapping.Utilities;

namespace EFCodeFirstWithMapping.Controller
{
    public class RegisterController : ApiController
    {
        private MyContext db = new MyContext();

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Post(RegisterModel model)
        {
            if (!String.IsNullOrEmpty(model.Name) && !String.IsNullOrEmpty(model.EmailID) &&
                !String.IsNullOrEmpty(model.Password))
            {
                User user = new User();
                user.Name = model.Name;
                user.EmailID = model.EmailID;
                user.Password = model.Password;
                user.Address = model.Address;
                user.IsDeleted = false;
                user.CreateDate = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
            }
            
        }
    }
}