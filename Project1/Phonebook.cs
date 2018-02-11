using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System;
using System.IO;


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
    class serial
    {
        public Collection<Contact> deserilizetion()
        {
            /*// десериализация
            XmlSerializer formatter = new XmlSerializer(typeof(Collection<Contact>));
            Collection<Contact> pb = new Collection<Contact>();
            using (FileStream fs = new FileStream("phonebook.xml", FileMode.OpenOrCreate))
            {
                Collection<Contact> deserilizePeople = (Collection<Contact>)formatter.Deserialize(fs);

                foreach (Contact p in deserilizePeople)
                {
                    pb.Add(p);
                }
            }*/
            Collection<Contact> pb = new Collection<Contact>();
            return pb;
        }
        public void serialisation(Collection<Contact> pb)
        {
           XmlSerializer formatter = new XmlSerializer(typeof(Collection<Contact>));

            FileStream fs1 = new FileStream("phonebook.xml", FileMode.OpenOrCreate);
            {
                formatter.Serialize(fs1, pb);
            }
            pb.Distinct();
        }

    }
}

