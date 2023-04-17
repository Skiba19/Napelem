using Napelem_API.Data;
using Napelem_API.Models;
using Napelem_API.Connection;
class Program
{
    static void Main()
    {
        using (NapelemContext context = new NapelemContext())
        {
            TCPConnection TCP = new TCPConnection();
            TCP.StartListening();
            foreach (Employee e in context.Employees)
            {
                if (e.name == "admin")
                {
                    break;
                }
                else
                {
                    Employee employee = new Employee()
                    {
                        name = "admin",
                        role = "admin",
                        username = "admin",
                        password = "admin",
                    };
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }
            }

            foreach (Employee e in context.Employees)
            {
                Console.WriteLine($"EmployeeID: {e.employeeID}");
                Console.WriteLine($"Name: {e.name}");
                Console.WriteLine($"Username: {e.username}");
                Console.WriteLine($"Password: {e.password}");
            }
        }
        Console.ReadKey();
    }
}
