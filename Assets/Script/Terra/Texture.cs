namespace ZedAngular.Model.Terra
{
    public class Texture
    {
    }
    public class GridTileBarView
    {
        public int SpotX { set; get; }
        public int SpotY { set; get; }
        public GridTileBarView()
        {
        }
        public GridTileBarView(int spotX, int spotY) {
             this.SpotX= spotX;
            this.SpotY = spotX;
        }
    }
}
