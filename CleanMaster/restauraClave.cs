using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Dominio;

namespace CleanMaster
{
    public partial class restauraClave : Form
    {
        CN_Usuario objUsuario = new CN_Usuario();
        public restauraClave()
        {
            InitializeComponent();
        }
        //habilita el movimiento del sistema.
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessaage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //habilita el movimiento del sistema.

        private void restauraClave_Load(object sender, EventArgs e)
        {

        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //permite el movimiento del formulario por toda la pantalla
            ReleaseCapture();
            SendMessaage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (txtRespuesta.Text != objUsuario.BuscarRespuesta(txtUsuario.Text))
            {
                MessageBox.Show("Respuesta incorrecta.", "Error", MessageBoxButtons.OK);
                return;
            }
            else if (txtContraseña.Text != txtConfirmarContraseña.Text)
            {
                MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK);
                return;
            }
            string claveMD5 = GenerarMD5.crearMD5(txtConfirmarContraseña.Text);
            objUsuario.ModificarClave(claveMD5, txtUsuario.Text);
            MessageBox.Show("Contraseña cambiada con éxito.", "Éxito", MessageBoxButtons.OK);
            Close();
        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtPregSeg.Text = objUsuario.BuscarPregunta(txtUsuario.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
