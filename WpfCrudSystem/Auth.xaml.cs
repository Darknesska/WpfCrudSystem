using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfCrudSystem.Class;

namespace WpfCrudSystem
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            string log = name.Text;
            string pass = pas.Text;
            if (!string.IsNullOrEmpty(log) && !string.IsNullOrEmpty(pass))
            {
                bool tr = false;
                string text;
                if (log.ToLower() == "admin" && pass.ToLower() == "admin" )
                {
                    tr = true;
                    AdminShop ad = new AdminShop();
                    ad.but3.Content = log.ToString();
                    MessageBox.Show("Admin на базе");
                    ad.Show();
                    this.Close();
                }
                if (!string.IsNullOrEmpty(File.ReadAllText("user.json")))
                {
                    using (StreamReader sr = new StreamReader("user.json"))
                    {
                        string text1 = sr.ReadToEnd();
                        text = JsonSerializer.Deserialize<string>(text1);
                    }
                    string[] arr = text.Split(";");
                    for (int i = 0; i < arr.Length; i += 2)
                    {
                        User user = new User(arr[i], arr[i + 1]);

                        if (log == user.login && pass == user.password)
                        {
                            tr = true;
                            using (StreamWriter sw = new StreamWriter("Malik.json", false))
                            {
                                sw.Write(JsonSerializer.Serialize(log + ";" + pass));
                            }
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.log = log;
                            mainWindow.pass = pass;
                            mainWindow.but3.Content = log;
                            MessageBox.Show("не админ , но тоже важен");
                            mainWindow.Show();
                            this.Close();
                            break;
                        }
                    }
                    if (!tr)
                    {
                        name.Text = null;
                        pas.Text = null;
                        MessageBox.Show("Некорректные данные");
                    }
                }
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Reg reg = new Reg();
            reg.Show();
            this.Close();
        }
    }
}
