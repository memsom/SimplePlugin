using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace AnotherPlugin
{
    public class Bootstrapper : Base, IBootstrap
    {
        public void Initialise(IWindsorContainer container)
        {
            container.Register(Component.For<IPlugIn>().ImplementedBy<SuperPlugin>().LifeStyle.Transient);

            container.Register(Component.For<IDataProcessor>().Instance(new DataProcessor()));
            container.Register(Component.For<IGetData>().ImplementedBy<GetData>().LifeStyle.Singleton);
            container.Register(Component.For<IAddData>().ImplementedBy<AddData>().LifeStyle.Singleton);
            container.Register(Component.For<IDataStore>().ImplementedBy<AnotherDataStore>().LifeStyle.Transient);
        }
    }
}
