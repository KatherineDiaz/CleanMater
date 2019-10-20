using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using CapaComun.Cache;

namespace CleanMaster
{
    public partial class Perfil : Form
    {
        CN_Usuario objUsuario = new CN_Usuario();
        public Perfil()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MostarPerfil();
            MostrarPregunta();
        }

        private void MostrarPregunta()
        {
            cmbIdPreg.DataSource = objUsuario.MostrarPreguntas();
            cmbIdPreg.ValueMember = "Id_Pregunta";
            cmbIdPreg.DisplayMember = "Pregunta";
        }
        private void MostarPerfil()
        {
            txtUser.Text = CC_SesionUsuarioCache.Usuario;
            txtNya.Text = CC_SesionUsuarioCache.Apellido + ", " + CC_SesionUsuarioCache.Nombre;
            txtTelefono.Text = CC_SesionUsuarioCache.Telefono.ToString();
            txtCelular.Text = CC_SesionUsuarioCache.Celular.ToString();
            txtDni.Text = CC_SesionUsuarioCache.NumIdentificacion.ToString();
            txtDireccion.Text = CC_SesionUsuarioCache.Direccion;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            
            //if (CC_SesionUsuarioCache.Clave != txtClaveActual.Text)
            //{
            //    MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (txtContraseña.Text != txtVerificarContraseña.Text)
            //{
            //    MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //string claveMD5 = GenerarMD5.crearMD5(txtVerificarContraseña.Text);
            //objUsuario.ModificarClave(claveMD5, txtUser.Text);
            //MessageBox.Show("Contraseña cambiada con exito.", "Exito", MessageBoxButtons.OK);
        }

        private void TxtRespuesta_Leave(object sender, EventArgs e)
        {
            txtRespuesta.UseSystemPasswordChar = true;
        }
    }
}
