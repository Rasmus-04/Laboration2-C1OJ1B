using Laboration_2.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Laboration_2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                await context.Database.MigrateAsync();
            }

            await SeedData.SeedAsync();
            System.Diagnostics.Debug.WriteLine("Database seeded successfully");
            base.OnStartup(e);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }

}
