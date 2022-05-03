using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeterinarioBasico
{
    public partial class VentanaLogin : Form
    {
        Conexion conexion = new Conexion();

        public VentanaLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String resultadoConexion = conexion.loginVeterinario(textBoxDNI.Text, textBoxPass.Text);
            MessageBox.Show(resultadoConexion);
            //VentanaPrincipal v = new VentanaPrincipal();
            //v.Show();
        }
    }
}
