using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DigitalJournal
{
    /// <summary>
    /// Логика взаимодействия для Deti.xaml
    /// </summary>
    public partial class Deti : Page
    {
        public Subpage Subpage;

        List<DetiTable> _result = new List<DetiTable>();

        public Deti(Subpage subpage)
        {
            InitializeComponent();

            grid.RowEditEnding += delegate //добавление и изменение строк
            {
                string sql = "UPDATE `deti` SET `FIO`='" + _result[grid.SelectedIndex].DetiFio + "',`DataRozhdeniya`='" + DateTime.Parse(_result[grid.SelectedIndex].DetiDataRozhdeniya).ToString("O") + "' WHERE `id`=" + _result[grid.SelectedIndex].DetiId;
                Database.ExecuteQuery(sql);

                Subpage.OpenSubpage(Subpage.Subpages.Deti);
            };

            Subpage = subpage;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT `deti`.`id`, `deti`.`FIO`, `deti`.`DataRozhdeniya`, `journal`.`fio_zayavitelya` FROM `deti`, `journal` WHERE `deti`.`JournalId` = `journal`.`id`";
            List<List<string>> query = Database.ExecuteQuery(sql);
            foreach (var q in query)
            {
                _result.Add(new DetiTable(
                    q[0],
                    q[1],
                    q[2].Remove(q[2].Length - 9),
                    q[3]
                ));
            }

            grid.ItemsSource = _result;
        }

        class DetiTable
        {
            public DetiTable() { }

            public DetiTable(string detiId, string detiFio, string detiDataRozhdeniya, string journalFioZayav)
            {
                DetiId = detiId;
                DetiFio = detiFio;
                DetiDataRozhdeniya = detiDataRozhdeniya;
                JournalFioZayav = journalFioZayav;
            }

            public string DetiId { get; set; }
            public string DetiFio { get; set; }
            public string DetiDataRozhdeniya { get; set; }
            public string JournalFioZayav { get; set; }
        }
    }
}
