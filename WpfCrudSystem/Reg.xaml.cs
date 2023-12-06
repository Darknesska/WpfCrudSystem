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

namespace WpfCrudSystem
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        public bool cheked = false;
        string text;
        public Reg()
        {
            InitializeComponent();
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            cheked = false;
            string log = name.Text;
            string pass = pas.Text;
            string pse = pase.Text;
            if ((!string.IsNullOrEmpty(log)) && (!string.IsNullOrEmpty(pass)) && (!string.IsNullOrEmpty(pse)) && (pass == pse))
            {
                if (!string.IsNullOrEmpty(File.ReadAllText("user.json")))
                {
                    using (StreamReader sr = new StreamReader("user.json"))
                    {
                        string text1 = sr.ReadToEnd();
                        text = JsonSerializer.Deserialize<string>(text1);
                        string[] arr = text.Split(";");
                        for (int i = 0; i < arr.Length; i += 2)
                        {
                            if (log == arr[i] && pass == arr[i + 1])
                            {
                                MessageBox.Show("такой пользователь уже есть");
                                cheked = true;
                                break;
                            }
                        }

                    }
                    if (!cheked)
                    {
                        using (StreamWriter sw = new StreamWriter("user.json"))
                        {
                            string personJson = JsonSerializer.Serialize(text + ";" + log + ";" + pass);
                            sw.Write(personJson);
                        }
                    }
                    cheked = true;
                    Auth auth = new Auth();
                    auth.Show();
                    this.Close();
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter("user.json"))
                    {
                        string personJson = JsonSerializer.Serialize(log + ";" + pass);
                        sw.Write(personJson);
                    }
                    Auth auth = new Auth();
                    auth.Show();
                    this.Close();
                }


            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }
    }
}
