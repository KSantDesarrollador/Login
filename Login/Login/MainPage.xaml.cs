using Login.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Login
{
    public partial class MainPage : ContentPage
    {
        public MainPage(string filename)
        {
            InitializeComponent();
            RepositorioUsuario.Inicializar(filename);
        }

        private void btnCancelar(object sender, EventArgs e)
        {
            txtUsuario.Text = null;
            txtContrasenia.Text = null;
            StatusMessage.Text = null;
            ErrorMessage.Text = null;
        }

        private void btnIngresar(object sender, EventArgs e)
        {
            int Encontrado = 0;
            
            List<Usuario> user = new List<Usuario>();
            user = Modelo.RepositorioUsuario.Instancia.GetAllUsers().ToList();
            foreach (var item in user)
            {
                if (item.NomUsuario == txtUsuario.Text && item.Password == txtContrasenia.Text)
                {
                    Encontrado = 1;
                }
            }
            if (Encontrado == 1)
            {
                StatusMessage.Text = "Bienvenido al Sistema";
                ((NavigationPage)this.Parent).PushAsync(new Principal());
                txtUsuario.Text = null;
                txtContrasenia.Text = null;
                StatusMessage.Text = null;
                ErrorMessage.Text = null;
            }
            else
            {
                ErrorMessage.Text = "Error de Usuario o Contrasenia";
                txtUsuario.Text = null;
                txtContrasenia.Text = null;
                StatusMessage.Text = null;
            }
        }

    }
}
