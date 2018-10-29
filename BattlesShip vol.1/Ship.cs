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
        private List<Cell> cellsShip = new List<Cell>();

        public Ship(int size, Cell[] cells)
        {
            this.size = size;
            for (int i = 0; i < cells.Length; i++)
            {
                cellsShip.Add(cells[i]); 
            }

        }
         
        public void SetSize(int size)
        {
            this.size = size;
        }
        
        public int GetSize()
        {
            return size;
        }

        public List<Cell> GetCells()
        {
            return cellsShip;
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
