using Conecta4.BO;

namespace Conecta4.Utils
{
    /// <summary>
    /// Clase para validar si hay ganador
    /// </summary>
    public class Validar
    {
        internal Tablero tablero = new Tablero();
        /// <summary>
        /// Variable para contar las coincidencias de ficha
        /// </summary>
        private int contador = 1;

        /// <summary>
        /// Este calculo sirve para verificar los valores que se encuentren en esta posicion |
        /// </summary>
        /// <param name="ficha">Valor de la ficha</param>
        /// <param name="fila">fila en la cual se encuentra la ficha</param>
        /// <param name="columna">columna en la cual se encuentra la ficha </param>
        /// <returns>Verdadero si se encuentran 4 valores consecutivos con el mismo valor de la ficha</returns>
        internal bool Vertical(char ficha, int fila, int columna)
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
        internal bool Horizontal(char ficha, int fila, int columna)
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
        internal bool DiagonalIzquierda(char ficha, int fila, int columna)
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
        internal bool DiagonalDerecha(char ficha, int fila, int columna)
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
    }
}
