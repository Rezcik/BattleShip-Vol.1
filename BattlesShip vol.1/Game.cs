using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlesShip_vol._1
{
    class Game
    {
        private bool isMyTurn = true;
        Field myField = new Field();
        Field botField = new Field();
        List<int[]> botTurns = new List<int[]>();

        public Game()
        {
            nextTurn();
        }

        private void Error(out int x, out int y)
        {
            string xStr = Console.ReadLine();
            string yStr = Console.ReadLine();

            while ((!Int32.TryParse(xStr, out x)) || (!Int32.TryParse(yStr, out y)) || !(Math.Abs(x) < myField.GetWidth()) || !(Math.Abs(x) < myField.GetHeight()))
            {
                Console.WriteLine("Ошибка \nВведите заново: ");
                xStr = Console.ReadLine();
                yStr = Console.ReadLine();
            }

        }

        private bool CheckCoord(int x, int y)
        {
            if (botTurns.Count() != 0)
            { 
                foreach (int[]coord in botTurns)
                {
                    if (coord[0] == x && coord[1] == y)
                    {
                        return false;
                    }
                }
            }
            botTurns.Add(new int[2] {x, y});
            return true;
        }

        private void myTurn()
        {
            int x = 0;
            int y = 0;
            myField.GetCellShip();
            Console.WriteLine();
            botField.GetCellShip();
            Console.WriteLine("Введи кординаты: ");
            Error(out x, out y);
            var cell = botField.GetCell(x, y);
            if (cell.isShipHere())
            {
                cell.SetShip(new Ship(0, x, y));
                Console.WriteLine("Все в корабль");
                var ships = botField.ShipCount();
                if (ships != 0)
                {
                    nextTurn();
                }
                else
                {
                    Console.WriteLine("Вы выиграли!");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Вы промахнулись!");
                isMyTurn = !isMyTurn;
                nextTurn();
            }
        }


        private void botTurn()
        {
            Random rand = new Random();
            int x;
            int y;

            do
            {
                x = rand.Next(0, botField.GetWidth());
                y = rand.Next(0, botField.GetHeight());

            }
            while (!CheckCoord(x, y));

            var cell = myField.GetCell(x, y);
            if (cell.isShipHere())
            {
                cell.SetShip(new Ship(0, x, y));
                Console.WriteLine("Бот попал " + x + " " + y);
                var ships = myField.ShipCount();
                if (ships != 0)
                {
                    nextTurn();
                }
                else
                {
                    Console.WriteLine("Вы проиграли!");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Бот промахнулся!");
                isMyTurn = !isMyTurn;
                nextTurn();
            }
        }

        private void nextTurn()
        {
            if (isMyTurn)
            {
                myTurn(); 
            }
            else
            {
                botTurn();
            }
        }


    }
}
