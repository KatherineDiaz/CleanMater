using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaComun.Cache;

namespace CleanMaster
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            lblUsuario.Text = CC_SesionUsuarioCache.Apellido +" "+ CC_SesionUsuarioCache.Nombre;
            lblRol.Text = CC_SesionUsuarioCache.Rol;
            //permisos para los formularios
            if (CC_SesionUsuarioCache.Rol == CC_Roles.Usuario)
            {
                //Deshabilito lo que el usuario no pueda realizar
                //ej.
                btnProveedores.Enabled = false;
                btnProducto.Enabled = false;
                btnUsuario.Enabled = false;
                btnCliente.Enabled = false;
            }
        }
        //habilita el movimiento del sistema.
        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessaage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //habilita el movimiento del sistema.


        private void PictureBox1_Click(object sender, EventArgs e)
        { //Movimiento del menu vertical
            if (MenuVertical.Width == 200)
            {
                MenuVertical.Width = 70;
            }
            else { MenuVertical.Width = 200; }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de querer salir?", "Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               Application.Exit();
            }
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int LX, LY;// Variables que almacenan las posiciones x e y del form
        private void Maximizar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            LX = this.Location.X; //Guarda la posicion x del form
            LY = this.Location.Y; //Guarda la posicion y del form

            this.Size = Screen.PrimaryScreen.WorkingArea.Size; //establece que el tamaño del formulario se = al tamaño de la pantalla principal
            this.Location = Screen.PrimaryScreen.WorkingArea.Location; //establece que la posicion del formulario va a ser = a la posicion de la pantalla principal
            restaurar.Visible = true;
            maximizar.Visible = false;

        }

        private void Restaurar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(920, 600); //Establece el tamaño inicial al from
            this.Location = new Point(LX, LY);//restaura a la posicion donde estaba el form antes de maximizar
            restaurar.Visible = false;
            maximizar.Visible = true;
        }
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            //permite el movimiento del formulario por toda la pantalla
            ReleaseCapture();
            SendMessaage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Avatar2_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new Perfil());
            MenuVertical.Width = 70;
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListaProveedores());
            MenuVertical.Width = 70;
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListaUsuarios());
            MenuVertical.Width = 70;
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListaClientes());
            MenuVertical.Width = 70;
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new ListaProductos());
            MenuVertical.Width = 70;
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //funcion para llamar a cualquier formulario hacia el panel3 0 panel central
        private void AbrirFormInPanel(object formhijo)
        {
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(fh);
            this.panel3.Tag = fh;
            fh.Show();
        }
        //En el evento click de los botones llamar a la funcion AbrirFormInPanel(new Formularioallamar);
    }
}
