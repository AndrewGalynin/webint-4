using System;
using System.Reflection;

class MyClass
{
    private int privateField;
    public string publicField;
    protected double protectedField;
    internal bool internalField;
    public static string staticField;

    public MyClass(int privateField, string publicField, double protectedField, bool internalField)
    {
        this.privateField = privateField;
        this.publicField = publicField;
        this.protectedField = protectedField;
        this.internalField = internalField;
    }

    private void PrivateMethod()
    {
        Console.WriteLine("Private Method");
    }

    public void PublicMethod(int parameter)
    {
        Console.WriteLine($"Public Method with parameter: {parameter}");
    }

    protected string ProtectedMethod(string input)
    {
        return $"Protected Method with input: {input}";
    }
}

class Program
{
    static void Main()
    {
        MyClass myObject = new MyClass(1, "Hello", 3.14, true);
        Type type = myObject.GetType();
        TypeInfo typeInfo = type.GetTypeInfo();

        Console.WriteLine($"Type: {type.FullName}");
        Console.WriteLine($"Is Class: {typeInfo.IsClass}");
        Console.WriteLine($"Is Public: {typeInfo.IsPublic}");

        MemberInfo[] members = type.GetMembers();
        Console.WriteLine("\nMembers:");
        foreach (var member in members)
        {
            Console.WriteLine($"Name: {member.Name}, MemberType: {member.MemberType}");
        }

        FieldInfo[] fields = type.GetFields();
        Console.WriteLine("\nFields:");
        foreach (var field in fields)
        {
            Console.WriteLine($"Name: {field.Name}, FieldType: {field.FieldType}");
        }

        MethodInfo method = type.GetMethod("PublicMethod");
        Console.WriteLine("\nCalling PublicMethod through Reflection:");
        method.Invoke(myObject, new object[] { 42 });

        Console.ReadLine();
    }
}
