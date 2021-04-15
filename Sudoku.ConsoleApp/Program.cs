using System;
using System.IO;


namespace Sudoku.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            string confere = "SIM";
            int[,] colunasSudoku = new int[9, 9];
            int[,] linhasSudoku = new int[9, 9];
            int[,] matrizes = new int[9, 9];
            int w = 0;

            string sudoku = @"1 3 2 5 7 9 4 6 8
                              4 9 8 2 6 1 3 7 5
                              7 5 6 3 8 4 2 1 9
                              6 4 3 1 5 8 7 9 2
                              5 2 1 7 9 3 8 4 6
                              9 8 7 4 2 6 5 3 1
                              2 1 4 9 3 5 6 8 7
                              3 6 5 8 1 7 9 2 4
                              8 7 9 6 4 2 1 5 3";


            using (StringReader sudokuReader = new StringReader(sudoku))
            {

                string linhaSudoku = "";

                EncontraLinhas(ref linhasSudoku, sudokuReader, ref linhaSudoku);
            }

            EncontraColuna(ref colunasSudoku, linhasSudoku);

            EncontrMatriz(linhasSudoku, ref matrizes, ref w);

            Valida(ref confere, linhasSudoku);

            Valida(ref confere, colunasSudoku);

            Valida(ref confere, matrizes);

            Console.WriteLine(confere);


        }

        private static int EncontrMatriz(int[,] linhasSudoku, ref int[,] matrizes, ref int w)
        {
            for (int x = 0; x < 9; x += 3)
            {
                for (int y = 0; y < 9; y += 3)
                {
                    int k = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            matrizes[w, k] = linhasSudoku[i + x, j + y];

                            k++;
                        }

                    }
                    w++;
                }
            }

            return w;
        }

        private static string EncontraLinhas(ref int[,] linhasSudoku, StringReader sudokuReader, ref string linhaSudoku)
        {
            for (int x = 0; x < 9; x++)
            {
                linhaSudoku = sudokuReader.ReadLine();
                string[] valores = linhaSudoku.Trim().Split();

                for (int y = 0; y < 9; y++)
                {
                    linhasSudoku[x, y] = Convert.ToInt32(valores[y]);
                }
            }

            return linhaSudoku;
        }

        private static void EncontraColuna(ref int[,] colunasSudoku, int[,] linhasSudoku)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    colunasSudoku[x, y] = linhasSudoku[y, x];
                }
            }
        }

        private static string Valida( ref string confere, int [,] linhaColunaOuMatriz)
        {
            for (int x = 0; x < 9; x++)

            {
                for (int y = 0; y < 9; y++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == y)
                        {
                        }

                        else if (linhaColunaOuMatriz[x, y] == linhaColunaOuMatriz[x, j])
                        {
                            confere = "NAO";
                        }
                    }
                }
            }

            return confere;
        }
    }
}
