using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DigitalJournal
{
    /// <summary>
    /// Логика взаимодействия для Spravochniki.xaml
    /// </summary>
    public partial class Spravochniki : Page
    {
        public Subpage Subpage;

        List<PrichinyOtkazaGrid> PrichinyOtkazaGridData = new List<PrichinyOtkazaGrid>();
        List<SposobyObrashcheniyaGrid> SposobyObrashcheniyaGridData = new List<SposobyObrashcheniyaGrid>();
        List<StatusGrid> StatusGridData = new List<StatusGrid>();
        List<UslugiGrid> UslugiGridData = new List<UslugiGrid>();
        List<NachaloUslugiGrid> NachaloUslugiGridData = new List<NachaloUslugiGrid>();
        List<SposobNapravleniyaMvzGrid> SposobNapravleniyaMvzGridData = new List<SposobNapravleniyaMvzGrid>();
        List<VidyZaprosovGrid> VidyZaprosovGridData = new List<VidyZaprosovGrid>();

        public Spravochniki(Subpage subpage)
        {
            InitializeComponent();

            PrichinyOtkazaGrid.RowEditEnding += delegate //добавление и изменение строк
            {
                if (PrichinyOtkazaGridData[PrichinyOtkazaGrid.SelectedIndex].PrichinaId == null)
                {
                    string sql = "INSERT INTO `prichiny_otkaza` (`id`, `prichina`) VALUES(NULL, '" +
                                 PrichinyOtkazaGridData[PrichinyOtkazaGrid.SelectedIndex].Prichina + "')";
                    Database.ExecuteQuery(sql);
                }
                else
                {
                    string sql = "UPDATE `prichiny_otkaza` SET `prichina` = '" +
                                 PrichinyOtkazaGridData[PrichinyOtkazaGrid.SelectedIndex].Prichina +
                                 "' WHERE `id` = " +
                                 PrichinyOtkazaGridData[PrichinyOtkazaGrid.SelectedIndex].PrichinaId;
                    Database.ExecuteQuery(sql);
                }

                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
            };

            PrichinyOtkazaGrid.PreviewKeyDown += delegate (object sender, KeyEventArgs args) //удаление строк
            {
                if (args.Key == Key.Delete && PrichinyOtkazaGrid.SelectedIndex < PrichinyOtkazaGridData.Count)
                {
                    MessageBoxResult _btn;
                    _btn = MessageBox.Show(
                        "Удалить строку: " + PrichinyOtkazaGridData[PrichinyOtkazaGrid.SelectedIndex].PrichinaId + ", " +
                        PrichinyOtkazaGridData[PrichinyOtkazaGrid.SelectedIndex].Prichina + "?",
                        "Подтвердите действие",
                        MessageBoxButton.YesNo);
                    if (_btn == MessageBoxResult.No)
                        PrichinyOtkazaGrid.CanUserDeleteRows = false;
                    if (_btn == MessageBoxResult.Yes)
                    {
                        PrichinyOtkazaGrid.CanUserDeleteRows = true;
                        if (PrichinyOtkazaGridData[PrichinyOtkazaGrid.SelectedIndex].PrichinaId != null)
                        {
                            string sql = "DELETE FROM `prichiny_otkaza` WHERE `id` = " +
                                         PrichinyOtkazaGridData[PrichinyOtkazaGrid.SelectedIndex].PrichinaId;
                            Database.ExecuteQuery(sql);
                            if (Database.Error)
                            {
                                PrichinyOtkazaGrid.CanUserDeleteRows = false;
                                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
                            }
                        }
                    }
                }
            };

            SposobyObrashcheniyaGrid.RowEditEnding += delegate //добавление и изменение строк
            {
                if (SposobyObrashcheniyaGridData[SposobyObrashcheniyaGrid.SelectedIndex].SposobObrId == null)
                {
                    string sql = "INSERT INTO `sposoby_obrashcheniya` (`id`, `sposoby`) VALUES (NULL, '" +
                                 SposobyObrashcheniyaGridData[SposobyObrashcheniyaGrid.SelectedIndex].SposobObr + "')";
                    Database.ExecuteQuery(sql);
                }
                else
                {
                    string sql = "UPDATE `sposoby_obrashcheniya` SET `sposoby` = '" +
                                 SposobyObrashcheniyaGridData[SposobyObrashcheniyaGrid.SelectedIndex].SposobObr +
                                 "' WHERE `id` = " +
                                 SposobyObrashcheniyaGridData[SposobyObrashcheniyaGrid.SelectedIndex].SposobObrId;
                    Database.ExecuteQuery(sql);
                }

                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
            };

            SposobyObrashcheniyaGrid.PreviewKeyDown += delegate (object sender, KeyEventArgs args) //удаление строк
            {
                if (args.Key == Key.Delete &&
                    SposobyObrashcheniyaGrid.SelectedIndex < SposobyObrashcheniyaGridData.Count)
                {
                    MessageBoxResult _btn;
                    _btn = MessageBox.Show(
                        "Удалить строку: " + SposobyObrashcheniyaGridData[SposobyObrashcheniyaGrid.SelectedIndex].SposobObrId + ", " +
                        SposobyObrashcheniyaGridData[SposobyObrashcheniyaGrid.SelectedIndex].SposobObr + "?",
                        "Подтвердите действие",
                        MessageBoxButton.YesNo);
                    if (_btn == MessageBoxResult.No)
                        SposobyObrashcheniyaGrid.CanUserDeleteRows = false;
                    if (_btn == MessageBoxResult.Yes)
                    {
                        SposobyObrashcheniyaGrid.CanUserDeleteRows = true;
                        if (SposobyObrashcheniyaGridData[SposobyObrashcheniyaGrid.SelectedIndex].SposobObrId != null)
                        {
                            string sql = "DELETE FROM `sposoby_obrashcheniya` WHERE `id` = " +
                                         SposobyObrashcheniyaGridData[SposobyObrashcheniyaGrid.SelectedIndex]
                                             .SposobObrId;
                            Database.ExecuteQuery(sql);
                            if (Database.Error)
                            {
                                SposobyObrashcheniyaGrid.CanUserDeleteRows = false;
                                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
                            }
                        }
                    }
                }
            };

            StatusGrid.RowEditEnding += delegate //добавление и изменение строк
            {

                if (StatusGridData[StatusGrid.SelectedIndex].StatusId == null)
                {
                    string sql = "INSERT INTO `status`(`id`, `status`) VALUES (NULL, '" +
                                 StatusGridData[StatusGrid.SelectedIndex].Status + "')";
                    Database.ExecuteQuery(sql);
                }
                else
                {
                    string sql = "UPDATE `status` SET `status` = '" +
                                 StatusGridData[StatusGrid.SelectedIndex].Status +
                                 "' WHERE `id` = " +
                                 StatusGridData[StatusGrid.SelectedIndex].StatusId;
                    Database.ExecuteQuery(sql);
                }

                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
            };

            StatusGrid.PreviewKeyDown += delegate (object sender, KeyEventArgs args) //удаление строк
            {
                if (args.Key == Key.Delete &&
                    StatusGrid.SelectedIndex < StatusGridData.Count)
                {
                    MessageBoxResult _btn;
                    _btn = MessageBox.Show(
                        "Удалить строку: " + StatusGridData[StatusGrid.SelectedIndex].StatusId + ", " +
                        StatusGridData[StatusGrid.SelectedIndex].Status + "?",
                        "Подтвердите действие",
                        MessageBoxButton.YesNo);
                    if (_btn == MessageBoxResult.No)
                        StatusGrid.CanUserDeleteRows = false;
                    if (_btn == MessageBoxResult.Yes)
                    {
                        StatusGrid.CanUserDeleteRows = true;
                        if (StatusGridData[StatusGrid.SelectedIndex].StatusId != null)
                        {
                            string sql = "DELETE FROM `status` WHERE `id` = " +
                                         StatusGridData[StatusGrid.SelectedIndex]
                                             .StatusId;
                            Database.ExecuteQuery(sql);
                            if (Database.Error)
                            {
                                StatusGrid.CanUserDeleteRows = false;
                                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
                            }
                        }
                    }
                }
            };

            UslugiGrid.RowEditEnding += delegate //добавление и изменение строк
            {
                if (UslugiGridData[UslugiGrid.SelectedIndex].UslugaId == null)
                {
                    string sql = "INSERT INTO `uslugi`(`id`, `uslugi`, `id_nachala`) VALUES (NULL,'" +
                                 UslugiGridData[UslugiGrid.SelectedIndex].Usluga + "','" +
                                 UslugiGridData[UslugiGrid.SelectedIndex].NachcloUslugi + "')";
                    Database.ExecuteQuery(sql);
                }
                else
                {
                    string sql = "UPDATE `uslugi` SET `uslugi`='" + UslugiGridData[UslugiGrid.SelectedIndex].Usluga +
                                 "',`id_nachala`='" + UslugiGridData[UslugiGrid.SelectedIndex].NachcloUslugi +
                                 "' WHERE  `id`=" + UslugiGridData[UslugiGrid.SelectedIndex].UslugaId;
                    Database.ExecuteQuery(sql);
                }

                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
            };

            UslugiGrid.PreviewKeyDown += delegate (object sender, KeyEventArgs args) //удаление строк
            {
                if (args.Key == Key.Delete &&
                    UslugiGrid.SelectedIndex < UslugiGridData.Count)
                {
                    MessageBoxResult _btn;
                    _btn = MessageBox.Show(
                        "Удалить строку: " + UslugiGridData[UslugiGrid.SelectedIndex].UslugaId + ", " +
                        UslugiGridData[UslugiGrid.SelectedIndex].Usluga + ", " +
                        UslugiGridData[UslugiGrid.SelectedIndex].NachcloUslugi + "?",
                        "Подтвердите действие",
                        MessageBoxButton.YesNo);
                    if (_btn == MessageBoxResult.No)
                        UslugiGrid.CanUserDeleteRows = false;
                    if (_btn == MessageBoxResult.Yes)
                    {
                        UslugiGrid.CanUserDeleteRows = true;
                        if (UslugiGridData[UslugiGrid.SelectedIndex].UslugaId != null)
                        {
                            string sql = "DELETE FROM `uslugi` WHERE `id` = " +
                            UslugiGridData[UslugiGrid.SelectedIndex]
                                .UslugaId;
                            Database.ExecuteQuery(sql);
                            if (Database.Error)
                            {
                                UslugiGrid.CanUserDeleteRows = false;
                                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
                            }
                        }
                    }
                }
            };

            NachaloUslugiGrid.RowEditEnding += delegate //добавление и изменение строк
            {
                if (NachaloUslugiGridData[NachaloUslugiGrid.SelectedIndex].NachaloId == null)
                {
                    string sql = "INSERT INTO `nachalo_uslugi`(`id`, `nachalo`) VALUES (NULL, '" +
                    NachaloUslugiGridData[NachaloUslugiGrid.SelectedIndex].Nachalo + "')";
                    Database.ExecuteQuery(sql);
                }
                else
                {
                    string sql = "UPDATE `nachalo_uslugi` SET `nachalo` = '" +
                    NachaloUslugiGridData[NachaloUslugiGrid.SelectedIndex].Nachalo +
                    "' WHERE `id` = " +
                    NachaloUslugiGridData[NachaloUslugiGrid.SelectedIndex].NachaloId;
                    Database.ExecuteQuery(sql);
                }

                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
            };

            NachaloUslugiGrid.PreviewKeyDown += delegate (object sender, KeyEventArgs args) //удаление строк
            {
                if (args.Key == Key.Delete &&
                    NachaloUslugiGrid.SelectedIndex < NachaloUslugiGridData.Count)
                {
                    MessageBoxResult _btn;
                    _btn = MessageBox.Show(
                        "Удалить строку: " + NachaloUslugiGridData[NachaloUslugiGrid.SelectedIndex].NachaloId + ", " +
                        NachaloUslugiGridData[NachaloUslugiGrid.SelectedIndex].Nachalo + "?",
                        "Подтвердите действие",
                        MessageBoxButton.YesNo);
                    if (_btn == MessageBoxResult.No)
                        NachaloUslugiGrid.CanUserDeleteRows = false;
                    if (_btn == MessageBoxResult.Yes)
                    {
                        NachaloUslugiGrid.CanUserDeleteRows = true;
                        if (NachaloUslugiGridData[NachaloUslugiGrid.SelectedIndex].NachaloId != null)
                        {
                            string sql = "DELETE FROM `nachalo_uslugi` WHERE `id` = " +
                            NachaloUslugiGridData[NachaloUslugiGrid.SelectedIndex]
                                .NachaloId;
                            Database.ExecuteQuery(sql);
                            if (Database.Error)
                            {
                                NachaloUslugiGrid.CanUserDeleteRows = false;
                                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
                            }
                        }
                    }
                }
            };

            SposobNapravleniyaMvzGrid.RowEditEnding += delegate //добавление и изменение строк
            {
                if (SposobNapravleniyaMvzGridData[SposobNapravleniyaMvzGrid.SelectedIndex].SposobNaprId == null)
                {
                    string sql = "INSERT INTO `sposob_napravleniya_mvz`(`id`, `sposoby`) VALUES (NULL, '" +
                    SposobNapravleniyaMvzGridData[SposobNapravleniyaMvzGrid.SelectedIndex].SposobNapr + "')";
                    Database.ExecuteQuery(sql);
                }
                else
                {
                    string sql = "UPDATE `sposob_napravleniya_mvz` SET `sposoby` = '" +
                    SposobNapravleniyaMvzGridData[SposobNapravleniyaMvzGrid.SelectedIndex].SposobNapr +
                    "' WHERE `id` = " +
                    SposobNapravleniyaMvzGridData[SposobNapravleniyaMvzGrid.SelectedIndex].SposobNaprId;
                    Database.ExecuteQuery(sql);
                }

                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
            };

            SposobNapravleniyaMvzGrid.PreviewKeyDown += delegate (object sender, KeyEventArgs args) //удаление строк
            {
                if (args.Key == Key.Delete &&
                    SposobNapravleniyaMvzGrid.SelectedIndex < SposobNapravleniyaMvzGridData.Count)
                {
                    MessageBoxResult _btn;
                    _btn = MessageBox.Show(
                        "Удалить строку: " + SposobNapravleniyaMvzGridData[SposobNapravleniyaMvzGrid.SelectedIndex].SposobNaprId + ", " +
                        SposobNapravleniyaMvzGridData[SposobNapravleniyaMvzGrid.SelectedIndex].SposobNapr + "?",
                        "Подтвердите действие",
                        MessageBoxButton.YesNo);
                    if (_btn == MessageBoxResult.No)
                        SposobNapravleniyaMvzGrid.CanUserDeleteRows = false;
                    if (_btn == MessageBoxResult.Yes)
                    {
                        SposobNapravleniyaMvzGrid.CanUserDeleteRows = true;
                        if (SposobNapravleniyaMvzGridData[SposobNapravleniyaMvzGrid.SelectedIndex].SposobNaprId != null)
                        {
                            string sql = "DELETE FROM `sposob_napravleniya_mvz` WHERE `id` = " +
                            SposobNapravleniyaMvzGridData[SposobNapravleniyaMvzGrid.SelectedIndex]
                                .SposobNaprId;
                            Database.ExecuteQuery(sql);
                            if (Database.Error)
                            {
                                SposobNapravleniyaMvzGrid.CanUserDeleteRows = false;
                                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
                            }
                        }
                    }
                }
            };

            VidyZaprosovGrid.RowEditEnding += delegate //добавление и изменение строк
            {
                if (VidyZaprosovGridData[VidyZaprosovGrid.SelectedIndex].VidZaprosaId == null)
                {
                    string sql = "INSERT INTO `vidy_zaprosov`(`id`, `vid_zaprosa`) VALUES (NULL, '" +
                                 VidyZaprosovGridData[VidyZaprosovGrid.SelectedIndex].VidZaprosa + "')";
                    Database.ExecuteQuery(sql);
                }
                else
                {
                    string sql = "UPDATE `vidy_zaprosov` SET `vid_zaprosa` = '" +
                                 VidyZaprosovGridData[VidyZaprosovGrid.SelectedIndex].VidZaprosa +
                                 "' WHERE `id` = " +
                                 VidyZaprosovGridData[VidyZaprosovGrid.SelectedIndex].VidZaprosaId;
                    Database.ExecuteQuery(sql);
                }

                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
            };

            VidyZaprosovGrid.PreviewKeyDown += delegate (object sender, KeyEventArgs args) //удаление строк
            {
                if (args.Key == Key.Delete &&
                    VidyZaprosovGrid.SelectedIndex < VidyZaprosovGridData.Count)
                {
                    MessageBoxResult _btn;
                    _btn = MessageBox.Show(
                        "Удалить строку: " + VidyZaprosovGridData[VidyZaprosovGrid.SelectedIndex].VidZaprosaId + ", " +
                        VidyZaprosovGridData[VidyZaprosovGrid.SelectedIndex].VidZaprosa + "?",
                        "Подтвердите действие",
                        MessageBoxButton.YesNo);
                    if (_btn == MessageBoxResult.No)
                        VidyZaprosovGrid.CanUserDeleteRows = false;
                    if (_btn == MessageBoxResult.Yes)
                    {
                        VidyZaprosovGrid.CanUserDeleteRows = true;
                        if (VidyZaprosovGridData[VidyZaprosovGrid.SelectedIndex].VidZaprosaId != null)
                        {
                            string sql = "DELETE FROM `vidy_zaprosov` WHERE `id` = " +
                                         VidyZaprosovGridData[VidyZaprosovGrid.SelectedIndex]
                                             .VidZaprosaId;
                            Database.ExecuteQuery(sql);
                            if (Database.Error)
                            {
                                VidyZaprosovGrid.CanUserDeleteRows = false;
                                Subpage.OpenSubpage(Subpage.Subpages.Spravochniki);
                            }
                        }
                    }
                }
            };

            Subpage = subpage;
        }

        private void Prichiny_Otkaza_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT `id`, `prichina` FROM `prichiny_otkaza`";
            List<List<string>> query = Database.ExecuteQuery(sql);
            foreach (var q in query)
            {
                //элементы массива[] -это значения столбцов из запроса SELECT
                PrichinyOtkazaGridData.Add(new PrichinyOtkazaGrid(
                    q[0],
                    q[1]
                ));
            }

            PrichinyOtkazaGrid.ItemsSource = PrichinyOtkazaGridData;
        }

        private void Sposoby_Obrashcheniya_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT `id`, `sposoby` FROM `sposoby_obrashcheniya`";
            List<List<string>> query = Database.ExecuteQuery(sql);
            foreach (var q in query)
            {
                //элементы массива[] -это значения столбцов из запроса SELECT
                SposobyObrashcheniyaGridData.Add(new SposobyObrashcheniyaGrid(
                    q[0],
                    q[1]
                ));
            }

            SposobyObrashcheniyaGrid.ItemsSource = SposobyObrashcheniyaGridData;
        }

        private void Status_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT `id`, `status` FROM `status`";
            List<List<string>> query = Database.ExecuteQuery(sql);
            foreach (var q in query)
            {
                //элементы массива[] -это значения столбцов из запроса SELECT
                StatusGridData.Add(new StatusGrid(
                    q[0],
                    q[1]
                ));
            }

            StatusGrid.ItemsSource = StatusGridData;
        }

        private void Uslugi_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT `id`, `nachalo` FROM `nachalo_uslugi`";
            List<List<string>> query = Database.ExecuteQuery(sql);
            Dictionary<string, string> nachalo = new Dictionary<string, string>();
            for (int i = 0; i < query.Count(); i++)
            {
                nachalo.Add(query[i][0], query[i][1]);
            }

            Nachalo.ItemsSource = nachalo;

            sql = "SELECT `id`, `uslugi`, `id_nachala` FROM `uslugi`";
            query = Database.ExecuteQuery(sql);
            foreach (var q in query)
            {
                //элементы массива[] -это значения столбцов из запроса SELECT
                UslugiGridData.Add(new UslugiGrid(
                    q[0],
                    q[1],
                    q[2]
                ));
            }

            UslugiGrid.ItemsSource = UslugiGridData;
        }

        private void Nachalo_Uslugi_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT `id`, `nachalo` FROM `nachalo_uslugi`";
            List<List<string>> query = Database.ExecuteQuery(sql);
            foreach (var q in query)
            {
                //элементы массива[] -это значения столбцов из запроса SELECT
                NachaloUslugiGridData.Add(new NachaloUslugiGrid(
                    q[0],
                    q[1]
                ));
            }

            NachaloUslugiGrid.ItemsSource = NachaloUslugiGridData;
        }

        private void Sposob_Napravleniya_MVZ_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT `id`, `sposoby` FROM `sposob_napravleniya_mvz`";
            List<List<string>> query = Database.ExecuteQuery(sql);
            foreach (var q in query)
            {
                //элементы массива[] -это значения столбцов из запроса SELECT
                SposobNapravleniyaMvzGridData.Add(new SposobNapravleniyaMvzGrid(
                    q[0],
                    q[1]
                ));
            }

            SposobNapravleniyaMvzGrid.ItemsSource = SposobNapravleniyaMvzGridData;
        }

        private void Vidy_Zaprosov_Grid_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT `id`, `vid_zaprosa` FROM `vidy_zaprosov`";
            List<List<string>> query = Database.ExecuteQuery(sql);
            foreach (var q in query)
            {
                //элементы массива[] -это значения столбцов из запроса SELECT
                VidyZaprosovGridData.Add(new VidyZaprosovGrid(
                    q[0],
                    q[1]
                ));
            }

            VidyZaprosovGrid.ItemsSource = VidyZaprosovGridData;
        }
    }

    class PrichinyOtkazaGrid
    {
        public PrichinyOtkazaGrid(string prichinaId, string prichina)
        {
            PrichinaId = prichinaId;
            Prichina = prichina;
        }

        public PrichinyOtkazaGrid()
        {
        }

        public string PrichinaId { get; set; }
        public string Prichina { get; set; }
    }

    class SposobyObrashcheniyaGrid
    {
        public SposobyObrashcheniyaGrid(string sposobObrId, string sposobObr)
        {
            SposobObrId = sposobObrId;
            SposobObr = sposobObr;
        }

        public SposobyObrashcheniyaGrid()
        {
        }

        public string SposobObrId { get; set; }
        public string SposobObr { get; set; }
    }

    class StatusGrid
    {
        public StatusGrid(string statusId, string status)
        {
            StatusId = statusId;
            Status = status;
        }

        public StatusGrid()
        {
        }

        public string StatusId { get; set; }
        public string Status { get; set; }
    }

    class UslugiGrid
    {
        public UslugiGrid(string uslugaId, string usluga, string nachaloUslugi)
        {
            UslugaId = uslugaId;
            Usluga = usluga;
            NachcloUslugi = nachaloUslugi;
        }

        public UslugiGrid()
        {
        }

        public string UslugaId { get; set; }
        public string Usluga { get; set; }
        public string NachcloUslugi { get; set; }
    }

    class NachaloUslugiGrid
    {
        public NachaloUslugiGrid(string nachaloId, string nachalo)
        {
            NachaloId = nachaloId;
            Nachalo = nachalo;
        }

        public NachaloUslugiGrid()
        {
        }

        public string NachaloId { get; set; }
        public string Nachalo { get; set; }
    }

    class SposobNapravleniyaMvzGrid
    {
        public SposobNapravleniyaMvzGrid(string sposobNaprId, string sposobNapr)
        {
            SposobNaprId = sposobNaprId;
            SposobNapr = sposobNapr;
        }

        public SposobNapravleniyaMvzGrid()
        {
        }

        public string SposobNaprId { get; set; }
        public string SposobNapr { get; set; }
    }

    class VidyZaprosovGrid
    {
        public VidyZaprosovGrid(string vidZaprosaId, string vidZaprosa)
        {
            VidZaprosaId = vidZaprosaId;
            VidZaprosa = vidZaprosa;
        }

        public VidyZaprosovGrid()
        {
        }

        public string VidZaprosaId { get; set; }
        public string VidZaprosa { get; set; }
    }
}
