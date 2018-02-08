using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace GUI.Staff
{
    public partial class StaffHome : System.Web.UI.Page
    {
        // function to check the session exists or else redirect to login 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.Cookies.AllKeys.Contains("Login"))
            {
                Response.Redirect("~/");
                return;
            }
            else if ((string)Session["loginuser"] != "Staff"){
                Response.Redirect("~/Member/MemberHome");
            }
        }

        //Function to add the new staff user
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // check if the staff already exists
            bool email = uniqueemailid(staffemailTextBox.Text);
            if (email == true)
            {
                emailuinuqe.Text = "User Already Exists";
            }
            else
            {
                // if staff is unique then append to the xml file
                emailuinuqe.Text = string.Empty;
                string Upload_Path = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
                string fLocation = Path.Combine(Upload_Path, @"Staff.xml");
                string encryptpass = EncryptionDecryptionDLLFile.Class1.Encrypt(staffpasswordTextBox.Text);
                FileStream fState = null;

                try
                {
                    XDocument xDocument = XDocument.Load(fLocation);
                    XElement root = xDocument.Element("Staff");
                    IEnumerable<XElement> rows = root.Descendants("User");
                    XElement firstRow = rows.First();
                    firstRow.AddBeforeSelf(
                    new XElement("User",
                    new XElement("EmailID", staffemailTextBox.Text),
                    new XElement("Password", encryptpass)));
                    xDocument.Save(fLocation);
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Staff Added Successfully')", true);
                    staffemailTextBox.Text = string.Empty;
                    staffpasswordTextBox.Text = string.Empty;

                }
                finally
                {
                    if (fState != null)
                    {
                        fState.Close();
                    }
                }
            }
        }

        // Function to reset the buttons
        protected void ResetButton_Click(object sender, EventArgs e)
        {
            staffemailTextBox.Text = string.Empty;
            staffpasswordTextBox.Text = string.Empty;
            emailuinuqe.Text = string.Empty;
        }

        // Function to check if staff emailid is unique
        public bool uniqueemailid(string email)
        {
            string Upload_Path = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            string fLocation = Path.Combine(Upload_Path, @"Staff.xml");
            bool error;
            if (File.Exists(fLocation))
            {
                FileStream fs = new FileStream(fLocation, FileMode.Open);
                XmlDocument doc = new XmlDocument();
                doc.Load(fs);
                foreach (XmlNode node in doc.SelectNodes("//User"))
                {
                    string username = node.SelectSingleNode("EmailID").InnerText;
                    if (username == email)
                    {
                        fs.Close();
                        error = true;
                        return error;
                    }
                    else
                    {
                        fs.Close();
                        error = false;
                        return error;

                    }
                }

            }
            error = false;
            return error;
        }
    }
}