using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06_Sneaking
{
    public class Engine
    {
        public void Proceed()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n][];

            FillingUpTheMatrix(n, matrix);

            var moves = Console
                .ReadLine()
                .ToCharArray();

            var enemyPositions = new int[2];

            var player = new Player(0, 0);

            FindingPlayerPosition(matrix, player);

            var enemiesList = new List<Enemy>();
            FindingEnemiesPosition(matrix, enemiesList, enemyPositions);

            for (int i = 0; i < moves.Length; i++)
            {
                var currentMove = moves[i];

                MovingTheEnemies(matrix, enemiesList);

                if (IsPlayerDead(matrix, player, enemiesList))
                {
                    matrix[player.Row][player.Col] = 'X';

                    break;
                }

                MovingThePlayer(matrix, player, currentMove);

                if (IsPlayerDead(matrix, player, enemiesList))
                {
                    matrix[player.Row][player.Col] = 'X';

                    break;
                }

                if (enemiesList.Any(x => x.Row == player.Row && x.Col == player.Col))
                {
                    var currEnemy = enemiesList
                        .FirstOrDefault(x => x.Row == player.Row && x.Col == player.Col);

                    matrix[currEnemy.Row][currEnemy.Col] = player.Symbol;

                    enemiesList.Remove(currEnemy);
                }
                else if (player.Row == enemyPositions[0])
                {
                    Console.WriteLine("Nikoladze killed!");

                    matrix[player.Row][player.Col] = player.Symbol;
                    matrix[enemyPositions[0]][enemyPositions[1]] = 'X';

                    break;
                }
                else
                {
                    matrix[player.Row][player.Col] = player.Symbol;
                }
            }

            PrintingTheMatrix(matrix);
        }

        private bool IsPlayerDead(char[][] matrix, Player player, List<Enemy> enemiesList)
        {
            if (enemiesList.Any(x => x.Row == player.Row))
            {
                var currEnemy = enemiesList
                    .FirstOrDefault(x => x.Row == player.Row);

                if (currEnemy.Symbol == 'b' && player.Col > currEnemy.Col ||
                    currEnemy.Symbol == 'd' && player.Col < currEnemy.Col)
                {
                    Console.WriteLine($"Sam died at {player.Row}, {player.Col}");
                    matrix[player.Row][player.Col] = 'X';

                    return true;
                }
            }

            return false;
        }

        private void MovingThePlayer(char[][] matrix, Player player, char currentMove)
        {
            matrix[player.Row][player.Col] = '.';

            switch (currentMove)
            {
                case 'U':
                    player.Row--;
                    break;
                case 'D':
                    player.Row++;
                    break;
                case 'L':
                    player.Col--;
                    break;
                case 'R':
                    player.Col++;
                    break;
            }
        }

        private void PrintingTheMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

        private void MovingTheEnemies(char[][] matrix, List<Enemy> enemiesList)
        {
            foreach (var enemy in enemiesList)
            {
                matrix[enemy.Row][enemy.Col] = '.';

                enemy.Move();

                if (!ValidatePosition(matrix, enemy.Row, enemy.Col))
                {
                    enemy.ReplaceSymbol();

                    if (enemy.Symbol == 'b')
                    {
                        enemy.Col = 0;
                    }
                    else
                    {
                        enemy.Col = matrix.Length - 1;
                    }
                }

                matrix[enemy.Row][enemy.Col] = enemy.Symbol;
            }
        }

        private static bool ValidatePosition(char[][] matrix, int row, int col)
                    => row >= 0 && row < matrix.Length &&
                       col >= 0 && col < matrix[row].Length;

        private void FindingEnemiesPosition(char[][] matrix, List<Enemy> enemiesList, int[] enemyPositions)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        enemiesList.Add(new Enemy(row, col, 'b', "right"));
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        enemiesList.Add(new Enemy(row, col, 'd', "left"));
                    }
                    else if (matrix[row][col] == 'N')
                    {
                        enemyPositions[0] = row;
                        enemyPositions[1] = col;
                    }
                }
            }
        }

        private void FindingPlayerPosition(char[][] matrix, Player player)
        {
            bool isFound = false;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'S')
                    {
                        player.Row = row;
                        player.Col = col;
                        isFound = true;

                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }
        }

        private void FillingUpTheMatrix(int n, char[][] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console
                    .ReadLine()
                    .ToCharArray();

                matrix[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                }
            }
        }
    }
}
