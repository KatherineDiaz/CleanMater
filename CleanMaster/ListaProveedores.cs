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
    public partial class ListaProveedores : Form
    {
        CN_Proveedor objProveedores = new CN_Proveedor();
        CN_Proveedor objetoCN = new CN_Proveedor();
        CN_Documento objetoDoc = new CN_Documento();
        public ListaProveedores()
        {
            InitializeComponent();
        }
        private void MostrarProveedores()
        {
            dgvProveedores.DataSource = objProveedores.MostrarProveedores();
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.ABM_PROVEEDORES(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, cmbIdti.SelectedValue.ToString(), txtNidentificacion.Text, txtCorreo.Text, CC_SesionUsuarioCache.Id_Usuario,4);
                MessageBox.Show("El proveedor se cargó correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvProveedores.DataSource = objProveedores.MostrarProveedores();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void MostrarTipoDocumento()
        {
            cmbIdti.DataSource = objetoDoc.MostrarDocumentos();
            cmbIdti.ValueMember = "Id_Tipo_Iden";
            cmbIdti.DisplayMember = "Tipo";
        }

        private void DgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text = dgvProveedores.CurrentRow.Cells["Nombre"].Value.ToString();
            txtDireccion.Text = dgvProveedores.CurrentRow.Cells["Domicilio"].Value.ToString();
            txtTelefono.Text = dgvProveedores.CurrentRow.Cells["Telefono"].Value.ToString();
            txtCelular.Text = dgvProveedores.CurrentRow.Cells["Celular"].Value.ToString();
            cmbIdti.Text = dgvProveedores.CurrentRow.Cells["Tipo"].Value.ToString();
            txtNidentificacion.Text = dgvProveedores.CurrentRow.Cells["Identificacion"].Value.ToString();
            txtCorreo.Text = dgvProveedores.CurrentRow.Cells["Correo_Electronico"].Value.ToString();
        }
        private void ListaProveedores_Load(object sender, EventArgs e)
        {
            MostrarProveedores();
            MostrarTipoDocumento();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea editar este proveedor?", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                objetoCN.ABM_PROVEEDORES(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, cmbIdti.SelectedValue.ToString(), txtNidentificacion.Text, txtCorreo.Text, CC_SesionUsuarioCache.Id_Usuario,6);
                MessageBox.Show("El Proveedor se editó correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvProveedores.DataSource = objProveedores.MostrarProveedores();           
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea dar de baja a este proveedor?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                objetoCN.ABM_PROVEEDORES(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, cmbIdti.SelectedValue.ToString(), txtNidentificacion.Text, txtCorreo.Text, CC_SesionUsuarioCache.Id_Usuario, 5);
                MessageBox.Show("El Proveedor se dió de baja correctamente");
                dgvProveedores.DataSource = objProveedores.MostrarProveedores();
            }
            else
            {
                MessageBox.Show("Seleccione un registro para poder borrarlo");
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void PnlAbmProveedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ListaProveedores_Activated(object sender, EventArgs e)
        {
            MostrarProveedores();
        }
    }
}
