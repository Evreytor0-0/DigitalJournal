using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using static DigitalJournal.Subpage;

namespace DigitalJournal
{
    /// <summary>
    /// Логика взаимодействия для Journal.xaml
    /// </summary>
    /// 


    public partial class Journal : Page
    {
        List<JournalTable> _result = new List<JournalTable>();
        public static int IdOfRow;
        public Subpage Subpage;
        private MessageBoxResult _btn;

        public Journal(Subpage subpage)
        {
            InitializeComponent();

            Subpage = subpage;
        }

        //Загрузка содержимого таблицы
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT " +
                            "`journal`.`id`, " +
                            "`journal`.`data_obrashcheniya`, " +
                            "`journal`.`data_postupleniya_dokumentov`, " +
                            "`sposoby_obrashcheniya`.`sposoby`, " +
                            "`journal`.`data_registracii`, " +
                            "`journal`.`fio_zayavitelya`, " +
                            "`journal`.`adres_zayavitelya`, " +
                            "`uslugi`.`uslugi`, " +
                            "`detiJoin`.`detiFIO`, " +
                            "`detiJoin`.`detiDate`, " +
                            "`journal`.`data_napravleniya_mvz`, " +
                            "`sposob_napravleniya_mvz_join`.`sposoby`, " +
                            "`journal`.`data_uvedomleniya_o_priostanovlenii`, " +
                            "`zaprosyJoin`.`vidZaprosa`, " +
                            "`zaprosyJoin`.`zaprosDate`, " +
                            "`statusJoin`.`status`, " +
                            "`journal`.`data_prinyatiya_resheniya`, " +
                            "`journal`.`data_nachala`, " +
                            "`journal`.`data_okonchaniya`, " +
                            "`journal`.`n_dela`, " +
                            "`prichiny_otkaza_join`.`prichina`, " +
                            "`journal`.`data_napravleniya_rezultata`, " +
                            "`specialist`.`fio` " +
                         "FROM " +
                            "`journal` " +
                         "LEFT JOIN( " +
                            "SELECT " +
                                "GROUP_CONCAT(`deti`.`FIO` SEPARATOR \", \") AS `detiFIO`, " +
                                "GROUP_CONCAT( " +
                                    "`deti`.`DataRozhdeniya` SEPARATOR \", \" " +
                            ") AS `detiDate`, " +
                            "`deti`.`JournalId` " +
                            "FROM " +
                                "`deti` " +
                            "GROUP BY " +
                                "`deti`.`JournalId` " +
                         ") `detiJoin` " +
                         "ON " +
                            "`detiJoin`.`JournalId` = `journal`.`id` " +
                         "LEFT JOIN( " +
                            "SELECT " +
                                "GROUP_CONCAT( " +
                                    "`vidy_zaprosov`.`vid_zaprosa` SEPARATOR \", \" " +
                                ") AS `vidZaprosa`, " +
                                "GROUP_CONCAT( " +
                                    "IFNULL(`zaprosy`.`data_postupleniya_otveta`, \"Нет ответа\") SEPARATOR \", \" " +
                                ") AS `zaprosDate`, " +
                                "`zaprosy`.`id_zhurnala` " +
                            "FROM " +
                                "`zaprosy`, " +
                                "`vidy_zaprosov` " +
                            "WHERE " +
                                "`zaprosy`.`id_zaprosa` = `vidy_zaprosov`.`id` " +
                            "GROUP BY " +
                                "`zaprosy`.`id_zhurnala` " +
                            ") AS `zaprosyJoin` " +
                            "ON " +
                                "`zaprosyJoin`.`id_zhurnala` = `journal`.`id`" +
                            "LEFT JOIN(" +
                                "SELECT " +
                                    "`sposob_napravleniya_mvz`.`id`, " +
                                    "`sposob_napravleniya_mvz`.`sposoby` " +
                                "FROM " +
                                    "`sposob_napravleniya_mvz` " +
                            ") AS `sposob_napravleniya_mvz_join` " +
                            "ON " +
                                "`sposob_napravleniya_mvz_join`.`id` = `journal`.`id_sposoba_naprvleniya` " +
                            "LEFT JOIN( " +
                                "SELECT " +
                                    "`status`.`id`, " +
                                    "`status`.`status` " +
                                "FROM " +
                                    "`status` " +
                            ") AS `statusJoin` " +
                            "ON " +
                                "`journal`.`id_rezultata` = `statusJoin`.`id` " +
                            "LEFT JOIN( " +
                                "SELECT " +
                                    "`prichiny_otkaza`.`id`, " +
                                    "`prichiny_otkaza`.`prichina` " +
                                "FROM " +
                                    "`prichiny_otkaza` " +
                            ") AS `prichiny_otkaza_join` " +
                            "ON " +
                                "`journal`.`id_prichiny_otkaza` = `prichiny_otkaza_join`.`id`, " +
                            "`sposoby_obrashcheniya`, " +
                            "`uslugi`, " +
                            "`specialist` " +
                         "WHERE " +
                            "`journal`.`id_sposoba_obrashcheniya` = `sposoby_obrashcheniya`.`id` AND " +
                            "`journal`.`id_uslugi` = `uslugi`.`id` AND `journal`.`id_specialista` = `specialist`.`id`" +
                            "ORDER BY `journal`.`id`  ASC";
            List<List<string>> query = Database.ExecuteQuery(sql);

