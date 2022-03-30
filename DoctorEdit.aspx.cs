using System;
using System.Data;
using System.Data.SqlClient;

namespace HealthcareData
{
    public partial class DoctorEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string UserName = Session["UserName"].ToString();
                string UserId = Session["UserId"].ToString();
                string UserLoginType = Session["UserLoginType"].ToString();
                string UserEmailID = Session["UserEmailID"].ToString();
                string Id = Request.QueryString["Id"].ToString();

                LoginName.Text = UserName;

                if (UserLoginType != "Admin")
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
                        string qry = "Select * from UserTable Where Id=@Id and LoginType='Doctor'";
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(qry, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new SqlParameter("@Id", Id));

                            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                            adapt.Fill(ds);
                        }
                        conn.Close();
                    }
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Name.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                            EmailAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailID"]);
                            Password.Text = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                            Gender.Text = Convert.ToString(ds.Tables[0].Rows[0]["Gender"]);
                            PhoneNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNo"]);
                            DoctorDegree.Text = Convert.ToString(ds.Tables[0].Rows[0]["DoctorDegree"]);
                            OpenTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["OpenTime"]);
                            CloseTime.Text = Convert.ToString(ds.Tables[0].Rows[0]["CloseTime"]);
                            Specialization.Text = Convert.ToString(ds.Tables[0].Rows[0]["Specialization"]);
                            Address.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
                            City.Text = Convert.ToString(ds.Tables[0].Rows[0]["City"]);
                            State.Text = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
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

            string Id = Request.QueryString["Id"].ToString();
            DataSet ds = new DataSet();
            string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConStr"].ToString();
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                string qry = "Update UserTable SET Name=@Name,EmailID=@EmailID,Password=@Password,Age=@Age,PhoneNo=@PhoneNo,DoctorDegree=@DoctorDegree,OpenTime=@OpenTime,CloseTime=@CloseTime,Specialization=@Specialization,Address=@Address,City=@City,State=@State Where Id=@Id";
                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
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

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            ErorrMessage.Text = "Save Successful";
            ErorrMessage.Visible = true;
        }
    }
}