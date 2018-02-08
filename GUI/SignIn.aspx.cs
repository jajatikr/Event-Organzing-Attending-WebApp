using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace GUI
{
    public partial class SignIn : System.Web.UI.Page
    {
        // Using single signin page for both staff and member, the state is stored in sessions and redirected based on the type of user
        protected void Page_Load(object sender, EventArgs e)
        {
            //checks the session of the user and retrieves the credentials from cookies and redirects them to home.
            string user = "";
            string fLocation = "";
            string Upload_Path = "";
            string role = (string)Session["loginuser"];
            if (role != null)
            {
                if (role.Contains("Member"))
                {
                    user = "Member";
                    Upload_Path = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
                    fLocation = Path.Combine(Upload_Path, @"Member.xml");
                    if (Request.Cookies["Login"] != null)
                    {
                        if (File.Exists(fLocation))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(fLocation);
                            foreach (XmlNode node in doc.SelectNodes("//User"))
                            {
                                string username = node.SelectSingleNode("EmailID").InnerText;
                                string password = node.SelectSingleNode("Password").InnerText;
                                password = EncryptionDecryptionDLLFile.Class1.Decrypt(password);
                                if (Request.Cookies["Login"]["username"] == username && Request.Cookies["Login"]["password"] == password && user == "Member")
                                {
                                    Response.Redirect("~/Member/MemberHome.aspx");
                                }
                            }
                        }

                    }
                }
                else
                {
                    user = "Staff";
                    Upload_Path = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
                    fLocation = Path.Combine(Upload_Path, @"Staff.xml");
                    if (Request.Cookies["Login"] != null)
                    {
                        if (File.Exists(fLocation))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(fLocation);
                            foreach (XmlNode node in doc.SelectNodes("//User"))
                            {
                                string username = node.SelectSingleNode("EmailID").InnerText;
                                string password = node.SelectSingleNode("Password").InnerText;
                                password = EncryptionDecryptionDLLFile.Class1.Decrypt(password);
                                if (Request.Cookies["Login"]["username"] == username && Request.Cookies["Login"]["password"] == password && user == "Staff")
                                {
                                    Response.Redirect("~/Staff/StaffHome.aspx");
                                }
                            }
                        }

                    }
                }
            }

            // checks if the user is a member / staff
            string role1 = (string)Session["loginuser"];
            if (role1 != null)
            {
                if (role1.Contains("Member"))
                {
                    //Header.InnerText = "Member Login";
                }
                else
                {
                    //Header.InnerText = "Staff Login";
                }
            }
            else
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx");
            }
        }


        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string user = "";
            string fLocation = "";
            string Upload_Path = "";
            string role = (string)Session["loginuser"];
            // To determine which xml file to search for based on the user type
            if (role != null)
            {
                if (role.Contains("Member"))
                {
                    user = "Member";
                    Upload_Path = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
                    fLocation = Path.Combine(Upload_Path, @"Member.xml");
                }
                else
                {
                    user = "Staff";
                    Upload_Path = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
                    fLocation = Path.Combine(Upload_Path, @"Staff.xml");
                }
            }

            // to check if the user credentials are valid
            if (File.Exists(fLocation))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fLocation);
                foreach (XmlNode node in doc.SelectNodes("//User"))
                {
                    string username = node.SelectSingleNode("EmailID").InnerText;
                    string password = node.SelectSingleNode("Password").InnerText;
                    password = EncryptionDecryptionDLLFile.Class1.Decrypt(password);

                    if (username == emailTextBox.Text && password == passwordTextBox.Text)
                    {
                        HttpCookie mycookie = new HttpCookie("Login");
                        mycookie["username"] = emailTextBox.Text;
                        mycookie["password"] = passwordTextBox.Text;
                        //Response.Cookies["authcookie"]["username"] = TextBox1.Text;
                        //Response.Cookies["authcookie"]["password"] = TextBox2.Text;
                        mycookie.Expires = DateTime.Now.AddDays(3);
                        Response.Cookies.Add(mycookie);
                        if (user == "Member")
                        {
                            Response.Redirect("~/Member/MemberHome.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Staff/StaffHome.aspx");
                        }
                    }
                    else
                    {
                        ResultLabel.Text = "Invalid Credentials !!";
                    }
                }
            }
            else
            {
                Session.Clear();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Member User Found')", true);
            }
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            emailTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
        }
    }
}