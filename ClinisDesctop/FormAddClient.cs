using ClinicSerivcenamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinisDesctop
{
    public partial class FormAddClient : Form
    {
        
        public FormAddClient()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            CreateClientRequest client = new CreateClientRequest();
            client.FirstName = textBoxName.Text;
            client.SurName = textBoxSurName.Text;
            client.Patronymic = textBoxPatronymic.Text;
            client.Document = textBoxDocument.Text;


            if (textBoxBirthday.Text.Contains('.'))
            {
                string[] s = textBoxBirthday.Text.Split('.');
                client.Birthday = new DateTime(Int32.Parse(s[2]), Int32.Parse(s[1]), Int32.Parse(s[0]));
            }
            else if (textBoxBirthday.Text.Contains('/'))
            {
                string[] s = textBoxBirthday.Text.Split('/');
                client.Birthday = new DateTime(Int32.Parse(s[2]), Int32.Parse(s[1]), Int32.Parse(s[0]));
            }
            else
            {
                client.Birthday = new DateTime(1960, 1, 1);
            }



            ClinicServiceClient clinicServiceClient = new ClinicServiceClient("http://localhost:5154/",
           new System.Net.Http.HttpClient());

            clinicServiceClient.CreateAsync(client);
 
            Close();

        }

       
    }
}
