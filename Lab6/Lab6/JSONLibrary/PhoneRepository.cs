using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONLibrary
{
    public class PhoneRepository : IPhoneDictionary
    {
        private const string file = @"D:\ALEX\STUDY\6SEM_3COURSE\Программирование интернет серверов\Готовые лабораторные\Lab6\Lab6\JSONLibrary\PhoneDictionary.json";
        static public List<Phone> Phones { get; set; }

        public void Create(Phone item)
    {
        if (item != null) {
            if (Get(item.Id) == null) {
                var id = Phones.Count + 1;
                Phones.Add(new Phone { Id = id, Name = item.Name, Number = item.Number });

                Save();
            }
        }
    }

        public Phone Get(int id) => Phones.Find(c => c.Id == id);

        public IEnumerable < Phone > GetAll()
        {
            string jsonString = File.ReadAllText(file);
            if (jsonString.CompareTo("") != 0)
            {
                Phones = JsonConvert.DeserializeObject<List<Phone>>(jsonString).ToList();
                return Phones.OrderBy(c => c.Name).ToList();
            }
            Phones = new List<Phone>();
            return Phones;
        }

        public void Remove(Phone item)
    {
        if (item != null) {
            Phones.Remove(Get(item.Id));

            Save();
        }
    }

        public void Update(Phone item)
    {
        if (item != null) {
            Phone newContact = Get(item.Id);
            newContact.Name = item.Name;
            newContact.Number = item.Number;

            Save();
        }
    }

        public void Save()
    {
        string json = JsonConvert.SerializeObject(Phones);
        File.WriteAllText(file, json);
    }
    }
}
