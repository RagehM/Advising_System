﻿using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Milestone_3
{
    public partial class Transcript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["MainConnection"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand retriveAdvisors = new SqlCommand("select* from Students_Courses_transcript  ", connection);

            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(retriveAdvisors);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            View_Students.DataSource = dataTable;
            View_Students.DataBind();
        }
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}