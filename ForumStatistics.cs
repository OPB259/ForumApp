using System;
using System.Collections.Generic;

public class ForumStatistics : IObserver<string>
{
    private int liczbaPytan = 0;
    private int liczbaOdpowiedzi = 0;

    public void OnCompleted()
    {
        // Nie używane w tym scenariuszu
    }

    public void OnError(Exception error)
    {
        // Nie używane w tym scenariuszu
    }

    public void OnNext(string value)
    {
        if (value.Contains("dodał pytanie"))
        {
            liczbaPytan++;
        }
        else if (value.Contains("dodał odpowiedź"))
        {
            liczbaOdpowiedzi++;
        }
        WyswietlStatystyki();
    }

    private void WyswietlStatystyki()
    {
        Console.WriteLine($"Liczba pytań: {liczbaPytan}, Liczba odpowiedzi: {liczbaOdpowiedzi}");
    }
}