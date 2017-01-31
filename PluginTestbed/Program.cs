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

            var plugin = container.Resolve<IPlugIn>();

            Console.WriteLine($"Plugin says {plugin.GetId()}");
        }
    }
}
