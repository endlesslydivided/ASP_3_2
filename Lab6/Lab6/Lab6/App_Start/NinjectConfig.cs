//using JSONLibrary;
using DBLibrary;

using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6.App_Start
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IPhoneDictionary>().To<PhoneRepository>().InTransientScope().Named("Transient");

            Bind<IPhoneDictionary>().To<PhoneRepository>().InThreadScope().Named("Thread");

            Bind<IPhoneDictionary>().To<PhoneRepository>().InRequestScope().Named("Request");
        }
    }
}