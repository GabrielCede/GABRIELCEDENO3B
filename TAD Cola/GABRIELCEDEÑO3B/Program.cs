using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GABRIELCEDEÑO3B
{
    class Cola
    {
        //ATRIBUTOS
        int[] vec;
        int p, u, tam;

        //CONSTRUCTOR
        public Cola(int n)
        {
            p = u = -1;
            tam = n;
            vec = new int[tam];
        }

        public bool esta_llena()
        {
            if (u >= tam - 1)
                return true;
            return false;
        }

        public bool esta_vacia()
        {
            if (p == -1)
                return true;
            return false;
        }

        public bool agregar(int dato)
        {
            if (!esta_llena())
            {
                vec[++u] = dato;
                if (u == 0)
                    p = 0;
                return true;
            }
            return false;
        }

        public bool extraer(ref int dato)
        {
            //ESTA VRIABLE SE USARA PARA MOVER EL DATO 1 al 0, el 2 al 1, el 3 al 2 ...
            int var = 1;

            //SI LA PILA NO ESTA VACIA:
            if (!esta_vacia())
            {
                //ENTONCES SACAMOS EL PRIMER DATO (P[O])
                dato = vec[p];

                for (int i = 0; i < vec.Length; i++)
                {
                    //SE PREGUNTA SI var ES MENOR A LA LONGITUD DEL ARREGLO, ESTO SE HACE DEBIDO A QUE var LLEGA A UN VALOR
                    //SUPERIOR A LA LONGITUD DEL ARREGLO
                    if (var < vec.Length)
                    {
                        //PASAMOS EL DATO DE UNA POSICION A OTRA
                        //EJEMPLO: vec[0]=vec[1] EL DATO EN LA POSICION 1 SE PASA A LA POSICION 0 Y ASI HASTA LA LONGITUD DEL ARREGLO
                        vec[i] = vec[var];
                        var++;
                    }
                }

                //AHORA LA VARIABLE QUE SE IRA MOVIENDO SERA u, YA QUE EL PRIMERO SIEMPRE SERA EL ELEMENTO 0
                if (u == p)
                {
                    p = u = -1;
                }
                else
                    //DECREMENTAMOS u YA QUE QUIERE DECIR QUE "HAY UN DATO MENOS EN LA COLA", EN REALIDAD EL DATO SIGUE ALLI
                    u--;
                return true;
            }
            return false;
        }


    }
}


namespace GABRIELCEDEÑO3B
{

    class Program
    {
        static void Main(string[] args)
        {
            //DECLARACION DE VARIABLES
            int i, n, dato = 0;

            //PEDIMOS LA LONGUITUD DE LA COLA
            Console.Write("¿CUANTOS ELEMENTOS? ");
            n = Convert.ToInt32(Console.ReadLine());

            //HACEMOS LA COLA
            Cola cola = new Cola(n);

            //HACEMOS UN OBJETO DE LA CLASE RANDOM PARA LLENAR LA COLA

            for (i = 0; i < n; i++)
            {
                Console.WriteLine("ingrese sus datos a la cola");
                int r = int.Parse(Console.ReadLine());

                //LE AGREGAMOS ELEMENTOS A LA COLA
                Console.WriteLine("\nINCERTANDO EN LA COLA");
                dato = r;
                if (cola.agregar(dato))
                    Console.WriteLine("Dato agregado: " + dato);
                else
                {
                    Console.WriteLine("Desbordamiento, cola llena");
                }
            }


            //LE EXTRAEMOS ELEMENTOS A LA COLA
            Console.WriteLine("\nEXTRAYENDO DATOS DE LA COLA");
            while (cola.extraer(ref dato))
            {
                Console.WriteLine("Dato extraido: " + dato);
            }
            Console.ReadKey();
        }
    }
}