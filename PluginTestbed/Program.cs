using Castle.Windsor;
using RatCow.SimplePlugin.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PluginTestbed
{
    class Program
    {
        static Type Get(Assembly assembly, Type type)
        {
            return assembly.GetTypes()
                .Where(p => type.IsAssignableFrom(p))
                .FirstOrDefault();
        }

        static void Main(string[] args)
        {
            var container = new WindsorContainer();

            var assembly = Assembly.LoadFile(Path.Combine(Environment.CurrentDirectory, Properties.Settings.Default.Plugin));

            var bootstrapperType = Get(assembly, typeof(IBootstrap));

            using (var bootstrap = (IBootstrap)Activator.CreateInstance(bootstrapperType))
            {
                bootstrap.Initialise(container);
            }

            if (container.Kernel.HasComponent(typeof(IPlugIn)))
            {
                var plugin = container.Resolve<IPlugIn>();

                Console.WriteLine($"Plugin says {plugin.GetId()}");
            }
            
            if (container.Kernel.HasComponent(typeof(IDataStore)))
            {
                var dataStore = container.Resolve<IDataStore>();
                dataStore.DataAdded += (s, e) =>
                {
                    Console.WriteLine($"Data added :: ID {e.Id.Id.ToString()}, DataId {e.DataId.Id.ToString()}, Success {e.Success}");
                    var result = dataStore.Retrieve(e.DataId);
                    Console.WriteLine($"Retrieve requested :: {result.Id.ToString()}");
                };

                dataStore.DataRetrieved += (s, e) =>
                {
                    Console.WriteLine($"Data retieved :: ID {e.Id.Id.ToString()}, Data {e.Data}, Success {e.Success}");
                };

                dataStore.Add("Hello, world");
            }

            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}
