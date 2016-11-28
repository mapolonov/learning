using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LObject.Domain.Core;

//Данный проект будет реализовывать интерфейсы, объявленные на нижних уровнях,
//и связывать их с хранилищем данных.В качестве хранилища данных будет использоваться бд MS SQL Server, 
//с которой мы будем взаимодействовать через Entity Framework.Поэтому добавим в этот проект 
//через nuGet все пакеты Entity Framework.Также добавим в проект ссылки 
//на проекты OnionApp.Domain.Core и OnionApp.Domain.Interfaces.
//После этого добавим в проект новый класс OrderContext:
namespace LObject.Infrastructure.Data
{
    public class LObjectDbContext : DbContext
    {
        public DbSet<LearningObject> LearningObjects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}
