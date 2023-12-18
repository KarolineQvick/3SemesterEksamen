using Model;

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");
    
    // Create
    Console.WriteLine("Indsæt et nyt task");
    db.Add(new TodoTask("En opgave der skal løses", false, "rengøring", new User("Rasmus")));
    db.SaveChanges();

    // Read
    Console.WriteLine("Find det sidste task");
    var lastTask = db.Tasks
        .OrderBy(b => b.TodoTaskId)
        .Last();
    Console.WriteLine($"Text: {lastTask.Text}");

/*
    //Delete
    Console.WriteLine("Sletter din task!");
    var example = db.Tasks.OrderBy(b => b.TodoTaskId)
        .First();
    Console.WriteLine($"Sletter!" + example.Text);
    db.Tasks.Remove(example);
    db.SaveChanges();
*/
    //Update
    Console.WriteLine("Updater");
    var example1 = db.Tasks.OrderBy(b => b.TodoTaskId)
        .First();
    example1.Text = "Testerr";
    db.Tasks.Update(example1);
    db.SaveChanges();

}

