using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LObject.Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private LObjectDbContext _db = new LObjectDbContext();
        private LearningObjectRepository _loRepository;
 
        public LearningObjectRepository LearningObject
        {
            get
            {
                if (_loRepository == null)
                    _loRepository = new LearningObjectRepository(_db);
                return _loRepository;
            }
        }
 
        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
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
