using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.MainScript.water2D
{
    public class Point
    {
        public int x { set; get; }
        public int z { set; get; }
        public Point(int X,int Z)
        {
            this.x = X;
            this.z = Z;
        }
        public override string ToString()
        {
            return this.x +"_"+ this.z;
        }
    }
}
