using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task1.DL;
using Task1.UI;

namespace Task1.BL
{
    class Grid
    {
        public Cell[,] maze;
        public int rowSize;
        public int colSize;
        public Grid(int rowSize, int columnSize, string filePath)
        {
            maze = new Cell[rowSize, columnSize];
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < rowSize; i++)
            {
                string line = lines[i];

                for (int j = 0; j < columnSize; j++)
                {
                    char value = line[j];
                    maze[i, j] = new Cell(value, i, j);
                }
            }
        }

        public Cell getLeftCell(Cell cell)
        {
            int x = cell.getX();
            int y = cell.getY();
            if (y > 0)
                return maze[x,y - 1];
            else
                return null;
        }
        public Cell getRightCell(Cell cell)
        {
            int x = cell.getX();
            int y = cell.getY();
            if (y < maze.GetLength(1) - 1)
                return maze[x, y + 1];
            else
                return null;
        }

        public Cell getDownCell(Cell cell)
        {
            int x = cell.getX();
            int y = cell.getY();
            if (x < maze.GetLength(0) - 1)
                return maze[x + 1, y];
            else
                return null;
        }

        public Cell getUpCell(Cell cell)
        {
            int x = cell.getX();
            int y = cell.getY();
            if (x > 0)
                return maze[x - 1, y];
            else
                return null;
        }
        public Cell FindPacman()
        {
            foreach (Cell cell in maze)
            {
                if (cell.IsPacmanPresent())
                {
                    return cell;
                }
            }

            return null;
        }
        public Cell FindGhost(char ghostCharacter)
        {
            foreach (Cell cell in maze)
            {
                if (cell.IsGhostPresent() && cell.getValue() == ghostCharacter)
                {
                    return cell;
                }
            }

            return null;
        }
        public void Draw()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j].getValue());
                }

                Console.WriteLine();
            }
        }


    }

    }
