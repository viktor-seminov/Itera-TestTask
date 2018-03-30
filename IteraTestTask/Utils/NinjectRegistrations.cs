using IteraTestTask.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IteraTestTask.Utils
{
    public class NinjectRegistrations: NinjectModule
    {
        public override void Load()
        {
            Bind<IEntityRepository>().To<EntityRepository>(); //You can switch between two different Repositories (EntityRepository/DapperRepository)
        }
    }
}