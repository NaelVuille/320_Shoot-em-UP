using shootEmUp.Properties;

namespace shootEmUp.Model
{
    public class Protection
    {
        private const int _PROTECTIONSIZE = 100;

        private int _x;
        private int _y;

        public static int PROTECTIONSIZE => _PROTECTIONSIZE;
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }

        

        public Protection(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.Protection, _x - _PROTECTIONSIZE / 2, _y - _PROTECTIONSIZE / 2, _PROTECTIONSIZE, _PROTECTIONSIZE);
        }
    }
}
