using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VeterinarioBasico
{
    class Conexion
    {
        public MySqlConnection conexion;

        public Conexion()
        {
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = veterinario; Uid = root; Pwd =; Port = 3306");
        }

        public string loginVeterinario(String DNI, String pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM cliente WHERE dni = @DNI AND contrasena = @pass", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@pass", pass);
                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    return resultado.GetString(0);
                }

                conexion.Close();
                return "error de usuario/contraseña";
            }
            catch(MySqlException e)
            {
                return "error";
                throw e;
            }
        }
    }
}
