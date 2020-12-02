using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodaGaussa
{
    class Program
    {



        static void Main(string[] args)
        {
            //double[,] matrixA = new double[,] { { 4, 1, 3, 2 }, { 1, 4, 1, 1 }, { 2, 3, 2, 4 }};
            double[,] matrixA = new double[,] { { 5,-3,21 }, { 1, -2,7 } };
            void wypisz(double[,] mat)
            {
                for (int i = 0; i < mat.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < mat.GetUpperBound(1) + 1; j++)
                    {
                        if (j == mat.GetUpperBound(1))
                            Console.Write(" |{0,12:N3}", mat[i, j]);
                        else
                            Console.Write("{0,8:N3}",mat[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n");
            }
           void elminacja(int s)
            {
                for (int i = s+1; i < matrixA.GetUpperBound(0) + 1; i++)
                {
                    for (int j = s+1; j < matrixA.GetUpperBound(1) + 1; j++)
                    {
                        matrixA[i, j] = matrixA[i, j] - (matrixA[i, s] / matrixA[s, s]) * matrixA[s, j];
                    }
                    matrixA[i, s] = 0;
                }
            }
            wypisz(matrixA);
            for (int s = 0; s < matrixA.GetUpperBound(0); s++)
            {
                elminacja(s);
                wypisz(matrixA);
            }
            double[] x = new double[matrixA.GetUpperBound(0) + 1];
            for (int i = matrixA.GetUpperBound(0); i >= 0; i--)
            {
                int s = 0,m=i;
                while (matrixA[i, s] == 0)
                {
                    s++;
                }
                double mianownik = matrixA[i, s], licznik = matrixA[i,matrixA.GetUpperBound(1)];
                s++;
                while (s < matrixA.GetUpperBound(1))
                {
                    licznik -= matrixA[i, s]*x[m+1];
                    m++;
                    s++;
                }
                x[i] = licznik/mianownik;
                Console.WriteLine("   x"+(i+1)+" = " + x[i]);
            }
            Console.ReadKey();
        }


    }
}
