using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary
{
    public interface IPhoneDictionary
    {
        IEnumerable<Phone> GetAll();
        Phone Get(int id);
        void Create(Phone item);
        void Remove(Phone item);
        void Update(Phone item);
    }
}
