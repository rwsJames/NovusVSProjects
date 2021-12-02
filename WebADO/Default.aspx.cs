using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                FillDropDownListWithCurrentCountries(ddlDemo);
            }
            newDataInputArea.Visible = false;
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

            ddl.Items.Add(new ListItem("All Countries", "_"));
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

        private void SelectFromControl(Control control)
        {
            string country =
                control is DropDownList ddl ?
                    ddl.SelectedValue
                : control is TextBox tb ?
                    tb.Text
                : "";

            dataCustomers.SelectParameters.Clear();
            if (country.Equals(""))
            {
                dataCustomers.SelectCommand = "SELECT * FROM Customers;";
            }
            else
            {
                dataCustomers.SelectCommand = "SELECT * FROM Customers WHERE Country=@Country;";
                dataCustomers.SelectParameters.Add(
                    new ControlParameter("Country", control.ID));
            }
        }

        protected void ddlDemo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectFromControl(ddlDemo);
            // Reset the user's search input
            tbSearch.Text = "";
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ddlDemo.SelectedValue != "_")
                SelectFromControl(ddlDemo);
            else
                SelectFromControl(tbSearch);
        }

        protected void DetailsView1_Load(object sender, EventArgs e)
        {
            newDataInputArea.Visible = true;
        }
    }
}