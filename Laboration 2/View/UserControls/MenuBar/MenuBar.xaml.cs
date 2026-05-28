using Laboration_2.Vy.AddEventWindow;
using Laboration_2.Vy.AddSpelWindow;
using Laboration_2.View.Windows.RegisterMemberWindow;
using System.Windows;
using System.Windows.Controls;

namespace Laboration_2.View.UserControls.MenuBar
{
    /// <summary>
    /// Interaction logic for MenuBar.xaml
    /// </summary>
    public partial class MenuBar : UserControl
    {
        public MenuBar()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            // För tillgång till members listan i MainWindow.xaml.cs
            MainWindow mainWindow = (MainWindow)parentWindow;

            RegisterMemberWindow addMemberWindow = new RegisterMemberWindow(parentWindow);
            parentWindow.Opacity = .4;
            bool? result = addMemberWindow.ShowDialog();

            if (result == true)
            {
                mainWindow.Members.Add(addMemberWindow.CreatedMember);
            }
            parentWindow.Opacity = 1;

        }

        private void NewSpel_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            // För tillgång till allaSpel listan i MainWindow.xaml.cs
            MainWindow mainWindow = (MainWindow)parentWindow;

            AddSpel nyttSpelWindow = new AddSpel(parentWindow);
            parentWindow.Opacity = .4;
            bool? result = nyttSpelWindow.ShowDialog();

            if (result == true)
            {
                mainWindow.AllaSpel.Add(nyttSpelWindow.CreatedSpel);
            }
            parentWindow.Opacity = 1;
        }

        private void NewEvent_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            // För tillgång till AllaAktiviteter listan i MainWindow.xaml.cs
            MainWindow mainWindow = (MainWindow)parentWindow;

            AddEvent NyttEventWindow = new AddEvent(parentWindow, mainWindow.AllaSpel);


            parentWindow.Opacity = .4;
            bool? result = NyttEventWindow.ShowDialog();

            if (result == true)
            {
                mainWindow.AllaAktiviteter.Add(NyttEventWindow.CreatedEvent);
            }
            parentWindow.Opacity = 1;
        }

        private void btnTestData_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            MainWindow mainWindow = (MainWindow)parentWindow;

            TestData.GenerateAllData(mainWindow.Members, mainWindow.AllaSpel, mainWindow.AllaAktiviteter);
        }
    }
}
