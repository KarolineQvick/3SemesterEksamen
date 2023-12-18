var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int nextId = 0;
List<Task> todos = new List<Task>();
todos.Add(new Task(nextId++, "Husk at handle", false));
todos.Add(new Task(nextId++, "Husk at betale skat", false));
todos.Add(new Task(nextId++, "Husk at gøre rent", false));

app.MapGet("/api/tasks", () => todos.ToArray());

app.MapPost("/api/tasks", (Task task) =>
{
    Task newTask = new Task(nextId++, task.text, task.done);
    todos.Add(newTask);
    return newTask + "Opgaven er tilføjet";
});

app.MapPut("/api/task/{id}", (int id, Task task) =>
{
 

    //hvis ID'et ikke eksiterer kan man ikke anvende PUT (man får bad request)
    if (todos.Where(x => x.id == id).Count() == 0)
    {
        return Results.BadRequest("Opgaven findes ikke");
    }

    else
    {
        //fjerner alle fra listen hvor id er lig det valgte id
        todos.RemoveAll(x => x.id == id);
        //tilføjer den opdaterede opgave med det tilhørende id som er skrevet i URL'en.
         Task newTask = new Task(nextId++, task.text, task.done);
          todos.Add(newTask); 
      
        return Results.Ok("opgaven er opdateret");
    }
});



app.MapDelete("/api/tasks/{id}", (int id) =>
{
    Task task = todos.Find(t => t.id == id);
    if (task == null)
    {
        return Results.NotFound("Opgaven findes ikke");
    }
    else
    {
        todos.Remove(task);
        return Results.Ok("Opgaven er slettet");
    }
});

app.Run();

record Task(int id, string text, bool done);
