using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void MemberRegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Member/MemberRegister.aspx");
        }

        protected void MemberSignInButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session["loginuser"] = "Member";
            Response.Redirect("~/SignIn.aspx");
        }

        protected void StaffSignInButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session["loginuser"] = "Staff";
            Response.Redirect("~/SignIn.aspx");
        }
    }
}