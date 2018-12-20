using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Update : System.Web.UI.Page
{
    connect cn = new connect();
    string time, email, datein, event_date, event_time, event_title;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.start();
        cn.dr = cn.read("select date,event,edate,time,email from Remainder_1");
        if (cn.dr.Read())
        {
            time = cn.dr.GetValue(0).ToString();
            event_title = cn.dr.GetValue(1).ToString();
            event_date = cn.dr.GetValue(2).ToString();
            event_time = cn.dr.GetValue(3).ToString();
            email = cn.dr.GetValue(4).ToString();
        }
        cn.dr.Close();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        cn.dml("update Reminder_1 set(date='" + DateTime.Now.ToLongDateString() + "',event='" + txtevent.Text.ToString() + "',edate='" + txtdate.Text.ToString() + "',time='" + time + "',email='" + txtemail.Text.ToString() + "')");
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        txtdate.Text = "";
        txtemail.Text = "";
        txtevent.Text = "";
        ddlam.Items.Remove(ddlam.SelectedItem);
        ddlHr.Items.Remove(ddlHr.SelectedItem);
        ddlMnt.Items.Remove(ddlMnt.SelectedItem);
        ddlsec.Items.Remove(ddlsec.SelectedItem);
    }
}