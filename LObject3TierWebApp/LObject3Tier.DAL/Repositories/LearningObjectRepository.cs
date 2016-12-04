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
    public class LearningObjectRepository : IRepository<LearningObject>
    {
        private LObjectDbContext _dbContext;

        public LearningObjectRepository(LObjectDbContext context)
        {
            this._dbContext = context;
        }

        public IEnumerable<LearningObject> GetAll()
        {
            return _dbContext.LearningObjects.ToList();
        }

        public LearningObject Get(int id)
        {
            return _dbContext.LearningObjects.Find(id);
        }

        public void Create(LearningObject item)
        {
            _dbContext.LearningObjects.Add(item);
        }

        public void Update(LearningObject item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<LearningObject> Find(Func<LearningObject, Boolean> predicate)
        {
            return _dbContext.LearningObjects.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            LearningObject item = _dbContext.LearningObjects.Find(id);
            if (item != null)
                _dbContext.LearningObjects.Remove(item);
        }
    }
}

