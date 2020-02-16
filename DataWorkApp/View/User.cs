using DataWorkApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWorkApp.View
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string LastName { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public Role Rolee { get; private set; }

        public User GetUser(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            LastName = person.LastName;
            Login = person.Login;
            Password = person.Password;
            Rolee = person.Executors.FirstOrDefault(ex => ex.IdPerson.Equals(person.Id)) == null ? Role.Manager : Role.Executor;
            return this;
        }
    }
}
