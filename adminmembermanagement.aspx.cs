using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //Go Button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMemberByID();
        }
        //active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Active");
        }
        //pending
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Pending");
        }
        //Deactive
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            updateMemberStatusByID("Deactive");
        }
        //Delete
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteMemberByID();
        }

        //user defined function
        bool checkIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open(); //If connection is closed initially ,open it.
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //Disconnected architechture
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void clearForm()
        {
            TextBox1.Text = "";  //member id
            TextBox8.Text = ""; //status
            TextBox7.Text = "";  //dob
            TextBox3.Text = ""; //contact
            TextBox4.Text = "";  //email
            TextBox9.Text = ""; //state
            TextBox10.Text = "";  //city
            TextBox11.Text = ""; //pincode
            TextBox6.Text = "";  //address
            TextBox2.Text = ""; //full name
        }
        void deleteMemberByID()
        {
                if (checkIfMemberExists())
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "'", con);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Member Deleted Successfully');</script>");
                        clearForm();
                        GridView1.DataBind();

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }

                }
                else if (checkIfMemberExists() == false)
                {
                    Response.Write("<script>alert('Invalid Member ID!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Member ID!')</script>");
                }

        }
        void getMemberByID()
        {
            /*  try
              {
                  SqlConnection con = new SqlConnection(strcon);
                  if (con.State == ConnectionState.Closed)
                  {
                      con.Open(); //If connection is closed initially ,open it.
                  }
                  SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);

                  //connected Architecture
                  SqlDataReader dr = cmd.ExecuteReader();
                  if (dr.HasRows)
                  {
                      while (dr.Read())
                      {
                          TextBox1.Text = dr.GetValue(0).ToString();  //member id
                          TextBox8.Text = dr.GetValue(1).ToString(); //status
                          TextBox7.Text = dr.GetValue(0).ToString();  //dob
                          TextBox3.Text = dr.GetValue(2).ToString(); //contact
                          TextBox4.Text = dr.GetValue(3).ToString();  //email
                          TextBox9.Text = dr.GetValue(4).ToString(); //state
                          TextBox10.Text = dr.GetValue(5).ToString();  //city
                          TextBox11.Text = dr.GetValue(6).ToString(); //pincode
                          TextBox6.Text = dr.GetValue(7).ToString();  //address
                          TextBox2.Text = dr.GetValue(0).ToString(); //full name
                      }

                  }
                  else
                  {
                      Response.Write("<script>alert('Invalid Credentials');</script>");
                  }
              }
              catch (Exception ex)
              {
                  Response.Write("<script>alert('" + ex.Message + "');</script>");
              }*/
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        

                        //TextBox1.Text = dr.GetValue(0).ToString();  //member id
                        TextBox8.Text = dr.GetValue(1).ToString(); //status
                        TextBox7.Text = dr.GetValue(10).ToString();  //dob
                        TextBox3.Text = dr.GetValue(2).ToString(); //contact
                        TextBox4.Text = dr.GetValue(3).ToString();  //email
                        TextBox9.Text = dr.GetValue(4).ToString(); //state
                        TextBox10.Text = dr.GetValue(5).ToString();  //city
                        TextBox11.Text = dr.GetValue(6).ToString(); //pincode
                        TextBox6.Text = dr.GetValue(7).ToString();  //address
                        TextBox2.Text = dr.GetValue(0).ToString(); //full name

                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateMemberStatusByID(string status)
        {
            if(checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open(); //If connection is closed initially ,open it.
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + TextBox1.Text.Trim() + "'", con);

                    //connected Architecture

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated');</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else if (checkIfMemberExists() == false)
            {
                Response.Write("<script>alert('Invalid Member ID!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID!')</script>");
            }

        }
    }
}