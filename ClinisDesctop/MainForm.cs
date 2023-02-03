using ClinicSerivcenamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinisDesctop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
           
        }

        private void buttonLoadClients_Click(object sender, EventArgs e)
        {
            //ClinicServiceClient clinicServiceClient = new ClinicServiceClient("http://localhost:5154/",
            //new System.Net.Http.HttpClient());

            //ICollection<Client> clients = clinicServiceClient.GetAllAllAsync().Result;

            //listViewClients.Items.Clear();
            //foreach (Client client in clients)
            //{
            //    ListViewItem item = new ListViewItem();
            //    item.Text = client.ClientId.ToString();

            //    ListViewItem.ListViewSubItem subItemSurname = new ListViewItem.ListViewSubItem();
            //    subItemSurname.Text = client.SurName; 
            //    item.SubItems.Add(subItemSurname);

            //    ListViewItem.ListViewSubItem subItemFirstName = new ListViewItem.ListViewSubItem();
            //    subItemFirstName.Text = client.FirstName;
            //    item.SubItems.Add(subItemFirstName);

            //    ListViewItem.ListViewSubItem subItemPatronymic = new ListViewItem.ListViewSubItem();
            //    subItemPatronymic.Text = client.Patronymic;
            //    item.SubItems.Add(subItemPatronymic);

            //    listViewClients.Items.Add(item);

            //}
            timerUpdate.Start();

        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            FormAddClient formAddClient= new FormAddClient();
            formAddClient.ShowDialog();
            

        }

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            ClinicServiceClient clinicServiceClient = new ClinicServiceClient("http://localhost:5154/",
                        new System.Net.Http.HttpClient());
            foreach (ListViewItem item in listViewClients.Items) 
            {
                if (item.Selected)
                {
                    
                    clinicServiceClient.DeleteAsync(int.Parse(item.Text));
                    listViewClients.Items.Remove(item);
                    
                }
             }
            
           
        }

        private void Update_Click(object sender, EventArgs e)
        {
            ClinicServiceClient clinicServiceClient = new ClinicServiceClient("http://localhost:5154/",
                        new System.Net.Http.HttpClient());

            Client _client = new Client();
            foreach (ListViewItem item in listViewClients.Items)
            {
                if (item.Selected)
                {
                    _client = clinicServiceClient.GetByIdAsync(int.Parse(item.Text)).Result;

                }
            }

            FormUpdateClient formUpdateClient = new FormUpdateClient(_client);
            formUpdateClient.ShowDialog();
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            ClinicServiceClient clinicServiceClient = new ClinicServiceClient("http://localhost:5154/",
                   new System.Net.Http.HttpClient());

            ICollection<Client> clients = clinicServiceClient.GetAllAllAsync().Result;

            listViewClients.Items.Clear();
            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.ClientId.ToString();

                ListViewItem.ListViewSubItem subItemSurname = new ListViewItem.ListViewSubItem();
                subItemSurname.Text = client.SurName;
                item.SubItems.Add(subItemSurname);

                ListViewItem.ListViewSubItem subItemFirstName = new ListViewItem.ListViewSubItem();
                subItemFirstName.Text = client.FirstName;
                item.SubItems.Add(subItemFirstName);

                ListViewItem.ListViewSubItem subItemPatronymic = new ListViewItem.ListViewSubItem();
                subItemPatronymic.Text = client.Patronymic;
                item.SubItems.Add(subItemPatronymic);

                listViewClients.Items.Add(item);

            }
        }
    }

   


    
}
