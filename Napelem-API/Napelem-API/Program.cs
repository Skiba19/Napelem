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
