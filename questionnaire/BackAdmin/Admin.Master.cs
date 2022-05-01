using questionnaire.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace questionnaire.BackAdmin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        private AccountManager _mgrAccount = new AccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            this._mgrAccount.Logout();
            Response.Redirect("../Login.aspx");
        }
    }
}