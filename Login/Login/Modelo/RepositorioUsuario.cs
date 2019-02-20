using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SQLite;

namespace Login.Modelo
{
    public class RepositorioUsuario
    {
        private SQLiteConnection conx;
        private static RepositorioUsuario instancia;
        public static RepositorioUsuario Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar a Inicializar");
                return instancia;
            }
        }

        public static void Inicializar(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException();

            if (instancia != null)
                instancia.conx.Close();

            instancia = new RepositorioUsuario(filename);
        }

        private RepositorioUsuario(string dbpath)
        {
            conx = new SQLiteConnection(dbpath);
            conx.CreateTable<Usuario>();
        }

        public String estadoMensaje;

        public int AgregarUsuario(string usuario, string password, string email)
        {
            int resultado = 0;
            try
            {
                resultado = conx.Insert(new Usuario()
                {
                    NomUsuario = usuario,
                    Password = password,
                    Email = email
                });
                estadoMensaje = string.Format("Cantidad de filas afectadas: {0}", resultado);
            }
            catch (Exception ex)
            {

                estadoMensaje = ex.Message;
            }
            return resultado;
        }

        public IEnumerable<Usuario> GetAllUsers()
            {
            try
            {
                return conx.Table<Usuario>();
            }
            catch (Exception ex)
            {

                estadoMensaje = ex.Message;
            }
            return Enumerable.Empty<Usuario>();
            }

        public object EliminarUsuario(object codigo)
        {
            int resultado = 0;

            try
            {
                resultado = conx.Delete(codigo);
                estadoMensaje = string.Format("Cantidad de filas afectadas: {0}", resultado);
            }
            catch (Exception ex)
            {

                estadoMensaje = ex.Message;
            }
            return resultado;
        }
    }
}
