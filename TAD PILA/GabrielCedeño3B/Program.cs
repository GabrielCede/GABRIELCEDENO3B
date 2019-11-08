using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GabrielCedeño3B
{
    class Program
    {
        //public static final int MAX_LENGTH = 5;
        public static String[] Pila = new String[5]; public static int cima = -1;
        public static String[] Pilaaux = new String[5]; public static int cimaaux = -1;

        public static void Main(String[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.WriteLine("\n\n\t\t\t  ======Menú Manejo Pila=======");
            Console.WriteLine("\t\t\t=                               =");
            Console.WriteLine("\t\t\t= 1- Ingresar número            =");
            Console.WriteLine("\t\t\t= 2- Eliminar número            =");
            Console.WriteLine("\t\t\t= 3- Buscar número              =");
            Console.WriteLine("\t\t\t= 4- Imprimir pila              =");
            Console.WriteLine("\t\t\t= 5- Contar pila                =");
            Console.WriteLine("\t\t\t= 6- Salir de pila              =");
            Console.WriteLine("\t\t\t=================================");
            Console.Write("\t\t\tOpcion: ");
            int op = Convert.ToInt32(Console.ReadLine());
            Opciones(op);
        }

        public static void Opciones(int op)
        {
            String salio;
            switch (op)
            {
                case 1:
                    Insertar(); Menu();
                    break;
                case 2:
                    salio = Desapilar();
                    if (!Vacia())
                    {
                        Console.Write("El dato que salio es: " + salio);
                    }
                    Menu();
                    break;
                case 3:
                    Buscar(); Menu();
                    break;
                case 4:
                    Imprimir(); Menu();
                    break;
                case 5:
                    Contar(); Menu();
                    break;
                case 6:
                default:
                    break;
            }
        }

        public static void Insertar()
        {
            Console.Write("\nDigite un dato para la pila : ");
            String dato = Console.ReadLine();
            Apilar(dato);
        }

        public static void Apilar(String dato)
        {
            if ((Pila.Length - 1) == cima)
            {
                Console.WriteLine("Capacidad de la pila al limite ");
                Imprimir();
            }
            else
            {
                cima++;
                // Console.WriteLine("Cima en la posición\n " + cima);
                Pila[cima] = dato;
            }
        }
        public static void Apilaraux(String dato)
        {
            if ((Pilaaux.Length - 1) == cimaaux)
            {
                Console.Write("Capacidad de la pila auxiliar al limite");
            }
            else
            {
                cimaaux++;
                Pilaaux[cimaaux] = dato;
            }
        }

        public static Boolean Vaciaaux()
        {
            return (cimaaux == -1);
        }
        public static Boolean Vacia()
        {
            if (cima == -1)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        public static void Imprimir()
        {
            String quedata, salida = " ";
            if (cima != -1)
            {
                do
                {
                    quedata = Desapilar();
                    salida = salida + quedata + "\n";
                    Apilaraux(quedata);
                } while (cima != -1);
                do
                {
                    quedata = Desapilaraux();
                    Apilar(quedata);
                } while (cimaaux != -1);
                Console.WriteLine(salida);
            }
            else
            {
                Console.Write("La pila esta vacía");
            }
        }

        public static String Desapilar()
        {
            String quedato;
            if (Vacia())
            {
                Console.Write("No se puede eliminar, pila vacía !!!");
                return ("");
            }
            else
            {
                quedato = Pila[cima];
                Pila[cima] = null;
                --cima;
                return (quedato);
            }
        }
        public static String Desapilaraux()
        {
            String quedato;
            if (cimaaux == -1)
            {
                Console.WriteLine("No se puede eliminar, pila vacía !!!");
                return ("");
            }
            else
            {
                quedato = Pilaaux[cimaaux];
                Pilaaux[cimaaux] = null;
                --cimaaux;
                return (quedato);
            }
        }

        public static void Buscar()
        {
            if (Vacia())
            {
                Console.Write("La pila esta vacìa");
                Console.ReadKey();
            }
            else
            {
                Console.Write("Digite el número a buscar: ");
                String cad = Console.ReadLine();
                String quedata;
                int bandera = 0; //no se encuentra
                do
                {
                    quedata = Desapilar();
                    if (cad.Equals(quedata))
                    {
                        bandera = 1; //si esta
                    }
                    Apilaraux(quedata);
                } while (cima != -1);
                do
                {
                    quedata = Desapilaraux();
                    Apilar(quedata);
                } while (cimaaux != -1);
                if (bandera == 1)
                {
                    Console.Write("Elemento encontrado");
                }
                else
                {
                    Console.Write("Elemento no encontrado :(");
                }
            }
        }

        public static void Contar()
        {
            String quedata;
            int contador = 0;
            if (cima != -1)
            {
                do
                {
                    quedata = Desapilar();
                    contador = contador + 1;
                    Apilaraux(quedata);
                } while (cima != -1);
                do
                {
                    quedata = Desapilaraux();
                    Apilar(quedata);
                } while (cimaaux != -1);
                Console.WriteLine("Elementos en la pila\n: " + contador);
            }
            else
            {
                Console.Write("La pila esta vacìa");
            }
        }
    }
}
