using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject3Tier.DAL.Entities;
using LObject3Tier.DAL.Identity;

namespace LObject3Tier.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<LearningObject> LearningObjects { get; }
        //IRepository<Course> Courses { get; }

        void Save();
   
    }
}
