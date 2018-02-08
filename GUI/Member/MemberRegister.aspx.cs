using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Xml.Linq;

namespace GUI.Member
{
    public partial class MemberRegister : System.Web.UI.Page
    {
        // Load the image verifier on each page load
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = "~/imageverifier.aspx";
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // check if the user is a unique user(EmailID)
            bool email = uniqueemailid(emailTextBox.Text);
            if (email == true)
            {
                uniqueemail.Text = "Email ID Already Exists";
                captchaTextBox.Text = string.Empty;
                verifyButton_Click(sender, e);
            }
            else
            {
                uniqueemail.Text = string.Empty;
                if (Session["generatedstring"].Equals(captchaTextBox.Text))
                {
                    string Upload_Path = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
                    string fLocation = Path.Combine(Upload_Path, @"Member.xml");
                    FileStream fState = null;
                    string password = EncryptionDecryptionDLLFile.Class1.Encrypt(passwordTextBox.Text);
                    if (!(File.Exists(fLocation)))
                    {
                        // To create a Xml file and insert data if there is no file
                        try
                        {
                            fState = new FileStream(fLocation, FileMode.Create);
                            XmlTextWriter writer = new XmlTextWriter(fState, System.Text.Encoding.Unicode);
                            writer.Formatting = Formatting.Indented;
                            writer.WriteStartDocument();
                            writer.WriteStartElement("Member");
                            writer.WriteStartElement("User");
                            writer.WriteElementString("FirstName", fnameTextBox.Text);
                            writer.WriteElementString("LastName", lnameTextBox.Text);
                            writer.WriteElementString("City", cityTextBox.Text);
                            writer.WriteElementString("State", stateTextBox.Text);
                            writer.WriteElementString("Zipcode", zipcodeTextBox.Text);
                            writer.WriteElementString("Mobile", mobileTextBox.Text);
                            writer.WriteElementString("Carrier", carrierName.Text);
                            writer.WriteElementString("EmailID", emailTextBox.Text);
                            writer.WriteElementString("Password", password);
                            writer.WriteElementString("CCNumber", creditCardNumTextBox.Text);
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Close();
                            fState.Close();
                        }
                        finally
                        {
                            if (fState != null)
                            {
                                fState.Close();
                            }
                        }
                    }
                    else
                    {
                        // If the file is already there then open it and append it
                        try
                        {
                            XDocument xDocument = XDocument.Load(fLocation);
                            XElement root = xDocument.Element("Member");
                            IEnumerable<XElement> rows = root.Descendants("User");
                            XElement firstRow = rows.First();
                            firstRow.AddBeforeSelf(
                            new XElement("User",
                            new XElement("FirstName", fnameTextBox.Text),
                            new XElement("LastName", lnameTextBox.Text),
                            new XElement("City", cityTextBox.Text),
                            new XElement("State", stateTextBox.Text),
                            new XElement("Zipcode", zipcodeTextBox.Text),
                            new XElement("Mobile", mobileTextBox.Text),
                            new XElement("Carrier", carrierName.Text),
                            new XElement("EmailID", emailTextBox.Text),
                            new XElement("Password", password),
                            new XElement("CCNumber", creditCardNumTextBox.Text)));
                            xDocument.Save(fLocation);

                        }
                        finally
                        {
                            if (fState != null)
                            {
                                fState.Close();
                            }
                        }
                    }
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Registration Successfull')", true);
                    resettextbox();
                    verifyButton_Click(sender, e);
                }
                else
                {
                    captchaTextBox.Text = string.Empty;
                    captchaTextBoxerror.Text = "Invalid Captcha";
                    verifyButton_Click(sender, e);

                }

            }

        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            resettextbox();
            verifyButton_Click(sender, e);
        }

        protected void verifyButton_Click(object sender, EventArgs e)
        {
            //to load image for the image verifier
            imageServiceReference.ServiceClient service1 = new imageServiceReference.ServiceClient();
            string userlength = "5";
            //Session.Clear();
            Session["userlength"] = userlength;
            string mystr = service1.GetVerifierString(userlength);
            Session["generatedstring"] = mystr;
            Image1.Visible = true;
        }

        // Function to check if the email is unique
        public bool uniqueemailid(string email)
        {
            string Upload_Path = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data");
            string fLocation = Path.Combine(Upload_Path, @"Member.xml");
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
        // Function to Reset the fields
        public void resettextbox()
        {
            fnameTextBox.Text = string.Empty;
            lnameTextBox.Text = string.Empty;
            cityTextBox.Text = string.Empty;
            stateTextBox.Text = string.Empty;
            zipcodeTextBox.Text = string.Empty;
            mobileTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
            confirmPasswordTextBox.Text = string.Empty;
            creditCardNumTextBox.Text = string.Empty;
            captchaTextBox.Text = string.Empty;
            uniqueemail.Text = string.Empty;
            captchaTextBoxerror.Text = string.Empty;

        }
    }

}