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
        /// <summary>
        /// Variable para contar las coincidencias de ficha
        /// </summary>
        private int contador = 1;
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

        /// <summary>
        /// Este calculo sirve para verificar los valores que se encuentren en esta posicion |
        /// </summary>
        /// <param name="ficha">Valor de la ficha</param>
        /// <param name="fila">fila en la cual se encuentra la ficha</param>
        /// <param name="columna">columna en la cual se encuentra la ficha </param>
        /// <returns>Verdadero si se encuentran 4 valores consecutivos con el mismo valor de la ficha</returns>
        public bool CalcularVertical(char ficha, int fila, int columna)
        {
            contador = 1;
            //Se asigna la posicion de la ficha y se incrementa en 1 el valor de la fila
            int tempFila = fila + 1;
            while (tempFila < 7)
            {
                //Verifica que el valor de la celda concida con el valor de la ficha
                if (tablero.Celdas[tempFila, columna] == ficha)
                {
                    contador++;
                    //Se incrementa en 1 la fila por cada iteracion es decir, si se encuentra en 3,3
                    //la siguiente vuelta evaluara la celda en la posicion 4,3
                    tempFila++;
                }
                else
                    break;
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
        /// <summary>
        /// Este calculo sirve para verificar los valores que se encuentren en esta posicion ----
        /// </summary>
        /// <param name="ficha">Valor de la ficha</param>
        /// <param name="fila">fila en la cual se encuentra la ficha</param>
        /// <param name="columna">columna en la cual se encuentra la ficha </param>
        /// <returns>Verdadero si se encuentran 4 valores consecutivos con el mismo valor de la ficha</returns>
        public bool CalcularHorizontal(char ficha, int fila, int columna)
        {
            contador = 1;
            //Se recorre la fila en busqueda de coincidencias del centro a la izquierda
            //es decir si la primera celda es 3,3
            //en la siguiente iteracion se evaluara el valor 3,2
            for (int i = columna - 1; i >= 0; i--)
            {
                if (tablero.Celdas[fila, i] != ficha)
                {
                    break;
                }
                contador++;
            }
            //Se recorre la fila en busqueda de coincidencias del centro a la derecha
            //es decir si la primera celda es 3,3
            //en la siguiente iteracion se evaluara el valor 3,4
            for (int j = columna + 1; j <= 6; j++)
            {
                if (tablero.Celdas[fila, j] != ficha)
                {
                    break;
                }
                contador++;
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

        /// <summary>
        /// Este calculo sirve para verificar los valores que se encuentren en esta posicion \
        /// </summary>
        /// <param name="ficha">Valor de la ficha</param>
        /// <param name="fila">fila en la cual se encuentra la ficha</param>
        /// <param name="columna">columna en la cual se encuentra la ficha </param>
        /// <returns>Verdadero si se encuentran 4 valores consecutivos con el mismo valor de la ficha</returns>
        public bool CalcularDiagonalIzquierda(char ficha, int fila, int columna)
        {
            contador = 1;

            //Se asigna la posicion de la ficha menos uno
            // para evaluar la diagonal superior \
            int tempFila = fila - 1;
            int tempColumna = fila - 1;

            while (tempFila >= 0 && tempColumna >= 0)
            {
                //Verifica que el valor de la celda concida con el valor de la ficha
                if (tablero.Celdas[tempFila, tempColumna] == ficha)
                {
                    contador++;
                    //Se resta 1 por cada iteracion es decir, si se encuentra en 3,3
                    //la siguiente vuelta evaluara la celda en la posicion 2,2
                    tempFila--;
                    tempColumna--;
                }
                else
                {
                    break;
                }
            }
            //Se asigna la posicion de la ficha mas uno
            // para evaluar la diagonal inferior \
            tempFila = fila + 1;
            tempColumna = fila + 1;

            while (tempFila < 7 && tempColumna < 7)
            {
                //Verifica que el valor de la celda concida con el valor de la ficha
                if (tablero.Celdas[tempFila, tempColumna] == ficha)
                {
                    contador++;
                    //Se resta 1 por cada iteracion es decir, si se encuentra en 3,3
                    //la siguiente vuelta evaluara la celda en la posicion 4,4
                    tempFila++;
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

        /// <summary>
        /// Este calculo sirve para verificar los valores que se encuentren en esta posicion /
        /// </summary>
        /// <param name="ficha">Valor de la ficha</param>
        /// <param name="fila">fila en la cual se encuentra la ficha</param>
        /// <param name="columna">columna en la cual se encuentra la ficha </param>
        /// <returns>Verdadero si se encuentran 4 valores consecutivos con el mismo valor de la ficha</returns>
        public bool CalcularDiagonalDerecha(char ficha, int fila, int columna)
        {
            contador = 1;

            //Se asigna la posicion de la ficha,
            //se suma 1 a la fila y se le resta 1 a la columna
            //por cada iteracion es decir, si se encuentra en 3,3
            //la siguiente vuelta evaluara la celda en la posicion 4,2
            //para evaluar la diagonal inferior /
            int tempFila = fila + 1;
            int tempColumna = columna - 1;

            while (tempFila < 7 && tempColumna >= 0)
            {
                //Verifica que el valor de la celda concida con el valor de la ficha
                if (tablero.Celdas[tempFila, tempColumna] == ficha)
                {
                    contador++;
                    //Se suma 1 a la fila y se le resta 1 a la columna
                    //por cada iteracion es decir, si se encuentra en 4,2
                    //la siguiente vuelta evaluara la celda en la posicion 5,1
                    tempFila++;
                    tempColumna--;
                }
                else
                {
                    break;
                }
            }
            //Se asigna la posicion de la ficha,
            //se resta 1 a la fila y se le suma 1 a la columna
            //por cada iteracion es decir, si se encuentra en 3,3
            //la siguiente vuelta evaluara la celda en la posicion 2,4
            //para evaluar la diagonal superior /
            tempFila = fila - 1;
            tempColumna = columna + 1;

            while (tempFila >= 0 && tempColumna < 7)
            {
                //Verifica que el valor de la celda concida con el valor de la ficha
                if (tablero.Celdas[tempFila, tempColumna] == ficha)
                {
                    contador++;
                    //se resta 1 a la fila y se le suma 1 a la columna
                    //por cada iteracion es decir, si se encuentra en 2,4
                    //la siguiente vuelta evaluara la celda en la posicion 1,5
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
