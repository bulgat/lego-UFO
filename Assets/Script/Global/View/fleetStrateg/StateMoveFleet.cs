using Assets.Script.strategChess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Global.View.fleetStrateg
{
    public class StateMoveFleet
    {
        public bool Move { get; }
        float X;
        float Y;

        public float MoveX { get; set; }
        public float MoveY { get; set; }

        public Point OldPoint { get; set; }
    
        List<Point> DestinationPointList { get; set; }

        public Point GetFirstDestination()
        {
            //Point firstPoint = this.DestinationPointList.First();
            //this.DestinationPointList.Remove(firstPoint);
            return this.DestinationPointList.First();
        }
        public bool NextDestination()
        {
          

            Point firstPoint = this.DestinationPointList.First();
            this.OldPoint = new Point(firstPoint.X, firstPoint.Y);
            this.DestinationPointList.Remove(firstPoint);

            if (this.DestinationPointList.Count == 0)
            {
                return false;
            }

            float deltaMoveX = this.MoveX - DestinationPointList.First().X;
            float deltaMoveY = this.MoveX - DestinationPointList.First().Y;

            this.X = deltaMoveX;
            this.Y = deltaMoveY;
            return true;
        }

        public StateMoveFleet( bool move , int StrSpotX, int StrSpotY, List<Point> destinationPointList)
        {
           
            this.Move = move;
            float deltaMoveX = StrSpotX - destinationPointList.First().X;
            float deltaMoveY = StrSpotX - destinationPointList.First().Y;

            this.OldPoint = new Point(StrSpotX, StrSpotY);

            this.X = deltaMoveX; 
            this.Y= deltaMoveY;
            this.MoveX = StrSpotX;
            this.MoveY = StrSpotY;

            this.DestinationPointList = destinationPointList;
        }
    }
}
