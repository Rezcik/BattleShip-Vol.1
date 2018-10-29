using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlesShip_vol._1
{
    public class Cell
    {
        private int x;
        private int y;
        private Ship ship;

        public Cell(int x, int y, Ship ship)
        {
            this.x = x;
            this.y = y;
            this.ship = ship;
        }

        public int GetX ()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public Ship GetShip()
        {
            return ship;
        }

        public bool isShipHere()
        {
            return ship.isExist() ? true : false;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public void SetShip(Ship ship)
        {
            this.ship = ship;
        }

        public string ToString ()
        {
            return "X = " + x + "; Y = " + y + "; " + ship.ToString();
        }
    }
}
