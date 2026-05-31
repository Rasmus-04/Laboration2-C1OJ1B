using Laboration_2.Model;
using Laboration_2.MVVM;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows;

namespace Laboration_2.ViewModel
{
    internal class CreateEventViewModel : ViewModelBase
    {
        public CreateEventViewModel(ObservableCollection<Game> allGames)
        {
            DpDate = DateTime.Now;
            CbAllGames = allGames;
        }

        public CreateEventViewModel(ObservableCollection<Game> allGames, Event eventToEdit)
        {
            _eventToEdit = eventToEdit;

            CbAllGames = allGames;

            TbEventTitel = eventToEdit.Name;
            DpDate = eventToEdit.EventDate;
            CbGame = allGames.FirstOrDefault(g => g.Id == eventToEdit.GameId);
            TbMaxParticepents = eventToEdit.MaxParticipants.ToString();

            ButtonText = "Spara";
        }

        private Event? _eventToEdit;
        public ObservableCollection<Game> CbAllGames { get; set; }

        public string ButtonText { get; set; } = "Lägg till";

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
            try
            {
                if (_eventToEdit != null)
                {
                    CreatedEvent = new Event(TbEventTitel, DpDate, CbGame, int.Parse(TbMaxParticepents));

                    _eventToEdit.Name = TbEventTitel;
                    _eventToEdit.EventDate = DpDate;
                    _eventToEdit.GameId = CbGame.Id;
                    _eventToEdit.MaxParticipants = int.Parse(TbMaxParticepents);

                    RequestSaveAndClose?.Invoke();
                }
                else
                {
                    CreatedEvent = new Event(TbEventTitel, DpDate, CbGame, int.Parse(TbMaxParticepents));
                    RequestSaveAndClose.Invoke();
                }
            }
            catch (Exception ex) when (
                ex is FormatException ||
                ex is ArgumentException)
            {
                MessageBox.Show("Max deltagare måste vara giltiga heltal.", "Fel", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
