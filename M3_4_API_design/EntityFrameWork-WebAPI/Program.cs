using Model;
using Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;



var builder = WebApplication.CreateBuilder(args);


// Tilføj TaskContext factory som service
// Vi giver builderen information om hvor den skal finde data henne
// 
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskContextSQLite")));

// Scope giver os muligheden for at lave en instans af vores service vi kan arbejde inden for
builder.Services.AddScoped<TaskService>();

var app = builder.Build();

// Vi henter TaskService og kalder metoden SeedData
using (var scope = app.Services.CreateScope())
{
    var dataservice = scope.ServiceProvider.GetRequiredService<TaskService>();
    dataservice.SeedData();
}

// I dine endpoints kan du nu bruge TaskContext som en dependency

// Åben op for "CORS" i din API.
// Læs om baggrunden her: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-6.0

var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(AllowCors);

app.MapGet("/", (TaskService taskService) => "Hello World!");


app.MapGet("/api/boardtasks/{id}", (TaskService Service, int id) =>
{
    return Service.GetBoardTasks(id);
});

app.MapPut("/api/task/{id}", (TaskService Service, int id, NewTask newTask) =>
{
    User AddUser = Service.GetUser(newTask.userId);
    return Service.CreateTask(new TodoTask { Text = newTask.text, Done = newTask.done, Category = newTask.category, User = AddUser}, id);
});



app.Run();


record NewTask (string text, bool done, string category, int userId);
