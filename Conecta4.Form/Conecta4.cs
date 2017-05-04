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
            //int celdas = n * n - minas;
            //if (a.Tag.ToString().Substring(0, 1).Equals("1"))
            //{
            //    a.Image = Image.FromFile("D:/Final/1.jpg");
            //    // terminaJuego("Usted Pierde!!!");
            //}
            //else
            //{
            //    a.Image = Image.FromFile("D:/Final/2.jpg");
            //    int res = cuenta(int.Parse(a.Tag.ToString().Substring(2, 1)), int.Parse(a.Tag.ToString().Substring(4, 1)));
            //    //TextBox te = new TextBox();
            //    Label te = new Label();
            //    te.Text = res.ToString();
            //    te.Location = new Point(a.Location.X, a.Location.Y);
            //    te.Parent = mat[1, 1];
            //    te.Width = 10;
            //    te.Height = 50;
            //    Controls.Add(te);
            //    a.Visible = false;
            //    cc++;
            //    if (cc == celdas)
            //    {
            //        terminaJuego("Usted Gana!!!");
            //    }
            //}
        }
    }
}
