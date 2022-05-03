using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace VeterinarioBasico
{
    public partial class Registro : Form
    {

        Conexion conexion = new Conexion();
        public Registro()
        {
            InitializeComponent();
        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBoxDNI.Text.Equals("") || textBoxNombre.Text.Equals("") || textBoxEmail.Text.Equals("") || textBoxPass.Text.Equals(""))
            {
                String textoPass = textBoxPass.Text;
                string myHash = BCrypt.Net.BCrypt.HashPassword(textoPass, BCrypt.Net.BCrypt.GenerateSalt());
                if (textBoxTlf.Text.Equals(""))
                {
                    MessageBox.Show(conexion.insertaUsuario(textBoxDNI.Text, textBoxNombre.Text, textBoxEmail.Text, 0, myHash));
                }
                else
                {
                    MessageBox.Show(conexion.insertaUsuario(textBoxDNI.Text, textBoxNombre.Text, textBoxEmail.Text, Int32.Parse(textBoxTlf.Text), myHash));
                }
            }
            else
            {
                MessageBox.Show("Faltan datos");
            }
            
        }
    }
}
