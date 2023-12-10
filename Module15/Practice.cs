using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Module15
{
    public class Practice
    {
        public static void Start()
        {
            // Исследование типа
            Type myClassType = typeof(MyClass);
            Console.WriteLine($"Class Name: {myClassType.Name}");

            Console.WriteLine("\nConstructors:");
            foreach (var constructor in myClassType.GetConstructors())
            {
                Console.WriteLine($"{constructor} - {constructor.Attributes}");
            }

            Console.WriteLine("\nFields and Properties:");
            foreach (var member in myClassType.GetMembers())
            {
                Console.WriteLine($"{member.MemberType} {member.Name} - {member.CustomAttributes}");
            }

            Console.WriteLine("\nMethods:");
            foreach (var method in myClassType.GetMethods())
            {
                Console.WriteLine($"{method.ReturnType} {method.Name} - {method.Attributes}");
            }

            // Создание экземпляра
            Console.WriteLine("\nCreating instance using Activator.CreateInstance:");
            object instance = Activator.CreateInstance(myClassType);
            Console.WriteLine($"Instance type: {instance.GetType().Name}");

            // Манипуляции с объектом
            PropertyInfo publicPropertyInfo = myClassType.GetProperty("PublicProperty");
            publicPropertyInfo.SetValue(instance, "New Value");
            Console.WriteLine($"Updated PublicProperty value: {publicPropertyInfo.GetValue(instance)}");

            MethodInfo publicMethod = myClassType.GetMethod("PublicMethod");
            publicMethod.Invoke(instance, null);

            // Расширенное исследование
            MethodInfo privateMethod = myClassType.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privateMethod.Invoke(instance, null);
        }
    }

    public class MyClass
    {
        private int privateField;
        public string PublicProperty { get; set; }
        private double PrivateProperty { get; set; }

        public MyClass()
        {
            // Конструктор без параметров
        }

        public MyClass(int value)
        {
            // Конструктор с параметром
            privateField = value;
        }

        public void PublicMethod()
        {
            Console.WriteLine("Public method called.");
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Private method called.");
        }
    }
}
