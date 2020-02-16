using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWorkApp.Entity;

namespace DataWorkApp
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new DataBase())
            {
                context.Person.Add(new Person
                {
                    FirstName = Fn.Text,
                    SecondName = Sn.Text,
                    LastName = LN.Name,
                    Login = Log.Text,
                    Password = Pas.Text
                });
                context.SaveChanges();
            }
            if (ManagerButton.Checked)
            {
                using (var context=new DataBase())
                {
                    context.Person.Load();
                    context.Manager.Add(new Manager
                    {
                        IdPerson = context.Person.Local.Last().Id,
                        CoefficientId = 1,
                        SalaryId =1
                    });
                    context.SaveChanges();
                }
            }
            MessageBox.Show("Пользователь добавлен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var context= new DataBase())
            {
                Int32 IdPers = int.Parse(IdBox.Text);
                var personDel = context.Person.FirstOrDefault(pers => pers.Id == IdPers);
                var managerDel = context.Manager.FirstOrDefault(pers => pers.IdPerson == IdPers);

                context.Manager.Remove(managerDel);
                context.Person.Remove(personDel);
                context.SaveChanges();
            }
            MessageBox.Show("Пользователь удалён","Succesful",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
