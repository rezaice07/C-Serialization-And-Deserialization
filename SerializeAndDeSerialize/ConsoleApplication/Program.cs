using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DoFactory.GangOfFour.Prototype.Structural
{
    class Program
    {  
        public static void SerializeData()
        {
            Employee employee = new Employee
            {
                Name = "Rejawnaul Reja",
                Phone = "01718055626",
                Salary = 75000,
                AdditionalEmaployeeInfo="This employee promotted as MVP"
            };

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fsout = new FileStream("employee.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            try
            {
                using (fsout)
                {
                    bf.Serialize(fsout, employee);
                    var message = "Object Serialized";
                    Console.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( "An error has occured");
            }
        }

        public static void DeSerializeData()
        {
            Employee employee = new Employee();

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fsin = new FileStream("employee.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                using (fsin)
                {
                    employee = (Employee)bf.Deserialize(fsin);
                    Console.WriteLine("Object Deserialized\n");

                    var employeeData = $"Deserialized EmployeeInfo:\nName: {employee.Name}, Phone: {employee.Phone}, Salary: {employee.Salary}";

                    Console.WriteLine(employeeData);
                }
            }
            catch
            {
                Console.WriteLine("An error has occured");
            }
        }
        static void Main(string[] args)
        {
            

            SerializeData();
            DeSerializeData();
            Console.ReadLine();
        }

        [Serializable]
        public class Employee
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public decimal Salary { get; set; }

            [NonSerialized]
            public string AdditionalEmaployeeInfo;
        }

    }

}