using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DAO_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new UserControlHome();
                    break;
                case "ItemUsuario":
                    usc = new UserControlUsuario();
                    break;
            }
            if (usc != null)
            {
                GridMain.Children.Add(usc);
            }
        }
    }
}