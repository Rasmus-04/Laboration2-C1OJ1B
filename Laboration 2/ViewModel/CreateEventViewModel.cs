using Laboration_2.Model;
using Laboration_2.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Laboration_2.ViewModel
{
    internal class CreateEventViewModel : ViewModelBase
    {
        public CreateEventViewModel(ObservableCollection<Game> allGames)
        {
            DpDate = DateTime.Now;
            CbAllGames = allGames;
        }

        public ObservableCollection<Game> CbAllGames { get; set; }



        public event Action RequestClose;
        public event Action RequestSaveAndClose;

        private string tbEventTitel;
        public string TbEventTitel { get; set; }
        private DateTime dpDate;
        public DateTime DpDate { get; set; }
        private string tbMaxParticepents;
        public string TbMaxParticepents { get; set; }
        private Game cbGame;
        public Game CbGame { get; set; }

        public Event CreatedEvent { get; private set; }

        public RelayCommand btnCloseWindow => new RelayCommand(execute => BtnCloseWindow());
        public RelayCommand btnAddEvent => new RelayCommand(execute => AddEvent_Click());


        private void BtnCloseWindow()
        {
            RequestClose.Invoke();
        }

        private void AddEvent_Click()
        {
            if (string.IsNullOrEmpty(TbEventTitel))
                MessageBox.Show("Namn måste vara ifyllt.", "Felaktig information", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (!int.TryParse(TbMaxParticepents, out _))
                MessageBox.Show("Max Deltagare måste vara ett giltigt tal.", "Felaktig information", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (DpDate == null)
                MessageBox.Show("Datum måste vara ifyllt.", "Felaktig information", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (CbGame == null)
                MessageBox.Show("Spel måste vara ifyllt.", "Felaktig information", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                CreatedEvent = new Event(TbEventTitel, DpDate, CbGame, int.Parse(TbMaxParticepents));
                RequestSaveAndClose.Invoke();
            }
        }
    }
}
