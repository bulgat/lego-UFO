using Assets.MainScript.water2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.MainScript.water3D
{
    public class Column
    {
        public int Stone { set; get; }
        public int Water { set; get; }
        public Point Position { set; get; }
        public Point VectorInertia { set; get; }
        public int VectorForce { set; get; }
        public Column(int stone, int water)
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
