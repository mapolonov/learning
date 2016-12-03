using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject.Domain.Core;
using LObject.Domain.Interfaces;

namespace LObject.Infrastructure.Data
{
    public class LearningObjectRepository : ILearningObjectRepository
    {
        private LObjectDbContext db;
        private bool disposed = false;

        public LearningObjectRepository()
        {
            this.db = new LObjectDbContext();
        }

        public LearningObjectRepository(LObjectDbContext dbcontext)
        {
            this.db = dbcontext;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<LearningObject> GetAll()
        {
            throw new NotImplementedException();
        }

        public LearningObject Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(LearningObject item)
        {
            throw new NotImplementedException();
        }

        public void Update(LearningObject item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}
