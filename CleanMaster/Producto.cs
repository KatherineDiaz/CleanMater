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
    public partial class Producto : Form
    {
        CN_Producto objetoCN = new CN_Producto();
        CN_Categoria objCategoria = new CN_Categoria();
        CN_Proveedor objProveedor = new CN_Proveedor();
        public Producto()
        {
            InitializeComponent();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                objetoCN.ABM_PRODUCTOS(txtNombre.Text, txtDescripcion.Text, txtPrecioCompra.Text, txtPrecioVenta.Text,
                txtCantidad.Text,txtStMin.Text,txtStMax.Text,cmbCategoria.SelectedValue.ToString(),cmbProveedor.SelectedValue.ToString(),
                CC_SesionUsuarioCache.Id_Usuario,4);
                MessageBox.Show("El producto se cargó correctamente");
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
        private void MostrarCategorias()
        {
            cmbCategoria.DataSource = objCategoria.MostrarCategorias();
            cmbCategoria.ValueMember = "Id_Categoria";
            cmbCategoria.DisplayMember = "Categoria";
        }
        private void MostrarProveedores()
        {
            cmbProveedor.DataSource = objProveedor.MostrarProveedores();
            cmbProveedor.ValueMember = "Id_Proveedor";
            cmbProveedor.DisplayMember = "Nombre";
        }
        private void Producto_Load(object sender, EventArgs e)
        {
            MostrarCategorias();
            MostrarProveedores();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
