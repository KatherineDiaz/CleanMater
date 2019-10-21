using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;

namespace CleanMaster
{
    public partial class ListaProductos : Form
    {
        CN_Producto objProducto = new CN_Producto();
        public ListaProductos()
        {
            InitializeComponent();
            MostrarProductos();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListaProductos_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        private void MostrarProductos()
        {
            dgvProductos.DataSource = objProducto.MostrarProductos();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Producto abmProducto = new Producto();
            abmProducto.Show();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
            //    objProducto.ABM_PRODUCTOS(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text, txtCelular.Text, cmbIdti.SelectedValue.ToString(), txtNidentificacion.Text, txtCorreo.Text, CC_SesionUsuarioCache.Id_Usuario, 5);
            //    MessageBox.Show("El producto se elimino correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    dgvProductos.DataSource = objProducto.MostrarProductos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            dgvProductos.DataSource = objProducto.BusquedaProductos(textBox1.Text);

        }
    }
}
