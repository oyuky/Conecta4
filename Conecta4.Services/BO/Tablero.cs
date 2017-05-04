using System.Collections.Generic;
using System.Data;

namespace Conecta4.BO
{
    public class Tablero
    {
        public char[,] Celdas { get; set; }
        public DataTable Tabla { get; set; }
    }
}
