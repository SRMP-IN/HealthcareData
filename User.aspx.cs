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
                if (Request.QueryString != null && !string.IsNullOrWhiteSpace(Request.QueryString["Id"]))
                {
                    ErorrMessage.Text = Request.QueryString["Id"].ToString();
                    ErorrMessage.Visible = true;
                }
                if (!IsPostBack)
                {
                    string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConStr"].ToString();
                    DataSet ds = new DataSet();
                    using (SqlConnection conn = new SqlConnection(ConStr))
                    {
                        string qry = "Select * from DoctorAppointment where UserId=@UserId  Order by BookingSlot desc    Select ID,ConCat('Name: ' ,Name,' PhoneNo:',PhoneNo,' ',DoctorDegree,' ',Specialization,' Address: ',Address,'-',City,'-',State,'-') As DoctorName from UserTable where LoginType='Doctor'";
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
            if (String.IsNullOrWhiteSpace(PatientName.Text))
            {
                ErorrMessage.Text = "Enter Patient Name";
                ErorrMessage.Visible = true;
                return;
            }
            if (String.IsNullOrWhiteSpace(BookingSlot.Text))
            {
                ErorrMessage.Text = "Enter Booking Slot";
                ErorrMessage.Visible = true;
                return;
            }
            if (String.IsNullOrWhiteSpace(Symptoms.Text))
            {
                ErorrMessage.Text = "Enter Patient Symptoms";
                ErorrMessage.Visible = true;
                return;
            }
            if (String.IsNullOrWhiteSpace(PatientAge.Text))
            {
                ErorrMessage.Text = "Enter Patient Age";
                ErorrMessage.Visible = true;
                return;
            }
            string UserId = Session["UserId"].ToString();

            DateTime dt = DateTime.Now;
            DataSet ds = new DataSet();
            string ConStr = System.Configuration.ConfigurationManager.AppSettings["ConStr"].ToString();
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                if (!DateTime.TryParse(BookingSlot.Text.Replace("T", " "), out dt))
                {
                    dt = DateTime.Now;
                }
                conn.Open();
                string qry = "INSERT INTO DoctorAppointment (Id ,DoctorId ,DoctorDetail,UserId, PatientName,PatientAge,PatientGender,PatientDetail,BookDate,Symptoms,BookingSlot,Checked) Values(@Id ,@DoctorId ,@DoctorDetail,@UserId, @PatientName,@PatientAge,@PatientGender,@PatientDetail,@BookDate,@Symptoms,@BookingSlot,'No')";
                using (SqlCommand cmd = new SqlCommand(qry, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("@Id", Guid.NewGuid().ToString("N").ToUpper() + DateTime.UtcNow.Ticks));
                    cmd.Parameters.Add(new SqlParameter("@DoctorId", DoctorList.SelectedValue));
                    cmd.Parameters.Add(new SqlParameter("@DoctorDetail", DoctorList.SelectedItem.ToString()));
                    cmd.Parameters.Add(new SqlParameter("@PatientName", PatientName.Text));
                    cmd.Parameters.Add(new SqlParameter("@PatientAge", PatientAge.Text));
                    cmd.Parameters.Add(new SqlParameter("@PatientGender", PatientGender.Text));
                    cmd.Parameters.Add(new SqlParameter("@PatientDetail", PatientDetail.Text));
                    cmd.Parameters.Add(new SqlParameter("@BookingSlot", dt));
                    cmd.Parameters.Add(new SqlParameter("@Symptoms", Symptoms.Text));
                    cmd.Parameters.Add(new SqlParameter("@BookDate", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@UserId", UserId));
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            ErorrMessage.Text = "Save Successful";
            ErorrMessage.Visible = true;
            Response.Redirect($"~/User.aspx?ID=Save Successful");
        }
    }
}