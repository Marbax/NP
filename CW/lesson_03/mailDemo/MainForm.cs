using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace mailDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            MailAddress fromM = new MailAddress(tbMailFrom.Text);
            MailAddress toM = new MailAddress(tbToMail.Text);


            using (MailMessage msg = new MailMessage(fromM, toM))
            {
                msg.Subject = tbTheme.Text;
                msg.Body = tbTheme.Text;

                SmtpClient smtp = new SmtpClient(tbServer.Text, (int)nudPort.Value);
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(tbMailFrom.Text, tbPass.Text);
                smtp.EnableSsl = cbSSL.Checked;
                //smtp.Timeout = 200;

                try
                {
                    //smtp.SendAsync(msg, "test");
                    smtp.Send(msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show(ex.Message, "Error!");
                }
            }
        }

        private void nudPort_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
