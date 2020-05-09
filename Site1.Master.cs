using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if(Session["role"].Equals(""))
                string sessionrole = Session["role"] as string;
                if(string.IsNullOrEmpty(sessionrole))
                {
                    LinkButton1.Visible = true;     //user login
                    LinkButton2.Visible = true;     //signup
                    LinkButton3.Visible = false;    //logout
                    LinkButton7.Visible = false;    //hello user link

                    LinkButton6.Visible = true;         //admin login
                    LinkButton11.Visible = false;       //author mgmt
                    LinkButton12.Visible = false;       //publisher mgmt
                    LinkButton8.Visible = false;        //book inventory
                    LinkButton9.Visible = false;        //book issuing
                    LinkButton10.Visible = false;       //member mgmt
                }
                else if(Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false;     //user login
                    LinkButton2.Visible = false;     //signup
                    LinkButton3.Visible = true;    //logout
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello " + Session["username"].ToString();    //hello user link


                    LinkButton6.Visible = true;
                    LinkButton11.Visible = false;
                    LinkButton12.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;     //user login
                    LinkButton2.Visible = false;     //signup
                    LinkButton3.Visible = true;    //logout
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello Admin";    //hello user link


                    LinkButton6.Visible = false;
                    LinkButton11.Visible = true;
                    LinkButton12.Visible = true;
                    LinkButton8.Visible = true;
                    LinkButton9.Visible = true;
                    LinkButton10.Visible = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] ="";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] ="";

            LinkButton1.Visible = true;     //user login
            LinkButton2.Visible = true;     //signup
            LinkButton3.Visible = false;    //logout
            LinkButton7.Visible = false;    //hello user link

            LinkButton6.Visible = true;         //admin login
            LinkButton11.Visible = false;       //author mgmt
            LinkButton12.Visible = false;       //publisher mgmt
            LinkButton8.Visible = false;        //book inventory
            LinkButton9.Visible = false;        //book issuing
            LinkButton10.Visible = false;       //member mgmt

            Response.Redirect("homepage.aspx");
        }
    }
}