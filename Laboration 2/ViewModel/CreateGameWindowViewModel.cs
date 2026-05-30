using Laboration_2.Model;
using Laboration_2.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Laboration_2.ViewModel
{
    internal class CreateGameWindowViewModel : ViewModelBase
    {
        public Game CreatedGame { get; private set; }

        public event Action RequestClose;
        public event Action RequestSaveAndClose;

        public RelayCommand btnCreateGame => new RelayCommand(execute => CreateGame());
        public RelayCommand btnCloseWindow => new RelayCommand(execute => BtnCloseWindow());


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
                Game newGame = new Game(TbTitel, int.Parse(TbMaxPlayers), int.Parse(TbMinPlayers));
                CreatedGame = newGame;
                RequestSaveAndClose?.Invoke();
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
