using Conecta4.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conecta4.WinForm
{
    public partial class Inicio : Form
    {
        private Herramientas herramientas = new Herramientas();
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnJugador1_Click(object sender, EventArgs e)
        {
            lblDadosJugador1.Text = "Dados: " + herramientas.TirarDados().ToString();
            btnJugador1.Enabled = false;
        }

        private void btnJugador2_Click(object sender, EventArgs e)
        {
            lblDadosJugador2.Text = "Dados: " + herramientas.TirarDados().ToString();
            btnJugador2.Enabled = false;
        }

        private void VerificarDados_TextChanged(object sender, EventArgs e)
        {
            int jugador1, jugador2;
            if (lblDadosJugador1.Text.Length > 0)
                jugador1 = int.Parse(lblDadosJugador1.Text.Replace("Dados: ", ""));
            else
                jugador1 = -1;
            jugador2 = lblDadosJugador2.Text.Length > 0 ? int.Parse(lblDadosJugador2.Text.Replace("Dados: ", "")) : -1;
            if (jugador1 != -1 && jugador2 != -1)
            {
                if (jugador1 > jugador2)
                {
                    lblResult.Text="El Jugador 1 inicia";
                    lkbContnuar.Text = "Continuar";
                    lkbContnuar.Visible = true;
                }
                else if (jugador2 > jugador1)
                {
                    lblResult.Text = "El Jugador 2 inicia";
                    lkbContnuar.Text = "Continuar";
                    lkbContnuar.Visible = true;
                }
                else
                {
                    lblResult.Text = "Empate se requiere tirar dados nuevamente";
                    lkbContnuar.Text = "Volver a tirar dados";
                    lkbContnuar.Visible = true;
                }
            }
        }

        private void Limpiar()
        {
            btnJugador1.Enabled = true;
            btnJugador2.Enabled = true;
            lblDadosJugador1.Text = "";
            lblDadosJugador2.Text = "";
            lkbContnuar.Visible = false;
        }

        private void lkbContnuar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lkbContnuar.Text == "Volver a tirar dados")
                Limpiar();
            else
            {
                Conecta4 form = new Conecta4();
                form.Show();
                this.Hide();
            }
        }
    }
}
