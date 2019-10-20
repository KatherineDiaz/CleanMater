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
    public partial class ListaClientes : Form
    {
        CN_Cliente objClientes = new CN_Cliente();
        CN_Cliente objetoCN = new CN_Cliente();
        CN_Documento objetoDoc = new CN_Documento();
        public ListaClientes()
        {
            InitializeComponent();
            MostrarClientes();
            MostrarTipoDocumento();
        }
        private void MostrarClientes()
        {
            dgvClientes.DataSource = objClientes.MostrarClientes();
        }

        private void DgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void MostrarTipoDocumento()
        {
            cmbIdti.DataSource = objetoDoc.MostrarDocumentos();
            cmbIdti.ValueMember = "Id_Tipo_Iden";
            cmbIdti.DisplayMember = "Tipo";
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.ABM_CLIENTE(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, cmbIdti.SelectedValue.ToString(), txtNidentificacion.Text, txtCorreo.Text, CC_SesionUsuarioCache.Id_Usuario, 4);
                MessageBox.Show("El cliente se cargó correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvClientes.DataSource = objClientes.MostrarClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.ABM_CLIENTE(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, cmbIdti.SelectedValue.ToString(), txtNidentificacion.Text, txtCorreo.Text, CC_SesionUsuarioCache.Id_Usuario, 5);
                MessageBox.Show("El cliente se elimino correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvClientes.DataSource = objClientes.MostrarClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
