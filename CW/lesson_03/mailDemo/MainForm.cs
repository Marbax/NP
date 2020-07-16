using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

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
                foreach (var item in cbFiles.Items)
                    msg.Attachments.Add(new Attachment(item as string));

                SmtpClient smtp = new SmtpClient(tbServer.Text, (int)nudPort.Value);
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(tbMailFrom.Text, tbPass.Text);
                smtp.EnableSsl = cbSSL.Checked;
                smtp.Timeout = 200;

                try
                {
                    smtp.SendAsync(msg, "test");
                    //smtp.Send(msg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show(ex.Message, "Error!");
                }
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
                cbFiles.Items.Add(OPF.FileName);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cbFiles.SelectedIndex != -1)
                cbFiles.Items.RemoveAt(cbFiles.SelectedIndex);
        }
    }
}
