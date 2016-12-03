using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject.Domain.Core;

namespace LObject.Services.Interfaces
{
    public interface ILearningObject
    {
        void CreateLearningObject(LearningObject lObject);

        void DisableLearningObject(LearningObject lo);

        void AssignStudent(LearningObject lo, User student);

        void UnAssignStudent(LearningObject lo, User student);
    }
}
