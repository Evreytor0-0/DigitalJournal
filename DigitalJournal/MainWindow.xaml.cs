using System.Windows;

namespace DigitalJournal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenPage(Pages.Login);
        }

        public enum Pages
        {
            Login,
            Subpage
        }

        public void OpenPage(Pages pages)
        {
            switch (pages)
            {
                case Pages.Login:
                    frame.Navigate(new Login(this));
                    break;
                case Pages.Subpage:
                    frame.Navigate(new Subpage(this));
                    break;
            }
        }
    }
}
