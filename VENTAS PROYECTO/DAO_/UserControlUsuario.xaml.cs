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

namespace DAO_
{
    /// <summary>
    /// Lógica de interacción para UserControlUsuario.xaml
    /// </summary>
    public partial class UserControlUsuario : UserControl
    {
        public UserControlUsuario()
        {
            InitializeComponent();
        }

        private void cardAdmUsuarios_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowAdminUsuario win = new WindowAdminUsuario();
            win.ShowDialog();
        }

        private void cardPassword_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowPassword win = new WindowPassword();
            win.ShowDialog();
        }
    }
}
