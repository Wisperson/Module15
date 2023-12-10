using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Module15
{
    public class Homework
    {
        public static void Start()
        {
            Type myType = typeof(Console);
            Console.WriteLine("Methods:");
            foreach (var method in myType.GetMethods())
            {
                Console.Write($"{method.ReturnType} {method.Name}(");

                // Вывод параметров метода
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType} {parameters[i].Name}");
                    if (i < parameters.Length - 1)
                        Console.Write(", ");
                }

                Console.Write(")\n");
            }

            // Вызов метода Substring
            string originalString = "Hello, World!";
            MethodInfo substringMethod = typeof(string).GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            if (substringMethod != null)
            {
                // Параметры метода
                object[] parameters = { 7, 5 }; // Начиная с позиции 7, взять 5 символов
                string result = (string)substringMethod.Invoke(originalString, parameters);

                Console.WriteLine("Original String: " + originalString);
                Console.WriteLine("Substring: " + result);
            }

            // Получение списка конструкторов класса List<T>
            Type listType = typeof(List<>);
            Type[] typeArgs = { typeof(int) }; // Укажите тип элементов списка

            Type genericListType = listType.MakeGenericType(typeArgs);
            ConstructorInfo[] constructors = genericListType.GetConstructors();

            Console.WriteLine("\nConstructors of List<int>:");
            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor);
            }
        }
    }
}
