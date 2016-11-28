using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject.Domain.Core;

namespace LObject.Domain.Interfaces
{
    public interface ILearningObjectRepository : IDisposable
    {
        IEnumerable<LearningObject> GetLearningObjectList();
        LearningObject GetLearningObject(int id);
        void Create(LearningObject item);
        void Update(LearningObject item);
        void Delete(int id);
        void Save();
    }
}
