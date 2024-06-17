using System;
using System.Collections.Generic;

public class Forum
{
    private List<string> pytania = new List<string>();
    private Dictionary<string, List<string>> odpowiedzi = new Dictionary<string, List<string>>();
    private List<IObserver<string>> obserwatorzy = new List<IObserver<string>>();

    public void DodajPytanie(string pytanie)
    {
        string idPytania = "Q" + (pytania.Count + 1).ToString();
        pytania.Add(idPytania);
        Notify($"Użytkownik dodał pytanie {idPytania}");
    }

    public void DodajOdpowiedz(string idPytania, string odpowiedz)
    {
        if (!odpowiedzi.ContainsKey(idPytania))
        {
            odpowiedzi[idPytania] = new List<string>();
        }
        odpowiedzi[idPytania].Add(odpowiedz);
        Notify($"Użytkownik dodał odpowiedź do pytania {idPytania}");
    }

    public IDisposable ZarejestrujObserwatora(IObserver<string> obserwator)
    {
        if (!obserwatorzy.Contains(obserwator))
            obserwatorzy.Add(obserwator);
        return new Unsubscriber(obserwatorzy, obserwator);
    }

    private void Notify(string informacja)
    {
        foreach (var obserwator in obserwatorzy)
        {
            obserwator.OnNext(informacja);
        }
    }

    private class Unsubscriber : IDisposable
    {
        private List<IObserver<string>> _obserwatorzy;
        private IObserver<string> _obserwator;

        public Unsubscriber(List<IObserver<string>> obserwatorzy, IObserver<string> obserwator)
        {
            _obserwatorzy = obserwatorzy;
            _obserwator = obserwator;
        }

        public void Dispose()
        {
            if (_obserwator != null && _obserwatorzy.Contains(_obserwator))
                _obserwatorzy.Remove(_obserwator);
        }
    }
}