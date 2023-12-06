using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace WpfCrudSystem
{
    /// <summary>
    /// Логика взаимодействия для Tovar.xaml
    /// </summary>
    public partial class Tovar : UserControl
    {
        public Tovar(string name, string cena, string kol, string opis, dynamic imge)
        {
            InitializeComponent();
            
            nazvl.Content = name;
            cenal.Content = cena;
            koll.Content = kol;
            opisl.Content = opis;
            try
            {
                Uri uri = new Uri(imge, UriKind.Absolute);
                ImageSource imgSource = new BitmapImage(uri);
                img.Source = imgSource;
            }
            catch { }
            Width = 800;
            Height = 250;
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            AdminShop admin = new AdminShop();
            admin.nametovtext.Text = nazvl.Content.ToString();
            admin.namekoltext.Text = koll.Content.ToString();
            admin.namecwenatext.Text = cenal.Content.ToString();
            admin.nameopistext.Text = opisl.Content.ToString();
            MessageBox.Show(admin.nametovtext.Text);

        }
    }
}

