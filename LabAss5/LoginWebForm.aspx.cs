using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace LabAss5
{
    public partial class LoginWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleDatebaseConnectionString1"].ConnectionString);
            conn.Open();
            string queryString = "Select UserName,Password from Logon where UserName='" + txtUsername.Text + "'";

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(queryString, conn);

            DataSet ds1 = new DataSet();
            adapter.Fill(ds1, "Logon");
            if (ds1.Tables["Logon"].Rows.Count == 0)
            {
                lblCaption.Text = "Invalid Username";
            }
            else
            {
                if (ds1.Tables["Logon"].Rows[0][1].ToString().Trim() == txtPassword.Text.Trim())
                {
                    lblCaption.Text = "Welcome," + txtUsername.Text;

                    Session["Uname"] = txtUsername.Text;
                    Server.Transfer("Welcome.aspx");
                }
                else
                {
                    lblCaption.Text = "Invalid Password";
                }
            }
            conn.Close();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}