using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Change
{
    /// <summary>
    /// Логика взаимодействия для Marks.xaml
    /// </summary>
    public partial class Marks : Page
    {
        public Subpage subpage;
        public CheckBox checkBox = new CheckBox();
        List<MarksTable> result = new List<MarksTable>();
        public Marks(Subpage _subpage)
        {
            InitializeComponent();

            subpage = _subpage;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            savebtn.Visibility = Visibility.Hidden;
            savebtn.Visibility = Visibility.Collapsed;
            grid.CanUserAddRows = true;
            string sql = "";
            //запрос
            if (User._right == 2)//teacher
            {
                dropbtn.Visibility = Visibility.Hidden;
                dropbtn.Visibility = Visibility.Collapsed;
                sql = "SELECT * FROM `zaprosy`";
                List<List<string>> query = Database.ExecuteQuery(sql);
                for (int i = 0; i < query.Count; i++)
                {
                    result.Add(new MarksTable(
                        query[i][0],
                        query[i][1],
                        query[i][2]
                        ));
                }
                grid.ItemsSource = result;
            }
            else
            {
                if (User._right == 1)//admin
                {
                    sql = "SELECT * FROM `zaprosy`";
                    List<List<string>> query = Database.ExecuteQuery(sql);
                    for (int i = 0; i < query.Count; i++)
                    {
                        result.Add(new MarksTable(
                            query[i][0],
                            query[i][1],
                            query[i][2],
                            query[i][3],
                            query[i][4],
                            query[i][5]
                            ));
                    }
                    grid.ItemsSource = result;
                }
                else
                {

                    sql = "SELECT * FROM `zaprosy`";
                    List<List<string>> query = Database.ExecuteQuery(sql);
                    for (int i = 0; i < query.Count; i++)
                    {
                        result.Add(new MarksTable(
                            query[i][0],
                            query[i][1]
                            ));
                    }
                    grid.CanUserAddRows = false;
                    grid.ItemsSource = result;
                }
            }
        }

        private void Drop_Click(object sender, RoutedEventArgs e)
        {
            while (grid.SelectedIndex != -1)
            {
                string sql = "DELETE FROM `marks`WHERE id=" + result[grid.SelectedIndex].Id;

                List<List<string>> query = Database.ExecuteQuery(sql);

                result = new List<MarksTable>();
                sql = "SELECT * FROM `zaprosy`";
                query = Database.ExecuteQuery(sql);
                for (int i = 0; i < query.Count; i++)
                {
                    result.Add(new MarksTable(
                        query[i][0],
                        query[i][1],
                        query[i][2],
                        query[i][3],
                        query[i][4],
                        query[i][5]
                        ));
                }
                grid.ItemsSource = result;
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedIndex != -1)
            {
                changebtn.Visibility = Visibility.Hidden;
                dropbtn.Visibility = Visibility.Hidden;
                if (User._right == 2)
                    dropbtn.Visibility = Visibility.Hidden;

                savebtn.Visibility = Visibility.Visible;
                string sql = "SELECT users.id, users.FIO, marks.id, marks.mark FROM users, marks, lessons, `group`, discipline_title " +
     "WHERE lessons.id = marks.idlesson AND marks.idstudent = `group`.id AND `group`.idstudent = users.id " +
     "AND lessons.id_discipline = discipline_title.id AND discipline_title.id = 2 AND `users`.`id` = " + result[grid.SelectedIndex].User;
                List<List<string>> query = Database.ExecuteQuery(sql);

                result = new List<MarksTable>();

                query = Database.ExecuteQuery(sql);
                for (int i = 0; i < query.Count; i++)
                {
                    result.Add(new MarksTable(
                        query[i][0],
                        query[i][1],
                        query[i][2],
                        query[i][3]
                        ));
                }
                grid.ItemsSource = result;
                grid.CanUserAddRows = true;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            savebtn.Visibility = Visibility.Hidden;
            dropbtn.Visibility = Visibility.Hidden;

            changebtn.Visibility = Visibility.Visible;
            string sql = "";
            for (int i = 0; i < result.Count; i++)
            {
                sql = "UPDATE `marks` SET `mark`=" + result[i].Date + " WHERE `id`=" + result[i].Title;
                Database.ExecuteQuery(sql);
            }

            List<List<string>> query = Database.ExecuteQuery(sql);

            result = new List<MarksTable>();
            sql = "SELECT users.id, `marks`.`id`, `discipline_title`.`title`, `lessons`.`date`, `users`.`FIO`, " +
"`marks`.`mark` FROM `users`, `marks`, `lessons`, `group`, `discipline_title` WHERE " +
"`lessons`.`id` = `marks`.`idlesson` AND `marks`.`idstudent` = `group`.`id` AND " +
"`group`.`idstudent` = `users`.`id` AND `lessons`.`id_discipline` = `discipline_title`.`id` ";
            query = Database.ExecuteQuery(sql);
            for (int i = 0; i < query.Count; i++)
            {
                result.Add(new MarksTable(
                    query[i][0],
                    query[i][1],
                    query[i][2],
                    query[i][3],
                    query[i][4],
                    query[i][5]
                    ));
            }
            grid.ItemsSource = result;
            if (User._right == 1)
                dropbtn.Visibility = Visibility.Visible;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    class MarksTable
    {
        public MarksTable(string user, string id, string title, string date, string fio, string mark)
        {
            this.User = user;
            this.Id = id;
            this.Title = title;
            this.Date = date;
            this.FIO = fio;
            this.Mark = mark;
        }

        public MarksTable(string user, string id, string title)
        {
            this.User = user;
            this.Id = id;
            this.Title = title;
        }
        public MarksTable(string user, string id)
        {
            this.User = user;
            this.Id = id;
        }

        public MarksTable(string user, string id, string title, string date)
        {
            this.User = user;
            this.Id = id;
            this.Title = title;
            this.Date = date;
        }

        public MarksTable(string id)
        {
            this.Id = id;
        }
        public MarksTable()
        {

        }
        public string User { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string FIO { get; set; }
        public string Mark { get; set; }
    }
}
