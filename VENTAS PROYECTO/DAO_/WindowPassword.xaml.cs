using DAO.IMPLEMENTACION;
using DAO.MODELADO;
using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Net.Mime.MediaTypeNames;


namespace DAO_
{
    /// <summary>
    /// Lógica de interacción para WindowPassword.xaml
    /// </summary>
    public partial class WindowPassword : Window
    {
        UsuarioImpl usuarioImpl;
        Usuario usuario;

        public WindowPassword()
        {
            InitializeComponent();
        }

        private void btnCambiar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword1.Password) ||
       string.IsNullOrWhiteSpace(txtPassword2.Password) ||
       string.IsNullOrWhiteSpace(txtPassword3.Password))
            {
                MessageBox.Show("Por favor, llenar todos los espacios.");
            }
            else
            {
                usuarioImpl = new UsuarioImpl();
                usuario = new Usuario();

                try
                {
                    DataTable dt = usuarioImpl.Login(Sesion.UsuarioSesion, txtPassword1.Password);
                    if (dt.Rows.Count > 0)
                    {
                        if (usuario.ValidarContraseña(txtPassword2.Password) && txtPassword2.Password == txtPassword3.Password)
                        {
                            usuario.Id = (short)Sesion.IdSesion;
                            usuario.Password = txtPassword2.Password;
                            if (usuarioImpl.CambiarContraseña(usuario) > 0)
                            {
                                MessageBox.Show("Cambio de contraseña exitosa");
                                WindowLogin windowLogin = new WindowLogin();
                                windowLogin.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Cambio de contraseña erronea");
                            }
                        }
                        else
                        {
                            MessageBox.Show("contraseña no validas debe ingresar un caracter mayuscula miniscula y numero");
                        }
                    }
                    else
                    {
                        MessageBox.Show("contraseña incorrecta");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
