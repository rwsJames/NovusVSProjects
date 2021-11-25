using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
namespace WebADO
{
    public partial class Default : System.Web.UI.Page
    {
        string _cnnString = ConfigurationManager.ConnectionStrings["NorthwindDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Create title
            Response.Write("<center><h1>Read data from database: </h1></center>");
            Response.Write("<br/>");
            if (!IsPostBack)
            {
                // Create content
                FillDropDownListWithCurrentCountries(ddlDemo);
            }
        }

        private void FillDropDownListWithCurrentCountries(DropDownList ddl)
        {
            // Create connection with db
            using SqlConnection cnn = new SqlConnection(_cnnString);

            // Create db-readable statement
            string sql = "SELECT DISTINCT Country FROM Customers ORDER BY Country;";
            using SqlCommand cmd = new SqlCommand(sql, cnn);

            // Open connection and execute statement
            cnn.Open();
            using SqlDataReader dr = cmd.ExecuteReader();

            ddl.Items.Add(new ListItem("Select a country...", ""));
            while (dr.Read())
                ddl.Items.Add(new ListItem(dr["Country"].ToString(), dr["Country"].ToString()));
        }

        // Fill Grid View with customers only from the entered country
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dataCustomers.SelectParameters.Clear();
            dataCustomers.SelectCommand = "SELECT * FROM Customers WHERE Country=@Country;";

            dataCustomers.SelectParameters.Add(
                new ControlParameter("Country", System.Data.DbType.String, tbSearch.ID, "Text"));

            // Reset the user's ddl selection
            ddlDemo.SelectedIndex = 0;
        }

        protected void ddlDemo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataCustomers.SelectParameters.Clear();
            dataCustomers.SelectCommand = "SELECT * FROM Customers WHERE Country=@Country;";

            dataCustomers.SelectParameters.Add(
                new ControlParameter("Country", System.Data.DbType.String, ddlDemo.ID, "SelectedValue"));

            // Reset the user's search input
            tbSearch.Text = "";
        }
    }
}