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
           
            TCPConnection TCP = new TCPConnection();
            TCP.StartListening();
            
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
                string name="test";//egyenlővé kell tenni a kapott értékkel
                int price=0, maxQuantity=0;//ugyszintén (csak a maxQuantityt)
                Component item = new Component()
                {
                    name = name,
                    price = price,
                    quantity=0,
                    max_quantity = maxQuantity
                };
                context.Components.Add(item);
                context.SaveChanges();
            }
            //Change price
            {
                int id = 1, newPrice = 600;//itt kapja meg az id-t és az új árat
                using (var db = new NapelemContext())
                {
                    var component = db.Components.Where(c => c.componentID == id).FirstOrDefault();
                    component.price = newPrice;
                    db.SaveChanges();
                }
            }

        }
    }
}
