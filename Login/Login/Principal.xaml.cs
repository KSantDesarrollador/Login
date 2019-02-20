using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Login.Modelo;

namespace Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Principal : ContentPage
	{
		public Principal ()
		{
			InitializeComponent ();
		}

        private void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            if (txtUsuario.Text != null || txtContrasenia.Text != null)
            {
                StatusMessage.Text = string.Empty;
                ErrorMessage.Text = string.Empty;
                RepositorioUsuario.Instancia.AgregarUsuario(txtUsuario.Text, txtContrasenia.Text, txtEmail.Text);
                StatusMessage.Text = RepositorioUsuario.Instancia.estadoMensaje;
                txtUsuario.Text = null;
                txtContrasenia.Text = null;
                txtEmail.Text = null;
            }
            else
            {
                ErrorMessage.Text = "Los campos no pueden estar vacios";
            }
            
        }

        private void btnTodoUsuarios_Clicked(object sender, EventArgs e)
        {
            StatusMessage.Text = string.Empty;
            ErrorMessage.Text = string.Empty;
            var TodoUsuarios = RepositorioUsuario.Instancia.GetAllUsers();
            ListaUsuarios.ItemsSource = TodoUsuarios;
            StatusMessage.Text = RepositorioUsuario.Instancia.estadoMensaje;
        }

        private void btnEliminaUsuario_Clicked(object sender, EventArgs e)
        {
            ErrorMessage.Text = string.Empty;
            var UsuarioEscogido = ListaUsuarios.SelectedItem;

            if (UsuarioEscogido != null)
            {              
                RepositorioUsuario.Instancia.EliminarUsuario(UsuarioEscogido);
                var TodoUsuarios = RepositorioUsuario.Instancia.GetAllUsers();
                ListaUsuarios.ItemsSource = TodoUsuarios;
                StatusMessage.Text = RepositorioUsuario.Instancia.estadoMensaje;

            }
        }
    }
}