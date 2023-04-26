using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.MainScript.water2D
{
    public class Cube
    {
        public int Stone { set; get; }
        public int Water  { set; get; }
        public Cube(int stone,int water)
        {
            this.Stone = stone;
            this.Water = water;
        }
        public int GetSum()
        {
            return this.Stone + this.Water;
        }
        
}
}
