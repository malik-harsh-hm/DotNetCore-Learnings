
using System.Reflection;

public class Program
{
    public static void Main(string[] args)
    {
        var obj = new { MyProperty = "value" };
        Type t = obj.GetType();
        PropertyInfo[] pInfo = t.GetProperties();
        foreach (var prop in pInfo)
        {
            Console.WriteLine("Property Name - {0}", prop.Name);
        }      
    }
}

