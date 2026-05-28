using Laboration_2.Model;
using System.Windows;

namespace Laboration_2.Vy.AddMemberVy
{
    /// <summary>
    /// Interaction logic for AddMember.xaml
    /// </summary>
    public partial class AddMember : Window
    {
        public Medlem CreatedMember { get; private set; }

        public AddMember(Window parentWindow)
        {
            InitializeComponent();
            Owner = parentWindow;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            int age;
            string name = txtName.Text;
            string email = txtEmail.Text;
            if (string.IsNullOrEmpty(name))
                MessageBox.Show("Namn måste vara ifyllt.", "Felaktigt namn", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (!int.TryParse(txtAge.Text, out age))
                MessageBox.Show("Ålder måste vara ifylld.", "Felaktig ålder", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (string.IsNullOrEmpty(email))
                MessageBox.Show("Epost måste vara ifylld.", "Felaktigt Epost", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                Medlem newMember = new Medlem(age, txtName.Text, txtEmail.Text);
                CreatedMember = new Medlem(age, name, email);
                DialogResult = true;
                Close();
            }
        }
    }
}
