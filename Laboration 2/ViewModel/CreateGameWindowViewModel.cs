using Laboration_2.Model;
using Laboration_2.MVVM;
using System.Windows;

namespace Laboration_2.ViewModel
{
    internal class CreateGameWindowViewModel : ViewModelBase
    {
        public Game CreatedGame { get; private set; }
        private Game _gameToEdit;

        public event Action RequestClose;
        public event Action RequestSaveAndClose;

        public RelayCommand btnCreateGame => new RelayCommand(execute => CreateGame());
        public RelayCommand btnCloseWindow => new RelayCommand(execute => BtnCloseWindow());

        public string ButtonText { get; set; } = "Lägg till";

        public CreateGameWindowViewModel()
        {
        }

        public CreateGameWindowViewModel(Game game)
        {
            _gameToEdit = game;
            TbTitel = game.Titel;
            TbMaxPlayers = game.MaxPlayers.ToString();
            TbMinPlayers = game.MinPlayers.ToString();
            ButtonText = "Spara";
        }

        private string tbTitel;
        public string TbTitel
        {
            get => tbTitel;
            set
            {
                tbTitel = value;
                OnPropertyChanged();
            }
        }

        private string tbMaxPlayers;
        public string TbMaxPlayers
        {
            get => tbMaxPlayers;
            set
            {
                tbMaxPlayers = value;
                OnPropertyChanged();
            }
        }

        private string tbMinPlayers;
        public string TbMinPlayers
        {
            get => tbMinPlayers;
            set
            {
                tbMinPlayers = value;
                OnPropertyChanged();
            }
        }


        private void CreateGame()
        {
            try
            {
                if (_gameToEdit != null)
                {
                    CreatedGame = new Game(TbTitel, int.Parse(TbMaxPlayers), int.Parse(TbMinPlayers));

                    _gameToEdit.Titel = TbTitel;
                    _gameToEdit.MaxPlayers = int.Parse(TbMaxPlayers);
                    _gameToEdit.MinPlayers = int.Parse(TbMinPlayers);
                    RequestSaveAndClose?.Invoke();
                }
                else
                {
                    CreatedGame = new Game(TbTitel, int.Parse(TbMaxPlayers), int.Parse(TbMinPlayers));
                    RequestSaveAndClose?.Invoke();
                }
                    
            }
            catch (Exception ex) when (
                ex is FormatException ||
                ex is ArgumentException)
            {
                MessageBox.Show("Max och Min spelare måste vara giltiga heltal.", "Fel", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Fel", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        

        private void BtnCloseWindow()
        {
            RequestClose?.Invoke();
        }
    }
}
