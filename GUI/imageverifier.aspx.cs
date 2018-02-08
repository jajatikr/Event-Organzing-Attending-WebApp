using System;
using System.IO;
using System.Drawing.Imaging;

namespace GUI
{
    public partial class imageverifier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            imageServiceReference.ServiceClient service = new imageServiceReference.ServiceClient();
            string mystr, userlen;
            if (Session["generatedstring"] == null)
            {
                if (Session["userlength"] == null)
                {
                    userlen = "5";
                }
                else
                {
                    userlen = Session["userlength"].ToString();
                }
                mystr = service.GetVerifierString(userlen);
                Session["generatedstring"] = mystr;
            }
            else
            {
                mystr = Session["generatedstring"].ToString();
            }
            Stream mystream = service.GetImage(mystr);
            System.Drawing.Image myimage = System.Drawing.Image.FromStream(mystream);
            Response.ContentType = "image/jpeg";
            myimage.Save(Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}