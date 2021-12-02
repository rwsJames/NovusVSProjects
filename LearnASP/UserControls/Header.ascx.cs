using System;

namespace LearnASP.UserControls
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDateNow.Text = DateTime.Now.ToLongDateString();
        }
    }
}