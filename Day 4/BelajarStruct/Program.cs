using System;using System;

namespace GenericsConstraintsDemo
{
    public class GenericClass<T> where T : struct
    {
        public T Message;
        public void GenericMethod(T Param1, T Param2)
        {
            Console.WriteLine($"Message: {Message}");
            Console.WriteLine($"Param1: {Param1}");
            Console.WriteLine($"Param2: {Param2}");
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class Program
    {
        static void Main()
        {
            // Instantiate Generic Class with Constraint
            GenericClass<int> intClass = new GenericClass<int>();
            intClass.Message = 30;
            intClass.GenericMethod(10, 20);

            //Compile Time Error as string is not a value type, it is a reference type
            //GenericClass<string> stringClass = new GenericClass<string>();

            //Compile Time Error as Employee is not a value type, it is a reference type
            //GenericClass<Employee> EmployeeClass = new GenericClass<Employee>();
            Console.ReadKey();
        }
    }
}

// namespace GenericsConstraintsDemo
// {
//     public class GenericClass<T> where T : struct
//     {
//         public T Message;
//         public void GenericMethod(T Param1, T Param2)
//         {
//             Console.WriteLine($"Message: {Message}");
//             Console.WriteLine($"Param1: {Param1}");
//             Console.WriteLine($"Param2: {Param2}");
//         }
//     }

//     public class Employee
//     {
//         public string Name { get; set; }
//         public string Location { get; set; }
//     }

//     public class Program
//     {
//         static void Main()
//         {
//             // Instantiate Generic Class with Constraint
//             GenericClass<int> intClass = new GenericClass<int>();
//             intClass.Message = 30;
//             intClass.GenericMethod(10, 20);

//             //Compile Time Error as string is not a value type, it is a reference type
//             //GenericClass<string> stringClass = new GenericClass<string>();

//             //Compile Time Error as Employee is not a value type, it is a reference type
//             //GenericClass<Employee> EmployeeClass = new GenericClass<Employee>();
//             Console.ReadKey();
//         }
//     }
// }