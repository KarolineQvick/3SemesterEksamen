var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/api/hello/{name}/{Age}", (string name, int age)   => new { Message = $"Hello {name}!, du er så gammel {age}"});


//Opgave 5 

String[] frugter = new String[]
{
    "æble", "banan", "pære", "ananas"
};
app.MapGet("/api/fruit", () => frugter); // returnerer et hele arrayet frugter 

app.MapGet("/api/fruit/{id}", (int id) => frugter[id]); // returnerer et enkelt element fra arrayet frugter

app.MapGet("/api/fruit/random", () => frugter[new Random().Next(0, frugter.Length)]); // returnerer et tilfældigt element fra arrayet frugter


//Opgave 6


    // tilføjer et element til arrayet frugter
    
app.MapPost("/api/fruit", (Fruit fruit) =>
{
    if (string.IsNullOrEmpty(fruit.name)) {
        // Return 400
        return Results.BadRequest();
        
    } else {
        // Tilføj frugtens navn til arrayet frugter
       // Returner 200 OK-status sammen med det opdaterede array frugter
        return Results.Ok(frugter);
    }
});



//Opgave 7
//Lav en API huskeliste 




//Når du koder POST-routen, er du nødt til at lave en type, der svarer til inputtet i routen. Typen kunne være følgende record, som placeres i bunden af Program.cs:
record Fruit(string name);
