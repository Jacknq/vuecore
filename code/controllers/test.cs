using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
//using TextTemplating;
namespace vuecore
{
    public class testc
    {
        public void print()
        {
            string assemblyName = "vuecore.dll";
            string assemblyPath = Environment.CurrentDirectory + "\\bin\\Debug\\net5.0\\" + assemblyName;
            //string[] namespaces = new string[]{ "bVue.code.controllers","bVue.code"};
            // Assembly.GetExecutingAssembly();
            //var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
           // var assembly =  AssemblyLoadContext.GetLoadContext(Assembly.LoadFile(assemblyPath)).LoadFromAssemblyPath(assemblyPath);
         //   AssemblyLoadContext.GetLoadContext(Assembly.GetExecutingAssembly()).LoadFromAssemblyPath(path)

            List<Type> types = new List<Type>();
            //foreach(var s in namespaces){
            types = types.Concat(GetTypesInNamespace(assembly, "")).ToList();
            foreach (var hub in types)
            {
                string hName = GetController(hub.Name);


                /** * The hub implemented by <#=hub.FullName#>    */
                string s = hub.Name != null ? hName : hName;
                Console.WriteLine(s);
            }
        }

        public void print2()
        {
            Console.Write("test class call");
        }

        public void tt()
        {
            string assemblyPath =""; 
            var fs = new FileStream(assemblyPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var peReader = new PEReader(fs);

            MetadataReader mr = peReader.GetMetadataReader();
            using (fs)
            {
                using (peReader)
                {
                    foreach (TypeDefinitionHandle tdefh in mr.TypeDefinitions)
                    {
                        TypeDefinition tdef = mr.GetTypeDefinition(tdefh);
                        TypeDefinition b = mr.GetTypeDefinition((TypeDefinitionHandle)tdef.BaseType );
                        b.ToString();
                       // tdef.Attributes.
                       var c = tdef.GetMethods();
                       if(c.Count>0)
                       {
                          var m=  tdef.GetMethods().First();
                          var mm = mr.GetMethodDefinition(m);
                       //   mm.Name.
                       }
                        // var b = tdef.Name.BaseType;
                       //    Type.GetTypeFromHandle(b).Name
                      // b.
                        string ns = mr.GetString(tdef.Namespace);
                        string name = mr.GetString(tdef.Name);
                       string ss = tdef.BaseType.GetType().ToString();
                    //    tdef.BaseType.Kind.ToString()
                        //.GetTypeDefinition(tdef.BaseType);
                        Console.WriteLine($"{ns}.{name}");
                    }
                }
            }
        }

        public Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => t.BaseType != null && t.BaseType.Name.ToLower().EndsWith("controller")
             //&& String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)
             ).ToArray();
        }
        private string GetController(string s)
        {
            return s.Replace("Controller", "", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}