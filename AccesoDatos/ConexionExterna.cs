using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AccesoDatos
{
    class ConexionExterna
    {
        public class ejemplo
        {
            string sLine = ""; // Creamos un string donde se guardaran las lineas del archivo
            int line = 0; // Leemos el numero de linea comenzando por 0
            string valor1 = ""; // Creamos un string
            string valor2 = ""; // Creamos un string
            ArrayList arrText = new ArrayList(); // Creamos una matriz para guardar linea por linea
            StreamReader objLeer = new StreamReader("archivo.txt");  // Creamos el objeto "objLeer" desde una funcion de la libreria IO.
            // La extension del archivo puede ser .txt  o .cfg, .ini, .inc, etc

            /* Creamos while para que lea todas las lineas e agrege un item a la matriz, si sLine no es nulo. Despues lo que realiza es un if, cumpliendo la misma condicion del bucle while*/
         while (sLine != null)
         {
            sLine = objLeer.ReadLine();
            if (sLine != null)
               arrText.Add(sLine);
         }
        //Cerramos el archivo
        objLeer.Close();

                        /*Realizamos un bluce foreach, recojemos datos de la matriz arrText y la volcamos en el string sOutput. foreach se utiliza muchos en casos de matriz lo que hace es tomar una coleccion de datos de la matriz y ir volcandolo. como hariamos con un for
int[] matriz = new int[] { 0, 1, 2, 3 };
int leer = 0;
for(int i = 0; i < 4; i++)
{
   leer = matriz[i];
}
Seguimos con el tema, dentro del foreach hacemos un switch para verificar en que linea nos encontramos, esto lo hacemos para poder identificar cada linea y haci asignarle una variable a la linea.
 */
         foreach (string sOutput in arrText)
         {
            switch(line)
            {
                  case 0: {   valor1 = sOutput;
                  break;}
                  case 1:{   valor2 = sOutput;
                  break;}                  
            }            
            line++;
         }   
/* y en resultado tenemos datos volcados en cada una de las variable.
Hagamos un ejemplo que yo hubiera tenia un txt con 2 lineas adentro:

hola
Como estas

entonces valor1 = hola y valor2 = Como estas
*/
}
    }
}
