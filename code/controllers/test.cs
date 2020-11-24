using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
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
        Assembly assembly = Assembly.LoadFrom(assemblyPath);

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