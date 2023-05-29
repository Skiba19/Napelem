using Napelem_API.Data;
using Napelem_API.Models;

var builder = WebApplication.CreateBuilder(args);

/*using (var db=new NapelemContext())
{
    Employee e = new Employee()
    {
        name = "admin",
        username = "admin",
        password = "admin",
        role="admin"
       
    };
    db.Add(e);
    db.SaveChanges();
}*/
// Add services to the container.

/*using (var db = new NapelemContext())
{
    Storage s = new Storage()
    {
        storageID = 7,
        componentID = 3,
        row = 1,
        column = 1,
        level = 1,
        current_quantity = 20

    };
    db.Storages.Attach(s);
    db.Storages.Remove(s);
    db.SaveChanges();
}*/
/*using (var db = new NapelemContext())
{
    Component c = new Component()
    {
        componentID = 8,
        name="cso",
        max_quantity=20,
        price=30,
        quantity=20,

    };
    db.Components.Attach(c);
    db.Components.Remove(c);
    db.SaveChanges();
}*/

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
