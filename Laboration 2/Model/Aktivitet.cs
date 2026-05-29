using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Laboration_2.Model
{
    public class Aktivitet : INotifyPropertyChanged
    {
        public int Id { get; }

        public string Namn { get; set; }

        public DateTime Datum { get; set; }

        public Spel Spel { get; set; }

        public int MaxDeltagare { get; set; }

        public int AntalDeltagare
        {
            get { return deltagare.Count; }
        }

        private ObservableCollection<Medlem> deltagare = new ObservableCollection<Medlem>();

        public ObservableCollection<Medlem> Deltagare
        {
            get { return deltagare; }
        }

        public Aktivitet(
            string namn,
            DateTime datum,
            Spel spel,
            int maxDeltagare,
            int id = 0)
        {
            if (string.IsNullOrWhiteSpace(namn))
                throw new Exception("Aktiviteten måste ha ett namn");

            if (maxDeltagare <= 0)
                throw new Exception("Maxdeltagare måste vara större än 0");

            Id = id;
            Namn = namn;
            Datum = datum;
            Spel = spel;
            MaxDeltagare = maxDeltagare;
        }

        public void AddDeltagare(Medlem medlem)
        {
            if (deltagare.Contains(medlem))
                throw new Exception("Medlem redan tillagd");

            if (deltagare.Count >= MaxDeltagare)
                return;

            deltagare.Add(medlem);

            OnPropertyChanged(nameof(AntalDeltagare));
        }

        public void RemoveDeltagare(Medlem medlem)
        {
            if (deltagare.Contains(medlem))
            {
                deltagare.Remove(medlem);

                OnPropertyChanged(nameof(AntalDeltagare));
            }
        }

        // LINQ - Sortering efter datum
        public static List<Aktivitet> SortByDate(List<Aktivitet> aktiviteter)
        {
            return aktiviteter
                .OrderBy(a => a.Datum)
                .ToList();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}