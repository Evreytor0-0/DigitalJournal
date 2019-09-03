using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DigitalJournal
{
    /// <summary>
    /// Логика взаимодействия для AddJournalRow.xaml
    /// </summary>
    public partial class AddJournalRow : Page
    {
        public Subpage Subpage;
        List<TextBox> _listDetiTextBox = new List<TextBox>();
        List<DatePicker> _listDetiDatePicker = new List<DatePicker>();
        List<ComboBox> _listZaprosyComboBox = new List<ComboBox>();
        List<Button> _listZaprosyDropButton = new List<Button>();
        List<Button> _listDetiDropButton = new List<Button>();
        public int DetiContextCount;
        public int ZaprosiContextCount;
        Dictionary<string, string> vidiZaprosov = new Dictionary<string, string>();

        public AddJournalRow(Subpage subpage)
        {
            InitializeComponent();

            Subpage = subpage;

            Binding();
        }

        private void Binding()
        {
            string sql = "SELECT * FROM `sposoby_obrashcheniya`";
            List<List<string>> query = Database.ExecuteQuery(sql);

            Dictionary<string, string> sposoby = new Dictionary<string, string>();

            for (int i = 0; i < query.Count(); i++)
            {
                sposoby.Add(query[i][0], query[i][1]);
            }

            SposobObr.ItemsSource = sposoby;

            sql = "SELECT `fio_zayavitelya` FROM `journal` GROUP BY `fio_zayavitelya`";
            query = Database.ExecuteQuery(sql);

            List<string> zayavitel = new List<string>();

            for (int i = 0; i < query.Count(); i++)
            {
                zayavitel.Add(query[i][0]);
            }

            FioZayav.ItemsSource = zayavitel;

            sql = "SELECT `adres_zayavitelya` FROM `journal` GROUP BY `adres_zayavitelya`";
            query = Database.ExecuteQuery(sql);

            List<string> adress = new List<string>();

            for (int i = 0; i < query.Count(); i++)
            {
                adress.Add(query[i][0]);
            }

            AdressZayav.ItemsSource = adress;

            sql = "SELECT * FROM `uslugi`";
            query = Database.ExecuteQuery(sql);

            Dictionary<string, string> uslugi = new Dictionary<string, string>();

            for (int i = 0; i < query.Count(); i++)
            {
                uslugi.Add(query[i][0], query[i][1]);
            }

            Usluga.ItemsSource = uslugi;

            sql = "SELECT * FROM `sposob_napravleniya_mvz`";
            query = Database.ExecuteQuery(sql);

            Dictionary<string, string> sposobZaprosa = new Dictionary<string, string>();

            for (int i = 0; i < query.Count(); i++)
            {
                sposobZaprosa.Add(query[i][0], query[i][1]);
            }

            SposobNaprav.ItemsSource = sposobZaprosa;

            sql = "SELECT * FROM `status`";
            query = Database.ExecuteQuery(sql);

            Dictionary<string, string> status = new Dictionary<string, string>();

            for (int i = 0; i < query.Count(); i++)
            {
                status.Add(query[i][0], query[i][1]);
            }

            Resultat.ItemsSource = status;

            sql = "SELECT `n_dela` FROM `journal` GROUP BY `n_dela`";
            query = Database.ExecuteQuery(sql);

            List<string> nDela = new List<string>();

            for (int i = 0; i < query.Count(); i++)
            {
                nDela.Add(query[i][0]);
            }

            NoDela.ItemsSource = nDela;

            sql = "SELECT * FROM `prichiny_otkaza`";
            query = Database.ExecuteQuery(sql);

            Dictionary<string, string> prichini = new Dictionary<string, string>();

            for (int i = 0; i < query.Count(); i++)
            {
                prichini.Add(query[i][0], query[i][1]);
            }

            Prichini.ItemsSource = prichini;

            sql = "SELECT * FROM `vidy_zaprosov`";
            query = Database.ExecuteQuery(sql);

            for (int i = 0; i < query.Count(); i++)
            {
                vidiZaprosov.Add(query[i][0], query[i][1]);
            }
        }

        private void Add_Child_Click(object sender, RoutedEventArgs e)
        {
            _listDetiDropButton.Add(new Button
            {
                Margin = new Thickness(0, 5, 0, 5),
                Content = "Удалить ребенка",
                Height = 58,
                Tag = _listDetiDropButton.Count
            });
            _listDetiDropButton[DetiContextCount].Click += Drop_Child_Click;
            _listDetiTextBox.Add(new TextBox
            {
                Margin = new Thickness(0, 5, 0, 5),
                MinWidth = 100,
                Height = 24,
                HorizontalAlignment = HorizontalAlignment.Left
            });
            _listDetiDatePicker.Add(new DatePicker
            {
                Margin = new Thickness(0, 5, 0, 5),
                Width = 100,
                Height = 24,
                HorizontalAlignment = HorizontalAlignment.Left
            });
            ChildrenDropBox.Children.Add(_listDetiDropButton[DetiContextCount]);
            ChildrenBox.Children.Add(_listDetiTextBox[DetiContextCount]);
            ChildrenBox.Children.Add(_listDetiDatePicker[DetiContextCount++]);
            UpdateLayout();
        }

        private void Add_Zapros_Click(object sender, RoutedEventArgs e)
        {
            if (DataNaprav.Text == "")
            {
                DataNaprav.SelectedDate = DateTime.Today;
            }

            _listZaprosyDropButton.Add(new Button
            {
                Margin = new Thickness(0, 5, 0, 5),
                Content = "Удалить запрос",
                Tag = _listZaprosyDropButton.Count
            });
            _listZaprosyDropButton[ZaprosiContextCount].Click += Drop_Zapros_Click;

            _listZaprosyComboBox.Add(new ComboBox
            {
                Margin = new Thickness(0, 5, 0, 5),
                SelectedValuePath = "Key",
                DisplayMemberPath = "Value",
                ItemsSource = vidiZaprosov,
                HorizontalAlignment = HorizontalAlignment.Left
            });
            ZaprosiDropBox.Children.Add(_listZaprosyDropButton[ZaprosiContextCount]);
            ZaprosiBox.Children.Add(_listZaprosyComboBox[ZaprosiContextCount++]);
            UpdateLayout();
        }

        private void Drop_Zapros_Click(object sender, RoutedEventArgs e) //удаление запроса
        {
            int index = _listZaprosyDropButton.FindIndex(s => Equals(s.Tag, ((Button)sender).Tag));
            _listZaprosyComboBox.RemoveAt(index);
            _listZaprosyDropButton.RemoveAt(index);
            ZaprosiDropBox.Children.RemoveAt(index);
            ZaprosiBox.Children.RemoveAt(index);
            ZaprosiContextCount--;
        }

        private void Drop_Child_Click(object sender, RoutedEventArgs e) //удаление детей
        {
            int index = _listDetiDropButton.FindIndex(s => Equals(s.Tag, ((Button)sender).Tag));
            _listDetiTextBox.RemoveAt(index);
            _listDetiDatePicker.RemoveAt(index);
            _listDetiDropButton.RemoveAt(index);
            ChildrenDropBox.Children.RemoveAt(index);
            ChildrenBox.Children.RemoveAt(index * 2);
            ChildrenBox.Children.RemoveAt(index * 2);
            DetiContextCount--;
        }

        private void Add_Row_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            if (DateObr.Text == "")
                message += "Введите дату обращения (дату заявления)\n";
            if (SposobObr.SelectedValue == null)
                message += "Введите способ обращения\n";
            if (FioZayav.Text == "")
                message += "Введите ФИО заявителя\n";
            if (AdressZayav.Text == "")
                message += "Введите Адрес заявителя\n";
            if (Usluga.SelectedValue == null)
                message += "Введите Услугу\n";
            if (DataResheniya.Text == "")
                message += "Введите Дату принятия решения\n";
            for (int i = 0; i < DetiContextCount; i++)
            {
                if (_listDetiTextBox[i].Text == "" && _listDetiDatePicker[i].Text != "" ||
                    _listDetiTextBox[i].Text != "" && _listDetiDatePicker[i].Text == "")
                    message += "Проверьте соответствие ФИО ребенка и даты его рождения\n";
            }
            if (message != "")
            {
                MessageBox.Show(message);
            }
            else
            {
                string sql =
                    "INSERT INTO `journal` (`id`, `data_obrashcheniya`, `data_postupleniya_dokumentov`,`id_sposoba_obrashcheniya`," +
                    " `data_registracii`, `fio_zayavitelya`, `adres_zayavitelya`, `id_uslugi`, `data_napravleniya_mvz`," +
                    " `id_sposoba_naprvleniya`, `data_uvedomleniya_o_priostanovlenii`, `id_rezultata`, `data_prinyatiya_resheniya`, " +
                    "`data_nachala`, `data_okonchaniya`, `n_dela`, `id_prichiny_otkaza`, `data_napravleniya_rezultata`, " +
                    "`id_specialista`) VALUES (NULL, '" +
                    DateTime.Parse(DateObr.Text).ToString("O") + "', " +
                    (DatePost.Text != "" ? "'" + DateTime.Parse(DateObr.Text).ToString("O") + "'" : "NULL") + ", '" +
                    SposobObr.SelectedValue + "', '" + DateTime.Parse(DateReg.Text).ToString("O") + "', '" +
                    FioZayav.Text + "', '" + AdressZayav.Text + "', '" + Usluga.SelectedValue + "', " +
                    (DataNaprav.Text != "" ? "'" + DateTime.Parse(DataNaprav.Text).ToString("O") + "'" : "NULL") +
                    ", " + (SposobNaprav.SelectedValue != null ? "'" + SposobNaprav.SelectedValue + "'" : "NULL") +
                    ", " +
                    (DataUvedoml.Text != "" ? "'" + DateTime.Parse(DataUvedoml.Text).ToString("O") + "'" : "NULL") +
                    ", " + (Resultat.SelectedValue != null ? "'" + Resultat.SelectedValue + "'" : "NULL") + ", '" +
                    DateTime.Parse(DataResheniya.Text).ToString("O") + "', " +
                    (DataNachala.Text != "" ? "'" + DateTime.Parse(DataNachala.Text).ToString("O") + "'" : "NULL") +
                    ", " +
                    (DataOkonchaniya.Text != ""
                        ? "'" + DateTime.Parse(DataOkonchaniya.Text).ToString("O") + "'"
                        : "NULL") + ", " + (NoDela.Text != "" ? "'" + NoDela.Text + "'" : "NULL") + ", " +
                    (Prichini.SelectedValue != null ? "'" + Prichini.SelectedValue + "'" : "NULL") + ", " +
                    (DataNapravleniya.Text != ""
                        ? "'" + DateTime.Parse(DataNapravleniya.Text).ToString("O") + "'"
                        : "NULL") + ", '" + User.Id + "'); SELECT LAST_INSERT_ID();";
                //запрос на добавление данных
                string lastJournalId = Database.ExecuteQuery(sql)[0][0];  //выполнение запроса и сохранение последнего id

                for (int i = 0; i < DetiContextCount; i++)
                {
                    if (_listDetiTextBox[i].Text != "" && _listDetiDatePicker[i].Text != "")
                    {
                        sql = "INSERT INTO `deti` (`id`, `FIO`, `DataRozhdeniya`, `JournalId`) VALUES (NULL, '" +
                              _listDetiTextBox[i].Text + "', '" + DateTime.Parse(_listDetiDatePicker[i].Text).ToString("O") + "', '" + lastJournalId +
                              "')";
                        Database.ExecuteQuery(sql);
                    }
                }

                for (int i = 0; i < ZaprosiContextCount; i++) //запрос на добавление запросов
                {
                    if (_listZaprosyComboBox[i].SelectedValue != null)
                    {
                        sql =
                            "INSERT INTO `zaprosy` (`id`, `id_zhurnala`, `id_zaprosa`, `data_postupleniya_otveta`) VALUES (NULL, '" +
                            lastJournalId + "', '" + _listZaprosyComboBox[i].SelectedValue + "', NULL)";
                        Database.ExecuteQuery(sql);
                    }
                }
                Subpage.OpenSubpage(Subpage.Subpages.Journal);
            }
        }

        private void FioZayav_KeyDown(object sender, KeyEventArgs e)
        {
            string sql = "SELECT `fio_zayavitelya` FROM `journal` WHERE `fio_zayavitelya` LIKE '" + FioZayav.Text + "%'  GROUP BY `fio_zayavitelya`";
            List<List<string>> query = Database.ExecuteQuery(sql);

            List<string> zayavitel = new List<string>();

            for (int i = 0; i < query.Count(); i++)
            {
                zayavitel.Add(query[i][0]);
            }

            FioZayav.ItemsSource = zayavitel;
        }

        private void AdressZayav_KeyDown(object sender, KeyEventArgs e)
        {
            string sql = "SELECT `adres_zayavitelya` FROM `journal` WHERE `adres_zayavitelya` LIKE '" + AdressZayav.Text + "%'  GROUP BY `adres_zayavitelya`";
            List<List<string>> query = Database.ExecuteQuery(sql);

            List<string> adress = new List<string>();

            for (int i = 0; i < query.Count(); i++)
            {
                adress.Add(query[i][0]);
            }

            AdressZayav.ItemsSource = adress;
        }

        private void NoDela_KeyDown(object sender, KeyEventArgs e)
        {
            string sql = "SELECT `n_dela` FROM `journal` WHERE `n_dela` LIKE '" + NoDela.Text + "%'  GROUP BY `n_dela`";
            List<List<string>> query = Database.ExecuteQuery(sql);

            List<string> nDela = new List<string>();

            for (int i = 0; i < query.Count(); i++)
            {
                nDela.Add(query[i][0]);
            }

            NoDela.ItemsSource = nDela;
        }
    }
}
