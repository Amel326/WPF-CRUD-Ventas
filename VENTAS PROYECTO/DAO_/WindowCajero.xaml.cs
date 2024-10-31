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
using System.Windows.Shapes;

namespace DAO_
{
    /// <summary>
    /// Lógica de interacción para WindowCajero.xaml
    /// </summary>
    public partial class WindowCajero : Window
    {
        public WindowCajero()
        {
            InitializeComponent();
        }

        private void btnSalir_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCollapseMenu_click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Visible;
            btnCollapseMenu.Visibility = Visibility.Collapsed;
            imgLogo.Visibility = Visibility.Collapsed;
        }

        private void btnOpenMenu_click(object sender, RoutedEventArgs e)
        {
            btnOpenMenu.Visibility = Visibility.Collapsed;
            btnCollapseMenu.Visibility = Visibility.Visible;
            imgLogo.Visibility = Visibility.Visible;
        }
        private void lvMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridMain.Children.Clear(); 

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    
                    WindowPassword windowPassword = new WindowPassword();
                    windowPassword.ShowDialog();
                    break;

                case "ItemUsuario":                   
                   
                    break;
            }
        }
    }
}
