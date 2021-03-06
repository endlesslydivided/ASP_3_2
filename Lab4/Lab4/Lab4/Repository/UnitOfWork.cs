using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Repository
{
    public class UnitOfWork : IDisposable
    {
        private СontactDBContext db = new СontactDBContext();
        private Repository<Contact> contactRepository;

        public Repository<Contact> ContactRepository
        {
            get
            {
                if (contactRepository == null)
                    contactRepository = new Repository<Contact>(db);
                return contactRepository;
            }
        }

       

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

