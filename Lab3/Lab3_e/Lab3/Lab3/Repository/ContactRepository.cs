using Lab3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Lab3.Repository
{
    public class ContactRepository : IRepository<Contact>
    {
        string path = HostingEnvironment.MapPath("~/App_Data/Contacts.json");
        static public List<Contact> Contacts { get; set; }

        public void Create(Contact item)
        {
            if (item != null)
            {
                if (Get(item.Id) == null)
                {
                    var id = Contacts.Count + 1;
                    Contacts.Add(new Contact { Id = id, Name = item.Name, Phone = item.Phone });

                    Save();
                }
            }
        }

        public Contact Get(int id)
        {
            return Contacts.Find(c => c.Id == id);
        }


        public IEnumerable<Contact> GetAll()
        {
            string jsonString = File.ReadAllText(path);
            if (jsonString.CompareTo("") != 0)
                Contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonString).ToList();
            else
                Contacts = new List<Contact>();
            return Contacts.OrderBy(c => c.Name).ToList();
        }

        public void Remove(Contact item)
        {
            if (item != null)
            {
                Contacts.Remove(Get(item.Id));

                Save();
            }
        }

        public void Update(Contact item)
        {
            if (item != null)
            {
                Contact newContact = Get(item.Id);
                newContact.Name = item.Name;
                newContact.Phone = item.Phone;

                Save();
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(path, json);
        }
    }
}