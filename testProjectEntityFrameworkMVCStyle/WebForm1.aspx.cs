using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjectEntityFrameworkMVCStyle.Model;

namespace testProjectEntityFrameworkMVCStyle
{
    public partial class WebForm1 : BasePage
    {
        UserManager userMgr = new UserManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void AddUser(string firstName, string lastName, string contactNumber)
        {
            userMgr.AddUser(firstName, lastName, contactNumber);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddUser(txtFirstName.Text, txtLastName.Text, txtPhone.Text);
            Response.Redirect("WebForm2.aspx");
        }
    }
}