using System;

using System.Data;
using System.Data.SqlClient;

namespace HealthcareData
{
    public partial class DoctorAdd : System.Web.UI.Page
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

                if (UserLoginType != "Admin")
                {
                    Response.Redirect("~/Default.aspx");
                    return;
                }
            }
            catch (Exception)
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
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

            DataSet ds = new DataSet();
            string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConStr"].ToString();
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                string qry = "INSERT INTO UserTable(Id,Name,EmailID,Password,Age,Gender,PhoneNo,LoginType,DoctorDegree,OpenTime,CloseTime,Specialization,Address,City,State)VALUES(@Id,@Name,@EmailID,@Password,@Age,@Gender,@PhoneNo,@LoginType,@DoctorDegree,@OpenTime,@CloseTime,@Specialization,@Address,@City,@State)";
                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@Id", Guid.NewGuid().ToString("N").ToUpper() + DateTime.UtcNow.Ticks));
                    cmd.Parameters.Add(new SqlParameter("@Name", Name.Text));
                    cmd.Parameters.Add(new SqlParameter("@EmailID", EmailAddress.Text));
                    cmd.Parameters.Add(new SqlParameter("@Password", Password.Text));
                    cmd.Parameters.Add(new SqlParameter("@Age", Age.Text));
                    cmd.Parameters.Add(new SqlParameter("@Gender", Gender.Text));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo.Text));
                    cmd.Parameters.Add(new SqlParameter("@DoctorDegree", DoctorDegree.Text));
                    cmd.Parameters.Add(new SqlParameter("@OpenTime", OpenTime.Text));
                    cmd.Parameters.Add(new SqlParameter("@CloseTime", CloseTime.Text));
                    cmd.Parameters.Add(new SqlParameter("@Specialization", Specialization.Text));
                    cmd.Parameters.Add(new SqlParameter("@Address", Address.Text));
                    cmd.Parameters.Add(new SqlParameter("@City", City.Text));
                    cmd.Parameters.Add(new SqlParameter("@State", State.Text));
                    cmd.Parameters.Add(new SqlParameter("@LoginType", "Doctor"));

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            ErorrMessage.Text = "Save Successful";
            ErorrMessage.Visible = true;
        }
    }
}