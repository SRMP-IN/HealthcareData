using System;
using System.Data;
using System.Data.SqlClient;

namespace HealthcareData
{
    public partial class PrescriptionEdit : System.Web.UI.Page
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
                        string qry = "Select * from DoctorAppointment where UserId=@UserId and Id=@Id Order by BookingSlot desc Select ID,ConCat('Name: ' ,Name,' PhoneNo:',PhoneNo,' ',DoctorDegree,' ',Specialization,' Address: ',Address,'-',City,'-',State,'-') As DoctorName from UserTable where LoginType='Doctor'";
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(qry, conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                            cmd.Parameters.Add(new SqlParameter("@Id", Id));
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
                            DoctorList.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DoctorId"]);
                            PatientName.Text = Convert.ToString(ds.Tables[0].Rows[0]["PatientName"]);
                            PatientAge.Text = Convert.ToString(ds.Tables[0].Rows[0]["PatientAge"]);
                            PatientGender.Text = Convert.ToString(ds.Tables[0].Rows[0]["PatientGender"]);
                            PatientDetail.Text = Convert.ToString(ds.Tables[0].Rows[0]["PatientDetail"]);

                            BookingSlot.Text = Convert.ToString(ds.Tables[0].Rows[0]["BookingSlot"]);
                            Prescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["Prescription"]);
                            Reports.Text = Convert.ToString(ds.Tables[0].Rows[0]["Reports"]);
                            Symptoms.Text = Convert.ToString(ds.Tables[0].Rows[0]["Symptoms"]);
                            Checked.Text = Convert.ToString(ds.Tables[0].Rows[0]["Checked"]);
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
            string UserId = Session["UserId"].ToString();
            string Id = Request.QueryString["Id"].ToString();

            string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConStr"].ToString();
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                conn.Open();
                string qry = "Delete From DoctorAppointment Where Id=@Id And UserId=@UserId";
                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            ErorrMessage.Text = "Delete Successful";
            ErorrMessage.Visible = true;
            Response.Redirect($"~/User.aspx?ID=Delete Successful");
        }
    }
}