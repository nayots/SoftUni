using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

        var sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");
        foreach (FieldInfo fiel in fields.Where(f => fieldNames.Contains(f.Name)))
        {
            sb.AppendLine($"{fiel.Name} = {fiel.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        var sb = new StringBuilder();

        foreach (var field in fields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var privMeth in privateMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{privMeth.Name} have to be public!");
        }

        foreach (var pubMeth in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{pubMeth.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MemberInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        var sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");
        foreach (var privMethod in privateMethods)
        {
            sb.AppendLine(privMethod.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] gettersAndSettersMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public);

        var sb = new StringBuilder();

        foreach (var gettermethod in gettersAndSettersMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{gettermethod.Name} will return {gettermethod.ReturnType}");
        }

        foreach (var setterMethod in gettersAndSettersMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{setterMethod.Name} will set field of {setterMethod.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}