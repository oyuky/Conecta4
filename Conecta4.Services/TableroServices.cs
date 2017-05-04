using Conecta4.Services.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4.Services
{
    public class TableroServices
    {
        private Tablero tablero = new Tablero();
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
                    }
                }
                ImprimirTablero();
                if (CalcularVertical(ficha, fila, columna - 1))
                {
                    hayGanador = 1;
                    break;
                }
                if (CalcularHorizontal(ficha, fila, columna - 1))
                {
                    hayGanador = 1;
                    break;
                }
                if (CalcularDiagonalIzquierda(ficha, fila, columna - 1))
                {
                    hayGanador = 1;
                    break;
                }
                if (CalcularDiagonalDerecha(ficha, fila, columna - 1))
                {
                    hayGanador = 1;
                    break;
                }


            } while (hayGanador == 0); // mientras no haya ganador
            return ganador;
        }

        public bool CalcularVertical(char ficha, int fila, int columna)
        {
            int contadorv = 0;
            if (fila <= 3)
            {
                for (int i = fila; i <= 6; i++)
                {
                    var fichaActual = tablero.Celdas[i, columna];
                    if (fichaActual == ficha)
                        contadorv++;
                    else
                        break;
                    if (contadorv >= 4)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool CalcularHorizontal(char ficha, int fila, int columna)
        {
            int counter = 1;

            for (int i = columna - 1; i >= 0; i--)
            {
                if (tablero.Celdas[fila, i] != ficha)
                {
                    break;
                }
                counter++;
            }

            for (int j = columna + 1; j <= 6; j++)
            {
                if (tablero.Celdas[fila, j] != ficha)
                {
                    break;
                }
                counter++;
            }

            if (counter >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CalcularDiagonalIzquierda(char ficha, int fila, int columna)
        {
            var tempFila = fila - 1;
            var tempColumna = fila - 1;

            int counter = 1;

            while (tempFila >= 0 && tempColumna >= 0)
            {
                if (tablero.Celdas[tempFila, tempColumna] == ficha)
                {
                    counter++;
                    tempFila--;
                    tempColumna--;
                }
                else
                {
                    break;
                }
            }

            tempFila = fila + 1;
            tempColumna = fila + 1;

            while (tempFila < 7 && tempColumna < 7)
            {
                if (tablero.Celdas[tempFila, tempColumna] == ficha)
                {
                    counter++;
                    tempFila++;
                    tempColumna++;
                }
                else
                {
                    break;
                }
            }
            if (counter >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CalcularDiagonalDerecha(char ficha, int fila, int columna)
        {
            int tempFila = fila + 1;
            int tempColumna = columna - 1;
            int contador = 1;

            while (tempFila < 7 && tempColumna >= 0)
            {
                if (tablero.Celdas[tempFila, tempColumna] == ficha)
                {
                    contador++;
                    tempFila++;
                    tempColumna--;
                }
                else
                {
                    break;
                }
            }
            tempFila = fila - 1;
            tempColumna = columna + 1;

            while (tempFila >= 0 && tempColumna < 7)
            {
                if (tablero.Celdas[tempFila, tempColumna] == ficha)
                {
                    contador++;
                    tempFila--;
                    tempColumna++;
                }
                else
                {
                    break;
                }
            }
            if (contador >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
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
