using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhoneBookCrud.Models;

namespace PhoneBookCrud.Controllers
{
    public class ContactController : ApiController
    {
       List<Contact> contacts = new List<Contact>();
        [HttpPost]
        public bool addContact(Contact c)
        {

            try
            {
                StreamWriter writer = new StreamWriter("C:/PhoneBook.txt",true);
                writer.Write(c.name + "," + c.contactNumber + "," + c.dob + "," + c.email + "," + c.saveOn + "\n");             
                writer.Flush();
                writer.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public void write(List<Contact> contacts1)
        {
            try
            {
                StreamWriter writer = new StreamWriter("C:/PhoneBook.txt");
                string output = "";
                for (int i = 0; i < contacts1.Count; i++)
                {
                    output = output + contacts1[i].name + "," + contacts1[i].contactNumber + "," + contacts1[i].dob + "," + contacts1[i].email + "," + contacts1[i].saveOn + "\n";
                }
                writer.Write(output);
                writer.Flush();
                writer.Close();              
            }
            catch (Exception ex)
            {
              

            }
        }

[HttpGet]
        public List<Contact> AllContactList()
        {
         
            StreamReader streamReader = new StreamReader("C:/PhoneBook.txt");
            string line = streamReader.ReadLine();
            while(line!=null)
            {
                string[] tokens = line.Split(',');
                Contact contact = new Contact();
                contact.name = tokens[0];
                contact.contactNumber = tokens[1];
                DateTime dateTime = DateTime.Parse(tokens[2]);
                contact.dob = dateTime;
                contact.email = tokens[3];
                dateTime = DateTime.Parse(tokens[4]);
                contact.saveOn = dateTime;
                contacts.Add(contact);
                line = streamReader.ReadLine();

            }
            return contacts;
        }


        private int searchContact(String number)
        {
            contacts = AllContactList();
            int index = -1;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].contactNumber==number)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public Contact getContact(String number)
        {

            contacts = AllContactList();
            int index = searchContact(number);
            return contacts[index];
        }


        [HttpPut]
        public bool updateContact(String number, Contact c)
        {
            contacts = AllContactList();
            int index = searchContact(number);

            if (index == -1)
                return false;
            else
            {
                contacts[index]=c;
                write(contacts);
                return true;
            }
        }
        [HttpPost]
        public bool deleteContact(String number)
        {
            int index = searchContact(number);

            if (index == -1)
                return false;
            else
            {
                contacts.RemoveAt(index);
                write(contacts);
                return true;
            }
        }



    }


}
