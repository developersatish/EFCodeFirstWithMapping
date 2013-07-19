using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EFCodeFirstWithMapping.Utilities;

namespace EFCodeFirstWithMapping
{
    public partial class CodeFirstWithMapping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }

        }

        protected void SaveByCode_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (!String.IsNullOrEmpty(NameTextBox.Text) && !String.IsNullOrEmpty(EmailTextBox.Text) &&
               !String.IsNullOrEmpty(PasswordTextBox.Text))
                {
                    MyContext db = new MyContext();
                    User user = new User();
                    user.Name = NameTextBox.Text;
                    user.EmailID = EmailTextBox.Text;
                    user.Password = PasswordTextBox.Text;
                    user.CreateDate = DateTime.Now;
                    user.IsDeleted = false;
                    user.Address = AddressTextBox.Text;
                    db.Users.Add(user);
                    db.SaveChanges();
                    Bind();
                }
            }


        }

        private void Bind()
        {
            MyContext db = new MyContext();
            BindGrid.DataSource = db.Users.ToList();
            BindGrid.DataBind();
        }
    }
}