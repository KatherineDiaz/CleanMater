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
    public partial class ListaUsuarios : Form
    {
        CN_Usuario objUsuario = new CN_Usuario();
        CN_Documento objetoDoc = new CN_Documento();
        CN_Rol objRol = new CN_Rol();
        public ListaUsuarios()
        {
            InitializeComponent();
        }

        private void ListaUsuarios_Load(object sender, EventArgs e)
        {
            MostrarTipoDocumento();
            MostrarUsuarios();
            MostrarRol();
        }
        private void MostrarUsuarios()
        {
            dgvUsuarios.DataSource = objUsuario.MostrarUsuarios();
        }
        private void MostrarTipoDocumento()
        {
            cmbIdti.DataSource = objetoDoc.MostrarDocumentos();
            cmbIdti.ValueMember = "Id_Tipo_Iden";
            cmbIdti.DisplayMember = "Tipo";
        }

        private void MostrarRol()
        {
            cmbRol.DataSource = objRol.MostrarRol();
            cmbRol.ValueMember = "Id_Rol";
            cmbRol.DisplayMember = "Rol";
        }

        private void LblContrasenia_Click(object sender, EventArgs e)
        {
            GenerarClave clave = new GenerarClave();
            lblContrasenia.Text = GenerarClave.crearClave();
        }

        private void DgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
            txtUsuario.Text = dgvUsuarios.CurrentRow.Cells["Usuario"].Value.ToString();
            txtNombre.Text = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();
            txtApellido.Text = dgvUsuarios.CurrentRow.Cells["Apellido"].Value.ToString();
            txtTelefono.Text = dgvUsuarios.CurrentRow.Cells["Telefono"].Value.ToString();
            txtCelular.Text = dgvUsuarios.CurrentRow.Cells["Celular"].Value.ToString();
            txtNumIdentificacion.Text = dgvUsuarios.CurrentRow.Cells["Identificacion"].Value.ToString();
            txtDireccion.Text = dgvUsuarios.CurrentRow.Cells["Domicilio"].Value.ToString();
            cmbRol.Text = dgvUsuarios.CurrentRow.Cells["Rol"].Value.ToString();
        }
        
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de dar de baja a este usuario?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objUsuario.ABM_USUARIOS(txtUsuario.Text, lblContrasenia.Text, txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtCelular.Text, cmbIdti.SelectedValue.ToString(), txtNumIdentificacion.Text, txtDireccion.Text, cmbRol.SelectedValue.ToString(), CC_SesionUsuarioCache.Id_Usuario, 5);
                MessageBox.Show("Usuario dado de baja con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objUsuario.MostrarUsuarios();
            }
            else
                return;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                objUsuario.ABM_USUARIOS(txtUsuario.Text,GenerarMD5.crearMD5(lblContrasenia.Text), txtNombre.Text, txtApellido.Text, txtTelefono.Text, txtCelular.Text, cmbIdti.SelectedValue.ToString(), txtNumIdentificacion.Text, txtDireccion.Text, cmbRol.SelectedValue.ToString(), CC_SesionUsuarioCache.Id_Usuario, 4);
                MessageBox.Show("El usuario se cargó correctamente");
                dgvUsuarios.DataSource = objUsuario.MostrarUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
