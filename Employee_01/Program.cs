using Employee_01.Models;
using Employee_01.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayOption();
            Console.ReadKey();
        }
        public static void DisplayOption()
        {
            Console.WriteLine("1. Show All Employee");
            Console.WriteLine("2. Insert Employee");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");

            var index=int.Parse(Console.ReadLine());
            Show(index);
        }
        public static void Show(int index)
        {
            EmployeeRepo employeeRepo = new EmployeeRepo();
            if(index == 1)
            {
                var employeelist = employeeRepo.GetAll();
                if (employeelist.Count() == 0)
                {
                    Console.WriteLine("***********************");
                    Console.WriteLine("No data found");
                    Console.WriteLine("***********************");
                    DisplayOption();
                }
                else
                {
                    foreach (var item in employeeRepo.GetAll())
                    {
                        Console.WriteLine($"Employee Id: {item.EmployeeId}, Name: {item.EmployeeName}, Age: {item.Age}, Gender:{item.Gender}, Address:{item.Address}");
                    }
                    Console.WriteLine("************************");
                    DisplayOption();
                }
            }
            else if(index == 2)
            {
                Console.WriteLine("**************************");
                Console.Write("Name :");
                string name = Console.ReadLine();

                Console.Write("Age :");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Gender:");
                string gender= Console.ReadLine();

                Console.Write("Address:");
                string address= Console.ReadLine();

                int maxId = employeeRepo.GetAll().Any() ? employeeRepo.GetAll().Max(x => x.EmployeeId) : 0;

                Employee employee = new Employee
                {
                    EmployeeId = maxId + 1,
                    EmployeeName = name,
                    Age = age,
                    Gender= gender,
                    Address = address
                };
                employeeRepo.Insert(employee);
                Console.WriteLine("Data Inserted successfully!!!");
                Console.WriteLine("**********************");
                DisplayOption();
            }
            else if(index==3)
            {
                Console.WriteLine("*****************************");
                Console.Write("Enter Employee Id to Update: ");
                int id = int.Parse(Console.ReadLine());
                var _employee = employeeRepo.GetById(id);

                if (_employee == null)
                {
                    Console.WriteLine("****************************");
                    Console.WriteLine("Employee Id is invalid!!!");
                    Console.WriteLine("*******************************");
                    DisplayOption();
                }
                else
                {
                    Console.WriteLine($"Update Info for Employee Id : {id}");
                    Console.WriteLine("*********************************");
                    Console.Write("Name :");
                    string name = Console.ReadLine();

                    Console.Write("Age :");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Gender :");
                    string gender = Console.ReadLine();

                    Console.Write("Address :");
                    string address = Console.ReadLine();

                    Employee employee = new Employee
                    {
                        EmployeeId = id,
                        EmployeeName = name,
                        Age = age,
                        Gender= gender,
                        Address = address
                    };
                    employeeRepo.Update(employee);
                    Console.WriteLine("Data Updated Successfully!!!");
                    Console.WriteLine("*****************************");
                    DisplayOption();
                }
            }
            else if(index== 4)
            {
                Console.WriteLine("***********************************");
                Console.Write("Enter Employee Id to Delete: ");
                int id = int.Parse(Console.ReadLine());
                var _employee = employeeRepo.GetById(id);

                if (_employee == null)
                {
                    Console.WriteLine("*******************************");
                    Console.WriteLine("Employee Id is invalid!!!");
                    Console.WriteLine("***********************************");
                    DisplayOption();
                }
                else
                {
                    employeeRepo.Delete(id);
                    Console.WriteLine("Data Deleted Successfully!!!");
                    Console.WriteLine("******************************");
                    DisplayOption();
                }
            }
        }
    }
}
