using Conecta4.BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conecta4.Utils
{
    public class Herramientas
    {
        private Tablero tablero = new Tablero();
        /// <summary>
        /// Variable para contar las coincidencias de ficha
        /// </summary>
        public char[,] CrearTablero()
        {
            char[,] tablerotemp = new char[7, 7];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                {
                    tablerotemp[i, j] = '0';
                }
            tablero.Celdas = tablerotemp;
            return tablerotemp;
        }
      
        public DataTable CrearTablero(int filasdt,int columnasdt)
        {
            DataTable dt = new DataTable("Tablero");
            for (int i = 1; i <= columnasdt; i++)
            {
                dt.Columns.Add("Columna" + i, typeof(Int32));
            }
            for (int i = 1; i <= filasdt; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 1; j <= columnasdt; j++)
                {
                    row[j - 1] = "0";
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        /// <summary>
        /// Se tiran los dados para ver que jugador es el primero 
        /// </summary>
        /// <returns>Regresa el jugador que iniciara</returns>
        public int TirarDados()
        {
            Console.WriteLine("Jugador 1 presione una tecla para tirar dados:");
            Console.ReadKey();
            Console.WriteLine();
            Random rnd1 = new Random();
            var jugador1 = rnd1.Next(0, 10);
            Console.WriteLine("Jugador 1 obtuvo:" + jugador1);
            Console.WriteLine("Jugador 2 presione una tecla para tirar dados:");
            Console.ReadKey();
            Console.WriteLine();
            Random rnd2 = new Random();
            var jugador2 = rnd1.Next(0, 10);
            Console.WriteLine("Jugador 2 obtuvo:" + jugador2);
            if (jugador1 > jugador2)
            {
                Console.WriteLine("El Jugador 1 inicia");
                return 1;
            }
            else if (jugador2 > jugador1)
            {
                Console.WriteLine("El Jugador 2 inicia");
                return 2;
            }
            else
            {
                Console.WriteLine("Empate se requiere tirar dados nuevamente");
                return -1;
            }
        }

        public int Jugar(int jugador)
        {
            Validar validarCtrl = new Validar();
            validarCtrl.tablero = tablero;
            int ganador;
            int hayGanador = 0; //aun no hay ganador
            char ficha = 'R';
            int columna;
            int fila = 0;
            do
            {
                ImprimirTablero();
                ganador = jugador;
                if (jugador == 1)
                {
                    jugador = 2;
                    ficha = 'R';
                }
                else
                {
                    jugador = 1;
                    ficha = 'A';
                }
                Console.WriteLine("Jugador " + ganador + " elija la fila en la cual se insertara la ficha (" + ficha + "): ");
                var columnaTemp = Console.ReadKey().KeyChar.ToString();
                if (int.TryParse(columnaTemp, out columna))
                {
                    if (columna <= 7)
                    {
                        for (int i = 6; i >= 0; i--)
                        {
                            if (tablero.Celdas[i, columna - 1].ToString() == "0")
                            {
                                tablero.Celdas[i, columna - 1] = ficha;
                                fila = i;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Columna Invalida");
                                continue; //volvemos la principio
                            }

                        }
                        ImprimirTablero();

                        if (validarCtrl.Vertical(ficha, fila, columna - 1))
                        {
                            hayGanador = 1;
                            break;
                        }
                        if (validarCtrl.Horizontal(ficha, fila, columna - 1))
                        {
                            hayGanador = 1;
                            break;
                        }
                        if (validarCtrl.DiagonalIzquierda(ficha, fila, columna - 1))
                        {
                            hayGanador = 1;
                            break;
                        }
                        if (validarCtrl.DiagonalDerecha(ficha, fila, columna - 1))
                        {
                            hayGanador = 1;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Columna Invalida! presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            } while (hayGanador == 0); // mientras no haya ganador
            return ganador;
        }
        
       

        public void ImprimirTablero()
        {
            Console.Clear();
            for (int i = 0; i < 7; i++)
            {
                StringBuilder str = new StringBuilder();
                for (int j = 0; j < 7; j++)
                {
                    str.Append(tablero.Celdas[i, j] + " ");
                }
                Console.WriteLine(str.ToString());
            }
        }
    }
}
