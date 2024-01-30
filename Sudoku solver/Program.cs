using System;
using System.Threading;

namespace Sudoku_solver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] grille =
            {
            {0,0,0,0,0,0,0,1,2},
            {0,0,0,0,0,0,0,0,3},
            {0,0,2,3,0,0,4,0,0},
            {0,0,1,8,0,0,0,0,5},
            {0,6,0,0,7,0,8,0,0},
            {0,0,0,0,0,9,0,0,0},
            {0,0,8,5,0,0,0,0,0},
            {9,0,0,0,4,0,5,0,0},
            {4,7,0,0,0,6,0,0,0}
            };
            AfficherGrille(grille);
            EstResolut(grille, 0);
            AfficherGrille(grille);
        }

        public static bool EstAbsentSurLigne(int solution, int[,] grille, int ligne)
        {
            for (int i = 0; i < 9; i++)
            {
                if (solution == grille[ligne, i])
                {
                    return false;
                }
            }

            return true;
        }
        
        public static bool EstAbsentSurColonne(int solution, int[,] grille, int colonne)
        {
            for (int i = 0; i < 9; i++)
            {
                if (solution == grille[i, colonne])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool EstAbsentBlock(int solution, int[,] grille, int ligne, int colonne)
        {
            int departLigne = ligne / 3 * 3;
            int finLigne = departLigne +  3;
            int departColonne = colonne / 3 * 3;
            int finColonne = departColonne + 3;
            for (int i = departLigne; i < finLigne; i++)
            {
                for (int j = departColonne; j < finColonne; j++)
                {
                    if (solution == grille[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool EstResolut(int[,] grille, int depart)
        {
            //AfficherGrille(grille);
            if(depart == 9 * 9)
                return true;
            int ligne = depart / 9;
            int colonne = depart % 9;

            if (grille[ligne, colonne] != 0)
            {
                return EstResolut(grille, depart + 1);
            }

            for (int solution = 1; solution <= 9; solution++)
            {
                if (EstAbsentSurLigne(solution, grille, ligne) && EstAbsentSurColonne(solution, grille, colonne) &&
                    EstAbsentBlock(solution, grille, ligne, colonne))
                {
                    grille[ligne, colonne] = solution;
                    if (EstResolut(grille, depart + 1))
                    {
                        return true;
                    }
                }
            }

            grille[ligne, colonne] = 0;
            return false;
        }
        public static void AfficherGrille(int[,] grille)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(j == 0)
                        Console.Write("|");
                    Console.Write(grille[i, j] + "|");
                    if ((j + 1) % 3 == 0 && j != 8)
                    {
                        Console.Write(" |");
                    }
                }
                if ((i + 1) % 3 == 0)
                {
                    Console.Write("\n");
                }
                Console.Write("\n");
            }
            Console.WriteLine("*************************************************************************");
        }
    }
}