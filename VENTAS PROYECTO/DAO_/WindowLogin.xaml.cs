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
using MySql.Data.MySqlClient;
using DAO.IMPLEMENTACION;
using DAO.MODELADO;
using DAO.INTERFAZ;
using MySqlX.XDevAPI;
using System.Data;

namespace DAO_
{
    /// <summary>
    /// Lógica de interacción para WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        byte cont = 0;
        UsuarioImpl implUsuario;

        public WindowLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = txtNombre.Text.Trim();
            if (txtNombre.Text != "" && txtPassword.Password != "")
            {
                //Verificar en la BDD
                try
                {
                    implUsuario = new UsuarioImpl();
                    DataTable dt = implUsuario.Login(txtNombre.Text, txtPassword.Password);

                    if (dt.Rows.Count > 0)
                    {
                        
                        //Existe Ingresamos
                        //Iniciar las variables de sesion

                        Sesion.IdSesion = int.Parse(dt.Rows[0][0].ToString());
                        Sesion.UsuarioSesion = dt.Rows[0][2].ToString();
                        Sesion.RolSesion = dt.Rows[0][1].ToString();

                        //Mostramos el menu segun el rol

                        if (Sesion.RolSesion == "Administrador")
                        {
                            MainWindow adminWindow = new MainWindow();
                            adminWindow.Show();
                        }
                        else if (Sesion.RolSesion == "Cajero")
                        {
                            WindowCajero cajeroWindow = new WindowCajero();
                            cajeroWindow.Show();
                        }
                        else
                        {
                            MessageBox.Show("Rol no reconocido.");
                        }

                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Nombre de Usuario y/o Contraseña incorrectos");
                        txtNombre.Text = "";
                        txtPassword.Password = "";
                        cont++;

                        if (cont > 3)
                        {
                            MessageBox.Show("Demasiados intentos fallidos. Cerrando aplicación.");
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
                }
            }

        }
    }
}
