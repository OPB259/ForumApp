using System;

class Program
{
    static void Main(string[] args)
    {
        Forum forum = new Forum();
        ForumStatistics statystyki = new ForumStatistics();

        using (forum.ZarejestrujObserwatora(statystyki))
        {
            forum.DodajPytanie("Jakie jest najlepsze IDE dla C#?");
            forum.DodajOdpowiedz("Q1", "Visual Studio");
            forum.DodajPytanie("Jakie są zalety programowania w C#?");
            forum.DodajOdpowiedz("Q2", "Jest wieloplatformowy dzięki .NET Core");
        }

        // Zarejestruj obserwatora ponownie i dodaj więcej pytań/odpowiedzi
        using (forum.ZarejestrujObserwatora(statystyki))
        {
            forum.DodajPytanie("Jakie są najlepsze praktyki w C#?");
            forum.DodajOdpowiedz("Q3", "Używaj async/await do operacji asynchronicznych");
        }

        Console.ReadKey();
    }
}