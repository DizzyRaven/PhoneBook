using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project1
{
    [Serializable]
    public class Contact
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public Contact(string name, string surname, string phone, string email)
        {
            this.Name = name;
            this.Surname = surname;
            this.Phone = phone;
            this.Email = email;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}\nPhone: {2}\nEmail: {3}\n========================", Name, Surname, Phone, Email);
        }

    }
}
