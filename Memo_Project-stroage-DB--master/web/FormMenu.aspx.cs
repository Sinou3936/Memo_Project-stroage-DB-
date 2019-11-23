using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebStreamApi
{
    public partial class FormMenu : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            Local.PostBackUrl = "~/FormStorage.aspx";
            DBConnect.PostBackUrl = "~/FormDB.aspx";
            
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
           

        }
    }
}