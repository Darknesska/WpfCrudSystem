using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using WpfCrudSystem.Class;

namespace WpfCrudSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string pass;
        public string log;
        List<MyItem> items = new List<MyItem>()
        {

        };
        public MainWindow()
        {
            
            InitializeComponent();
            
            if (!string.IsNullOrEmpty(File.ReadAllText("kategory.json")))
            {
                string[] qwe = JsonSerializer.Deserialize<string>(File.ReadAllText("kategory.json")).Split(";");
                SortCategory.ItemsSource = qwe;
            }
            SortBy.ItemsSource = new string[] { "name", "cene", "kol", "opis" };
            SortDir.ItemsSource = new string[] { "SortBy", "DeSort" };
            string text1 = File.ReadAllText("tovar.json");
            try
            {
                if (!string.IsNullOrEmpty(JsonSerializer.Deserialize<string>(text1)))
                {
                    string text2 = JsonSerializer.Deserialize<string>(text1);

                    string[] arr = text2.Split(';');
                    for (int i = 0; i < arr.Length; i += 6)
                    {
                        items.Add(new MyItem(arr[i], arr[i + 1], arr[i + 2], arr[i + 3], arr[i + 4], arr[i + 5]));
                        Tovar tovar = new Tovar(arr[i], arr[i + 1], arr[i + 2], arr[i + 3], arr[i + 4]);
                        }
                    items = items.OrderBy(b => b.name2).ToList();
                    for (int i = 0; i < items.Count; i++)
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                    }
                    SortBy.SelectionChanged += SelectionChanged;
                    SortDir.SelectionChanged += SelectionChanged;
                    SortCategory.SelectionChanged += SelectionChanged;

                }
            }
            catch { }
        }
        public void Sortirovka()
        {
            var sort = SortCategory.SelectedItem.ToString();
            var SortProperty = SortBy.SelectedItem.ToString();
            var SortDirection = SortDir.SelectedItem.ToString();
            if (SortProperty == "name")
            {
                if (SortDirection == "SortBy")
                {
                    listTovarov.Items.Clear();
                    items = items.OrderBy(b => b.name2).ToList();
                    for (int i = 0; i < items.Count; i++)
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                    }
                }
                else
                {
                    listTovarov.Items.Clear();
                    items = items.OrderByDescending(b => b.name2).ToList();
                    for (int i = 0; i < items.Count; i++)
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                    }
                }
            }
            else if (SortProperty == "cene")
            {
                if (SortDirection == "SortBy")
                {
                    listTovarov.Items.Clear();
                    items = items.OrderBy(b => b.cena2).ToList();
                    for (int i = 0; i < items.Count; i++)
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                    }
                }
                else
                {
                    listTovarov.Items.Clear();
                    items = items.OrderByDescending(b => b.cena2).ToList();
                    for (int i = 0; i < items.Count; i++)
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                    }
                }
            }
            else if (SortProperty == "kol")
            {
                if (SortDirection == "SortBy")
                {
                    listTovarov.Items.Clear();
                    items = items.OrderBy(b => b.kol2).ToList();
                    for (int i = 0; i < items.Count; i++)
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                    }
                }
                else
                {
                    listTovarov.Items.Clear();
                    items = items.OrderByDescending(b => b.kol2).ToList();
                    for (int i = 0; i < items.Count; i++)
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                    }
                }
            }
            else if (SortProperty == "opis")
            {
                if (SortDirection == "SortBy")
                {
                    listTovarov.Items.Clear();
                    items = items.OrderBy(b => b.opis2).ToList();
                    for (int i = 0; i < items.Count; i++)
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                    }
                }
                else
                {
                    listTovarov.Items.Clear();
                    items = items.OrderByDescending(b => b.opis2).ToList();
                    for (int i = 0; i < items.Count; i++)
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                    }
                }
            }
            string[] qwe = JsonSerializer.Deserialize<string>(File.ReadAllText("kategory.json")).Split(";");
            for (int l = 0; l < qwe.Length; l++)
            {
                if (sort == "all")
                {
                    listTovarov.Items.Clear();
                    for (int i = 0; i < items.Count; i++)
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                    }
                }
                else if (qwe[l] == sort)
                {
                    listTovarov.Items.Clear();
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].cat == sort)
                        {
                            Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                            listTovarov.Items.Add(tovar);
                        }
                    }
                }

            }
        }

        private void addinmag_Click(object sender, RoutedEventArgs e)
        {
            Elements elements = new Elements();
            int items1 = listTovarov.SelectedIndex;
            var result = MessageBox.Show($"Добавить в корзину Товар {items1} ?", "Покупка", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes && items1 != -1)
            {
                int v;
                if (int.TryParse(numeric.Text, out v))
                {
                    v = int.Parse(numeric.Text);
                    elements.kor_add(items1, log, pass, v);
                    numeric.Text = null;
                    numeric.Text = "1";
                }
                else
                {
                    MessageBox.Show("Выбирете число товаров");
                    numeric.Text = null;
                }
            }

        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sortirovka();
        }
        private void korzina_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(log) && !string.IsNullOrEmpty(pass))
            {
                KorzinaWpf kor = new KorzinaWpf();
                kor.pass = pass;
                kor.log = log;
                kor.but3.Content = log + ";" + pass;
                kor.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("войдите в аккаунт или Зарегайте акк");
            }
        }

        private void SortDir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void but3_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void numeric_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void text1_TextChanged(object sender, TextChangedEventArgs e)
        {
            listTovarov.Items.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                char[] chars = text1.Text.ToLower().ToCharArray();
                if (chars.Length == 0)
                {
                    for (int k = 0; k < items.Count; k++)
                    {
                        Tovar tovar = new Tovar(items[k].name2, items[k].cena2, items[k].kol2, items[k].opis2, items[k].img2);
                        listTovarov.Items.Add(tovar);
                    }
                    break;
                }
                for (int l = 0; l < chars.Length; l++)
                {
                    if (items[i].name2.Contains(text1.Text))
                    {
                        Tovar tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(tovar);
                        break;
                    }
                }
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Гость может просматривовать товар." +
                " Клиент может покупать товар и просматрировать ");

        }
    }
}
