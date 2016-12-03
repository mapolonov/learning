using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.Entities;

namespace LObject3Tier.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<LearningObject> LearningObjects { get; }
        IRepository<Student> Students { get; }
        void Save();
    }
}
