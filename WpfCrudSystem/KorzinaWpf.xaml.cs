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
    /// Логика взаимодействия для KorzinaWpf.xaml
    /// </summary>
    public partial class KorzinaWpf : Window
    {
        public string log;
        public string pass;
        List<MyItem> itemses = new List<MyItem>()
        {

        };
        public KorzinaWpf()
        {

            
            InitializeComponent();
            if (!string.IsNullOrEmpty(File.ReadAllText("kategory.json")))
            {
                string[] qwe = JsonSerializer.Deserialize<string>(File.ReadAllText("kategory.json")).Split(";");
                SortCategory.ItemsSource = qwe;
            }
            SortBy.ItemsSource = new string[] { "name", "cene", "kol", "opis" };
            SortDir.ItemsSource = new string[] { "SortBy", "DeSort" };
            Elements elements = new Elements();
            itemses = elements.vivod_kor();
            if (itemses != null)
            {
                itemses = itemses.OrderBy(b => b.name2).ToList();
                for (int i = 0; i < itemses.Count; i++)
                {
                    Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                    listTovar.Items.Add(Tovar);
                }
                SortBy.SelectionChanged += SelectionChanged;
                SortDir.SelectionChanged += SelectionChanged;
                SortCategory.SelectionChanged += SelectionChanged;
            }
        }

        private void buy_Click(object sender, RoutedEventArgs e)
        {
            int items1 = listTovar.SelectedIndex;
            var result = MessageBox.Show($"хотите купить {items1} товар?", "Покупка", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Elements elements = new Elements();
                elements.delete_korzina(items1, itemses);
                listTovar.Items.Clear();
                using (StreamReader sr = new StreamReader("korzina.json"))
                {
                    string text1 = sr.ReadToEnd();
                    string text2 = JsonSerializer.Deserialize<string>(text1);
                    if (!string.IsNullOrEmpty(text1))
                    {
                        try
                        {
                            string[] arr = text2.Split('?');
                            string[] arr2 = arr[1].Split(",");
                            for (int i = 0; i < arr2.Length; i += 5)
                                {
                                    Tovar Tovar = new Tovar(arr2[i], arr2[i + 1], arr2[i + 2], arr2[i + 3], arr2[i + 4]);
                                listTovar.Items.Add(Tovar);
                                }
                            listTovar.Items.Clear();
                            itemses = itemses.OrderBy(b => b.name2).ToList();
                            for (int i = 0; i < itemses.Count; i++)
                            {
                                Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                                listTovar.Items.Add(Tovar);
                            }
                            SortBy.SelectionChanged += SelectionChanged;
                            SortDir.SelectionChanged += SelectionChanged;
                            SortCategory.SelectionChanged += SelectionChanged;
                        }
                        catch { }
                    }
                }
            }
        }
        public void SortList()
        {
            var sort = SortCategory.SelectedItem.ToString();
            var SortProperty = SortBy.SelectedItem.ToString();
            var SortDirection = SortDir.SelectedItem.ToString();
            if (SortProperty == "name")
            {
                if (SortDirection == "SortBy")
                {
                    listTovar.Items.Clear();
                    itemses = itemses.OrderBy(b => b.name2).ToList();
                    for (int i = 0; i < itemses.Count; i++)
                    {
                        Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                        listTovar.Items.Add(Tovar);
                    }
                }
                else
                {
                    listTovar.Items.Clear();
                    itemses = itemses.OrderByDescending(b => b.name2).ToList();
                    for (int i = 0; i < itemses.Count; i++)
                    {
                        Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                        listTovar.Items.Add(Tovar);
                    }
                }
            }
            if (SortProperty == "cene")
            {
                if (SortDirection == "SortBy")
                {
                    listTovar.Items.Clear();
                    itemses = itemses.OrderBy(b => b.cena2).ToList();
                    for (int i = 0; i < itemses.Count; i++)
                    {
                        Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                        listTovar.Items.Add(Tovar);
                    }
                }
                else
                {
                    listTovar.Items.Clear();
                    itemses = itemses.OrderByDescending(b => b.cena2).ToList();
                    for (int i = 0; i < itemses.Count; i++)
                    {
                        Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                        listTovar.Items.Add(Tovar);
                    }
                }
            }
            if (SortProperty == "kol")
            {
                if (SortDirection == "SortBy")
                {
                    listTovar.Items.Clear();
                    itemses = itemses.OrderBy(b => b.kol2).ToList();
                    for (int i = 0; i < itemses.Count; i++)
                    {
                        Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                        listTovar.Items.Add(Tovar);
                    }
                }
                else
                {
                    listTovar.Items.Clear();
                    itemses = itemses.OrderByDescending(b => b.kol2).ToList();
                    for (int i = 0; i < itemses.Count; i++)
                    {
                        Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                        listTovar.Items.Add(Tovar);
                    }
                }
            }
            if (SortProperty == "opis")
            {
                if (SortDirection == "SortBy")
                {
                    listTovar.Items.Clear();
                    itemses = itemses.OrderBy(b => b.opis2).ToList();
                    for (int i = 0; i < itemses.Count; i++)
                    {
                        Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                        listTovar.Items.Add(Tovar);
                    }
                }
                else
                {
                    listTovar.Items.Clear();
                    itemses = itemses.OrderByDescending(b => b.opis2).ToList();
                    for (int i = 0; i < itemses.Count; i++)
                    {
                        Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                        listTovar.Items.Add(Tovar);
                    }
                }
            }
            string[] qwe = JsonSerializer.Deserialize<string>(File.ReadAllText("kategory.json")).Split(";");
            for (int l = 0; l < qwe.Length; l++)
            {
                if (sort == "all")
                {
                    listTovar.Items.Clear();
                    for (int i = 0; i < itemses.Count; i++)
                    {
                        Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                        listTovar.Items.Add(Tovar);
                    }
                }
                else if (qwe[l] == sort)
                {
                    listTovar.Items.Clear();
                    for (int i = 0; i < itemses.Count; i++)
                    {
                        if (itemses[i].cat == sort)
                        {
                            Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                            listTovar.Items.Add(Tovar);
                        }
                    }
                }
            }
        }
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortList();
        }

        private void poisk_Click(object sender, RoutedEventArgs e)
        {
            int items1 = listTovar.SelectedIndex;
            var result = MessageBox.Show($"хотите отправить {items1} ?", "да?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Elements elements = new Elements();
                elements.delete_korzina(items1, itemses);
                listTovar.Items.Clear();
                using (StreamReader sr = new StreamReader("korzina.json"))
                {
                    try
                    {
                        string text2 = JsonSerializer.Deserialize<string>(sr.ReadToEnd());
                        if (!string.IsNullOrEmpty(text2))
                        {
                            string[] arr = text2.Split('?');
                            string[] arr2 = arr[1].Split(",");
                            for (int i = 0; i < arr2.Length; i += 5)
                            {
                                Tovar Tovar = new Tovar(arr2[i], arr2[i + 1], arr2[i + 2], arr2[i + 3], arr2[i + 4]);
                                listTovar.Items.Add(Tovar);
                            }
                            listTovar.Items.Clear();
                            itemses = itemses.OrderBy(b => b.name2).ToList();
                            for (int i = 0; i < itemses.Count; i++)
                            {
                                Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                                listTovar.Items.Add(Tovar);
                            }
                            SortBy.SelectionChanged += SelectionChanged;
                            SortDir.SelectionChanged += SelectionChanged;
                            SortCategory.SelectionChanged += SelectionChanged;
                        }


                    }
                    catch { }
                }

            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("Malik.json"))
            {
                string text;
                string text1 = sr.ReadToEnd();
                text = JsonSerializer.Deserialize<string>(text1);
                string[] arr = text.Split(";");
                for (int i = 0; i < arr.Length; i += 2)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.but3.Content = arr[0];
                    MessageBox.Show("Ds");
                    mainWindow.Show();
                    this.Close();
                    break;
                }

            }

        }

        private void SortDir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void text1_TextChanged(object sender, TextChangedEventArgs e)
        {
            listTovar.Items.Clear();
            for (int i = 0; i < itemses.Count; i++)
            {
                char[] chars = text1.Text.ToCharArray();
                if (chars.Length == 0)
                {
                    for (int k = 0; k < itemses.Count; k++)
                    {
                        Tovar Tovar = new Tovar(itemses[k].name2, itemses[k].cena2, itemses[k].kol2, itemses[k].opis2, itemses[k].img2);
                        listTovar.Items.Add(Tovar);
                    }
                    break;
                }
                for (int l = 0; l < chars.Length; l++)
                {
                    if (itemses[i].name2.Contains(text1.Text))
                    {
                        Tovar Tovar = new Tovar(itemses[i].name2, itemses[i].cena2, itemses[i].kol2, itemses[i].opis2, itemses[i].img2);
                        listTovar.Items.Add(Tovar);
                        break;
                    }
                }
            }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secret secret = new Secret();
            secret.Show();
            
        }
    }
}
