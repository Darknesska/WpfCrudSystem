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
    /// Логика взаимодействия для AdminShop.xaml
    /// </summary>
    public partial class AdminShop : Window
    {
        List<MyItem> items = new List<MyItem>()
        {

        };
        public AdminShop()
        {
            InitializeComponent();
            SortBy.ItemsSource = new string[] { "name", "cene", "kol", "opis" };
            SortDir.ItemsSource = new string[] { "SortBy", "DeSort" };
            if (!string.IsNullOrEmpty(File.ReadAllText("kategory.json")))
            {
                string[] qwe = JsonSerializer.Deserialize<string>(File.ReadAllText("kategory.json")).Split(";");
                SortCategory.ItemsSource = qwe;
            }
            string text2;
            using (StreamReader sr = new StreamReader("tovar.json"))
            {
                string text1 = sr.ReadToEnd();
                if (!string.IsNullOrEmpty(text1))
                {
                    try
                    {
                        text2 = JsonSerializer.Deserialize<string>(text1);
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
                    catch { }
                }
            }
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
            private void SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                Sortirovka();
            }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            string nametovtext1 = nametovtext.Text;
            string nameopistext1 = nameopistext.Text;
            string namekoltext1 = namekoltext.Text;
            string namecwenatext1 = namecwenatext.Text;
            dynamic nameimgtext1 = imgsear.Source;
            string category = namekategtext.Text;
            namekategtext.Text = null;
            Elements elements = new Elements();
            elements.add_admin(nametovtext1, nameopistext1, namekoltext1, namecwenatext1, nameimgtext1, category);
            bool isint = int.TryParse(namekoltext1, out int numericValue);
            bool isint2 = int.TryParse(namecwenatext1, out int numericValue1);
            if (!string.IsNullOrEmpty(nametovtext1) && !string.IsNullOrEmpty(nameopistext1) && !string.IsNullOrEmpty(namekoltext1) && !string.IsNullOrEmpty(namecwenatext1) && isint && isint2 && !string.IsNullOrEmpty(category))
            {
                if (!string.IsNullOrEmpty(File.ReadAllText("kategory.json")))
                {
                    string cat = JsonSerializer.Deserialize<string>(File.ReadAllText("kategory.json"));
                    string[] catty = cat.Split(";");
                    bool vv = false;
                    for (int i = 0; i < catty.Length; i++)
                    {
                        if (catty[i] == category)
                        {
                            vv = true;
                        }
                    }
                    if (!vv)
                    {
                        string qwe = JsonSerializer.Deserialize<string>(File.ReadAllText("kategory.json"));
                        if (qwe != "")
                        {
                            using (StreamWriter r = new StreamWriter("kategory.json"))
                            {
                                r.Write(JsonSerializer.Serialize(qwe + ";" + category));
                            }
                        }
                        else
                        {
                            using (StreamWriter r = new StreamWriter("kategory.json"))
                            {
                                r.Write(JsonSerializer.Serialize("all" + ";" + category));
                            }
                        }
                    }
                    vv = false;

                }
                else
                {
                    File.WriteAllText("kategory.json", JsonSerializer.Serialize("all" + ";" + category));
                }
                string[] asd = JsonSerializer.Deserialize<string>(File.ReadAllText("kategory.json")).Split(";");
                if (!string.IsNullOrEmpty(File.ReadAllText("kategory.json")))
                {
                    string[] qwe = JsonSerializer.Deserialize<string>(File.ReadAllText("kategory.json")).Split(";");
                    SortCategory.ItemsSource = qwe;
                }
            }
            else
            {
                nametovtext.Text = null;
                nameopistext.Text = null;
                namekoltext.Text = null;
                namecwenatext.Text = null;
            }
            items.Clear();
            string text2 = File.ReadAllText("tovar.json");

            string text1 = JsonSerializer.Deserialize<string>(text2);
            if (!string.IsNullOrEmpty(text1))
            {

                listTovarov.Items.Clear();
                string[] arr = text1.Split(';');
                for (int i = 0; i < arr.Length; i += 6)
                {
                    items.Add(new MyItem(arr[i], arr[i + 1], arr[i + 2], arr[i + 3], arr[i + 4], arr[i + 5]));
                    Tovar tovar = new Tovar(arr[i], arr[i + 1], arr[i + 2], arr[i + 3], arr[i + 4]);
                    listTovarov.Items.Add(tovar);
                    }
            }

            nametovtext.Text = null;
            nameopistext.Text = null;
            namekoltext.Text = null;
            namecwenatext.Text = null;
            
        }
    

        private void update_Click(object sender, RoutedEventArgs e)
        {
            string nametovtext1 = nametovtext.Text;
            string nameopistext1 = nameopistext.Text;
            string namekoltext1 = namekoltext.Text;
            string namecwenatext1 = namecwenatext.Text;
            dynamic nameimgtext1 = imgsear.Source;
            string category = namekategtext.Text;
            if (!string.IsNullOrEmpty(nametovtext1) && !string.IsNullOrEmpty(nameopistext1) && !string.IsNullOrEmpty(namekoltext1) && !string.IsNullOrEmpty(namecwenatext1) && !string.IsNullOrEmpty(category))
            {
                Elements elements = new Elements();
                int items1 = listTovarov.SelectedIndex;
                var result = MessageBox.Show($"хотите обновить {items1} айтем?", "да?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    elements.update(nametovtext1, nameopistext1, namekoltext1, namecwenatext1, nameimgtext1, items1, category);
                    listTovarov.Items.Clear();
                    string text3;
                    using (StreamReader sr = new StreamReader("tovar.json"))
                    {
                        string text1 = sr.ReadToEnd();
                        if (!string.IsNullOrEmpty(text1))
                        {
                            try
                            {
                                text3 = JsonSerializer.Deserialize<string>(text1);
                                string[] arr = text3.Split(';');
                                for (int i = 0; i < arr.Length; i += 5)
                                {
                                    Tovar tovar = new Tovar(arr[i], arr[i + 1], arr[i + 2], arr[i + 3], arr[i + 4]);
                                    listTovarov.Items.Add(tovar);
                                    }
                            }
                            catch { }
                        }
                    }
                }
                nametovtext.Text = null;
                nameopistext.Text = null;
                namekoltext.Text = null;
                namecwenatext.Text = null;
                namekategtext.Text = null;

            }
            SortBy.SelectionChanged += SelectionChanged;
        }

    

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            Elements elements = new Elements();
            int items1 = listTovarov.SelectedIndex;
            var result = MessageBox.Show($"удалить {items1} товар?", "Удаление?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes && items1 != -1)
            {
                elements.delete_admin(items1);
                listTovarov.Items.Clear();
                using (StreamReader sr = new StreamReader("tovar.json"))
                {
                    string text1 = sr.ReadToEnd();
                    string text2 = JsonSerializer.Deserialize<string>(text1);
                    if (!string.IsNullOrEmpty(text1))
                    {
                        try
                        {
                            string[] arr = text2.Split(';');
                            for (int i = 0; i < arr.Length; i += 6)
                            {
                                Tovar userTovar = new Tovar(arr[i], arr[i + 1], arr[i + 2], arr[i + 3], arr[i + 4]);
                                listTovarov.Items.Add(userTovar);
                            }
                        }
                        catch { }
                    }
                }

            }
        }

        private void namekategtext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nameopistext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void namekoltext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void nametovtext_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "";
            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
         "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
         "Portable Network Graphic (*.png)|*.png";
            Nullable<bool> result = dlg.ShowDialog();

            
            if (result == true)
            {
               
                imgsear.Source = new BitmapImage(new Uri(dlg.FileName));
            }
        }

        private void text1_TextChanged(object sender, TextChangedEventArgs e)
        {
            listTovarov.Items.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                char[] chars = text1.Text.ToCharArray();
                if (chars.Length == 0)
                {
                    for (int k = 0; k < items.Count; k++)
                    {
                        Tovar Tovar = new Tovar(items[k].name2, items[k].cena2, items[k].kol2, items[k].opis2, items[k].img2);
                        listTovarov.Items.Add(Tovar);
                    }
                    break;
                }
                for (int l = 0; l < chars.Length; l++)
                {
                    if (items[i].name2.Contains(text1.Text))
                    {
                        Tovar Tovar = new Tovar(items[i].name2, items[i].cena2, items[i].kol2, items[i].opis2, items[i].img2);
                        listTovarov.Items.Add(Tovar);
                        break;
                    }
                }
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

        private void listTovarov_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

