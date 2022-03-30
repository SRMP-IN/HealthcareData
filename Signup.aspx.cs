using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace HealthcareData
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErorrMessage.Text = "";
            ErorrMessage.Visible = false;
            Session.Abandon();
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EmailAddress.Text))
            {
                ErorrMessage.Text = "Enter Email Address";
                ErorrMessage.Visible = true;
                return;
            }

            if (String.IsNullOrWhiteSpace(Password.Text))
            {
                ErorrMessage.Text = "Enter Password";
                ErorrMessage.Visible = true;
                return;
            }
            if (String.IsNullOrWhiteSpace(Name.Text))
            {
                ErorrMessage.Text = "Enter Name";
                ErorrMessage.Visible = true;
                return;
            }

            string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConStr"].ToString();

            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                string qry = "Select * from UserTable where Emailid=@Emailid";

                SqlParameter p1 = new SqlParameter("@Emailid", EmailAddress.Text);
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(p1);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(ds);
                }
                conn.Close();
            }
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ErorrMessage.Text = "email already exists, please check with system admin";
                    ErorrMessage.Visible = true;
                    return;
                }
            }

            ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                string qry = "INSERT INTO UserTable(Id,Name,EmailID,Password,Age,Gender,PhoneNo,LoginType)VALUES(@Id,@Name,@EmailID,@Password,@Age,@Gender,@PhoneNo,@LoginType)";
                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@Id", Guid.NewGuid().ToString("N").ToUpper()+DateTime.UtcNow.Ticks));
                    cmd.Parameters.Add(new SqlParameter("@Name", Name.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmailID", EmailAddress.Text));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password.Text));
                    cmd.Parameters.Add(new SqlParameter("@Age", Age.Text));
                    cmd.Parameters.Add(new SqlParameter("@Gender", Gender.Text));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo.Text));
                    cmd.Parameters.Add(new SqlParameter("@LoginType", "User"));
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            ErorrMessage.Text = "Create Successful, Login now.";
            ErorrMessage.Visible = true;
        }
    }
}