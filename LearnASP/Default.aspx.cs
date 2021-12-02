using System;
using System.Collections.Generic;
using System.Web.UI;

namespace LearnASP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            Control ctrl = Page.LoadControl("~/UserControls/Header.ascx");
            phHeader.Controls.Add(ctrl);

            List<string> names = new List<string>()
            {
                "John Doe",
                "John Jean",
                "Sam Clue",
                "Harry Berg"
            };
            gvCustomers.DataSource = names;
            gvCustomers.DataBind();
            blCustomers.DataSource = names;
            blCustomers.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                string fname = tbFirstName.Text;
                string lname = tbLastName.Text;
                string state = ddlState.SelectedValue;
                string email = tbEmail.Text;
                string birthday = tbBirthday.Text;

                labelOutput.Text = fname + " | " + lname + " | " + email + " | " + birthday + " | " + state;
            }
        }
    }
}