using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class SignedInMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void SignOutHyperlink_Click(object sender, EventArgs e)
        {
            HttpCookie mycookie = new HttpCookie("Login");
            mycookie.Expires = DateTime.Now.AddDays(-3);
            Response.Cookies.Add(mycookie);
            Session.Clear();
            Response.Redirect("~/Default.aspx");
        }
    }
}