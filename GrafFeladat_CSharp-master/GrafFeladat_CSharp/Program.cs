using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafFeladat_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var a_graf = new Graf(6);
            a_graf.Hozzaad(0, 1);
            a_graf.Hozzaad(1, 2);
            a_graf.Hozzaad(0, 2);
            a_graf.Hozzaad(2, 3);
            a_graf.Hozzaad(3, 4);
            a_graf.Hozzaad(4, 5);
            a_graf.Hozzaad(2, 4);

            var b_graf = new Graf(8);
            b_graf.Hozzaad(0, 1);
            b_graf.Hozzaad(1, 3);
            b_graf.Hozzaad(4, 2);
            b_graf.Hozzaad(2, 6);
            b_graf.Hozzaad(5, 6);
            b_graf.Hozzaad(7, 0);
            b_graf.Hozzaad(6, 7);

            var c_graf = new Graf(4);
            c_graf.Hozzaad(0, 1);
            c_graf.Hozzaad(1, 2);
            c_graf.Hozzaad(2, 3);



            Console.WriteLine("a_graf : ");
            Console.WriteLine(a_graf);

            Console.WriteLine("Szélességi : \n");
            a_graf.Szelessegi(3);

            Console.WriteLine("Mélységi : \n");
            a_graf.Melysegi(3);

            Console.WriteLine("Feszítőfa : \n");
            Console.WriteLine(a_graf.FeszFa());

            Console.WriteLine("Összefüggő : \n");
            Console.WriteLine(a_graf.Osszefuggo());

            /*------------------------------------------*/

            Console.WriteLine("b_graf : ");
            Console.WriteLine(b_graf);

            Console.WriteLine("Szélességi : \n");
            b_graf.Szelessegi(3);

            Console.WriteLine("Mélységi : \n");
            b_graf.Melysegi(3);

            Console.WriteLine("Feszítőfa : \n");
            Console.WriteLine(b_graf.FeszFa());

            Console.WriteLine("Összefüggő : \n");
            Console.WriteLine(b_graf.Osszefuggo());

            /*------------------------------------------*/

            Console.WriteLine("c_graf : ");
            Console.WriteLine(c_graf);

            Console.WriteLine("Szélességi : \n");
            c_graf.Szelessegi(3);

            Console.WriteLine("Mélységi : \n");
            c_graf.Melysegi(3);

            Console.WriteLine("Feszítőfa : \n");
            Console.WriteLine(c_graf.FeszFa());

            Console.WriteLine("Összefüggő : \n");
            Console.WriteLine(c_graf.Osszefuggo());

            Console.ReadLine();
        }
    }
}
