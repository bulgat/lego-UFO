using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.strategChess
{
    public class PathMove
    {
        public int FleetId;
        public List<Point> PathList {  get; }
        public Point PathLast { get; }
        public ButtonEvent ButtonEvent { get; }
        public PathMove(List<Point> pathList, ButtonEvent buttonEvent, int fleetId) { 
            this.PathList = pathList;
           this.PathLast = new Point(pathList.Last().X, pathList.Last().Y);
            this.ButtonEvent = buttonEvent;
            this.FleetId = fleetId;
        }
        
    }
}
