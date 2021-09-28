using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            labelFirstName.Text = Resource1.FirstName;
            labelLastName.Text = Resource1.LastName;
            buttonAdd.Text = Resource1.Add;

            listBoxUsers.DataSource = users;
            listBoxUsers.DisplayMember = "FullName";
            listBoxUsers.ValueMember = "ID";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FirstName = textBoxFirstName.Text,
                LastName = textBoxLastName.Text
            };
        users.Add(u);
        }
    }
}
