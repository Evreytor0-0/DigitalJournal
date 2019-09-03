using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DigitalJournal
{
    /// <summary>
    /// Логика взаимодействия для UserLogin.xaml
    /// </summary>
    public partial class Login : Page
    {
        public MainWindow MainWindow;

        public Login(MainWindow mainWindow)
        {
            InitializeComponent();

            MainWindow = mainWindow;

            UserLogin.Focus();
        }

        static string Md5(string text)
        {
            return Md5(Encoding.UTF8.GetBytes(text));
        }

        static string Md5(byte[] bytes)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(bytes);
                var sb = new StringBuilder(hashBytes.Length * 2);
                for (int i = 0; i < hashBytes.Length; i++) sb.AppendFormat("{0:x2}", hashBytes[i]);
                return sb.ToString();
            }
        }

        public void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (UserLogin.Text.Length > 0) // проверяем введён ли логин
            {
                if (Password.Password.Length > 0) // проверяем введён ли пароль
                {
                    // ищем в базе данных пользователя с такими данными
                    string sql = "SELECT * FROM specialist WHERE login = '" + UserLogin.Text + "' AND password = '" + Md5(Password.Password) + "'";
                    List<List<string>> query = Database.ExecuteQuery(sql);
                    if (query.Count > 0) // если такая запись существует
                    {
                        User.Id = Convert.ToInt32(query[0][0]);
                        if (UserLogin.Text == "admin")
                            User.Right = "admin";
                        else
                            User.Right = "user";
                        MainWindow.OpenPage(MainWindow.Pages.Subpage);
                    }
                    else MessageBox.Show("Пользователь не найден"); // выводим ошибку
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку
        }

        //public void Window_KeyDown(object sender, KeyEventArgs e) //переделать
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        if (user.IsFocused)
        //        {
        //            if (password.Password.Length > 0)
        //            {
        //                if (user.Text.Length > 0) // проверяем введён ли логин
        //                {
        //                    // ищем в базе данных пользователя с такими данными
        //                    string sql = "SELECT * FROM specialist WHERE login = '" + user.Text + "' AND password = '" + md5(password.Password) + "'";
        //                    List<List<string>> query = Database.ExecuteQuery(sql);
        //                    if (query.Count > 0) // если такая запись существует
        //                    {
        //                        mainWindow.OpenPage(MainWindow.Pages.subpage);
        //                    }
        //                    else MessageBox.Show("Пользователь не найден"); // выводим ошибку
        //                }
        //                else MessageBox.Show("Введите логин"); // выводим ошибку
        //            } else
        //                password.Focus();
        //        }
        //        else
        //        {
        //            if (user.Text.Length > 0) // проверяем введён ли логин
        //            {
        //                if (password.Password.Length > 0) // проверяем введён ли пароль
        //                {
        //                    // ищем в базе данных пользователя с такими данными
        //                    string sql = "SELECT * FROM specialist WHERE login = '" + user.Text + "' AND password = '" + md5(password.Password) + "'";
        //                    List<List<string>> query = Database.ExecuteQuery(sql);
        //                    if (query.Count > 0) // если такая запись существует
        //                    {
        //                        mainWindow.OpenPage(MainWindow.Pages.subpage);
        //                    }
        //                    else MessageBox.Show("Пользователь не найден"); // выводим ошибку
        //                }
        //                else MessageBox.Show("Введите пароль"); // выводим ошибку
        //            }
        //            else MessageBox.Show("Введите логин"); // выводим ошибку
        //        }               
        //    }
        //}

        //public void Window_KeyDown(object sender, KeyEventArgs e) //переделать, не работает
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        if ((UserLogin.IsFocused || Password.IsFocused) && UserLogin.Text.Length > 0 && Password.Password.Length > 0)
        //        {
        //            string sql = "SELECT * FROM specialist WHERE login = '" + UserLogin.Text + "' AND password = '" + Md5(Password.Password) + "'";
        //            List<List<string>> query = Database.ExecuteQuery(sql);
        //            if (query.Count > 0) // если такая запись существует
        //            {
        //                User.Id = Convert.ToInt32(query[0][0]);
        //                User.Right = UserLogin.Text;
        //                MainWindow.OpenPage(MainWindow.Pages.Subpage);
        //            }
        //        }
        //        else
        //        {
        //            if (UserLogin.IsFocused && Password.Password.Length == 0)
        //            {
        //                Password.Focus();
        //            }
        //        }
        //    }
        //}
    }
}
