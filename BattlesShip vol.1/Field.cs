using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlesShip_vol._1
{
    class Field
    {
        private const int width = 10;
        private const int height = 10;
        private const int shipCountMax = 10;
        private Cell [,] field = new Cell[width , height];
        private int x;
        private int y;
        private Cell cell;
        private Random rand = new Random();
        private int shipCount = 0;//счет кораблей

        private void initField()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    field[i, j] = new Cell(i, j, new Ship(0, i, j));

                }
            }
        }

        public Field ()
        {
            initField();          

            while (shipCount < shipCountMax)
            {
                x = rand.Next(0, width);
                y = rand.Next(0, height);
                x = x == width ? x-- : x;
                y = y == height ? y-- : y;
                cell = field[x, y];
                if (!cell.isShipHere() && canSetShip(x, y))
                {
                    cell.SetShip(new Ship(1, x, y));
                    shipCount++;
                }
            }            
        }

        private bool canSetShip(int x, int y)
        {
            int maxHeight = height - 1;
            int maxWidth = width - 1;
            //правая нижняя граница
            if (x == maxWidth && y == maxHeight)
            {
                if (field[x - 1, y - 1].isShipHere() || field[x, y - 1].isShipHere() ||
                    field[x - 1, y].isShipHere())
                {
                    return false;
                }
                return true;
            }
            //правая верхняя граница
            if (x == maxWidth && y == 0)
            {
                if (field[x - 1, y].isShipHere() || field[x, y + 1].isShipHere() ||
                    field[x - 1, y + 1].isShipHere())
                {
                    return false;
                }
                return true;
            }
            //левая верхняя граница
            if (x == 0 && y == 0)
            {
                if (field[x + 1, y + 1].isShipHere() || field[x, y + 1].isShipHere() ||
                    field[x + 1, y].isShipHere())
                {
                    return false;
                }
                return true;
            }
            //левая нижняя граница
            if (x == 0 && y == maxHeight)
            {
                if (field[x, y - 1].isShipHere() || field[x + 1 , y].isShipHere() ||
                    field[x + 1, y - 1].isShipHere())
                {
                    return false;
                }
                return true;
            }
            //граничные точки на верхней грани
            if (y == 0 && x > 0 && x < maxWidth)
            {
                if (field[x - 1, y].isShipHere() || field[x - 1, y + 1].isShipHere() ||
                    field[x, y + 1].isShipHere() || field[x + 1, y + 1].isShipHere() ||
                    field[x + 1, y].isShipHere())
                {
                    return false;
                }
                return true;
            }
            //граничные точки на левой грани
            if (x == 0 && y > 0 && y < maxHeight)
            {
                if (field[x, y - 1].isShipHere() || field[x + 1, y - 1].isShipHere() ||
                    field[x + 1, y].isShipHere() || field[x + 1, y + 1].isShipHere() ||
                    field[x, y + 1].isShipHere())
                {
                    return false;
                }
                return true;
            }
            //граничные точки на правой грани
            if (x == maxWidth && y > 0 && y < maxHeight)
            {
                if (field[x - 1, y].isShipHere() || field[x - 1, y + 1].isShipHere() ||
                    field[x, y + 1].isShipHere() || field[x, y - 1].isShipHere() ||
                    field[x - 1, y - 1].isShipHere())
                {
                    return false;
                }
                return true;
            }
            //граничные точки на нижней грани
            if (y == maxHeight && x > 0 && x < maxWidth)
            {
                if (field[x + 1, y].isShipHere() || field[x + 1, y - 1].isShipHere() ||
                    field[x, y - 1].isShipHere() || field[x - 1, y - 1].isShipHere() ||
                    field[x - 1, y].isShipHere())
                {
                    return false;
                }
                return true;
            }
            //проверка внутренних клеток 
            if ((x != maxWidth || x != 0) && (y != maxHeight || y != 0))
            {
                if (field[x - 1, y - 1].isShipHere() || field[x, y - 1].isShipHere() ||
                    field[x + 1, y - 1].isShipHere() || field[x + 1, y].isShipHere() ||
                    field[x + 1, y + 1].isShipHere() || field[x, y + 1].isShipHere() ||
                    field[x - 1, y + 1].isShipHere() || field[x - 1, y].isShipHere())
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetHeight()
        {
            return height;
        }

        public int ShipCount()
        {
            int k = 0;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (field[i, j].isShipHere())
                    {
                        k++;
                    }
                }
            }
            return k;
        }

        //получить клетки в которых есть корабли
        public void GetCellShip()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (field[i, j].isShipHere())
                    {
                        Console.WriteLine(field[i, j].ToString());
                    }
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return field[x, y];
        }

        public Cell[,] GetField()
        {
            return field;
        }
    }
}
