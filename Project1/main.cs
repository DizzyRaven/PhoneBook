using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;

namespace Project1
{
    class program
    {
        static void Main()
        {
            program m = new program();
            /* Uncoment if .dat file is empty
            Collection<Contact> startPb = new Collection<Contact>();
            startPb.Add(new Contact("Ilya", "Bondar", "12312412532", "asdasd@gmail,com"));
            m.serialisation(startPb);*/
            m.consoleUI();
        }
        public void consoleUI()
        {
            program m = new program();
            Queries query = new Queries();
            Collection<Contact> myPhoneBook = deserilizetion();


            string s = "";
            string input;
            Console.WriteLine("Welcom to PhoneBook DB!\n");

            while (s != "0")
            {
                myPhoneBook = deserilizetion();
                Console.WriteLine("========================");
                Console.WriteLine("Please, enter the numer of operation you would like to chose\n" +
                              "1. Search by Name\n" +
                              "2. Search by Surname\n" +
                              "3. Add new contact\n" +
                              "4. Sorry, not working\n" +
                              "5. Show reversed\n" +
                              "6. Get all email-addresses\n"+
                              "0. EXIT\n");
                s = Console.ReadLine();
                switch (s)
                {
                    case ("1"):
                        Console.Write("Enter first letter of name: ");
                        input = Console.ReadLine();
                        query.nameSearch(myPhoneBook, input);
                        break;
                    case ("2"):
                        Console.Write("Enter first letter of surname: ");
                        input = Console.ReadLine();
                        query.surnameSearch(myPhoneBook, input);
                        break;
                    case ("3"):
                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Surname: ");
                        string surname = Console.ReadLine();
                        Console.WriteLine("PhoneNumber: ");
                        string phone = Console.ReadLine();
                        Console.WriteLine("Email: ");
                        string email = Console.ReadLine();
                        query.addNew(myPhoneBook, name, surname, phone, email);
                        break;
                    case ("4"):
                        //=====
                        break;
                    case ("5"):
                        query.reversedSort(myPhoneBook);
                        break;
                    case ("6"):
                        query.getMail(myPhoneBook);
                        break;
                    case ("0"):
                        Console.WriteLine("EXITING...");
                        break;
                    default:
                        Console.WriteLine("No such operation!");
                        break;
                }
            }

        }
        Collection<Contact> deserilizetion()
        {
            // десериализация
            BinaryFormatter formatter = new BinaryFormatter();
            Collection<Contact> pb = new Collection<Contact>();
            using (FileStream fs = new FileStream("phonebook.dat", FileMode.OpenOrCreate))
            {
                Collection<Contact> deserilizePeople = (Collection<Contact>)formatter.Deserialize(fs);

                foreach (Contact p in deserilizePeople)
                {
                    pb.Add(p);
                }
            }
            return pb;
        }
        public void serialisation(Collection<Contact> pb)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("phonebook.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, pb);
            }
            pb.Distinct();
        }



    }
}
