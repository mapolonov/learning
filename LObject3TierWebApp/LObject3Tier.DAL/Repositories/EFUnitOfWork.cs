using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.EF;
using LObject3Tier.DAL.Entities;
using LObject3Tier.DAL.Interfaces;

namespace LObject3Tier.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private LObjectDbContext _dbContext;
        private LearningObjectRepository _loRepository;
        //private StudentRepository _studentRepository;
        private bool _disposed = false;

            
        public EFUnitOfWork(string connectionString)
        {
            _dbContext = new LObjectDbContext(connectionString);
        }

        public IRepository<LearningObject> LearningObjects
        {
            get { return _loRepository ?? (_loRepository = new LearningObjectRepository(_dbContext)); }
        }

        //public IRepository<Student> Students
        //{
        //    get { return _studentRepository ?? (_studentRepository = new StudentRepository(_dbContext)); }
        //}

       
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
