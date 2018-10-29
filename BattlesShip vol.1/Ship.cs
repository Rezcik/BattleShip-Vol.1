using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattlesShip_vol._1
{
    public class Ship
    {
        private int size;
        private int x;
        private int y;

        public Ship(int size, int x, int y)
        {
            this.size = size;
            this.x = x;
            this.y = y;

        }
         
        public void SetSize(int size)
        {
            this.size = size;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public int GetSize()
        {
            return size;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public bool isExist()
        {
            return size != 0 ? true : false;
        }

        public string ToString()
        {
            return "Размер: " + size.ToString();
        }

    }
}
