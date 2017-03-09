using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjProblema02
{
    class CompleteRange
    {
        static void Main(string[] args)
        {
            CompleteRange obj = new CompleteRange();
            Console.WriteLine("PROBLEMA 02");
            string cadena;
            Console.WriteLine("Formato de numeros a ingresar ejemplo 5,6,2,30");
            int icantidadPruebas = 6;
            for (int i = 0; i < icantidadPruebas; i++)
            
{
                cadena = "";
                if (i == icantidadPruebas / 2)
                {
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("PROBLEMA 02");
                    Console.WriteLine("Formato de numeros positivos a ingresar ejemplo 5,6,2,30");
                    Console.WriteLine("Ingrese los números");
                }
                Console.WriteLine("Escriba la cadena");
                cadena = Console.ReadLine();
                while (cadena.Length == 0)
                {
                    Console.WriteLine("Vuelva a ingresar los números");
                    cadena = Console.ReadLine();
                }
                Console.WriteLine("Orden resultante: {0}", obj.build(cadena));
                Console.WriteLine();
            }
            Console.WriteLine("Pruebas terminadas");
            Console.ReadKey();
        }

        private string build(string cadena)
        {
            try
            {
                string[] valores = cadena.Split(',');
                string cadenaResultante = "";
                if (valores.Length > 1)
                {
                    int intMenor =Convert.ToInt32(valores[0]);
                    foreach (var item in valores)
                    {

                        if (intMenor > Convert.ToInt32(item))
                        {
                            intMenor = Convert.ToInt32(item);
                        }
                    }

                    int intMayor = Convert.ToInt32(valores[0]);
                    foreach (var item in valores)
                    {

                        if (intMayor < Convert.ToInt32(item))
                        {
                            intMayor = Convert.ToInt32(item);
                        }
                    }

                    cadenaResultante = intMenor.ToString();
                    for (int i = intMenor +1; i <= intMayor; i++)
                    {
                        cadenaResultante = cadenaResultante + ", " + i.ToString();
                    }

                    return cadenaResultante;

                }

                return cadena;                

            }
            catch (Exception)
            {
                return "Valores ingresados no correctos";
            }
        }
    }
}
