using System.Windows;
using System.Windows.Controls;
using static DigitalJournal.MainWindow;

namespace DigitalJournal
{
    /// <summary>
    /// Логика взаимодействия для Subpage.xaml
    /// </summary>
    public partial class Subpage : Page
    {
        public MainWindow MainWindow;

        public Subpage(MainWindow mainWindow)
        {
            InitializeComponent();

            MainWindow = mainWindow;

            //OpenSubpage(Subpages.Users);
            OpenSubpage(Subpages.Journal);

            if (User.Right != "admin")
                user_btn.Visibility = Visibility.Collapsed;
        }

        public enum Subpages
        {
            Journal,
            Zaprosy,
            Deti,
            Spravochniki,
            AddJournalRow,
            EditJournalRow,
            Users
        }

        public void OpenSubpage(Subpages subpages)
        {
            switch (subpages)
            {
                case Subpages.Journal:
                    subframe.Navigate(new Journal(this));
                    break;
                case Subpages.Zaprosy:
                    subframe.Navigate(new Zaprosy(this));
                    break;
                case Subpages.Deti:
                    subframe.Navigate(new Deti(this));
                    break;
                case Subpages.Spravochniki:
                    subframe.Navigate(new Spravochniki(this));
                    break;
                case Subpages.AddJournalRow:
                    subframe.Navigate(new AddJournalRow(this));
                    break;
                case Subpages.EditJournalRow:
                    subframe.Navigate(new EditJournalRow(this));
                    break;
                case Subpages.Users:
                    subframe.Navigate(new Users(this));
                    break;
            }
        }

        private void Journal_Click(object sender, RoutedEventArgs e)
        {
            OpenSubpage(Subpages.Journal);
        }

        private void Zaprosy_Click(object sender, RoutedEventArgs e)
        {
            OpenSubpage(Subpages.Zaprosy);
        }

        private void Spravochniki_Click(object sender, RoutedEventArgs e)
        {
            OpenSubpage(Subpages.Spravochniki);
        }

        private void Deti_Click(object sender, RoutedEventArgs e)
        {
            OpenSubpage(Subpages.Deti);
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            if (User.Right == "admin")
                OpenSubpage(Subpages.Users);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenPage(Pages.Login);
        }
    }
}
