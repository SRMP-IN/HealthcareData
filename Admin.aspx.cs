using System;
using System.Data;
using System.Data.SqlClient;

namespace HealthcareData
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string UserName = Session["UserName"].ToString();
                string UserId = Session["UserId"].ToString();
                string UserLoginType = Session["UserLoginType"].ToString();
                string UserEmailID = Session["UserEmailID"].ToString();

                LoginName.Text = UserName;
                LoginName1.Text = UserName;

                if (UserLoginType != "Admin")
                {
                    Response.Redirect("~/Default.aspx");
                    return;
                }

                string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConStr"].ToString();
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    string qry = "Select * from UserTable where Id=@UserId";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(qry, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                        adapt.Fill(ds);
                    }
                    conn.Close();
                }
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Grid.DataSource = ds.Tables[0];
                        Grid.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}