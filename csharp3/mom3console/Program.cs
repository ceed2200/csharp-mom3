// Lösning till uppgift Moment 3 i kurs DT071G. Kod skapad av Cecilia Edvardsson. 

using consoleLibrary;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        // Tömmer eventuell tidigare skrift
        Console.Clear();

        // Presentation av innehåll
        Console.WriteLine(" ");
        Console.WriteLine("Cecilias gästbok (´•o•`)");
        Console.WriteLine(" ");
        Console.WriteLine("*** Lagrade inlägg ***");

        // Hämtar in JSON-fil där inlägg lagras
        var postsFile = File.ReadAllText(@"./posts.json");
        // Lista skapas med struktur efter klassen Post
        var postsList = JsonSerializer.Deserialize<List<Post>>(postsFile);

        // Om inlägg finns lagrade så listas dessa
        if (postsList!.Count > 0)
        {
            for (var i = 0; postsList.Count > i; i++)
            {
                Console.WriteLine("[" + i + "] " + postsList[i].Author + " - " + postsList[i].Content);
            }
        }
        else
        {
            Console.WriteLine("Inga inlägg finns lagrade ännu. Skriv gärna ett nytt!");
        }

        // Menyn
        Console.WriteLine(" ");
        Console.WriteLine("Vad vill du göra? Välj enligt nedanstående alternativ.");
        Console.WriteLine("1. Skriv nytt inlägg");
        Console.WriteLine("2. Ta bort inlägg");
        Console.WriteLine("X. Avsluta");
        Console.WriteLine(" ");

        // Hämta in användarens kommando för att göra något
        string? userAction = Console.ReadLine();

        // Val av åtgärd i gästboken
        while (userAction?.Length == 0)
        {
            Console.WriteLine("Vänligen välj åtgärd bland de listade alternativen.");
            userAction = Console.ReadLine();
        }

        while (userAction != "1" && userAction != "2" && userAction != "X" && userAction != "x")
        {
            Console.WriteLine("Vänligen välj åtgärd bland de listade alternativen.");
            userAction = Console.ReadLine();
        }

        if (userAction == "1")
        {
            Post.WritePost();
        }
        else if (userAction == "2")
        {
            Post.ErasePost();
        }
        else if (userAction == "X" || userAction == "x")
        {
            Environment.Exit(0);
        }
    }
}


