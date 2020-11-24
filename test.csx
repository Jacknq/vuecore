#! "net5.0"
#r "nuget: Microsoft.NETCore.Targets, 5.0.0"
#r ".\\bin\\Debug\\net5.0\\vuecore.dll" 
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Text;
using vuecore;
//same error here when try to read types from assembly
string assemblyName = "vuecore.dll";
string assemblyPath = Environment.CurrentDirectory + "\\bin\\Debug\\net5.0\\" + assemblyName;
//string[] namespaces = new string[]{ "bVue.code.controllers","bVue.code"};
testc t = new testc();
t.print2();
ProxyDomain pd = new ProxyDomain();
//Assembly assembly = pd.GetAssembly(assemblyPath);
Assembly assembly = Assembly.ReflectionOnlyLoad(assemblyPath);

var asms = AppDomain.CurrentDomain
.GetAssemblies().Where(a=>a.GetName().Name=="vuecore").First();
//Assembly assembly = asms;//
 assembly = Assembly.GetExecutingAssembly();
wl("");
// foreach (var a in asms)
// {
//     wl(a.GetName().Name);
// }

List<Type> types = new List<Type>();
//foreach(var s in namespaces){
// foreach (var a in asms)
// {
    types = types.Concat(GetTypesInNamespace(assembly, "")).ToList();
//}
foreach (var hub in types)
{
    string hName = GetController(hub.Name);

    w(hub.Name != null ? hName : hName);
}
private string GetController(string s)
{
    return s.Replace("Controller", "", StringComparison.InvariantCultureIgnoreCase);
}

public Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
{
    return assembly.GetTypes().Where(t => t.BaseType != null && t.BaseType.Name.ToLower().EndsWith("controller")
     //&& String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)
     ).ToArray();
}
public void w(string s)
{
    Write(s);
}
public void wl(string s)
{
    WriteLine(s);
}
class ProxyDomain : MarshalByRefObject
{
    public Assembly GetAssembly(string assemblyPath)
    {
        try
        {
            return Assembly.LoadFrom(assemblyPath);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message);
        }
    }
}
//}
w("Hello world!");
