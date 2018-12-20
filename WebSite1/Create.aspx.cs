using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web.Mail;
using System.Activities.Expressions;

public partial class Create : System.Web.UI.Page
{   connect cn = new connect();
    string time, email, datein, event_date, event_time, event_title;

    protected void Page_Load(object sender, EventArgs e)
    {
        cn.start();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        time = ddlHr.SelectedItem.Value + ":" + ddlMnt.SelectedItem.Value + ":" + ddlsec.SelectedItem.Value + ":" + ddlam.SelectedItem.Value;
        cn.dml("insert into Reminder_1 (date,event,edate,time,email) values('" + DateTime.Now.ToLongDateString() + "','" + txtevent.Text.ToString() + "','" + txtdate.Text.ToString() + "','" + txtemail.Text.ToString() + "')");
        Response.Write("<script>alert('Your Request Has Been Send');window.location='Home.aspx';</script>");
        datein = DateTime.Now.ToLongDateString();
        cn.dr = cn.read("select date,event,edate,time,email from Remainder_1");
        if(cn.dr.Read())
        {
            time =cn.dr.GetValue(0).ToString();
            event_title= cn.dr.GetValue(1).ToString();
            event_date= cn.dr.GetValue(2).ToString();
            event_time= cn.dr.GetValue(3).ToString();
            email= cn.dr.GetValue(4).ToString();
            if(datein == DateTime.Now.ToLongDateString())
            {
                /*System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To = email;
                msg.From='aryadrishya03@gmail.com';
                msg.Subject = "Just a Reminder for  " + event_title;
                msg.BodyFormat = MailFormat.Html;
                msg.Body =
                "Here is your reminder not to miss " + event_title +
                " on " + event_date + " at " + event_time;

                SmtpMail.Send(msg);*/
                SmtpClient smtpClient = new SmtpClient("domain.a2hosted.com", 25);

                smtpClient.Credentials = new System.Net.NetworkCredential("user@example.com", "password");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.Subject = event_title.ToString();
                mailMessage.Body = "Here is your reminder not to miss " + event_title +
                " on " + event_date + " at " + event_time;
               /* Dim smtpClient As SmtpClient = New SmtpClient("domain.a2hosted.com", 25)

                     smtpClient.Credentials = System.Activities.Expressions.New System.Net.NetworkCredential("user@example.com", "password")
                       smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network

                        Dim mailMessage As MailMessage = New MailMessage()
                        mailMessage.Subject = txtSubject.Text
                        mailMessage.Body = txtBody.Text

                        Try
                         smtpClient.Send(mailMessage)
                          Label1.Text = "Message sent"
                         Catch ex As Exception
           
                         End Try
             */
            }
            cn.dr.Close();
        }
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