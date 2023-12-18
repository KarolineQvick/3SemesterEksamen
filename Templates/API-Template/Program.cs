var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

/*
//her laver vi en liste af users
int nextId = 0;
List<User> Customers = new List<User>()
{

    Customers.Add(new User("Hans", "HANS@gmail.com", nextId++, "erhverv")),
    Customers.Add(new User("jens", "HANS@gmail.com", nextId++, "privat"))



};
*/

int nextId = 0;
List<User> Customers = new List<User>()
{
    new User("Hans", "kunde1@mail.com", nextId++, "erhverv"),
    new User("John", "john@example.com", nextId++, "privat")
};



app.MapGet("/", () => "Hello World!");

app.MapGet("/api/Names", () => Customers);

app.MapGet("/api/Names/{id}", (int id) =>
{
    var user = Customers.FirstOrDefault(p => p.id == id);
    if (user == null)
    {
        throw new Exception ($"User with id {id} not found");
    }
    else
    {
        return user;
    }
    
});

app.MapPost("/api/Names/add", (User customer) =>
{
    Customers.Add(customer);
    return Customers;
});

app.MapDelete("/api/Names/delete/{id}", (int id) =>
{
    var user = Customers.FirstOrDefault(p => p.id == id);
    if (user == null)
    {
        throw new Exception ($"User with id {id} not found");
    }
    else
    {
        Customers.Remove(user);
        return Customers + $"User with id {id} has been deleted";
    }
    
});

app.MapGet("/api/emails/{type}", (string type) =>
{
    var users = Customers.Where(p => p.TypeOfUser == type).Select(u => u.Email).ToList();
    if (users.Count == 0)
    {
        throw new Exception ($"User with type {type} not found");
    }
    else
    {
        return users;
    }
    
});

app.MapPut("/api/Names/update/{id}", (int id, User customer) =>
{
    // Find den bruger, der skal opdateres baseret på ID
    var user = Customers.FirstOrDefault(p => p.id == id);
    if (user == null)
    {
        throw new Exception ($"User with id {id} not found");
    }
    else
    {
        // Opdater brugerens attributter med de nye værdier
        user.Name = customer.Name;
        user.Email = customer.Email;
        user.TypeOfUser = customer.TypeOfUser;
        
        // Returner den opdaterede liste af kunder
        return Customers;
    }
});

app.Run();
//record User(string Name, string Email, int id, string TypeOfUser);



//Teori spørgsmål 
//1. Hvad er et REST API? - En REST API er En REST API (Representational State Transfer API) er en arkitektonisk stil til at designe netværksbaserede webtjenester. Den er baseret på principperne om den eksisterende World Wide Web-infrastruktur og bruger standard HTTP-protokollen til at oprette, læse, opdatere og slette (CRUD) ressourcer.

//2. Hvorfor er det vigtigt at kunne lave et REST API? - Fordi det er en af de mest brugte måder at lave API'er på.
//3. Hvad gør en REST API god? - At den er nem at bruge og forstå.
//4. Hvad gør en REST API sikker? - At den har en god authentication, roller og permissions. og claims 

