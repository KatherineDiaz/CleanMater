using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using Dominio;
using CapaComun.Cache;

namespace CleanMaster
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void msgError(string error)
        {
            lblError.Text = error;
            lblError.Visible = true;
        }

        //PLACEHOLDER USUARIO Y CLAVE
        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }
        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }
        //PLACEHOLDER USUARIO Y CLAVE

        private void Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estás seguro de querer salir?", "Salida", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void cerrarSesion(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text = "Usuario";
            txtClave.Text = "Clave";
            txtClave.UseSystemPasswordChar = false;
            lblError.Visible = false;
            this.Show();
            btnAcceder.Focus();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAcceder.PerformClick();
            }
        }

        private void LkLblContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            restauraClave restauraClave = new restauraClave();
            restauraClave.Show();
        }

        private void TxtClave_Enter(object sender, EventArgs e)
        {
            if (txtClave.Text == "Clave")
            {
                txtClave.Text = "";
                txtClave.ForeColor = Color.LightGray;
                txtClave.UseSystemPasswordChar = true;
            }
        }

        private void TxtClave_Leave(object sender, EventArgs e)
        {
            if (txtClave.Text == "")
            {
                txtClave.Text = "Clave";
                txtClave.ForeColor = Color.DimGray;
                txtClave.UseSystemPasswordChar = false;
            }
        }
        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "Usuario")
            {
                if (txtUsuario.Text != "Clave")
                {
                    CN_Usuario usuario = new CN_Usuario();
                    string clave = GenerarMD5.crearMD5(txtClave.Text);
                    var inicioCorrecto = usuario.InicioSesion(txtUsuario.Text, clave);
                    if (inicioCorrecto == true)
                    {
                        Principal principal = new Principal();
                        principal.Show();
                        principal.FormClosed += cerrarSesion;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Los datos ingresados son incorrectos");
                        txtClave.Clear();
                        txtUsuario.Focus();
                    }
                }
                else msgError("Por favor ingrese su clave");
            }
            else msgError("Por favor ingrese su usuario");
        }
    }
}
