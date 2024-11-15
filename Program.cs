// Oppsett av web serveren
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Library library = new Library();

// Legg til noen placholder bøker
Book martian = new Book("Martian", "Jack Black", new DateTime(2002, 10, 10));
library.AddNewBook(martian);
Book foundation = new Book("Foundation", "Jane Doe", new DateTime(1940, 04, 05));
library.AddNewBook(foundation);
Book howToCode = new Book("How to Code When You Have No Idea", "Ctrl + Z", new DateTime(2019, 4, 1));
library.AddNewBook(howToCode);
Book cookingForProgrammers = new Book("Cooking for Programmers: Just Add Semicolons", "Chef.exe", new DateTime(2020, 2, 29));
library.AddNewBook(cookingForProgrammers);
Book procrastinatorGuide = new Book("Procrastinator's Guide to Getting Things Done... Eventually", "Ida Rather-Not", new DateTime(2021, 3, 15));
library.AddNewBook(procrastinatorGuide);
Book debugging101 = new Book("Debugging 101: A Horror Story", "Buggy McCodeface", new DateTime(2022, 10, 31));
library.AddNewBook(debugging101);
Book zenOfCoffee = new Book("The Zen of Coffee and Code", "Bean There", new DateTime(2018, 5, 4));
library.AddNewBook(zenOfCoffee);
Book survivingMondays = new Book("Surviving Mondays: A Memoir", "Anita Break", new DateTime(2023, 1, 2));
library.AddNewBook(survivingMondays);
Book artificialIntelligence = new Book("Artificial Intelligence for Cats", "Purrgrammer", new DateTime(2021, 11, 11));
library.AddNewBook(artificialIntelligence);

// Konfigurer endpunktene (hvilken meldinger vi responderer på og logik vi skal kjøre)
// Metode:     GET
// URI (sti):  /book
app.MapGet("/book", () =>
{
    Console.WriteLine("Henter ut tilgjengelige bøker");
    return library.ListAvailableBooks();
});

// Metode:     POST
// URI (sti):  /
app.MapPost("/book/borrow", (BorrowRequest request) =>
{
    Book? book = library.BorrowBook(request.Title);

    if (book == null)
    {
        Console.WriteLine("Fant ikke boken");
        return Results.NotFound();
    }
    else
    {
        Console.WriteLine("Fant boken");
        Console.WriteLine("Låner " + book.Title);
        return Results.Ok(book);
    }
});

app.MapPost("/book/return", (ReturnRequest request) =>
{
    Book? book = library.ReturnBook(request.Title);

    if (book == null)
    {
        Console.WriteLine("Fant ikke boken");
        return Results.NotFound();

    }
    else
    {
        Console.WriteLine("Fant boken");
        Console.WriteLine("Returnerer " + book.Title);
        return Results.Ok(book);
    }
});
// Start web serveren
app.Run();