using System;
using System.Data;
using System.Data.SqlClient;

namespace HealthcareData
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ErorrMessage.Text = "";
            ErorrMessage.Visible = false;

            EmailAddress.Text = "Adm22in@admin.con";
            Password.Text = "3232";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(EmailAddress.Text))
            {
                ErorrMessage.Text = "InValid Login";
                ErorrMessage.Visible = true;
                return;
            }

            if (String.IsNullOrWhiteSpace(Password.Text))
            {
                ErorrMessage.Text = "InValid Login";
                ErorrMessage.Visible = true;
                return;
            }

            string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConStr"].ToString();

            string qry = "Select * from UserTable where Emailid=@Emailid and Password=@Password";

            SqlParameter p1 = new SqlParameter("@Emailid", EmailAddress.Text);
            SqlParameter p2 = new SqlParameter("@Password", Password.Text);

            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    adapt.Fill(ds);
                }
                conn.Close();
            }
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["UserName"] = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                    Session["UserId"] = Convert.ToString(ds.Tables[0].Rows[0]["Id"]);
                    Session["UserEmailID"] = Convert.ToString(ds.Tables[0].Rows[0]["EmailID"]);
                    Session["UserLoginType"] = Convert.ToString(ds.Tables[0].Rows[0]["LoginType"]);
                    if (Session["UserLoginType"].ToString() == "User")
                    {
                        Response.Redirect("~/User.aspx");
                    }
                    else if (Session["UserLoginType"].ToString() == "Admin")
                    {
                        Response.Redirect("~/Admin.aspx");
                    }
                    else if (Session["UserLoginType"].ToString() == "Doctor")
                    {
                        Response.Redirect("~/Doctor.aspx");
                    }
                    else
                    {
                        ErorrMessage.Text = "InValid Login";
                        ErorrMessage.Visible = true;
                    }
                }
                else
                {
                    ErorrMessage.Text = "InValid Login";
                    ErorrMessage.Visible = true;
                }
            }
            else
            {
                ErorrMessage.Text = "InValid Login";
                ErorrMessage.Visible = true;
            }
        }
    }
}