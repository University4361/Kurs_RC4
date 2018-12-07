using Kurs_RC4.Blom;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurs_RC4
{
    class Program
    {
        static void Main(string[] args)
        {
            User Ilya = new User(new List<MatrixElement>
            {
                new MatrixElement
                {
                    X = 0,
                    Y = 0, 
                    Value = 3
                },
                new MatrixElement
                {
                    X = 0,
                    Y = 1,
                    Value = 10
                },
                new MatrixElement
                {
                    X = 0,
                    Y = 2,
                    Value = 11
                },
            }, "Ilya Lavrov");

            Console.WriteLine();

            User Julia = new User(new List<MatrixElement>
            {
                new MatrixElement
                {
                    X = 0,
                    Y = 0,
                    Value = 1
                },
                new MatrixElement
                {
                    X = 0,
                    Y = 1,
                    Value = 3
                },
                new MatrixElement
                {
                    X = 0,
                    Y = 2,
                    Value = 15
                },
            }, "Julia Mirzabaeva");

            Console.WriteLine();

            User Denis = new User(new List<MatrixElement>
            {
                new MatrixElement
                {
                    X = 0,
                    Y = 0,
                    Value = 7
                },
                new MatrixElement
                {
                    X = 0,
                    Y = 1,
                    Value = 86
                },
                new MatrixElement
                {
                    X = 0,
                    Y = 2,
                    Value = 15
                },
            }, "Deniska");

            Console.WriteLine();

            Ilya.SendMessageTo(Denis, "Kak dela Denis?");

            Console.WriteLine();

            Julia.SendMessageTo(Ilya, "Kak detki Ilya?");

            Console.WriteLine();

            Denis.SendMessageTo(Julia, "Kak nastroenie Julia?");

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
