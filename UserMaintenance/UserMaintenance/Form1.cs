using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            labelFullName.Text = Resource1.FullName;
            buttonAdd.Text = Resource1.Add;
            buttonWriteOut.Text = Resource1.WriteOut;

            listBoxUsers.DataSource = users;
            listBoxUsers.DisplayMember = "FullName";
            listBoxUsers.ValueMember = "ID";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBoxFullName.Text
            };
            users.Add(u);
            textBoxFullName.Clear();
        }

        private void buttonWriteOut_Click(object sender, EventArgs e)
        {
            //StreamWriter sw;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            save.FilterIndex = 2;
            save.DefaultExt = "txt";
            try
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(save.FileName))
                    {
                        foreach (var item in users)
                        {
                            sw.Write("ID: ");
                            sw.Write(item.ID);
                            sw.Write(" Teljes név: ");
                            sw.Write(item.FullName);
                            sw.WriteLine();
                        }
                    }
                    MessageBox.Show("Sikeres fájlbaírás!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
