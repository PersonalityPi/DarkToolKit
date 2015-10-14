﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkPluginLib;
using System.IO;
using System.Reflection;

namespace DarkToolKit
{
    public static class PluginLoader
    {
        public static ICollection<DarkPlugin> plugins;
        public static ICollection<DarkPlugin> LoadPlugins(string path)
        {
            string[] dllFileNames = null;

            if (Directory.Exists(path))
            {
                dllFileNames = Directory.GetFiles(path, "*.dll");

                ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
 
                foreach (string dllFile in dllFileNames)
                {
                    
                   // AssemblyName an = AssemblyName.GetAssemblyName(dllFile);

                   // Assembly assembly = Assembly.Load(an);
            

                    byte[] assemblyBytes = File.ReadAllBytes(dllFile);
                    Assembly assembly = Assembly.Load(assemblyBytes);  
                    assemblies.Add(assembly);
                }

                Type pluginType = typeof(DarkPlugin);
                ICollection<Type> pluginTypes = new List<Type>();
                foreach (Assembly assembly in assemblies)
                {
                    if (assembly != null)
                    {
                        Type[] types = assembly.GetTypes();

                        foreach (Type type in types)
                        {
                            if (type.IsInterface || type.IsAbstract)
                            {
                                continue;
                            }
                            else
                            {
                                if (type.GetInterface(pluginType.FullName) != null)
                                {
                                    pluginTypes.Add(type);
                                }
                            }
                        }
                    }
                }

                plugins = new List<DarkPlugin>(pluginTypes.Count);
                foreach (Type type in pluginTypes)
                {
                    DarkPlugin plugin = (DarkPlugin)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }
                return plugins;
            }
            return null;
        }
    }
}
