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
        private List<Ship> Ships = new List<Ship>();
        private Cell [,] field = new Cell[width , height];
        private int x;
        private int y;
        private Cell cell;
        private Random rand = new Random();
        private int shipCount = 0;//счет кораблей
        /*private const int fShip = 1;
        private const int tShip = 2;
        private const int twShip = 3;
        private const int oShip = 4;*/

        private void initField()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    field[i, j] = new Cell(i, j);

                }
            }
        }

        /*private void createFourShip(Cell cell)
        {
            int maxHeight = height - 1;
            int maxWidth = width - 1;
            var x = cell.GetX();
            var y = cell.GetY();
            var r = rand.Next(0, 100);
            //правая нижняя граница
            if (x == maxWidth && y == maxHeight)
            {
                if (!(field[x - 1, y - 1].isShipHere() && field[x, y - 1].isShipHere() &&
                    field[x - 1, y].isShipHere() && field[].isShipHere()))
                {
                    if (r % 2 == 0) //корабль горизонтально
                    {
                        Ships.Add(new Ship(4, new Cell[4] { cell, field[x - 1, y], field[x - 2, y], field[x - 3, y] }));
                        return;
                    }
                    //иначе вертикально
                    Ships.Add(new Ship(4, new Cell[4] { cell, field[x, y - 1], field[x, y - 2], field[x, y - 3] }));
                    return;
                }
            }
            //правая верхняя граница
            if (x == maxWidth && y == 0)
            {
                if (field[x - 1, y].isShipHere() || field[x, y + 1].isShipHere() ||
                    field[x - 1, y + 1].isShipHere())
                {
                    if (r % 2 ==0)//корабль горизонтально
                    {
                        Ships.Add(new Ship(4, new Cell[4] { cell, field[x - 1, y], field[x - 2, y], field[x - 3, y] }));
                        return;
                    }
                    //иначе вертикально
                    Ships.Add(new Ship(4, new Cell[4] { cell, field[x, y - 1], field[x, y - 2], field[x, y - 3] }));
                    return;
                }
            }
            //левая верхняя граница
            if (x == 0 && y == 0)
            {
                if (field[x + 1, y + 1].isShipHere() || field[x, y + 1].isShipHere() ||
                    field[x + 1, y].isShipHere())
                {
                    if (r % 2 == 0)//корабль горизонтально
                    {
                        Ships.Add(new Ship(4, new Cell[4] { cell, field[x + 1, y], field[x + 2, y], field[x + 3, y] }));
                        return;
                    }
                    //иначе вертикально
                    Ships.Add(new Ship(4, new Cell[4] { cell, field[x, y + 1], field[x, y + 2], field[x, y + 3] }));
                    return;
                }
            }
            //левая нижняя граница
            if (x == 0 && y == maxHeight)
            {
                if (field[x, y - 1].isShipHere() || field[x + 1, y].isShipHere() ||
                    field[x + 1, y - 1].isShipHere())
                {
                    if (r % 2 == 0)//корабль горизонтально
                    {
                        Ships.Add(new Ship(4, new Cell[4] { cell, field[x + 1, y], field[x + 2, y], field[x + 3, y] }));
                        return;
                    }
                    //иначе вертикально
                    Ships.Add(new Ship(4, new Cell[4] { cell, field[x, y - 1], field[x, y - 2], field[x, y - 3] }));
                    return;
                }
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
        }*/

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
                    cell.SetShip();
                    Ships.Add(new Ship(1, new Cell[1] { cell }));
                    shipCount++;
                }
            }            
        }

        public bool isShipHere(int x, int y)
        {
            foreach(Ship ship in Ships)
            {
                foreach(Cell cell in ship.GetCells())
                {
                    if (cell.GetX() == x && cell.GetY() == y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string ShotTo(int x, int y)
        {
            Ship ship = null;
            foreach (Ship s in Ships)
            {
                foreach (Cell cell in s.GetCells())
                {
                    if (cell.GetX() == x && cell.GetY() == y)
                    {
                        ship = s;
                    }
                }
            }
            ship.GetCells().Remove(ship.GetCells().Find(c => c.GetX() == x && c.GetY() == y));
            var oldSize = ship.GetSize();
            if (oldSize != 1)
            {
                ship.SetSize(oldSize--);
                return "Popal";
            }
            Ships.Remove(ship);
            return "killed";
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
            return Ships.Count();
        }

        //получить клетки в которых есть корабли
        public void GetCellShip()
        {
            Ship ship = null;
            foreach (Ship s in Ships)
            {
                foreach (Cell cell in s.GetCells())
                {
                    Console.Write(cell.ToString() + s.ToString());
                }
                Console.WriteLine();
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