            foreach (var q in query)
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                _result.Add(new JournalTable(
                    q[0],
                    q[1].Remove(q[1].Length - 9),
                    q[2] != "" ? q[2].Remove(q[2].Length - 9) : q[2],
                    q[3],
                    q[4].Remove(q[1].Length - 9),
                    q[5].Replace(" ", "\r\n"),
                    q[6],
                    q[7],
                    q[8].Replace(", ", ",\r\n"),
                    q[9].Replace(", ", ",\r\n"),
                    q[10] != "" ? q[10].Remove(q[10].Length - 9) : q[10],
                    q[11],
                    q[12] != "" ? q[12].Remove(q[12].Length - 9) : q[12],
                    q[13].Replace(", ", ",\r\n"),
                    q[14].Replace(", ", ",\r\n"),
                    q[15],
                    q[16].Remove(q[1].Length - 9),
                    q[17] != "" ? q[17].Remove(q[17].Length - 9) : q[17],
                    q[18] != "" ? q[18].Remove(q[18].Length - 9) : q[18],
                    q[19],
                    q[20],
                    q[21] != "" ? q[21].Remove(q[21].Length - 9) : q[21],
                    q[22]
                ));
            }
            grid.ItemsSource = _result;
        }

        private void Drop_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedIndex != -1)
            {
                _btn = MessageBox.Show("Удалить строку?", "Сообщение", MessageBoxButton.YesNo);
                if (_btn == MessageBoxResult.Yes)
                {
                    string sql = "";
                    IdOfRow = Convert.ToInt32(_result[grid.SelectedIndex].JournalId);

                    sql += "DELETE FROM `deti` WHERE `JournalId` = " + IdOfRow + ";";
                    sql += "DELETE FROM `zaprosy` WHERE `id_zhurnala` = " + IdOfRow + ";";
                    sql += "DELETE FROM `journal` WHERE `journal`.`id` = " + IdOfRow + "; ";
                    Database.ExecuteQuery(sql);
                    Subpage.OpenSubpage(Subpages.Journal);
                }

                if (_btn == MessageBoxResult.No)
                {
                    grid.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("Выберите строку");
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedIndex != -1)
            {
                IdOfRow = Convert.ToInt32(_result[grid.SelectedIndex].JournalId);
                Subpage.OpenSubpage(Subpages.EditJournalRow);
            }
            else
            {
                MessageBox.Show("Выберите строку");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Subpage.OpenSubpage(Subpages.AddJournalRow);
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = null;
            _result.Clear();
            string sql = "SELECT " +
                            "`journal`.`id`, " +
                            "`journal`.`data_obrashcheniya`, " +
                            "`journal`.`data_postupleniya_dokumentov`, " +
                            "`sposoby_obrashcheniya`.`sposoby`, " +
                            "`journal`.`data_registracii`, " +
                            "`journal`.`fio_zayavitelya`, " +
                            "`journal`.`adres_zayavitelya`, " +
                            "`uslugi`.`uslugi`, " +
                            "`detiJoin`.`detiFIO`, " +
                            "`detiJoin`.`detiDate`, " +
                            "`journal`.`data_napravleniya_mvz`, " +
                            "`sposob_napravleniya_mvz_join`.`sposoby`, " +
                            "`journal`.`data_uvedomleniya_o_priostanovlenii`, " +
                            "`zaprosyJoin`.`vidZaprosa`, " +
                            "`zaprosyJoin`.`zaprosDate`, " +
                            "`statusJoin`.`status`, " +
                            "`journal`.`data_prinyatiya_resheniya`, " +
                            "`journal`.`data_nachala`, " +
                            "`journal`.`data_okonchaniya`, " +
                            "`journal`.`n_dela`, " +
                            "`prichiny_otkaza_join`.`prichina`, " +
                            "`journal`.`data_napravleniya_rezultata`, " +
                            "`specialist`.`fio` " +
                         "FROM " +
                            "`journal` " +
                         "LEFT JOIN( " +
                            "SELECT " +
                                "GROUP_CONCAT(`deti`.`FIO` SEPARATOR \", \") AS `detiFIO`, " +
                                "GROUP_CONCAT( " +
                                    "`deti`.`DataRozhdeniya` SEPARATOR \", \" " +
                            ") AS `detiDate`, " +
                            "`deti`.`JournalId` " +
                            "FROM " +
                                "`deti` " +
                            "GROUP BY " +
                                "`deti`.`JournalId` " +
                         ") `detiJoin` " +
                         "ON " +
                            "`detiJoin`.`JournalId` = `journal`.`id` " +
                         "LEFT JOIN( " +
                            "SELECT " +
                                "GROUP_CONCAT( " +
                                    "`vidy_zaprosov`.`vid_zaprosa` SEPARATOR \", \" " +
                                ") AS `vidZaprosa`, " +
                                "GROUP_CONCAT( " +
                                    "IFNULL(`zaprosy`.`data_postupleniya_otveta`, \"Нет ответа\") SEPARATOR \", \" " +
                                ") AS `zaprosDate`, " +
                                "`zaprosy`.`id_zhurnala` " +
                            "FROM " +
                                "`zaprosy`, " +
                                "`vidy_zaprosov` " +
                            "WHERE " +
                                "`zaprosy`.`id_zaprosa` = `vidy_zaprosov`.`id` " +
                            "GROUP BY " +
                                "`zaprosy`.`id_zhurnala` " +
                            ") AS `zaprosyJoin` " +
                            "ON " +
                                "`zaprosyJoin`.`id_zhurnala` = `journal`.`id`" +
                            "LEFT JOIN(" +
                                "SELECT " +
                                    "`sposob_napravleniya_mvz`.`id`, " +
                                    "`sposob_napravleniya_mvz`.`sposoby` " +
                                "FROM " +
                                    "`sposob_napravleniya_mvz` " +
                            ") AS `sposob_napravleniya_mvz_join` " +
                            "ON " +
                                "`sposob_napravleniya_mvz_join`.`id` = `journal`.`id_sposoba_naprvleniya` " +
                            "LEFT JOIN( " +
                                "SELECT " +
                                    "`status`.`id`, " +
                                    "`status`.`status` " +
                                "FROM " +
                                    "`status` " +
                            ") AS `statusJoin` " +
                            "ON " +
                                "`journal`.`id_rezultata` = `statusJoin`.`id` " +
                            "LEFT JOIN( " +
                                "SELECT " +
                                    "`prichiny_otkaza`.`id`, " +
                                    "`prichiny_otkaza`.`prichina` " +
                                "FROM " +
                                    "`prichiny_otkaza` " +
                            ") AS `prichiny_otkaza_join` " +
                            "ON " +
                                "`journal`.`id_prichiny_otkaza` = `prichiny_otkaza_join`.`id`, " +
                            "`sposoby_obrashcheniya`, " +
                            "`uslugi`, " +
                            "`specialist` " +
                         "WHERE " +
                            "`journal`.`id_sposoba_obrashcheniya` = `sposoby_obrashcheniya`.`id` AND " +
                            "`journal`.`id_uslugi` = `uslugi`.`id` AND `journal`.`id_specialista` = `specialist`.`id`  AND `journal`.`fio_zayavitelya` LIKE '" + FilterTextBox.Text + "%' " +
                            "ORDER BY `journal`.`id`  ASC";
            List<List<string>> query = Database.ExecuteQuery(sql);

            foreach (var q in query)
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                _result.Add(new JournalTable(
                    q[0],
                    q[1].Remove(q[1].Length - 9),
                    q[2] != "" ? q[2].Remove(q[2].Length - 9) : q[2],
                    q[3],
                    q[4].Remove(q[1].Length - 9),
                    q[5].Replace(" ", "\r\n"),
                    q[6],
                    q[7],
                    q[8].Replace(", ", ",\r\n"),
                    q[9].Replace(", ", ",\r\n"),
                    q[10] != "" ? q[10].Remove(q[10].Length - 9) : q[10],
                    q[11],
                    q[12] != "" ? q[12].Remove(q[12].Length - 9) : q[12],
                    q[13].Replace(", ", ",\r\n"),
                    q[14].Replace(", ", ",\r\n"),
                    q[15],
                    q[16].Remove(q[1].Length - 9),
                    q[17] != "" ? q[17].Remove(q[17].Length - 9) : q[17],
                    q[18] != "" ? q[18].Remove(q[18].Length - 9) : q[18],
                    q[19],
                    q[20],
                    q[21] != "" ? q[21].Remove(q[21].Length - 9) : q[21],
                    q[22]
                ));
            }
            grid.ItemsSource = _result;
        }
    }

    class JournalTable
    {
        public JournalTable(
            string journalId, string journalDataObrashcheniya, string journalDataPostupleniyaDokumentov,
            string sposobyObrashcheniyaSposoby, string journalDataRegistracii, string journalFioZayavitelya,
            string journalAdresZayavitelya, string uslugiUslugi, string detiJoinDetiFio,
            string detiJoinDetiDate, string journalDataNapravleniyaMvz,
            string sposobNapravleniyaMvzSposoby, string journalDataUvedomleniyaOPriostanovlenii,
            string zaprosyJoinVidZaprosa, string zaprosiJoinZaprosDate, string statusStatus,
            string journalDataPrinyatiyaResheniya, string journalDataNachala, string journalDataOkonchaniya, string journalNDela,
            string prichinyOtkazarichina, string journalDataNapravleniyaRezultata, string specialistFio
            )
        {
            JournalId = journalId;
            JournalDataObrashcheniya = journalDataObrashcheniya;
            JournalDataPostupleniyaDokumentov = journalDataPostupleniyaDokumentov;
            SposobyObrashcheniyaSposoby = sposobyObrashcheniyaSposoby;
            JournalDataRegistracii = journalDataRegistracii;
            JournalFioZayavitelya = journalFioZayavitelya;
            JournalAdresZayavitelya = journalAdresZayavitelya;
            UslugiUslugi = uslugiUslugi;
            DetiJoinDetiFio = detiJoinDetiFio;
            DetiJoinDetiDate = detiJoinDetiDate;
            JournalDataNapravleniyaMvz = journalDataNapravleniyaMvz;
            SposobNapravleniyaMvzSposoby = sposobNapravleniyaMvzSposoby;
            JournalDataUvedomleniyaOPriostanovlenii = journalDataUvedomleniyaOPriostanovlenii;
            ZaprosyJoinVidZaprosa = zaprosyJoinVidZaprosa;
            ZaprosiJoinZaprosDate = zaprosiJoinZaprosDate;
            StatusStatus = statusStatus;
            JournalDataPrinyatiyaResheniya = journalDataPrinyatiyaResheniya;
            JournalDataNachala = journalDataNachala;
            JournalDataOkonchaniya = journalDataOkonchaniya;
            JournalNDela = journalNDela;
            PrichinyOtkazaPrichina = prichinyOtkazarichina;
            JournalDataNapravleniyaRezultata = journalDataNapravleniyaRezultata;
            SpecialistFio = specialistFio;
        }

        public string JournalId { get; set; }
        public string JournalDataObrashcheniya { get; set; }
        public string JournalDataPostupleniyaDokumentov { get; set; }
        public string SposobyObrashcheniyaSposoby { get; set; }
        public string JournalDataRegistracii { get; set; }
        public string JournalFioZayavitelya { get; set; }
        public string JournalAdresZayavitelya { get; set; }
        public string UslugiUslugi { get; set; }
        public string DetiJoinDetiFio { get; set; }
        public string DetiJoinDetiDate { get; set; }
        public string JournalDataNapravleniyaMvz { get; set; }
        public string SposobNapravleniyaMvzSposoby { get; set; }
        public string JournalDataUvedomleniyaOPriostanovlenii { get; set; }
        public string ZaprosyJoinVidZaprosa { get; set; }
        public string ZaprosiJoinZaprosDate { get; set; }
        public string StatusStatus { get; set; }
        public string JournalDataPrinyatiyaResheniya { get; set; }
        public string JournalDataNachala { get; set; }
        public string JournalDataOkonchaniya { get; set; }
        public string JournalNDela { get; set; }
        public string PrichinyOtkazaPrichina { get; set; }
        public string JournalDataNapravleniyaRezultata { get; set; }
        public string SpecialistFio { get; set; }
    }
}
