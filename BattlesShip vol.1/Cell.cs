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
        private bool isShip = false;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }


        public int GetX ()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public bool isShipHere()
        {
            return isShip;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public void SetShip()
        {
            isShip = true;
        }

        public string ToString ()
        {
            return "X = " + x + "; Y = " + y + "; ";
        }
    }
}
