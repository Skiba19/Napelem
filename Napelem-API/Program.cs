using Napelem_API.Data;
using Napelem_API.Models;
using Napelem_API.Connection;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        using (NapelemContext context = new NapelemContext())
        {
           
            //TCPConnection TCP = new TCPConnection();
            //TCP.StartListening();
            
            //Login button
            foreach (Employee e in context.Employees)
            {
                if (e.username == "ide jön a username" && e.password == "ide a password")
                {
                    if (e.role == "admin")
                        Console.WriteLine();//ehelyett kell elküldeni az "Acess Admin"-t
                    if (e.role == "Stock Manager")
                        Console.WriteLine();//ehelyett kell elküldeni az "Acess Stock Manager"-t
                    if (e.role == "Professional")
                        Console.WriteLine();//ehelyett kell elküldeni az "Acess Professional"-t
                    if (e.role == "Stock Keeper")
                        Console.WriteLine();//ehelyett kell elküldeni az "Acess Stock Keeper"-t
                }
                else Console.WriteLine();//ehelyett kell elküldeni az "Acess Denied"-t
            }
            //Send Componens
            foreach(Component c in context.Components)
            {
                Console.WriteLine(c.componentID.ToString(), c.name, c.quantity, c.max_quantity, c.price);
                //itt el kell küldeni ezeket az adatokat
            }
            //Add new item button
            {
                Component comp = new Component() //itt kapja meg a Componenst
                {
                    name = "test",
                    price = 200,
                    max_quantity=100
                };
                Component item = new Component()
                {
                    name = comp.name,
                    price = comp.price,
                    quantity=0,
                    max_quantity = comp.max_quantity
                };
                context.Components.Add(item);
                context.SaveChanges();
            }
            //Change price
            {
                int newPrice = 600;//itt kapja meg az új árat
                Component comp = new Component() //itt kapja meg a Componenst
                {
                    componentID=3,
                    name = "test",
                    price = 200,
                    max_quantity = 0,
                    quantity=0
                };
                using (var db = new NapelemContext())
                {
                    var component = db.Components.Where(c => c.componentID == comp.componentID).FirstOrDefault();
                    component.price = newPrice;
                    db.SaveChanges();
                }
            }
            //B5 - Add Component to Storage
            {
                Component c = new Component()//Component amiből kivesszük a componentID-t
                {
                    componentID = 66, //ezt csak a teszt kedvéért adom meg, nem kell megadni
                    name="testComponent",
                    quantity=16,
                    max_quantity=69,
                    price = 100
                };
                int row = 5, column = 2, level=1;//sor, oszlop, szint paraméter
                Storage s = new Storage()
                {
                    componentID = c.componentID,
                    row= row, 
                    column = column, 
                    level=level
                };
                context.Storages.Add(s);
                context.SaveChanges();
            }
            //B6 - Change Component maxQuantity
            {
                int newMaxQuantity = 600;//itt kapja meg az új maxQuantity-t
                Component comp = new Component() //itt kapja meg a Componenst
                {
                    componentID = 6,
                    name = "test",
                    price = 200,
                    max_quantity = 0,
                    quantity = 0
                };
                using (var db = new NapelemContext())
                {
                    var component = db.Components.Where(c => c.componentID == comp.componentID).FirstOrDefault();
                    component.max_quantity = newMaxQuantity;
                    db.SaveChanges();
                }
            }
            //A1 - Add Project
            { 
                Employee e = new Employee()//employeeID-hez hoztam létre
                {
                    name = "Teszt Elek",
                    role = "csoves",
                    username = "test",
                    password = "test"
                };
                Project p = new Project() //itt kapja meg a Project-et
                {
                    name= "test",
                    employeeID = e.employeeID,
                    status="test",
                    project_price= 200,
                    project_description ="test",
                    project_location ="test",
                    project_orderer="Feri",
                    estimated_Time=70,
                    wage=10
                    
                };
                context.Projects.Add(p);
                context.SaveChanges();
            }
            //A2 - Projektek listázása
            {
                foreach(Project p in context.Projects)
                {
                    Console.WriteLine(p.projectID.ToString(), p.employeeID, p.name, p.status, p.project_price, p.project_location, p.project_description, p.project_orderer, p.estimated_Time.ToString(), p.wage.ToString());
                }
            }
            //A3 - Komponensek listázása
            {
                foreach(Component component in  context.Components)
                {
                    Console.WriteLine(component.componentID.ToString(), component.name, component.quantity, component.max_quantity, component.price); ;
                }
            }
            //A4 - Projekthez komponens hozzárendelése
            {
                Project p = new Project() //itt kapja meg a Project-et
                {
                    name = "test",
                    employeeID = 53,
                    status = "test",
                    project_price = 200,
                    project_description = "test",
                    project_location = "test",
                    project_orderer = "Feri",
                    estimated_Time = 70,
                    wage = 10
                };
                Component co = new Component() //itt kapja meg a Componenst
                {
                    componentID = 6,
                    name = "test",
                    price = 200,
                    max_quantity = 0,
                    quantity = 0
                };
                Reservation r = new Reservation()
                {
                    projectID=p.projectID,
                    componentID=co.componentID
                };
                context.Reservations.Add(r);
                context.SaveChanges();
            }
            // A5 - Becsült munkavégzési idő rögzítése, munkadíj meghatározása
            {
                int est = 100, w = 50;//idő és pénz
                Project pro = new Project() //itt kapja meg a Project-et
                {
                    projectID = 1,
                    name = "test",
                    employeeID = 53,
                    status = "test",
                    project_price = 200,
                    project_description = "test",
                    project_location = "test",
                    project_orderer = "Feri",
                    estimated_Time = 70,
                    wage = 10
                };
                using (var db = new NapelemContext())
                {
                    var project = db.Projects.Where(p => p.projectID == pro.projectID).FirstOrDefault();
                    project.estimated_Time = est;
                    project.wage = w;
                    db.SaveChanges();
                }
            }
        }
    }
}
