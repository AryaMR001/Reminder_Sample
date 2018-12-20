using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Delete : System.Web.UI.Page
{
    connect cn = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.start();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        cn.dml("delete from Reminder_1");
    }
}