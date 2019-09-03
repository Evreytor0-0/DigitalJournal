using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DigitalJournal
{
    /// <summary>
    /// Логика взаимодействия для Zaprosy.xaml
    /// </summary>
    public partial class Zaprosy : Page
    {
        public Subpage Subpage;

        public Zaprosy(Subpage subpage)
        {
            InitializeComponent();

            Subpage = subpage;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //запрос
            string sql = "SELECT `zaprosy`.`id`, `journal`.`fio_zayavitelya`, `vidy_zaprosov`.`vid_zaprosa`, `zaprosy`.`data_postupleniya_otveta` " +
                "FROM `zaprosy`, `journal`, `vidy_zaprosov` " +
                "WHERE `zaprosy`.`id_zaprosa` = `vidy_zaprosov`.id AND `zaprosy`.`id_zhurnala` = `journal`.`id` ORDER BY `journal`.`id`  ASC";
            List<List<string>> query = Database.ExecuteQuery(sql);
            List<ZaprosyTable> result = new List<ZaprosyTable>();
            foreach (var q in query)
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                result.Add(new ZaprosyTable(
                    q[0],
                    q[1],
                    q[2],
                    q[3] != "" ? q[3].Remove(q[3].Length - 9) : q[3]
                ));
            }
            grid.ItemsSource = result;
        }

        private void Otchet_OnClick(object sender, RoutedEventArgs e)
        {
            if (MinDate.Text != "" && MaxDate.Text != "")
            {
                string sql = "SELECT COUNT(`id`) FROM `zaprosy` WHERE `data_postupleniya_otveta`>='" +
                             DateTime.Parse(MinDate.Text).ToString("O") +
                             "' AND`data_postupleniya_otveta`<='" + DateTime.Parse(MaxDate.Text).ToString("O") + "' ";
                string otch = Database.ExecuteQuery(sql)[0][0];
                OtchetTextBlock.Text = otch;
            }
            else
            {
                MessageBox.Show("Введите даты начала и конца периода");
            }
        }
    }

    class ZaprosyTable
    {
        public ZaprosyTable(string zaprosId, string zaprosFio, string zapros, string dataOtv)
        {
            ZaprosId = zaprosId;
            ZaprosFIO = zaprosFio;
            Zapros = zapros;
            DataOtv = dataOtv;
        }

        public string ZaprosId { get; set; }
        public string ZaprosFIO { get; set; }
        public string Zapros { get; set; }
        public string DataOtv { get; set; }
    }
}
