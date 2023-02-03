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
    public partial class FormUpdateClient : Form
    {
        Client _client = new Client();
        public FormUpdateClient()
        {
            InitializeComponent();
        }

        public FormUpdateClient(Client client)
        {   
            _client = client;
            InitializeComponent();
            textBoxSurName.Text = _client.SurName;
            textBoxName.Text = _client.FirstName;
            textBoxPatronymic.Text = _client.Patronymic;
            textBoxDocument.Text = _client.Document;
            textBoxBirthday.Text = _client.Birthday.Date.ToShortDateString();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
           

            UpdateClientRequest client = new UpdateClientRequest();
            client.ClientId = _client.ClientId;
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

            clinicServiceClient.UpdateAsync(client);

            Close();
        }
    }
}
