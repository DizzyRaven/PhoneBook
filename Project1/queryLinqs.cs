using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Project1
{

    public class Queries
    {
        public void nameSearch(Collection<Contact> pb, string starts)
        {
            var sorted = from t in pb
                         where t.Name.StartsWith(starts)
                         orderby t.Name
                         select t;
            Console.WriteLine("========================");
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
        }
        public void surnameSearch(Collection<Contact> pb, string starts)
        {
            var sorted = from t in pb
                         where t.Surname.StartsWith(starts)
                         orderby t.Surname
                         select t;
            Console.WriteLine("========================");
            foreach (var item in sorted)
            {
                Console.WriteLine(item);
            }
            if (sorted.ToArray().Length == 1)
                delOption(pb, sorted.First());
        }
        public void reversedSort(Collection<Contact> pb)
        {
            var sorted = from t in pb
                         orderby t.Name
                         select t;
            Console.WriteLine("========================");
            foreach (var item in sorted.Reverse())
            {
                Console.WriteLine(item);
            }
        }
        public void delOption(Collection<Contact> pb, Contact contact)
        {
            Console.WriteLine("Put R to remove or 0 to Exit");
            string s = Console.ReadLine();
            if(s=="r" || s == "R")
            {
                Console.WriteLine("Contact "+contact.Name+" "+ contact.Surname+" have been removed!");
                pb.Remove(contact);
                serialisation(pb);
            }
                
        }
        public void getMail(Collection<Contact> pb)
        {
            var sorted = from t in pb
                         orderby t.Email
                         select t;
            Console.WriteLine("========================");
            foreach (var item in sorted)
            {

                if (item.Email.Trim() != "")
                {
                    Console.Write(item.Name + " " + item.Surname.First() +". - ");
                    Console.WriteLine(item.Email);
                }
            }
        }
        public Collection<Contact> addNew(Collection<Contact> pb, string name, string surname, string phone, string email)
        {
            if (name.Trim() != "" && surname.Trim() != "")
            {
                pb.Add(new Contact(name, surname, phone, email));
                serialisation(pb);
                Console.WriteLine("Added!");
            }
            else
                Console.WriteLine("Name and surname can't be empty!!!");
            return pb;
        }
        public Collection<Contact> remove(Collection<Contact> pb, string name, string surname, string phone, string email)
        {
            pb.Remove(new Contact(name, surname, phone, email));
            serialisation(pb);
            return pb;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        public void serialisation(Collection<Contact> pb)
        {


            using (FileStream fs = new FileStream("phonebook.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, pb);
            }
            pb.Distinct();
        }
    }
}
