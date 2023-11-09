namespace consoleLibrary;
using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

public class Post
{
    public string? Author { get; set; }
    public string? Content { get; set; }

    // Metod för att lägga till inlägg
    public static void WritePost()
    {
        // Ser till att Console hämtar in och skriver ut åäö
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        // Tömmer tidigare skrift
        Console.Clear();

        // Presentation av innehåll
        Console.WriteLine(" ");
        Console.WriteLine("Cecilias gästbok (´•o•`)");
        Console.WriteLine(" ");
        Console.WriteLine("Här kan du skriva nytt inlägg i gästboken.");
        Console.WriteLine("(För att avsluta programmet, skriv 'X')");
        Console.WriteLine(" ");

        // Tar reda på författare
        Console.WriteLine("Vad heter du?");
        string? authorInput = Console.ReadLine();

        // Ger möjlighet att avsluta
        while (authorInput == "X" || authorInput == "x")
        {
            Environment.Exit(0);
        }

        // Kontrollerar input
        while (authorInput?.Length < 3)
        {
            Console.WriteLine("Vad heter du? (Minst 3 tecken)");
            authorInput = Console.ReadLine();
        }

        // Tar reda på innehåll
        Console.WriteLine("Vad vill du skriva?");
        string? contentInput = Console.ReadLine();

        // Ger möjlighet att avsluta
        while (contentInput == "X" || contentInput == "x")
        {
            Environment.Exit(0);
        }

        // Kontrollerar input
        while (contentInput?.Length < 3)
        {
            Console.WriteLine("Vad vill du skriva? (Minst 3 tecken)");
            contentInput = Console.ReadLine();
        }

        // Tar fram tidigare sparade inlägg och skapar lista
        var postsFile = File.ReadAllText(@"./posts.json");
        var postsList = JsonSerializer.Deserialize<List<Post>>(postsFile);

        // Lägger till inlägg i listan baserat på input
        postsList?.Add(new Post() { Author = authorInput, Content = contentInput });

        // Säkerställer att åäö fungerar
        var unicodeOption = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        // Skapar ny fil med nya listan
        string fileName = "posts.json";
        string jsonString = JsonSerializer.Serialize(postsList, unicodeOption);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("Nu är inlägget tillagt.");
    }
    public static void ErasePost()
    {
        // Tömmer tidigare skrift
        Console.Clear();

        // Presentation av innehåll
        Console.WriteLine(" ");
        Console.WriteLine("Cecilias gästbok (´•o•`)");
        Console.WriteLine(" ");
        Console.WriteLine("Här kan du ta bort ett inlägg i gästboken.");
        Console.WriteLine("(För att avsluta programmet, skriv 'X')");
        Console.WriteLine(" ");

        // Tar reda på önskad radering
        Console.WriteLine("Vilket inlägg vill du ta bort? Uppge tillhörande siffra.");
        string? eraseInput = Console.ReadLine();

        // Kontrollerar input
        while (eraseInput?.Length < 1)
        {
            Console.WriteLine("Vänligen uppge vilket inlägg du vill tas bort.");
            eraseInput = Console.ReadLine();
        }

        // Ger möjlighet att avsluta
        while (eraseInput == "X" || eraseInput == "x")
        {
            Environment.Exit(0);
        }

        // Tar fram tidigare sparade inlägg och skapar lista
        var postsFile = File.ReadAllText(@"./posts.json");
        var postsList = JsonSerializer.Deserialize<List<Post>>(postsFile);

        // Tar bort inlägg i listan baserat på input
        int chosenItem = Convert.ToInt32(eraseInput);

        if (chosenItem > postsList!.Count)
        {
            Console.WriteLine("Du har angett att ett inlägg som inte existerar ska raderas. Kör om programmet och välj bland de inlägg som ses i listan.");
            Environment.Exit(0);
        }

        postsList!.RemoveAt(chosenItem);

        // Säkerställer att åäö fungerar
        var unicodeOption = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };

        // Skapar ny fil med nya listan
        string fileName = "posts.json";
        string jsonString = JsonSerializer.Serialize(postsList, unicodeOption);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("Inlägget är nu borttaget.");
    }
}




