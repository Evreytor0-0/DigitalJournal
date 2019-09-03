using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DigitalJournal
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Page
    {
        public Subpage Subpage;

        List<SpecialistTable> _result = new List<SpecialistTable>();

        public Users(Subpage subpage)
        {
            InitializeComponent();

            grid.RowEditEnding += delegate //добавление и изменение строк
            {
                if (_result[grid.SelectedIndex].SpecialistId == null)
                {
                    string sql = "INSERT INTO `specialist`(`id`, `fio`, `login`, `password`) VALUES (NULL, '" +
                                 _result[grid.SelectedIndex].SpecialistFio + "', '" + _result[grid.SelectedIndex].SpecialistLogin + "', MD5('" + _result[grid.SelectedIndex].SpecialistPassword + "'))";
                    Database.ExecuteQuery(sql);
                }
                else
                {
                    string sql = "SELECT `password` FROM `specialist` WHERE `id` = " + _result[grid.SelectedIndex].SpecialistId;
                    List<List<string>> check = Database.ExecuteQuery(sql);
                    if (check[0][0] == _result[grid.SelectedIndex].SpecialistPassword)
                    {
                        sql = "UPDATE `specialist` SET `fio`='" + _result[grid.SelectedIndex].SpecialistFio +
                              "',`login`='" + _result[grid.SelectedIndex].SpecialistLogin + "' WHERE `id`=" +
                              _result[grid.SelectedIndex].SpecialistId;
                    }
                    else
                    {
                        sql = "UPDATE `specialist` SET `fio`='" + _result[grid.SelectedIndex].SpecialistFio +
                              "',`login`='" + _result[grid.SelectedIndex].SpecialistLogin + "',`password`=MD5('" +
                              _result[grid.SelectedIndex].SpecialistPassword + "') WHERE `id`=" +
                              _result[grid.SelectedIndex].SpecialistId;
                    }

                    Database.ExecuteQuery(sql);
                }

                Subpage.OpenSubpage(Subpage.Subpages.Users);
            };

            grid.PreviewKeyDown += delegate (object sender, KeyEventArgs args) //удаление строк
            {
                if (args.Key == Key.Delete && grid.SelectedIndex < _result.Count)
                {
                    MessageBoxResult _btn;
                    _btn = MessageBox.Show(
                        "Удалить строку: " + _result[grid.SelectedIndex].SpecialistId + ", " +
                        _result[grid.SelectedIndex].SpecialistFio + ", " + _result[grid.SelectedIndex].SpecialistLogin + ", " + _result[grid.SelectedIndex].SpecialistPassword + "?",
                        "Подтвердите действие",
                        MessageBoxButton.YesNo);
                    if (_btn == MessageBoxResult.No)
                        grid.CanUserDeleteRows = false;
                    if (_btn == MessageBoxResult.Yes)
                    {
                        grid.CanUserDeleteRows = true;
                        if (_result[grid.SelectedIndex].SpecialistId != null)
                        {
                            string sql = "DELETE FROM `specialist` WHERE `id` = " +
                                         _result[grid.SelectedIndex].SpecialistId;
                            Database.ExecuteQuery(sql);
                            if (Database.Error)
                            {
                                grid.CanUserDeleteRows = false;
                                Subpage.OpenSubpage(Subpage.Subpages.Users);
                            }
                        }
                    }
                }
            };

            Subpage = subpage;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT `id`, `fio`, `login`, `password` FROM `specialist`";
            List<List<string>> query = Database.ExecuteQuery(sql);
            foreach (var q in query)
            {
                _result.Add(new SpecialistTable(
                    q[0],
                    q[1],
                    q[2],
                    q[3]
                ));
            }

            grid.ItemsSource = _result;
        }
    }

    class SpecialistTable
    {
        public SpecialistTable() { }

        public SpecialistTable(string specialistId, string specialistFio, string specialistLogin, string specialistPassword)
        {
            SpecialistId = specialistId;
            SpecialistFio = specialistFio;
            SpecialistLogin = specialistLogin;
            SpecialistPassword = specialistPassword;
        }

        public string SpecialistId { get; set; }
        public string SpecialistFio { get; set; }
        public string SpecialistLogin { get; set; }
        public string SpecialistPassword { get; set; }
    }
}
