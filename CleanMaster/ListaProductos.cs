﻿using System;
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
            
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}