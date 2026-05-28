using Laboration_2.Model;
using System.Collections.ObjectModel;
using System.Windows;
namespace Laboration_2
{
    public partial class MainWindow : Window
    {

        private ObservableCollection<Medlem> members = new ObservableCollection<Medlem>();
        private ObservableCollection<Spel> allaSpel = new ObservableCollection<Spel>();
        private ObservableCollection<Aktivitet> allaAktiviteter = new ObservableCollection<Aktivitet>();

        public ObservableCollection<Medlem> Members
        {
            get { return members; }
            set { members = value; }
        }

        public ObservableCollection<Spel> AllaSpel
        {
            get { return allaSpel; }
            set { allaSpel = value; }
        }

        public ObservableCollection<Aktivitet> AllaAktiviteter
        {
            get { return allaAktiviteter; }
            set { allaAktiviteter = value; }
        }

        

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}