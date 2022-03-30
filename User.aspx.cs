using System;
using System.Data;
using System.Data.SqlClient;

namespace HealthcareData
{
    public partial class User : System.Web.UI.Page
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

                if (UserLoginType != "User")
                {
                    Response.Redirect("~/Default.aspx");
                    return;
                }

                if (!IsPostBack)
                {
                    string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConStr"].ToString();
                    DataSet ds = new DataSet();
                    using (SqlConnection conn = new SqlConnection(ConStr))
                    {
                        string qry = "Select * from DoctorAppointment where UserId=@UserId    Select ID,ConCat('Name: ' ,Name,' PhoneNo:',PhoneNo,' ',DoctorDegree,' ',Specialization,' Address: ',Address,'-',City,'-',State,'-') As DoctorName from UserTable where LoginType='Doctor'";
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
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            DoctorList.DataSource = ds.Tables[1];
                            DoctorList.DataTextField = "DoctorName";
                            DoctorList.DataValueField = "ID";
                            DoctorList.DataBind();
                        }

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Grid.DataSource = ds.Tables[0];
                            Grid.DataBind();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
        }
    }
}