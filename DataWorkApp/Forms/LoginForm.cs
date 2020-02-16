using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWorkApp.Entity;
using DataWorkApp.View;

namespace DataWorkApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DataBase())
                {
                    var user = context.Person.FirstOrDefault(person => person.Login.Equals(textBox1.Text) && person.Password.Equals(textBox2.Text));
                    if (user == null) throw new Exception("Enter close");

                    this.Hide();
                    Singleton<User>.Instance().GetUser(user).GetForm().Show();
                }
            }
            catch(Exception ex)
            {
                if(ex.Message.ToString()=="Enter close")
                MessageBox.Show("Enter close","No",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
    }
}
