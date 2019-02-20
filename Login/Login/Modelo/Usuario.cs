using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Login.Modelo
{
    [Table("usuario")]
   public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100), Unique]
        public string NomUsuario { get; set; }

        [MaxLength(70)]
        public string Password { get; set; }

        [MaxLength(100), Unique]
        public string Email { get; set; }
    }
}
