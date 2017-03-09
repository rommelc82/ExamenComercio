using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjChangeString
{
    class ChangeString
    {
        public string build(string cadena)
        {
            try
            {
                string retornaFinal = "";
                char[] letrasMinusculas = { 'a','b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o',
'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
                char[] letrasMayusculas = { 'A','B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O',
'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
                foreach (var item in cadena)
                {
                    int indiceMin = 0;
                    int indiceMay = 0;
                    bool ingreso = false;
                    foreach (char itemMin in letrasMinusculas)
                    {
                        indiceMin++;
                        if (item == itemMin)
                        {
                            if ('z' == item)
                            {
                                retornaFinal = retornaFinal + "a";
                                ingreso = true;
                                break;
                            }
                            else
                            {
                                retornaFinal = retornaFinal + letrasMinusculas[indiceMin].ToString();
                                ingreso = true;
                                break;
                            }
                        }
                    }

                    foreach (char itemMay in letrasMayusculas)
                    {
                        indiceMay++;
                        if (item == itemMay)
                        {
                            if ('Z' == item)
                            {
                                retornaFinal = retornaFinal + "A";
                                ingreso = true;
                                break;
                            }
                            else
                            {
                                retornaFinal = retornaFinal + letrasMayusculas[indiceMay].ToString();
                                ingreso = true;
                                break;
                            }
                        }
                    }
                    if (!ingreso)
                    {
                        retornaFinal = retornaFinal + item;
                    }
                }
                return retornaFinal;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
