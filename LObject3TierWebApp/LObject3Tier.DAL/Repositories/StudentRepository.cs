using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.EF;
using LObject3Tier.DAL.Entities;
using LObject3Tier.DAL.Interfaces;

namespace LObject3Tier.DAL.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private LObjectDbContext _dbContext;

        public StudentRepository(LObjectDbContext context)
        {
            this._dbContext = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _dbContext.Students;
        }

        public Student Get(int id)
        {
            return _dbContext.Students.Find(id);
        }

        public void Create(Student item)
        {
            _dbContext.Students.Add(item);
        }

        public void Update(Student item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Student> Find(Func<Student, Boolean> predicate)
        {
            return _dbContext.Students.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Student item = _dbContext.Students.Find(id);
            if (item != null)
                _dbContext.Students.Remove(item);
        }
    }
}

