using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp43
{
    public partial class SendingEmail : Form
    {
        public SendingEmail()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string to;
            string sub;
            string body;
            string attachment;
            string email;
            string password;
            to = textBox1.Text;
            sub = textBox2.Text;
            body = textBox3.Text;
            attachment = textBox4.Text;
            email = "senusandeepa17@gmail.com";
            password = "nokia6sss";
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(email, password);
            MailMessage mail = new MailMessage(email, to, sub, body);
            mail.Attachments.Add(new Attachment(textBox4.Text));
            mail.BodyEncoding = UTF8Encoding.UTF8;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            try
           {
                client.Send(mail);
                MessageBox.Show("Email sent successfully");
           }
           catch(System.Net.Mail.SmtpException )
            {
                MessageBox.Show("Failed" );
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                textBox4.Text = picPath;
            }
        }
    }
}
