using Conecta4;
using Conecta4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conecta4Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Inicializar();
            Console.ReadKey();
        }

        static void Inicializar()
        {
            Console.WriteLine();
            TableroServices tableroCtrl = new TableroServices();
            var jugadorIni = tableroCtrl.TirarDados();
            while(jugadorIni==-1)
            {
                Console.Clear();
                jugadorIni = tableroCtrl.TirarDados();
            }
            Console.WriteLine("Presione una tecla para iniciar el juego...");
            Console.ReadKey();
            var temp = tableroCtrl.CrearTablero();
            for (int i = 0; i < 7; i++)
            {
                StringBuilder str = new StringBuilder();
                for (int j = 0; j < 7; j++)
                {
                    str.Append(temp[i, j] + " ");
                }
                Console.WriteLine(str.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("El ganador es el jugador no. " + tableroCtrl.Jugar(jugadorIni));
            Console.ReadKey();

        }
    }
}
