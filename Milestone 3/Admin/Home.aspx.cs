﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SqlServer.Server;
using System.Configuration;

namespace Milestone_3.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null || !Session["id"].Equals("-1"))
            {
                Response.Redirect("~/Login/Login.aspx");
            }
        }

        protected void viewAllAdvisors(object sender, EventArgs e)
        { 
            Response.Redirect("ViewAdvisors.aspx");
        }

        protected void viewStudentsWithAdvisors(object sender, EventArgs e)
        {
            Response.Redirect("ViewStudentsWithAdvisors.aspx");
        }

        protected void viewPendingRequests(object sender, EventArgs e)
        {
            Response.Redirect("ViewPendingRequests.aspx");
        }

        protected void viewInstructirsWithAssignedCourses(object sender, EventArgs e)
        {
            Response.Redirect("InstructorsWithCourses.aspx");
        }

        protected void viewSemesterWithOfferedCourses(object sender, EventArgs e)
        {
            Response.Redirect("SemesterWithCourses.aspx");
        }
        protected void deleteCourse(object sender, EventArgs e)//(needs more testing)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand delete = new SqlCommand("Procedures_AdminDeleteCourse", connection);
            try
            {
                int id = Int16.Parse(c_id.Text);
                delete.CommandType = CommandType.StoredProcedure;
                delete.Parameters.Add(new SqlParameter("@courseID", id));
                connection.Open();
                delete.ExecuteNonQuery();
                connection.Close();
                string script = "alert('Successful');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

            }
            catch(FormatException)
            {
                string script = "alert('Failure, The provided field was left empty, please try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

            }


  
           

        }
        protected void deleteSlot(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand delete = new SqlCommand("Procedures_AdminDeleteSlots", connection);
          
                String id = semster_id.Text;
            if (id.Length > 0)
            {
                delete.CommandType = CommandType.StoredProcedure;
                delete.Parameters.Add(new SqlParameter("@current_semester", id));
                connection.Open();
                delete.ExecuteNonQuery();
                connection.Close();
                string script = "alert('Successful');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else { 
                string script = "alert('Failure, The provided field was left empty, please try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }

        }


        protected void addExam(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand add = new SqlCommand("Procedures_AdminAddExam", connection);
            String Type = type.Text;
            String date_time = date.Text.Replace("T"," ");
            if (Type.Length == 0 || date_time.Length == 0)
            {

                string script = "alert('Failure, The provided field(s) was left empty, please try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else if (DateTime.Parse(date_time) < DateTime.Now)
            {

                string script = "alert('You cannot create exam in the past');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
             
                try
                {
                    int id = Int16.Parse(courseID.Text);
                    add.CommandType = CommandType.StoredProcedure;
                    add.Parameters.Add(new SqlParameter("@courseID", id));
                    add.Parameters.Add(new SqlParameter("@date", date_time));
                    add.Parameters.Add(new SqlParameter("@Type", Type));
                    connection.Open();
                    add.ExecuteNonQuery();
                    //Response.Write(date_time);
                    connection.Close();
                    string script = "alert('Successful');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                catch (FormatException)
                {
                   
                    string script = "alert('Failure, The provided field(s) was left empty, please try again');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }
        }


            protected void viewPayments(object sender, EventArgs e)
        {
            Response.Redirect("Payments.aspx");
        }
        protected void issuePayment(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand issue = new SqlCommand("Procedures_AdminIssueInstallment", connection);
            try
            {
                int id = Int16.Parse(payment_id.Text);
                issue.CommandType = CommandType.StoredProcedure;
                issue.Parameters.Add(new SqlParameter("@payment_id", id));
                connection.Open();
                issue.ExecuteNonQuery();
                connection.Close();
                string script = "alert('Successful  ');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            catch (FormatException)
            {
                string script = "alert('Failure, The provided field(s) was left empty, please try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            catch (OverflowException)
            {
                string script = "alert('Failure, The provided is too large, please try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
           
        }

        protected void updateStatus(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["con"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand update = new SqlCommand("FN_AdminCheckStudentStatus", connection);
            try
            {
                int id = Int16.Parse(studen_financial.Text);//TODO : change to student id   
                update.CommandType = CommandType.StoredProcedure;
                update.Parameters.Add(new SqlParameter("@Student_id", id));
                connection.Open();
                update.ExecuteNonQuery();
                connection.Close();
                string script = "alert('Successful');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            catch (FormatException)
            {
                string script = "alert('Failure, The provided field(s) was left empty, please try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            catch (OverflowException)
            {
                string script = "alert('Failure, The provided is too large, please try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }

        protected void addSemester(object sender, EventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand createSemester = new SqlCommand("AdminAddingSemester", connection);
            createSemester.CommandType = CommandType.StoredProcedure;

            createSemester.Parameters.Add(new SqlParameter("@start_date", e_input1.Value));
            createSemester.Parameters.Add(new SqlParameter("@end_date", e_input2.Value));
            createSemester.Parameters.Add(new SqlParameter("@semester_code", e_input3.Text));


            connection.Open();
            //e_message_box.Text = "";
            if (e_input1.Value.Equals("") || e_input2.Value.Equals("") || e_input3.Text.Equals(""))
            {
                //e_message_box.Text = "Failure, one of the provided boxes was left empty, please fill it and try again";
                string script = "alert('Failure, one of the provided fields was left empty, please fill it and try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else if (DateTime.Parse(e_input2.Value) < DateTime.Parse(e_input1.Value))
            {
                //e_message_box.Text = "Failure, the end date is before the start date, please try again";
                string script = "alert('Failure, the end date is before the start date, please try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                try
                {
                    createSemester.ExecuteNonQuery();
                    //e_message_box.Text = "Success, the semester was added";
                    string script = "alert('Success, the semester was added');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                catch (SqlException)
                {
                    //e_message_box.Text = "Failure, the semester code already exists, please try again";
                    string script = "alert('Failure, the semester code already exists, please try again');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }
            connection.Close();
        }

        protected void addCourse(object sender, EventArgs e)
        {
            String connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand createCourse = new SqlCommand("Procedures_AdminAddingCourse", connection);
            createCourse.CommandType = CommandType.StoredProcedure;

            createCourse.Parameters.Add(new SqlParameter("@major", f_input1.Text));
            createCourse.Parameters.Add(new SqlParameter("@semester", f_input2.Value));
            createCourse.Parameters.Add(new SqlParameter("@credit_hours", f_input3.Value));
            createCourse.Parameters.Add(new SqlParameter("@name", f_input4.Text));
            createCourse.Parameters.Add(new SqlParameter("@is_offered", f_input5.Checked));
            //createCourse.Parameters.Add(new SqlParameter("@is_offered", is_offered.Text));


            connection.Open();
            //f_message_box.Text = "";
            if (f_input1.Text == "" || f_input4.Text == "" || f_input2.Value == "" || f_input3.Value == "")
            {
                //f_message_box.Text = "Failure, one of the provided boxes was left empty, please fill it and try again";
                string script = "alert('Failure, one of the provided boxes was left empty, please fill it and try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                createCourse.ExecuteNonQuery();
                //f_message_box.Text = "Success, the Course was added";
                string script = "alert('Success, the Course was added');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            connection.Close();
        }

        protected void linkInstructorWithCourseOnSlot(object sender, EventArgs e)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand linkInstructorWithCourseOnSlot = new SqlCommand("Procedures_AdminLinkInstructor", connection);
            linkInstructorWithCourseOnSlot.CommandType = CommandType.StoredProcedure;

            linkInstructorWithCourseOnSlot.Parameters.Add(new SqlParameter("@instructor_id", g_input2.Value));
            linkInstructorWithCourseOnSlot.Parameters.Add(new SqlParameter("@cours_id", g_input1.Value));
            linkInstructorWithCourseOnSlot.Parameters.Add(new SqlParameter("@slot_id", g_input3.Value));
            connection.Open();
            //g_message_box.Text = "";
            if (g_input1.Value == "" || g_input2.Value == "" || g_input3.Value == "") 
            {
                //g_message_box.Text = "Failure, one of the provided boxes was left empty, please fill it and try again";
                string script = "alert('Failure, one of the provided boxes was left empty, please fill it and try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                try
                {
                    if (linkInstructorWithCourseOnSlot.ExecuteNonQuery() == 0)
                    {
                        //g_message_box.Text = "Failure, this slot does not exist";
                        string script = "alert('Failure, this slot does not exist');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else
                    {
                        //g_message_box.Text = "Success, the Instructor was linked with the Course on the Slot";
                        string script = "alert('Success, the Instructor was linked with the Course on the Slot');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("FOREIGN KEY constraint \"FK__Slot__course_id")) 
                    {
                        //g_message_box.Text = "Failure, the entered course does not exist, please try again";
                        string script = "alert('Failure, the entered course does not exist, please try again');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else
                    {
                        //g_message_box.Text = "Failure, the entered instructor does not exist, please try again";
                        string script = "alert('Failure, the entered instructor does not exist, please try again');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                }
            }
            connection.Close();
        }

        protected void linkStudentWithAdvisor(object sender, EventArgs e)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand linkStudentWithAdvisor = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", connection);
            linkStudentWithAdvisor.CommandType = CommandType.StoredProcedure;

            linkStudentWithAdvisor.Parameters.Add(new SqlParameter("@studentID", h_input1.Value));
            linkStudentWithAdvisor.Parameters.Add(new SqlParameter("@advisorID", h_input2.Value));
            connection.Open();
            //h_message_box.Text = "";
            if (h_input1.Value == "" || h_input2.Value == "")
            {
                //h_message_box.Text = "Failure, one of the provided boxes was left empty, please fill it and try again";
                string script = "alert('Failure, one of the provided boxes was left empty, please fill it and try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                try
                {
                    if (linkStudentWithAdvisor.ExecuteNonQuery() == 0)
                    {
                        //h_message_box.Text = "Failure, the entered student does not exist, please try again";
                        string script = "alert('Failure, the entered student does not exist, please try again');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else
                    {
                        //h_message_box.Text = "Success, the Student was linked with the Advisor";
                        string script = "alert('Success, the Student was linked with the Advisor');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                }
                catch (SqlException)
                {
                    //h_message_box.Text = "Failure, the entered advisor does not exist, please try again";
                    string script = "alert('Failure, the entered advisor does not exist, please try again');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }

        }

        protected void linkStudentWithCourseWithInstructor(object sender, EventArgs e)
        {
            String ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand linkStudentWithCourseWithInstructor = new SqlCommand("Procedures_AdminLinkStudent", connection);
            linkStudentWithCourseWithInstructor.CommandType = CommandType.StoredProcedure;

            linkStudentWithCourseWithInstructor.Parameters.Add(new SqlParameter("@cours_id", i_input1.Value));
            linkStudentWithCourseWithInstructor.Parameters.Add(new SqlParameter("@instructor_id", i_input2.Value));
            linkStudentWithCourseWithInstructor.Parameters.Add(new SqlParameter("@studentID", i_input3.Value));
            linkStudentWithCourseWithInstructor.Parameters.Add(new SqlParameter("@semester_code", i_input4.Text));

            connection.Open();
            //i_message_box.Text = "";
            if (i_input1.Value == "" || i_input2.Value == "" || i_input3.Value == "" || i_input4.Text == "") 
            { 
                //i_message_box.Text = "Failure, one of the provided boxes was left empty, please fill it and try again";
                string script = "alert('Failure, one of the provided boxes was left empty, please fill it and try again');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
            else
            {
                try
                {
                    linkStudentWithCourseWithInstructor.ExecuteNonQuery();
                    //i_message_box.Text = "Success, the Student was assigned the Course with the Instructor";
                    string script = "alert('Success, the Student was assigned the Course with the Instructor');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("FOREIGN KEY constraint \"FK__Student_I__stude"))
                    {
                        //i_message_box.Text = "Failure, the entered student does not exist, please try again";
                        string script = "alert('Failure, the entered student does not exist, please try again');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else if (ex.Message.Contains("FOREIGN KEY constraint \"FK__Student_I__cours__"))
                    {
                        //i_message_box.Text = "Failure, the entered course does not exist, please try again";
                        string script = "alert('Failure, the entered course does not exist, please try again');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else if (ex.Message.Contains("FOREIGN KEY constraint \"FK__Student_I__instr"))
                    {
                        //i_message_box.Text = "Failure, the entered instructor does not exist, please try again";
                        string script = "alert('Failure, the entered instructor does not exist, please try again');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else if (ex.Message.Contains("duplicate key"))
                    {
                        //i_message_box.Text = "Failure, the entered student is already assigned this course, please try again";
                        string script = "alert('Failure, the entered student is already assigned this course, please try again');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                    else
                    {
                        string script = "alert('Failure, Unidentified Error, please try again');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                }
            }
        }

        protected void fetchActiveStudents(object sender, EventArgs e)
        {
            Response.Redirect("activeStudent.aspx");
        }
        protected void viewGradPlans(object sender, EventArgs e)
        {
            Response.Redirect("GraduationPlans.aspx");
        }
        protected void viewTranscripts(object sender, EventArgs e)
        {
            Response.Redirect("Transcript.aspx");
        }

        protected void BackToLogin(object sender, EventArgs e)
        {
            Session["id"] = null;
            Response.Redirect("~/Login/Login.aspx");
        }

        protected void ToRegistration(object sender, EventArgs e)
        {
            Response.Redirect("NewRegister.aspx");
        }
    }
}