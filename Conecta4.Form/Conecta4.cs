using Conecta4.Utils;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Conecta4.WinForm
{
    public partial class Conecta4 : Form
    {
        private int filasdt = int.Parse(ConfigurationManager.AppSettings["NoFilas"]);
        private int columnasdt = int.Parse(ConfigurationManager.AppSettings["NoColumnas"]);
        private Herramientas herramientas = new Herramientas();
        private PictureBox[,] tablero;
        public Conecta4()
        {
            InitializeComponent();
        }

        private void Conecta4_Load(object sender, EventArgs e)
        {
            pbFicha.Image = Properties.Resources.rojo;
            pbFicha.Tag = "R";
            ImprimirTablero(filasdt+1);
        }

        private void ImprimirTablero(int filas)
        {
            tablero = new PictureBox[columnasdt, filas];
            for (int i = 0; i < filas; i++)
            {
                tablero[i, 0] = new PictureBox();
                tablero[i, 0].BackColor = Color.Red;
                tablero[i, 0].Width = 50;
                tablero[i, 0].Height = 50;
                tablero[i, 0].Location = new Point(55 * i, 55 * 0);
                tablero[i, 0].Tag = "0," + i + "," + 0;
                tablero[i, 0].SizeMode = PictureBoxSizeMode.StretchImage;
                tablero[i, 0].MouseClick += new MouseEventHandler(Columna_Click);
                Controls.Add(tablero[i, 0]);
                continue;
            }
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnasdt; j++)
                {

                    tablero[i, j] = new PictureBox();
                    tablero[i, j].BackColor = Color.Gray;
                    tablero[i, j].Width = 50;
                    tablero[i, j].Height = 50;
                    tablero[i, j].Location = new Point(55 * i, 55 * j);
                    tablero[i, j].Tag = "0," + i + "," + j;
                    tablero[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    Controls.Add(tablero[i, j]);
                }
            }
        }

        private void Columna_Click(object sender, EventArgs e)
        {
            PictureBox a = (PictureBox)sender;
            int columna = int.Parse(a.Tag.ToString().Substring(2, 1));
            char ficha = ' ';
            for (int i = filasdt; i >= 0; i--)
            {
                var datos = tablero[columna, i].Tag.ToString().Split(',');
                if (datos[0] == "0" && datos[2]!="0")
                {
                    tablero[columna, i].Tag = pbFicha.Tag.ToString() + "," + columna + "," + i;
                    tablero[columna, i].Image = pbFicha.Image;
                    if (pbFicha.Tag.ToString() == "R")
                    {
                        ficha = 'R';
                        pbFicha.Tag = "A";
                        pbFicha.Image = Properties.Resources.amarillo;
                    }
                    else
                    {
                        ficha = 'A';
                        pbFicha.Tag = "R";
                        pbFicha.Image = Properties.Resources.rojo;
                    }
                    if (herramientas.Jugar(tablero, filasdt, columnasdt, columna, i, ficha))
                        lblGanador.Text = "Gana el jugador con la ficha " + ficha;
                    break;
                }
            }
        }
    }
}
