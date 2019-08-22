using PluginBase;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace WPFPluginLoadProblem
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            PluginLoadContext firstPluginCtx = new PluginLoadContext(
                Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), @"..\..\..\..\FirstPlugin\bin\Debug\netcoreapp3.0\FirstPlugin.dll"));
            using (firstPluginCtx.EnterContextualReflection())
            {
                IPlugin firstPlugin = (IPlugin)firstPluginCtx.PluginAssembly.CreateInstance("FirstPlugin.FirstPlugin");
                firstPlugin.Run();
            }

            PluginLoadContext secondPluginCtx = new PluginLoadContext(
                Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), @"..\..\..\..\SecondPlugin\bin\Debug\netcoreapp3.0\SecondPlugin.dll"));
            using (secondPluginCtx.EnterContextualReflection())
            {
                IPlugin secondPlugin = (IPlugin)secondPluginCtx.PluginAssembly.CreateInstance("SecondPlugin.SecondPlugin");
                secondPlugin.Run();
            }
        }
    }

    class PluginLoadContext : AssemblyLoadContext
    {
        private AssemblyDependencyResolver _resolver;
        public Assembly PluginAssembly { get; }

        public PluginLoadContext(string pluginPath)
        {
            _resolver = new AssemblyDependencyResolver(pluginPath);
            PluginAssembly = LoadFromAssemblyPath(pluginPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            string path = _resolver.ResolveAssemblyToPath(assemblyName);
            if (path != null)
            {
                return LoadFromAssemblyPath(path);
            }

            return null;
        }
    }
}
