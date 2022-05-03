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

        public Boolean loginVeterinario(String DNI, String pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM cliente WHERE dni = @DNI", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    String passwordConHash = resultado.GetString("contrasena");
                    if(BCrypt.Net.BCrypt.Verify(pass, passwordConHash))
                    {
                        return true;
                    }
                    return false;
                }

                conexion.Close();
                return false;
            }
            catch(MySqlException e)
            {
                return false;
                throw e;
            }
        }

        public String insertaUsuario(String DNI, String nombre, String email, int tlf, String pass)
        {
            try
            {
                
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("INSERT INTO cliente(dni, nombre, email, tlf, contrasena) VALUES (@DNI, @nombre, @email, @tlf, @pass)", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@nombre", nombre);
                consulta.Parameters.AddWithValue("@email", email);
                if (tlf == 0)
                {
                    consulta.Parameters.AddWithValue("@tlf", null);
                }
                consulta.Parameters.AddWithValue("@pass", pass);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "OK";

            }
            catch (MySqlException e)
            {
                return "error";
                throw e;
            }
        }

    }
}
