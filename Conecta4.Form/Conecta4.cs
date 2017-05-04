using Conecta4.Utils;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace Conecta4.WinForm
{
    public partial class Conecta4 : Form
    {
        private int filasdt = int.Parse(ConfigurationManager.AppSettings["NoFilas"]);
        private int columnasdt = int.Parse(ConfigurationManager.AppSettings["NoColumnas"]);
        PictureBox[,] tablero;
        public Conecta4()
        {
            InitializeComponent();
        }

        private void Conecta4_Load(object sender, EventArgs e)
        {
            Herramientas herramientas = new Herramientas();
            //gvwTablero.DataSource = herramientas.CrearTablero(filasdt, columnasdt);
            ImprimirTablero(filasdt+1, columnasdt);
        }

        private void ImprimirTablero(int filasdt, int columnasdt)
        {
            tablero = new PictureBox[columnasdt, filasdt];
            for (int i = 0; i < filasdt; i++)
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
            for (int i = 0; i < filasdt; i++)
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
                    //tablero[i, j].MouseClick += new MouseEventHandler(Pic_Clic);
                    Controls.Add(tablero[i, j]);
                }
            }
        }

        private void Columna_Click(object sender, EventArgs e)
        {

            PictureBox a = (PictureBox)sender;
            int columna = int.Parse(a.Tag.ToString().Substring(0, 1));
            tablero[columna, 0] = new PictureBox();
            //if (columna <= 7)
            //{
            //    for (int i = columna; i >= 0; i--)
            //    {
            //        if (tablero[i, columna - 1].ToString() == "0")
            //        {
            //            tablero[i, columna - 1].Image = ficha;
            //            fila = i;
            //            break;
            //        }
            //        else
            //        {
            //        }
            //    }
            //}
            //            if (a.Tag.ToString().Substring(0, 1).Equals("1"))
            //{
            //    a.Image = Image.FromFile("D:/Final/1.jpg");
            //}
        }
    }
}
