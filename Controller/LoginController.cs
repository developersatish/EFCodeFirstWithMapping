using System.Linq;
using System.Web.Http;
using EFCodeFirstWithMapping.Utilities;

namespace EFCodeFirstWithMapping.Controller
{
    public class LoginController : ApiController
    {
        private MyContext db = new MyContext();

        public bool Post(LoginModel model)
        {
            IQueryable<User> users = db.Users;
            if (users.Any(x => x.EmailID == model.EmailId && x.Password == model.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}