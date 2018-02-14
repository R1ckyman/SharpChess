using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Menu : Form
    {
        String nickname;
        String password;

        public Menu()
        {
            InitializeComponent();

            this.FormClosing += Menu_FormClosing;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        
        //Al darle al 'X' de la ventana o alt + f4
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {

                DialogResult eleccion = MessageBox.Show("¿Quiere cerrar la aplicación?", "Saliendo..", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (eleccion == DialogResult.Yes)
                {
                Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            nickname = nickBox.Text;
            password = passwordBox.Text;
            if (nickname == "test" && password == "test")
            {
                switch (appBox.Text)
                {
                    case "Ajedrez":
                        MessageBox.Show("Sesión iniciada --- Ajedrez","Inicio de sesión completado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.Hide();

                        Ajedrez ajedrez = new Ajedrez();

                        ajedrez.Show();
                        break;
                    case "Adivina un número":
                        MessageBox.Show("Sesión iniciada --- Adivina un número", "Inicio de sesión completado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.Hide();

                        Adivinar adivinar = new Adivinar();

                        adivinar.Show();
                        break;
                    default:
                        MessageBox.Show("Selecciona un aplicación", "Inicio de sesión completado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Error, login incorrecto", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}