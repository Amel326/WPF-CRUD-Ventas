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

namespace DAO_
{
    /// <summary>
    /// Lógica de interacción para WindowAdminUsuario.xaml
    /// </summary>
    public partial class WindowAdminUsuario : Window
    {
        byte op = 0;
        UsuarioImpl usuarioImpl;
        Usuario t;
        public WindowAdminUsuario()
        {
            InitializeComponent();
        }

        void Habilitar()
        {
            btnInsertar.IsEnabled = false;
            btnModificar.IsEnabled = false;
            btnEliminar.IsEnabled = false;

            btnGuardar.IsEnabled = true;
            btnCancelar.IsEnabled = true;
            datePicker.IsEnabled = true;

            txtCi.IsEnabled = true;
            txtNombres.IsEnabled = true;
            txtApellidoPaterno.IsEnabled = true;
            txtApellidoMaterno.IsEnabled = true;
            txtSexo.IsEnabled = true;
            txtRol.IsEnabled = true;
        }
        void Deshabilitar()
        {
            btnInsertar.IsEnabled = true;
            btnModificar.IsEnabled = true;
            btnEliminar.IsEnabled = true;

            btnGuardar.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            datePicker.SelectedDate = null;

            txtCi.Text = "";
            txtNombres.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtSexo.Text = "";
            txtRol.Text = "";
        }

        void Select()
        {
            try
            {
                usuarioImpl = new UsuarioImpl();
                dgvData.ItemsSource = null;
                dgvData.ItemsSource = usuarioImpl.Select().DefaultView;
                dgvData.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Deshabilitar();
        }
        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            this.op = 1;
            Habilitar();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            this.op = 2;
            Habilitar();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Deshabilitar();
            if (t != null)
            {
                if (MessageBox.Show("Estas seguro de eliminar el registro?" +
                                    "del usuario: " + t.Nombres + " " + t.PrimerApellido, "Eliminar",
                                    MessageBoxButton.YesNo, MessageBoxImage.Question)
                                    == MessageBoxResult.Yes)
                {
                    try
                    {
                        usuarioImpl = new UsuarioImpl();
                        if (usuarioImpl.Delete(t) > 0)
                        {
                            MessageBox.Show("Registro Eliminado");
                            Select();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se elimino registro");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro");
            }
        }


        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            switch (this.op)
            {
                case 1:
                    if (string.IsNullOrWhiteSpace(txtCi.Text) ||
                        string.IsNullOrWhiteSpace(txtNombres.Text) ||
                        string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) ||
                        string.IsNullOrWhiteSpace(txtApellidoMaterno.Text) ||
                        string.IsNullOrWhiteSpace(datePicker.Text) ||
                        string.IsNullOrWhiteSpace(txtSexo.Text) ||
                        string.IsNullOrWhiteSpace(txtRol.Text))
                    {
                        MessageBox.Show("Por favor, llenar todos los espacios vacíos.");
                    }
                    else
                    {
                        try
                        {
                            string rol = (txtRol.SelectedItem as ComboBoxItem)?.Content.ToString();
                            string sexo = (txtSexo.SelectedItem as ComboBoxItem)?.Content.ToString();

                            t = new Usuario(txtCi.Text,
                                            txtNombres.Text,
                                            txtApellidoPaterno.Text,
                                            txtApellidoMaterno.Text,
                                            DateTime.Parse(datePicker.Text),
                                            sexo,
                                            rol);

                            t.NombreUsuario = t.GenerarUsuario();
                            t.Password = t.GenerarUsuario();


                            usuarioImpl = new UsuarioImpl();
                            while ((usuarioImpl.ValidarUsuario(t)) > 0)
                            {
                                t.NombreUsuario = t.GenerarUsuario();
                            }

                            if (usuarioImpl.Insert(t) > 0)
                            {
                                MessageBox.Show("Registro Exitoso");
                                Select();
                                Deshabilitar();
                            }
                            else
                            {
                                MessageBox.Show("Registro Erroneo");
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;

                case 2:
                    if (t != null)
                    {
                        DateTime? date = DateTime.Now;
                        t.Ci = txtCi.Text;
                        t.Nombres = txtNombres.Text;
                        t.PrimerApellido = txtApellidoPaterno.Text;
                        t.SegundoApellido = txtApellidoMaterno.Text;
                        if (datePicker.SelectedDate.HasValue)
                        {
                            date = datePicker.SelectedDate.Value;
                            t.FechaNacimiento = date.Value;
                        }
                        else
                        {
                            t.FechaNacimiento = DateTime.MinValue;
                        }
                        string rol = (txtRol.SelectedItem as ComboBoxItem)?.Content.ToString();
                        string sexo = (txtSexo.SelectedItem as ComboBoxItem)?.Content.ToString();
                        t.Sexo = sexo;
                        t.Rol = rol;

                        usuarioImpl = new UsuarioImpl();

                        if (usuarioImpl.Update(t) > 0)
                        {
                            MessageBox.Show("Modificacion Exitosa");
                            Select();
                            Deshabilitar();
                        }
                        else
                        {
                            MessageBox.Show("Modificacion Erronea");
                        }
                    }
                    break;
            }
        }

        private void dgvData_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void dgvData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvData.SelectedItem != null && dgvData.Items.Count > 0)
            {
                DataRowView d = (DataRowView)dgvData.SelectedItem;
                byte id = byte.Parse(d.Row.ItemArray[0].ToString());

                t = null;

                try
                {
                    usuarioImpl = new UsuarioImpl();
                    t = usuarioImpl.Get(id);

                    if (t != null)
                    {
                        txtCi.Text = t.Ci;
                        txtNombres.Text = t.Nombres;
                        txtApellidoPaterno.Text = t.PrimerApellido;
                        txtApellidoMaterno.Text = t.SegundoApellido;
                        datePicker.SelectedDate = t.FechaNacimiento;
                        txtSexo.Text = t.Sexo;
                        txtRol.Text = t.Rol;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
